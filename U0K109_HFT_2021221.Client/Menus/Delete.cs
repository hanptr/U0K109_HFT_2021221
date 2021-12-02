namespace U0K109_HFT_2021221.Client
{
    public class Delete
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


                        write?.Invoke("Apple service (to delete) id: ");

                        int serviceId = int.Parse(input?.Invoke());

                        rest.Delete(serviceId, "/appleService");

                        writeline?.Invoke($"Apple service (id: {serviceId}) deleted successfully.");
                        break;

                    case "2":

                        write?.Invoke("Customer (to delete) id: ");
                        int customerId = int.Parse(input?.Invoke());

                        rest.Delete(customerId, "/customer");

                        write?.Invoke($"Customer (id: {customerId}) deleted successfully.");
                        break;

                    case "3":

                        write?.Invoke("Serial (to delete): ");
                        int productSerial = int.Parse(input?.Invoke());

                        rest.Delete(productSerial, "/appleProduct");

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
