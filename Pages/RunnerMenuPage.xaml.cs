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

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerMenuPage.xaml
    /// </summary>
    public partial class RunnerMenuPage : Page
    {
        public RunnerMenuPage()
        {
            InitializeComponent();

            ContactsBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице редактирования профиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfileEditButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ProfileEditPage());
        }

        /// <summary>
        /// Нажатие на кнопку контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactsButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ContactsBorder.Visibility = Visibility.Visible;

        }

        /// <summary>
        /// Нажатие на крестик для закрытие всплывающего окна контактов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cross_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            ContactsBorder.Visibility = Visibility.Collapsed;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MySponsorPage());
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MyResultsPage());
        }
    }
}
