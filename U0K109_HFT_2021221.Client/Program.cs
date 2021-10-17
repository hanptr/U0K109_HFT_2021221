using System;
using U0K109_HFT_2021221.Data;

namespace U0K109_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AppleDbContext test = new AppleDbContext();
            test.SaveChanges();
            ;
        }
    }
}
