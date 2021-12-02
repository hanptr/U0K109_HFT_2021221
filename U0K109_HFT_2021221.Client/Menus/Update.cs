using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Client
{
    public class Update
    {
        public void Start(Clear clear, Input input, Output write, Output writeline, RestService rest)
        {
            clear?.Invoke();
            writeline?.Invoke("Update menu");
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

                        
                        write?.Invoke("Apple service id: ");

                        int serviceId = int.Parse(input?.Invoke());
                        AppleService updatedService = rest.Get<AppleService>(serviceId, "/appleService");

                        write?.Invoke("Service name: ");
                        updatedService.ServiceName = input?.Invoke();

                        write?.Invoke("Location: ");
                        updatedService.Location = input?.Invoke();

                        rest.Put<AppleService>(updatedService, "/appleService");

                        write?.Invoke($"Apple service (id: {serviceId}) updated successfully.");
                        break;

                    case "2":

                        write?.Invoke("Customer id: ");
                        int customerId = int.Parse(input?.Invoke());

                        Customer updatedCustomer = rest.Get<Customer>(customerId, "/customer");

                        write?.Invoke("Customer name: ");
                        updatedCustomer.Name = input?.Invoke();

                        write?.Invoke("Email: ");
                        updatedCustomer.Email = input?.Invoke();

                        write?.Invoke("Used this Apple service(service id): ");
                        updatedCustomer.ServiceID = int.Parse(input?.Invoke());

                        rest.Put<Customer>(updatedCustomer, "/customer");

                        write?.Invoke($"Customer (id: {customerId}) updated successfully.");
                        break;

                    case "3":

                        write?.Invoke("Serial: ");
                        int productSerial=int.Parse(input?.Invoke());

                        AppleProduct updatedProduct = rest.Get<AppleProduct>(productSerial, "/appleProduct");

                        write?.Invoke("Type: ");
                        updatedProduct.Type = (U0K109_HFT_2021221.Models.Type)Enum.Parse(typeof(U0K109_HFT_2021221.Models.Type), input?.Invoke());

                        write?.Invoke("Color: ");
                        updatedProduct.Color = input?.Invoke();

                        write?.Invoke("Owner (customer id): ");
                        updatedProduct.CustomerID = int.Parse(input?.Invoke());

                        write?.Invoke("In this Apple service (service id): ");
                        updatedProduct.ServiceID = int.Parse(input?.Invoke());

                        rest.Put<AppleProduct>(updatedProduct, "/appleProduct");

                        write?.Invoke($"Apple product (id: {productSerial}) updated successfully.");
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
