using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Data;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
         AppleDbContext db;
        public CustomerRepository(AppleDbContext db)
        {
            this.db = db;
        }

        public void Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public Customer Read(int id)
        {
            return
                db.Customers.FirstOrDefault(t => t.CustomerID == id);
        }

        public IQueryable<Customer> GetAll()
        {
            return db.Customers;
        }

        public void Delete(int id)
        {
            var customerToDelete = Read(id);
            db.Customers.Remove(customerToDelete);
            db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var carToUpdate = Read(customer.CustomerID);
            carToUpdate.Email = customer.Email;
            carToUpdate.Name = customer.Name;
            carToUpdate.ServiceID = customer.ServiceID;
            db.SaveChanges();
        }
    }
}
