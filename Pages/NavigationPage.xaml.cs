using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage(int pageNumber)
        {
            InitializeComponent();


            //Проверка выбранной страницы для перехода
            switch (pageNumber)
            {
                case 1:
                    NavigationFrame.NavigationService.Navigate(new RunnerCheckPage());
                    break;
                case 2:
                    NavigationFrame.NavigationService.Navigate(new ViewerRegistrationPage());
                    break;
                case 3:
                    NavigationFrame.NavigationService.Navigate(new Sponsor());
                    break;
                case 4:
                    NavigationFrame.NavigationService.Navigate(new InfoPage());
                    break;
                case 5:
                    NavigationFrame.NavigationService.Navigate(new LoginPage());
                    break;
            }

            if (!String.IsNullOrEmpty(Properties.Settings.Default.currentUserEmail)||!String.IsNullOrWhiteSpace(Properties.Settings.Default.currentUserEmail))
            {
                LogOutButton.Visibility = Visibility.Visible;
                Console.WriteLine(Properties.Settings.Default.currentUserEmail);
            }

        }

        /// <summary>
        /// Действия кнопки возврата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Кнопка для выхода из своего аккаунта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogOutButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.currentUserEmail = "";
            Properties.Settings.Default.Save();
            this.NavigationService.Navigate(new StartingPage());
        }


    }
}
