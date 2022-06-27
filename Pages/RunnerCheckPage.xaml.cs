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
    /// Логика взаимодействия для RunnerCheckPage.xaml
    /// </summary>
    public partial class RunnerCheckPage : Page
    {
        public RunnerCheckPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Переход на страницу регистрации бегуна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewRunner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new RunnerRegistrationPage());
        }

        /// <summary>
        /// Нажатие на кнопку старого бегуна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOldRunner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
