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
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string TenNCC = "";
                if (formData.Keys.Contains("TenNCC") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { TenNCC = Convert.ToString(formData["TenNCC"]); }
                string DiachiNCC = "";
                if (formData.Keys.Contains("DiachiNCC") && !string.IsNullOrEmpty(Convert.ToString(formData["DiachiNCC"]))) { DiachiNCC = Convert.ToString(formData["DiachiNCC"]); }
                long total = 0;
                var data = _nhaCCBusines.Search(page, pageSize, out total, TenNCC, DiachiNCC);
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
