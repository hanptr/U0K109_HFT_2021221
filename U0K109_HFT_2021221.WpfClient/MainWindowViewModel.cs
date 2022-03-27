using Microsoft.Toolkit.Mvvm.ComponentModel;
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
                        ServiceID=value.ServiceID
                    };
                    OnPropertyChanged();
                }
                (DeleteAppleServiceCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateAppleServiceCommand { get; set; }
        public ICommand DeleteAppleServiceCommand { get; set; }
        public ICommand UpdateAppleServiceCommand { get; set; }
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
                AppleServices = new RestCollection<AppleService>("http://localhost:21980/", "appleService");
                CreateAppleServiceCommand = new RelayCommand(
                    () =>
                    {
                        AppleServices.Add(new AppleService()
                        {
                            ServiceName = SelectedAppleService.ServiceName,
                            Location = "Sajt"

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
                        return (SelectedAppleService != null && SelectedAppleService.Products.Count() == 0);
                    });
                UpdateAppleServiceCommand = new RelayCommand(() =>
                {
                    AppleServices.Update(SelectedAppleService);
                });
                SelectedAppleService = new AppleService();
            }
        }
    }
}
