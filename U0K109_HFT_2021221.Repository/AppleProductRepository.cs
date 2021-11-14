﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Data;

namespace U0K109_HFT_2021221.Repository
{
    class AppleProductRepository : IAppleProductRepository
    {
        AppleDbContext db;
        public AppleProductRepository(AppleDbContext db)
        {
            this.db = db;
        }

        public void Create(AppleProduct appleProduct)
        {
            db.AppleProducts.Add(appleProduct);
            db.SaveChanges();
        }

        public AppleProduct Read(int id)
        {
            return
                db.AppleProducts.FirstOrDefault(t => t.Serial == id);
        }

        public IQueryable<AppleProduct> GetAll()
        {
            return db.AppleProducts;
        }

        public void Delete(int id)
        {
            var appleProductToDelete = Read(id);
            db.AppleProducts.Remove(appleProductToDelete);
            db.SaveChanges();
        }

        public void Update(AppleProduct appleProduct)
        {
            var appleProductToUpdate = Read(appleProduct.Serial);
            appleProductToUpdate.Type = appleProduct.Type;
            appleProductToUpdate.ServiceID = appleProduct.ServiceID;
            appleProductToUpdate.CustomerID = appleProduct.CustomerID;
            db.SaveChanges();
        }
    }
}
