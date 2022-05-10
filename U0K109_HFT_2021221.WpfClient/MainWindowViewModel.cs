using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using U0K109_HFT_2021221.Models;

namespace U0K109_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        //AppleService
        public RestCollection<AppleService> AppleServices { get; set; }
        private AppleService selectedAppleService;

        public AppleService SelectedAppleService
        {
            get { return selectedAppleService; }
            set
            {
                if (value!=null)
                {
                    selectedAppleService = new AppleService()
                    {
                        ServiceName = value.ServiceName,
                        ServiceID = value.ServiceID,
                        Location = value.Location,
                        Customers = value.Customers,
                        Products = value.Products
                    };
                    OnPropertyChanged();
                    (CreateAppleServiceCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteAppleServiceCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateAppleServiceCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        //Customer
        public RestCollection<Customer> Customers { get; set; }
        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (value != null)
                {
                    selectedCustomer = new Customer()
                    {
                        ServiceID = value.ServiceID,
                        CustomerID=value.CustomerID,
                        Email=value.Email,
                        Name=value.Name,
                        AppleService=value.AppleService,
                        Products=value.Products
                        
                    };
                    OnPropertyChanged();
                    (CreateCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateCustomerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        //AppleProcuct
        public RestCollection<AppleProduct> AppleProducts { get; set; }
        private AppleProduct selectedAppleProduct;

        public AppleProduct SelectedAppleProduct
        {
            get { return selectedAppleProduct; }
            set
            {
                if (value != null)
                {
                    selectedAppleProduct = new AppleProduct()
                    {
                        ServiceID=value.ServiceID,
                        Serial=value.Serial,
                        AppleService=value.AppleService,
                        Color=value.Color,
                        Customer=value.Customer,
                        CustomerID=value.CustomerID,
                        Type=value.Type
                    };
                    OnPropertyChanged();
                    (CreateAppleProductCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteAppleProductCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateAppleProductCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        //appleservice command
        public ICommand CreateAppleServiceCommand { get; set; }
        public ICommand DeleteAppleServiceCommand { get; set; }
        public ICommand UpdateAppleServiceCommand { get; set; }

        //customer command
        public ICommand CreateCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand UpdateCustomerCommand { get; set; }

        //appleservice command
        public ICommand CreateAppleProductCommand { get; set; }
        public ICommand DeleteAppleProductCommand { get; set; }
        public ICommand UpdateAppleProductCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                return
                    (bool)DependencyPropertyDescriptor
                    .FromProperty(DesignerProperties.
                    IsInDesignModeProperty,
                    typeof(FrameworkElement))
                    .Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
           
            if (!IsInDesignMode)
            {
                //appleservice
                AppleServices = new RestCollection<AppleService>("http://localhost:21980/", "appleService", "hub");
                CreateAppleServiceCommand = new RelayCommand(
                    () =>
                    {
                        AppleServices.Add(new AppleService()
                        {
                            ServiceName = SelectedAppleService.ServiceName,
                            Location=SelectedAppleService.Location
                            //ServiceID=selectedAppleService.ServiceID,
                        }
                            );
                    }
                    );
                DeleteAppleServiceCommand = new RelayCommand(
                    () =>
                    {
                        AppleServices.Delete(SelectedAppleService.ServiceID);
                    },
                    () =>
                    {
                        return (SelectedAppleService != null && SelectedAppleService.Products.Count() == 0 && SelectedAppleService.Customers.Count()==0);
                    });
                UpdateAppleServiceCommand = new RelayCommand(() =>
                {
                    AppleServices.Update(SelectedAppleService);
                });
                SelectedAppleService = new AppleService();

                //customer
                Customers= new RestCollection<Customer>("http://localhost:21980/", "customer", "hub");
                CreateCustomerCommand = new RelayCommand(
                    () =>
                    {
                        Customers.Add(new Customer()
                        {
                            ServiceID=SelectedCustomer.ServiceID,
                            AppleService=SelectedCustomer.AppleService,
                            Email=SelectedCustomer.Email,
                            Name=SelectedCustomer.Name
                        }
                       );
                    }
                    );
                DeleteCustomerCommand = new RelayCommand(
                    () =>
                    {
                        Customers.Delete(SelectedCustomer.CustomerID);
                    },
                    () =>
                    {
                        return (SelectedCustomer != null && SelectedCustomer.Products.Count() == 0);
                    });
                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Update(SelectedCustomer);
                });
                SelectedCustomer = new Customer();

                //appleProduct
                AppleProducts= new RestCollection<AppleProduct>("http://localhost:21980/", "appleProduct", "hub");
                CreateAppleProductCommand = new RelayCommand(
                    () =>
                    {
                        AppleProducts.Add(new AppleProduct()
                        {
                            ServiceID=SelectedCustomer.ServiceID,
                            AppleService=SelectedCustomer.AppleService,
                            CustomerID=SelectedCustomer.CustomerID,
                            Color=SelectedAppleProduct.Color,
                            Customer=SelectedAppleProduct.Customer,
                            Type=SelectedAppleProduct.Type
                        }
                      );
                    }
                    );
                DeleteAppleProductCommand = new RelayCommand(() => AppleProducts.Delete(SelectedAppleProduct.Serial));
                UpdateAppleProductCommand = new RelayCommand(() =>
                {
                    AppleProducts.Update(SelectedAppleProduct);
                });
                SelectedAppleProduct = new AppleProduct();
            }
        }
    }
}
