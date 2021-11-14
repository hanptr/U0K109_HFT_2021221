﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Repository
{
    public interface IAppleService
    {
        void Create(AppleService appleService);
        void Delete(int id);
        IQueryable<AppleService> GetAll();
        AppleService Read(int id);
        void Update(AppleService appleService);
    }
}
