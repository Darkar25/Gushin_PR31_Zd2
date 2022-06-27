using MaraphonSkills.Core.API;
using MaraphonSkills.Core.ModelAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaraphonSkills
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        Core.user3Entities context;
        public TestWindow()
        {
            context = new Core.user3Entities();
            InitializeComponent();
            CharityListview.ItemsSource = context.Charity.ToArray();
            
        }
    }
}
