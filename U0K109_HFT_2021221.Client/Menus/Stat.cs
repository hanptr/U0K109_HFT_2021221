using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U0K109_HFT_2021221.Client
{
    public class Stat
    {
        public void Start(Clear clear, Input input, Output write, Output writeline, RestService rest)
        {
            clear?.Invoke();
            writeline?.Invoke("Stat menu");
            writeline?.Invoke("");
            writeline?.Invoke("0. Back to main");
            writeline?.Invoke("1. AvgProdPerCustomerPerService");
            writeline?.Invoke("2. CustomerCountWithGmailPerService");
            writeline?.Invoke("3. CountOfProdSerialStartingWith2PerService");
            writeline?.Invoke("4. CountOfCustomerNameStartingWithBPerService");
            writeline?.Invoke("5. CountOfProdcutsWithBlackColorPerService");
            writeline?.Invoke("");
            string choice = "";
            while (!choice.Equals("0"))
            {
                choice = input?.Invoke();
                switch (choice)
                {
                    case "0":
                        break;
                    case "1":
                        var get = rest.Get<KeyValuePair<int, double>>("stat/avgprodpercustomerperservice");
                        foreach (var item in get)
                        {
                            writeline?.Invoke("Service: "+ item.Key+" AVGPRODUCT: "+item.Value);
                        }
                        break;
                    case "2":
                        var get1 = rest.Get<KeyValuePair<int, int>>("stat/customercountwithgmailperservice");
                        foreach (var item in get1)
                        {
                            writeline?.Invoke("Service:" + item.Key + " Count of customers using gmail: " + item.Value);
                        }
                        break;
                    case "3":
                        var get2 = rest.Get<KeyValuePair<int, int>>("stat/countofprodserialstartingwith2perservice");
                        foreach (var item in get2)
                        {
                            writeline?.Invoke("Service:" + item.Key + " Count of products where seriaal number starts with 2: " + item.Value);
                        }
                        break;
                    case "4":
                        var get3 = rest.Get<KeyValuePair<int, int>>("stat/countofcustomernamestartingwithbperservice");
                        foreach (var item in get3)
                        {
                            writeline?.Invoke("Service:" + item.Key + " Count of customer whose name starts with B: " + item.Value);
                        }
                        break;
                    case "5":
                        var get4 = rest.Get<KeyValuePair<int, int>>("stat/countofprodcutswithblackcolorperservice");
                        foreach (var item in get4)
                        {
                            writeline?.Invoke("Service:" + item.Key + " Count black colored products: " + item.Value);
                        }
                        break;
                    default:
                        writeline?.Invoke("Invalid option.");
                        break;
                }
            }
        }
    }
}
