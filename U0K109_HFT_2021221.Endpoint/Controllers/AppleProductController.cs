using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using U0K109_HFT_2021221.Logic;
using U0K109_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace U0K109_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppleProductController : ControllerBase
    {
        IAppleProductLogic appleProductLogic;
        public AppleProductController(IAppleProductLogic appleProductLogic)
        {
            this.appleProductLogic = appleProductLogic;
        }
        // GET: api/appleProduct
        [HttpGet]
        public IEnumerable<AppleProduct> Get()
        {
            return appleProductLogic.GetAll();
        }

        // GET api/appleProduct/5
        [HttpGet("{id}")]
        public AppleProduct Get(int id)
        {
            return appleProductLogic.Read(id);
        }

        // POST api/appleProduct
        [HttpPost]
        public void Post([FromBody] AppleProduct value)
        {
            appleProductLogic.Create(value);
        }

        // PUT api/appleProduct/5
        [HttpPut]
        public void Put([FromBody] AppleProduct value)
        {
            appleProductLogic.Update(value);
        }

        // DELETE api/appleProduct/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            appleProductLogic.Delete(id);
        }
    }
}
