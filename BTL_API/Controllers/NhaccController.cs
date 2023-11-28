using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;


namespace BTL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCCController : ControllerBase
    {
        private INhaCCBusiness _nhaCCBusines;
        public NhaCCController(INhaCCBusiness nhaCCBusines)
        {
            _nhaCCBusines = nhaCCBusines;
        }
        [Route("get-by-id/{NhaCCID}")]
        [HttpGet]
        public NhaCCModel GetDatabyID(string NhaCCID)
        {
            return _nhaCCBusines.GetDatabyID(NhaCCID);
        }
        [Route("create-nhacc")]
        [HttpPost]
        public NhaCCModel CreateItem([FromBody] NhaCCModel model)
        {
            _nhaCCBusines.Create(model);
            return model;
        }
        [Route("update-nhacc")]
        [HttpPost]
        public NhaCCModel UpdateItem([FromBody] NhaCCModel model)
        {
            _nhaCCBusines.Update(model);
            return model;
        }
        [Route("delete-nhacc")]
        [HttpDelete]
        public NhaCCModel DeleteItem([FromBody] NhaCCModel model)
        {
            _nhaCCBusines.Delete(model);
            return model;
        }

    }
}
