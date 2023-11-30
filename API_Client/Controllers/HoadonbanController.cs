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
    }
}
