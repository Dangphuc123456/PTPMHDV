using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using DataModel;
using BusinessLogicLayer;

namespace BTL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoadonnhapController : ControllerBase
    {
        private IHoaDonNhapBusiness _hoaDonNhapBusiness;
        public HoadonnhapController(IHoaDonNhapBusiness hoaDonNhapBusiness)
        {
            _hoaDonNhapBusiness = hoaDonNhapBusiness;
        }
        [Route("get-by-id/{MaHDNhap}")]
        [HttpGet]
        public HoaDonNhapModel GetDatabyID(string MaHDNhap)
        {
            return _hoaDonNhapBusiness.GetDatabyID(MaHDNhap);
        }
        [Route("create-hoadon")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _hoaDonNhapBusiness.Create(model);
            return model;
        }
        [Route("update-hoadon")]
        [HttpPost]
        public HoaDonNhapModel Update([FromBody] HoaDonNhapModel model)
        {
            _hoaDonNhapBusiness.Update(model);
            return model;
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string NhaCCID = "";
                if (formData.Keys.Contains("NhaCCID") && !string.IsNullOrEmpty(Convert.ToString(formData["NhaCCID"]))) { NhaCCID = Convert.ToString(formData["NhaCCID"]); }
                DateTime? fr_NgayNhap = null;
                if (formData.Keys.Contains("fr_NgayNhap") && formData["fr_NgayNhap"] != null && formData["fr_NgayNhap"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayNhap"].ToString());
                    fr_NgayNhap = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayNhap = null;
                if (formData.Keys.Contains("to_NgayNhap") && formData["to_NgayNhap"] != null && formData["to_NgayNhap"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayNhap"].ToString());
                    to_NgayNhap = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _hoaDonNhapBusiness.Search(page, pageSize, out total, NhaCCID, fr_NgayNhap, to_NgayNhap);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

