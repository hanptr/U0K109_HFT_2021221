using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Client
{
    public class Read
    {
        public void Start(Clear clear, Input input, Output write, Output writeline, RestService rest)
        {
            clear?.Invoke();
            writeline?.Invoke("Read menu");
            writeline?.Invoke("");
            writeline?.Invoke("0. Back to main");
            writeline?.Invoke("1. Apple Service");
            writeline?.Invoke("2. Customer");
            writeline?.Invoke("3. Apple Product");
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
                        var get = rest.Get<AppleService>("/appleService");
                        foreach (var item in get)
                        {
                            writeline?.Invoke(item.ToString());
                            writeline?.Invoke("");
                        }
                        break;
                    case "2":
                        var get1 = rest.Get<Customer>("/customer");
                        foreach (var item in get1)
                        {
                            writeline?.Invoke(item.ToString());
                            writeline?.Invoke("");
                        }
                        break;
                    case "3":
                        var get2 = rest.Get<AppleProduct>("/appleProduct");
                        foreach (var item in get2)
                        {
                            writeline?.Invoke(item.ToString());
                            writeline?.Invoke("");
                        }
                        break;
                    default:
                        writeline?.Invoke("Invalid option.");
                        writeline?.Invoke("");
                        break;
                }
            }
        }
    }
}
