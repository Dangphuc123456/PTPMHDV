using BusinessLogicLayer.Interfaces;
using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace API_Client.Controllers
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
    }
}