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
    /// <summary>
    /// Логика взаимодействия для ServiceImagePage.xaml
    /// </summary>
    public partial class ServiceImagePage : Page
    {
        public Service service { get; set; }
        public ObservableCollection<ServicePhoto> photos { get; set; }
        

        public ServiceImagePage(Service GetService)
        {
            InitializeComponent();
            service = GetService;
            photos = new ObservableCollection<ServicePhoto>(BaseClass.db.ServicePhoto.Where(item => item.ServiceID == service.ID).ToList());
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
