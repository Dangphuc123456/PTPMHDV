using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using DataModel;

namespace BTL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoadonbanController : ControllerBase
    {
        private IHoaDonBanBusiness  _hoaDonBanBusiness;
        public HoadonbanController(IHoaDonBanBusiness hoaDonBanBusiness)
        {
            _hoaDonBanBusiness = hoaDonBanBusiness;
        }
        [Route("get-by-id/{MaHDBan}")]
        [HttpGet]
        public HoaDonBanModel GetDatabyID(string MaHDBan)
        {
            return _hoaDonBanBusiness.GetDatabyID(MaHDBan);
        }
        [Route("create-hoadon")]
        [HttpPost]
        public HoaDonBanModel CreateItem([FromBody] HoaDonBanModel model)
        {
            _hoaDonBanBusiness.Create(model);
            return model;
        }
        [Route("update-hoadon")]
        [HttpPost]
        public HoaDonBanModel Update([FromBody] HoaDonBanModel model)
        {
            _hoaDonBanBusiness.Update(model);
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
                string TenKhach = "";
                if (formData.Keys.Contains("TenKhach") && !string.IsNullOrEmpty(Convert.ToString(formData["TenKhach"]))) { TenKhach = Convert.ToString(formData["TenKhach"]); }
                DateTime? fr_NgayBan = null;
                if (formData.Keys.Contains("fr_NgayBan") && formData["fr_NgayBan"] != null && formData["fr_NgayBan"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayBan"].ToString());
                    fr_NgayBan = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayBan = null;
                if (formData.Keys.Contains("to_NgayBan") && formData["to_NgayBan"] != null && formData["to_NgayBan"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayBan"].ToString());
                    to_NgayBan = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _hoaDonBanBusiness.Search(page, pageSize, out total, TenKhach, fr_NgayBan, to_NgayBan);
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
