using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer.Interfaces;
using DataModel;
using BusinessLogicLayer;

namespace BTL_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonanController : ControllerBase
    {
        private IMonanBusiness _monanBusiness;
        public MonanController(IMonanBusiness monanBusiness) 
        { 
           _monanBusiness = monanBusiness;
        }
        [Route("get-by-id/{Mamonan}")]
        [HttpGet]
        public MonanModel GetDatabyID(string Mamonan)
        {
            return _monanBusiness.GetDatabyID(Mamonan);
        }
        [Route("create-monan")]
        [HttpPost]
        public MonanModel CreateItem([FromBody] MonanModel model)
        {
            _monanBusiness.Create(model);
            return model;
        }
        [Route("update-monan")]
        [HttpPost]
        public MonanModel UpdateItem([FromBody] MonanModel model)
        {
            _monanBusiness.Update(model);
            return model;
        }
        [Route("delete-monan")]
        [HttpDelete]
        public MonanModel DeleteItem([FromBody] MonanModel model)
        {
            _monanBusiness.Delete(model);
            return model;
        }
       
        
    }
}
