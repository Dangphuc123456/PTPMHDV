using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace BTL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private INhanVienBusiness _nhanVienBusiness;
        public NhanVienController(INhanVienBusiness nhanVienBusiness)
        {
            _nhanVienBusiness = nhanVienBusiness;
        }
        [Route("get-by-id/{MaNhanVien}")]
        [HttpGet]
        public NhanVienModel GetDatabyID(string MaNhanVien)
        {
            return _nhanVienBusiness.GetDatabyID(MaNhanVien);
        }
        [Route("create-nhanvien")]
        [HttpPost]
        public NhanVienModel CreateItem([FromBody] NhanVienModel model)
        {
            _nhanVienBusiness.Create(model);
            return model;
        }
        [Route("update-nhanvien")]
        [HttpPost]
        public NhanVienModel UpdateItem([FromBody] NhanVienModel model)
        {
            _nhanVienBusiness.Update(model);
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
                string TenNhanVien = "";
                if (formData.Keys.Contains("TenNhanVien") && !string.IsNullOrEmpty(Convert.ToString(formData["TenNhanVien"]))) { TenNhanVien = Convert.ToString(formData["TenNhanVien"]); }
                string DiaChi = "";
                if (formData.Keys.Contains("DiaChi") && !string.IsNullOrEmpty(Convert.ToString(formData["DiaChi"]))) { DiaChi = Convert.ToString(formData["DiaChi"]); }
                long total = 0;
                var data = _nhanVienBusiness.Search(page, pageSize, out total, TenNhanVien, DiaChi);
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

