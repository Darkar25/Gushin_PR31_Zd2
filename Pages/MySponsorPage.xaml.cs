using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MySponsorPage.xaml
    /// </summary>
    public partial class MySponsorPage : Page, INotifyPropertyChanged
    {
        Core.user3Entities context;
        Core.Runner currentRunner;
        Core.User currentUser;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MaraphonSkills.Core.Sponsor> Sponsors { get; set; } = new ObservableCollection<MaraphonSkills.Core.Sponsor>();
        public decimal Total => Sponsors.Sum(x => x.Amount);
        public Core.Sponsor DisplaySponsor { get; set; }
        public MySponsorPage()
        {
            context = new Core.user3Entities();
            var email = Properties.Settings.Default.currentUserEmail;
            currentRunner = context.Runner.Where(x => x.Email == email).First();
            currentUser = context.User.Where(x => x.Email == email).First();
            foreach (var s in currentRunner.Sponsor)
                Sponsors.Add(s);
            DisplaySponsor = Sponsors[new Random().Next(0, Sponsors.Count)];
            InitializeComponent();

        }
    }
}
