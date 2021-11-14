using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Repository
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Delete(int id);   
        IQueryable<Customer> GetAll();
        Customer Read(int id);
        void Update(Customer customer);
    }
}
