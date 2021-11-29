using System;
using Moq;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using U0K109_HFT_2021221.Models;
using U0K109_HFT_2021221.Repository;
using U0K109_HFT_2021221.Logic;

namespace U0K109_HFT_2021221.Test
{
    [TestFixture]
    public class Test
    {
        IAppleProductLogic appleProdLogic;
        IAppleServiceLogic appleServLogic;
        ICustomerLogic customerLogic;
        [SetUp]
        public void MoqSetup()
        {
            var moqAppleProductRepo = new Mock<IAppleProductRepository>();
            var moqAppleServiceRepo = new Mock<IAppleServiceRepository>();
            var moqCustomerRepo = new Mock<ICustomerRepository>();

            var appleServices = new List<AppleService>()
            {
                new AppleService()
                {
                    ServiceID=1,
                    ServiceName="A1",
                    Location="Budapest"
                },
                new AppleService()
                {
                    ServiceID=2,
                    ServiceName="A2",
                    Location="Érd"
                }
            }.AsQueryable();

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    Email="bela@gmail.com",
                    Name="Bela Bela",
                    CustomerID=1,
                    ServiceID=appleServices.ElementAt(0).ServiceID
                },
                new Customer()
                {
                    Email="sanyi@gmail.com",
                    Name="Sanyi Sanyi",
                    CustomerID=1,
                    ServiceID=appleServices.ElementAt(1).ServiceID
                }
            }.AsQueryable();

            var appleProducts = new List<AppleProduct>()
            {
                new AppleProduct()
                {
                    Color="Black",
                    Serial=11111,
                    Type=Models.Type.iPad,
                    CustomerID=customers.ElementAt(0).CustomerID,
                    ServiceID=appleServices.ElementAt(0).ServiceID
                },
                new AppleProduct()
                {
                    Color="Red",
                    Serial=11112,
                    Type=Models.Type.AppleWatch,
                    CustomerID=customers.ElementAt(1).CustomerID,
                    ServiceID=appleServices.ElementAt(1).ServiceID
                }
            }.AsQueryable();

            //Service
            appleServices.ElementAt(0).Customers.Add(customers.ElementAt(0));
            appleServices.ElementAt(1).Customers.Add(customers.ElementAt(1));

            appleServices.ElementAt(0).Products.Add(appleProducts.ElementAt(0));
            appleServices.ElementAt(1).Products.Add(appleProducts.ElementAt(1));

            //Customer
            customers.ElementAt(0).Products.Add(appleProducts.ElementAt(0));
            customers.ElementAt(1).Products.Add(appleProducts.ElementAt(1));

            //RepoSetup
            moqCustomerRepo.Setup(customer => customer.GetAll()).Returns(customers);
            moqAppleProductRepo.Setup(appleProduct => appleProduct.GetAll()).Returns(appleProducts);
            moqAppleServiceRepo.Setup(appleService => appleService.GetAll()).Returns(appleServices);

            appleServLogic = new AppleServiceLogic(moqAppleServiceRepo.Object);
            customerLogic = new CustomerLogic(moqCustomerRepo.Object);
            appleProdLogic = new AppleProductLogic(moqAppleProductRepo.Object);

        }

        [Test]
        public void Test1()
        {
            var result = appleServLogic.AvgProdPerCustomerPerService();
            var expected = new List<KeyValuePair<int, double>>()
            {
                new KeyValuePair<int, double>(1, 1),
                new KeyValuePair<int, double>(2, 1)
            };
            ;
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Test2()
        {
            var result = appleServLogic.CountOfCustomerNameStartingWithBPerService();
            var expected = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(2, 0)
            };
            ;
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Test3()
        {
            var result = appleServLogic.CountOfProdcutsWithBlackColorPerService();
            var expected = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(2, 0)
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Test4()
        {
            var result = appleServLogic.CountOfProdSerialStartingWith2PerService();
            var expected = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(1, 0),
                new KeyValuePair<int, int>(2, 0)
            };
            ;
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Test5()
        {
            var result = appleServLogic.CustomerCountWithGmailPerService();
            var expected = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(2, 1)
            };
            ;
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void Test6()
        {
            AppleService serv = new();
            serv.Location = "%";
            Assert.That(() => { appleServLogic.Create(serv); }, Throws.Exception);
        }
        [Test]
        public void Test7()
        {
            Customer custom = new();
            custom.Email = "belagmail.com";
            Assert.That(() => { customerLogic.Create(custom); }, Throws.Exception);
        }
        [Test]
        public void Test8()
        {
            Customer custom = new();
            custom.CustomerID = -1;
            Assert.That(() => { customerLogic.Create(custom); }, Throws.Exception);
        }
        [Test]
        public void Test9()
        {
            AppleProduct prod = new();
            prod.Serial = -1;
            Assert.That(() => { appleProdLogic.Create(prod); }, Throws.Exception);
        }
        [Test]
        public void Test10() 
        {
            AppleProduct prod = new();
            prod.Serial = 999999999;
            Assert.That(() => { appleProdLogic.Create(prod); }, Throws.Exception);
        }
    }
}
