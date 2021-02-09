using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace DemoTest.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnToList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceListPage());
        }

        private void BtnToService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicePafe(new Base.Service));
        }
    }
}
