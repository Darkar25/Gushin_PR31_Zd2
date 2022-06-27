using MaraphonSkills.Core.API;
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
    /// Логика взаимодействия для CharityPage.xaml
    /// </summary>
    public partial class CharityPage : Page
    {
        Core.user3Entities context;
        public CharityPage()
        {
            context = new Core.user3Entities();

            InitializeComponent();

            CharityItemsControl.ItemsSource = context.Charity.ToArray();
        }
    }
}
