using DemoTest.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ServiceListPage : Page
    {
        public ObservableCollection<Service> services { get; set; }
        public ServiceListPage()
        {
            InitializeComponent();
            services = new ObservableCollection<Service>(BaseClass.db.Service.ToList());
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

            //if (CmbSearch.Text == "По убыванию")
            //{
            //    //LWService.ItemsSource = BaseClass.db.Service.OrderByDescending(x => x.Cost).ToString();
            //    services = new ObservableCollection<Service>(BaseClass.db.Service.OrderByDescending(x => x.Cost));
            //    this.DataContext = null;
            //    this.DataContext = this;
            //} else if (CmbSearch.Text == "По возрастанию")
            //{
            //    //LWService.ItemsSource = BaseClass.db.Service.OrderBy(x => x.Cost).ToString();
            //    services = new ObservableCollection<Service>(BaseClass.db.Service.OrderBy(x => x.Cost));
            //    this.DataContext = null;
            //    this.DataContext = this;
            //}
        }
    }
}
