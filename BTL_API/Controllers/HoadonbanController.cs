using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using DataModel;
using BusinessLogicLayer;

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
        [Route("delete-hoadon")]
        [HttpDelete]
        public HoaDonBanModel Delete(HoaDonBanModel model)
        {
            _hoaDonBanBusiness.Delete(model);
            return model;
        }
    }
}
