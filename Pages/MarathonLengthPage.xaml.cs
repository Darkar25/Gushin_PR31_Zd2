using MaraphonSkills.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для MarathonLengthPage.xaml
    /// </summary>
    public partial class MarathonLengthPage : Page, INotifyPropertyChanged
    {
        user3Entities context;

        public event PropertyChangedEventHandler PropertyChanged;

        public HowLong hl { get; set; }
        public MarathonLengthPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();
            spid.ItemsSource = context.HowLong.Where(x => x.Id <= 7).ToList();
            dist.ItemsSource = context.HowLong.Where(x => x.Id > 7).ToList();
        }

        private void spid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hl = (sender as ListView).SelectedItem as HowLong;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(hl)));
        }
    }
}
