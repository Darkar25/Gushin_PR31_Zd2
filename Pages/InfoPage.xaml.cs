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
    /// Логика взаимодействия для InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице информации о марафоне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarathonSkillsInfoButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MarathonInfoPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице "Насколько долгий марафон"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HowLongInfoButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MarathonLengthPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице предыдущих результатов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviousResultsButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new PreviousRunsPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице благотворительных организаций
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new CharityPage());
        }

        /// <summary>
        /// Нажатие на кнопку перехода к странице BMI калькулятора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new BMICalculatorPage());
        }
    }
}
