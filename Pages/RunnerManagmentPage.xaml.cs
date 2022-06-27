using MaraphonSkills.Core;
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
    /// Логика взаимодействия для RunnerManagmentPage.xaml
    /// </summary>
    public partial class RunnerManagmentPage : Page
    {
        public Registration reg { get; set; }
        public RunnerManagmentPage(Runner run)
        {
            reg = run.Registration.First();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CertificatePage(reg.Runner));
        }
    }
}
