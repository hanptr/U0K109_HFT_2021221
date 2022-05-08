using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using U0K109_HFT_2021221.Endpoint.Services;
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
        IHubContext<SignalRHub> hub;
        public AppleProductController(IAppleProductLogic appleProductLogic, IHubContext<SignalRHub> hub)
        {
            this.appleProductLogic = appleProductLogic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("AppleProductCreated", value);
        }

        // PUT api/appleProduct/5
        [HttpPut]
        public void Put([FromBody] AppleProduct value)
        {
            appleProductLogic.Update(value);
            this.hub.Clients.All.SendAsync("AppleProductUpdated", value);
        }

        // DELETE api/appleProduct/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var appleProductToDelete = this.appleProductLogic.Read(id);
            appleProductLogic.Delete(id);
            this.hub.Clients.All.SendAsync("AppleProductDeleted", appleProductToDelete);
        }
    }
}
