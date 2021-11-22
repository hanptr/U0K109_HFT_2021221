using System.Collections.Generic;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer customer);
        void Delete(int id);
        IEnumerable<Customer> GetAll();
        Customer Read(int id);
        void Update(Customer customer);
    }
}