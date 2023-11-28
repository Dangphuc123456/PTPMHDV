using BusinessLogicLayer;
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
        [Route("delete-nhanvien")]
        [HttpDelete]
        public NhanVienModel DeleteItem([FromBody] NhanVienModel model)
        {
            _nhanVienBusiness.Delete(model);
            return model;
        }       
    }
}

