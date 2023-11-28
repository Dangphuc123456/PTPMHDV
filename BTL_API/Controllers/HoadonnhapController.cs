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

    }
}

