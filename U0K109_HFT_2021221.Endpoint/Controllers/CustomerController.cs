using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using U0K109_HFT_2021221.Logic;
using U0K109_HFT_2021221.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace U0K109_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic customerLogic;
        public CustomerController(ICustomerLogic customerLogic)
        {
            this.customerLogic = customerLogic;
        }
        // GET: api/customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerLogic.GetAll();
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customerLogic.Read(id);
        }

        // POST api/customer
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            customerLogic.Create(value);
        }

        // PUT api/customer/5
        [HttpPut]
        public void Put([FromBody] Customer value)
        {
            customerLogic.Update(value);
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerLogic.Delete(id);
        }
    }
}
