using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Data;

namespace U0K109_HFT_2021221.Repository
{
    class AppleServiceRepository : IAppleServiceRepository
    {
        AppleDbContext db;
        public AppleServiceRepository(AppleDbContext db)
        {
            this.db = db;
        }

        public void Create(AppleService appleService)
        {
            db.AppleServices.Add(appleService);
            db.SaveChanges();
        }

        public AppleService Read(int id)
        {
            return
                db.AppleServices.FirstOrDefault(t => t.ServiceID == id);
        }

        public IQueryable<AppleService> GetAll()
        {
            return db.AppleServices;
        }

        public void Delete(int id)
        {
            var appleServiceToDelete = Read(id);
            db.AppleServices.Remove(appleServiceToDelete);
            db.SaveChanges();
        }

        public void Update(AppleService appleService)
        {
            var appleServiceToUpdate = Read(appleService.ServiceID);
            appleServiceToUpdate.Location = appleService.Location;
            appleServiceToUpdate.ServiceName = appleService.ServiceName;
            db.SaveChanges();
        }
    }
}
