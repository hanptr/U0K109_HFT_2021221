using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Client
{
    public class Create
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

                        AppleService service = new AppleService();

                        write?.Invoke("Service name: ");
                        service.ServiceName=input?.Invoke();

                        write?.Invoke("Location: ");
                        service.Location = input?.Invoke();

                        rest.Post(service, "/appleService");
                        break;

                    case "2":

                        Customer customer = new Customer();

                        write?.Invoke("Customer name: ");
                        customer.Name = input?.Invoke();
                        write?.Invoke("Email: ");
                        customer.Email = input?.Invoke();
                        write?.Invoke("Used this Apple service(service id): ");
                        customer.ServiceID = int.Parse(input?.Invoke());
                        rest.Post(customer, "/customer");
                        break;

                    case "3":

                        AppleProduct product = new AppleProduct();

                        //write?.Invoke("Product serial number: ");
                        //int sId = int.Parse(input?.Invoke());
                        //var result = rest.Get<AppleProduct>("/appleProduct");
                        //bool isUnique = false;
                        //if (result.FirstOrDefault(x => x.Serial == sId) == null)
                        //{
                        //    product.Serial = sId;
                        //}
                        //else
                        //{
                        //    while (isUnique == false)
                        //    {
                        //        write?.Invoke("This product serial has already been recorded in the database, give another one: ");
                        //        sId =int.Parse(input?.Invoke());
                        //        if (result.FirstOrDefault(x => x.Serial == sId) == null)
                        //        {
                        //            isUnique = true;
                        //        }
                        //    }
                        //    product.Serial = sId;
                        //}

                        write?.Invoke("Type: ");
                        product.Type = (U0K109_HFT_2021221.Models.Type)Enum.Parse(typeof(U0K109_HFT_2021221.Models.Type), input?.Invoke());

                        write?.Invoke("Color: ");
                        product.Color = input?.Invoke();

                        write?.Invoke("Owner (customer id): ");
                        product.CustomerID = int.Parse(input?.Invoke());

                        write?.Invoke("In this Apple service (service id): ");
                        product.ServiceID = int.Parse(input?.Invoke());
                        
                        rest.Post<AppleProduct>(product, "/appleProduct");
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
