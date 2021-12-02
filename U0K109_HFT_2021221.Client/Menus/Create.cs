using System;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Client
{
    public class Create
    {
        public void Start(Clear clear, Input input, Output write, Output writeline, RestService rest)
        {
            clear?.Invoke();
            writeline?.Invoke("Create menu");
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
                        service.ServiceName = input?.Invoke();

                        write?.Invoke("Location: ");
                        service.Location = input?.Invoke();

                        rest.Post<AppleService>(service, "/appleService");

                        write?.Invoke("Apple service created successfully.");
                        break;

                    case "2":

                        Customer customer = new Customer();

                        write?.Invoke("Customer name: ");
                        customer.Name = input?.Invoke();

                        write?.Invoke("Email: ");
                        customer.Email = input?.Invoke();

                        write?.Invoke("Used this Apple service(service id): ");
                        customer.ServiceID = int.Parse(input?.Invoke());

                        rest.Post<Customer>(customer, "/customer");

                        write?.Invoke("Customer created successfully.");
                        break;

                    case "3":

                        AppleProduct product = new AppleProduct();

                        write?.Invoke("Type: ");
                        product.Type = (U0K109_HFT_2021221.Models.Type)Enum.Parse(typeof(U0K109_HFT_2021221.Models.Type), input?.Invoke());

                        write?.Invoke("Color: ");
                        product.Color = input?.Invoke();

                        write?.Invoke("Owner (customer id): ");
                        product.CustomerID = int.Parse(input?.Invoke());

                        write?.Invoke("In this Apple service (service id): ");
                        product.ServiceID = int.Parse(input?.Invoke());

                        rest.Post<AppleProduct>(product, "/appleProduct");

                        write?.Invoke("Apple product created successfully.");
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
