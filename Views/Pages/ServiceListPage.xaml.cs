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
        }
    }
}
