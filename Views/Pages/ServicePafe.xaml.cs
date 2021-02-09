using DemoTest.Base;
using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace DemoTest.Views.Pages
{
    // Проблема с добавлением изображения
    /// <summary>
    /// Логика взаимодействия для ServicePafe.xaml
    /// </summary>
    public partial class ServicePafe : Page
    {
        public Service service { get; set; }
        public OpenFileDialog file = new OpenFileDialog();
        public string PathToImage;

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
            file.Filter = "(*.jpg); (*.png) | *.jpg; *.png";

            if (file.ShowDialog() == true)
            {
                ImgBox.Source = new BitmapImage(new Uri(file.FileName));
            }

            PathToImage = file.FileName;
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
                    service.MainImagePath = PathToImage;
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


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }

        private void TxbTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TxbTime.Text != "")
                {
                    int TimeLimit = int.Parse(TxbTime.Text);
                    if (TimeLimit > 14400) BtnSave.IsEnabled = false;
                    else BtnSave.IsEnabled = true;
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Упс, что-то пошло не так", MessageBoxButton.OK, MessageBoxImage.Error) ;
            }
        }
    }
}
