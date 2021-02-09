using DemoTest.Base;
using Microsoft.Win32;
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

            ShowServiceID();
        }


        /// <summary>
        /// Навигация назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        /// <summary>
        /// Выбор и загрузка изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChoose_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "(*.jpg); (*.png) | *.jpg; *.png";

            if (file.ShowDialog() == true)
            {
                ImgBox.Source = new BitmapImage(new Uri(file.FileName));
            }
        }

        void ShowServiceID()
        {
            if (service.ID != 0) LblId.Content = $"ID: {service.ID}";
            else LblId.Content = "Новый сервис";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                var ServiceExist = BaseClass.db.Service.FirstOrDefault(s => s.Title == TxbTitle.Text);


                if (service.ID == 0)
                {
                    if (ServiceExist != null) MessageBox.Show("Такой сервис существует!");
                    BaseClass.db.Service.Add(service);
                    BaseClass.db.SaveChanges();
                    MessageBox.Show("Операция выполнена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    BaseClass.db.SaveChanges();
                    MessageBox.Show("Операция выполнена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Упс, что-то пошло не так", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void CheckData()
        {
            int TimeLimit = int.Parse(TxbTime.Text);
            if (TimeLimit > 14400)
            {
                BtnSave.IsEnabled = false;
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }
    }
}
