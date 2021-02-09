using DemoTest.Base;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ServicePafe.xaml
    /// </summary>
    public partial class ServicePafe : Page
    {
        public Service service { get; set; }
        public ServicePafe(Service GetService)
        {
            InitializeComponent();

            service = GetService;
            this.DataContext = this;
        }
    }
}
