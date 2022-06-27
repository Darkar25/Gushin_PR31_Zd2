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
    /// Логика взаимодействия для CoordinatorMenuPage.xaml
    /// </summary>
    public partial class CoordinatorMenuPage : Page
    {
        public CoordinatorMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка перехода к странице управления бегунами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunnersButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new RunnersManagementPage());
        }

        /// <summary>
        /// Кнопка перехода к странице управления благотворительными организациями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new CharityManagementPage());
        }
    }
}
