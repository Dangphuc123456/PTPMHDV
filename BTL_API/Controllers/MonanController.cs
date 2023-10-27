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
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string Tenmonan = "";
                if (formData.Keys.Contains("Tenmonan") && !string.IsNullOrEmpty(Convert.ToString(formData["Tenmonan"]))) { Tenmonan = Convert.ToString(formData["Tenmonan"]); }
                string Loaimonan = "";
                if (formData.Keys.Contains("Loaimonan") && !string.IsNullOrEmpty(Convert.ToString(formData["Loaimonan"]))) { Loaimonan = Convert.ToString(formData["Loaimonan"]); }
                long total = 0;
                var data = _monanBusiness.Search(page, pageSize, out total, Tenmonan, Loaimonan);
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
