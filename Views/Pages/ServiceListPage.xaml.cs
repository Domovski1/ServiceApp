using DemoTest.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoTest.Views.Pages
{
    public partial class ServiceListPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Service> services { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string CountService { get; set; }

        public ServiceListPage()
        {
            InitializeComponent();
            services = new ObservableCollection<Service>(BaseClass.db.Service.ToList());
            CountService = BaseClass.db.Service.Count().ToString();
            this.DataContext = this;
            Clicked();
        }


        void Clicked()
        {
            TxbCost.TextDecorations = TextDecorations.Strikethrough;
        }

        private void CmbSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CmbSearch.Text)
            {
                case "По убыванию":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.OrderByDescending(x => x.Cost));
                    this.DataContext = null;
                    this.DataContext = this;
                    break;
                case "По возрастанию":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.OrderBy(x => x.Cost));
                    this.DataContext = null;
                    this.DataContext = this;
                    break;
                case "Скидка 0-5%":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.Where(x => x.Discount < 5));
                    this.DataContext = null;
                    this.DataContext = this; ;
                    break;
                case "Скидка 5-15%":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.Where(x => x.Discount >= 5 && x.Discount < 15));
                    this.DataContext = null;
                    this.DataContext = this; ;
                    break;
                case "Скидка 15-30%":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.Where(x => x.Discount >= 15 && x.Discount < 30));
                    this.DataContext = null;
                    this.DataContext = this; ;
                    break;
                case "Скидка 30-70%":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.Where(x => x.Discount >= 30 && x.Discount < 70));
                    this.DataContext = null;
                    this.DataContext = this; ;
                    break;
                case "Скидка 70-100%":
                    services = new ObservableCollection<Service>(BaseClass.db.Service.Where(x => x.Discount >= 70 && x.Discount <100));
                    this.DataContext = null;
                    this.DataContext = this; ;
                    break;
            }

        }

        private void LWService_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new ServicePafe((Service)LWService.SelectedItem));
            NavigationService.Navigate(new ServiceImagePage((Service)LWService.SelectedItem));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            Service NewService = new Service()
            {
                Title = "New Item",
                Cost = 1330,
                DurationInSeconds = 13300,
                Discount = 16
            };
            BaseClass.db.Service.Add(NewService);
            BaseClass.db.SaveChanges();
            MessageBox.Show("Added new service", "Done");

            //try
            //{
            //    BaseClass.db.Service.Remove((Service)LWService.SelectedItem);
            //    //BaseClass.db.SaveChanges();
            //    MessageBox.Show("Удалено");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Exception");
            //}
        }
    }
}
