using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Data;
using U0K109_HFT_2021221.Logic;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace U0K109_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IAppleServiceLogic appleServiceLogic;
        public StatController(IAppleServiceLogic appleServiceLogic)
        {
            this.appleServiceLogic = appleServiceLogic;
        }
        //1 GET: stat/AvgProdPerCustomerPerService
        [HttpGet]
        public IEnumerable<KeyValuePair<int, double>> AvgProdPerCustomerPerService()
        {
            return appleServiceLogic.AvgProdPerCustomerPerService();
        }
        //2 GET: stat/CustomerCountWithGmailPerService
        [HttpGet]
        public IEnumerable<KeyValuePair<int, int>> CustomerCountWithGmailPerService()
        {
            return appleServiceLogic.CustomerCountWithGmailPerService();
        }
        //3 GET: stat/CountOfProdSerialStartingWith2PerService
        [HttpGet]
        public IEnumerable<KeyValuePair<int, int>> CountOfProdSerialStartingWith2PerService()
        {
            return appleServiceLogic.CountOfProdSerialStartingWith2PerService();
        }
        //4 GET: stat/CountOfCustomerNameStartingWithBPerService
        [HttpGet]
        public IEnumerable<KeyValuePair<int, int>> CountOfCustomerNameStartingWithBPerService()
        {
            return appleServiceLogic.CountOfCustomerNameStartingWithBPerService();
        }
        //5 GET: stat/CountOfProdcutsWithBlackColorPerService
        [HttpGet]
        public IEnumerable<KeyValuePair<int, int>> CountOfProdcutsWithBlackColorPerService()
        {
            return appleServiceLogic.CountOfProdcutsWithBlackColorPerService();
        }

    }
}
