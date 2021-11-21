﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;

namespace U0K109_HFT_2021221.Logic
{
    class CustomerLogic : ICustomerLogic
    {
        ICustomerRepository customerRepo;
        public CustomerLogic(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public void Create(Customer customer)
        {
            if (!customer.Email.Contains('@'))
            {
                throw new Exception("E-mail does not meet the requirements.")
            }
            else
            {
                customerRepo.Create(customer);
            }
        }

        public void Delete(int id)
        {
            customerRepo.Delete(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return customerRepo.GetAll();
        }

        public Customer Read(int id)
        {
            return customerRepo.Read(id);
        }

        public void Update(Customer customer)
        {
            customerRepo.Update(customer);
        }

        //non-rud methods

        public double AVGProduct() 
        {
            return customerRepo.GetAll()
                .Average(t => t.Products.Count);
        }
        public IEnumerable<Customer> MoreThanOneProduct()
        {
            return customerRepo.GetAll().Where(t => t.Products.Count > 1);     
        }
        public IEnumerable<Customer> CustomersWithGmail()
        {
            return customerRepo.GetAll().Where(t => t.Email.StartsWith("g"));
        }
    }
}
