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
    public class AppleServiceController : ControllerBase
    {
        IAppleServiceLogic appleServiceLogic;
        IHubContext<SignalRHub> hub;
        public AppleServiceController(IAppleServiceLogic appleServiceLogic, IHubContext<SignalRHub> hub)
        {
            this.appleServiceLogic = appleServiceLogic;
            this.hub=hub;
        }

        // GET: api/appleService
        [HttpGet]
        public IEnumerable<AppleService> Get()
        {
            return appleServiceLogic.GetAll();
        }

        // GET api/appleService/5
        [HttpGet("{id}")]
        public AppleService Get(int id)
        {
            return appleServiceLogic.Read(id);
        }

        // POST api/appleService
        [HttpPost]
        public void Post([FromBody] AppleService value)
        {
            appleServiceLogic.Create(value);
            this.hub.Clients.All.SendAsync("AppleServiceCreated", value);
        }

        // PUT api/appleService/5
        [HttpPut]
        public void Put([FromBody] AppleService value)
        {
            appleServiceLogic.Update(value);
            this.hub.Clients.All.SendAsync("AppleServiceUpdated", value);

        }

        // DELETE appleService/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var appleServiceToDelete = this.appleServiceLogic.Read(id);
            appleServiceLogic.Delete(id);
            this.hub.Clients.All.SendAsync("AppleServiceDeleted", appleServiceToDelete);

        }
    }
}
