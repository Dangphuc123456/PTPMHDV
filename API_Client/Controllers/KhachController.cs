using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API_Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachController : ControllerBase
    {
        private IKhachBusiness _khachBusiness;
        public KhachController(IKhachBusiness khachBusiness)
        {
            _khachBusiness = khachBusiness;
        }
        [Route("get-by-id/{MaKhach}")]
        [HttpGet]
        public KhachHangModel GetDatabyID(string MaKhach)
        {
            return _khachBusiness.GetDatabyID(MaKhach);
        }
        [Route("create-khach")]
        [HttpPost]
        public KhachHangModel CreateItem([FromBody] KhachHangModel model)
        {
            _khachBusiness.Create(model);
            return model;
        }
        [Route("update-khach")]
        [HttpPost]
        public KhachHangModel UpdateItem([FromBody] KhachHangModel model)
        {
            _khachBusiness.Update(model);
            return model;
        }


        [Route("delete-khach")]
        [HttpDelete]
        public KhachHangModel DeleteItem([FromBody] KhachHangModel model)
        {
            _khachBusiness.Delete(model);
            return model;
        }
    }
}
