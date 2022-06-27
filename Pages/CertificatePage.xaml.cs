using MaraphonSkills.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CertificatePage.xaml
    /// </summary>
    public partial class CertificatePage : Page
    {
        public ObservableCollection<user3> Marathons { get; set; }
        public RunnerMarathon Run { get; set; }
        Runner runner;
        public CertificatePage(Runner runner)
        {
            this.runner = runner;
            Core.user3Entities context = new Core.user3Entities();
            Marathons = new ObservableCollection<user3>(context.user3.ToArray());
            Run = (mar.SelectedItem as user3).RunnerMarathon.FirstOrDefault(x => x.Runner == runner);
            if(Run == null)
            {
                MessageBox.Show("Этот бегун не учавствовал в этом марафоне");
            }
            InitializeComponent();
        }

        private void mar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Run = (mar.SelectedItem as user3).RunnerMarathon.FirstOrDefault(x => x.Runner == runner);
            if (Run == null)
            {
                MessageBox.Show("Этот бегун не учавствовал в этом марафоне");
            }
        }
    }
}
