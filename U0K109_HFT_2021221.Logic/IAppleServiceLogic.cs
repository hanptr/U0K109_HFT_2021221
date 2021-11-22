using System.Collections.Generic;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.Logic
{
    public interface IAppleServiceLogic
    {
        IEnumerable<KeyValuePair<int, double>> AvgProdPerCustomerPerService();
        IEnumerable<KeyValuePair<int, int>> CountOfCustomerNameStartingWithBPerService();
        IEnumerable<KeyValuePair<int, int>> CountOfProdcutsWithBlackColorPerService();
        IEnumerable<KeyValuePair<int, int>> CountOfProdSerialStartingWith2PerService();
        void Create(AppleService appleService);
        IEnumerable<KeyValuePair<int, int>> CustomerCountWithGmailPerService();
        void Delete(int id);
        IEnumerable<AppleService> GetAll();
        IEnumerable<AppleService> IdStartsWithTwo();
        AppleService Read(int id);
        void Update(AppleService appleService);
    }
}