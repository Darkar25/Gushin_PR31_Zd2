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
    /// Логика взаимодействия для MarathonInfoPage.xaml
    /// </summary>
    public partial class MarathonInfoPage : Page
    {
        public MarathonInfoPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на интерактивную карту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InteractiveMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new MarathonMapPage());
        }
    }
}
