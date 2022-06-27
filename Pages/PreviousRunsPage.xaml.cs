using MaraphonSkills.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
    /// Логика взаимодействия для PreviousRunsPage.xaml
    /// </summary>
    public partial class PreviousRunsPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<user3> marathons { get; set; }
        public ObservableCollection<EventType> distants { get; set; }
        Core.user3Entities context = new user3Entities();

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<RunnerMarathon> Runners { get; set; } = new ObservableCollection<RunnerMarathon>();
        public int Finished => Runners.Count(x => x.Time.HasValue);
        public TimeSpan AvgTime => TimeSpan.FromSeconds(Runners.Any()? Runners.Average(x => x.Time.HasValue ? x.Time.Value.TotalSeconds : 0) : 0);
        public PreviousRunsPage()
        {
            marathons = new ObservableCollection<user3>(context.user3.ToArray());
            distants = new ObservableCollection<EventType>(context.EventType.ToArray());
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Runners.Clear();
            var mid = (marathon.SelectedItem as user3).MarathonId;
            var et = (distance.SelectedItem as EventType).EventTypeId;
            var a = context.RunnerMarathon.Where(x => x.MarathonId == mid && x.user3.Event.Any(ev => ev.EventType.EventTypeId == et));
            if (gender.SelectedIndex == 1)
            {
                a = a.Where(x => x.Runner.Gender == "M");
            } else if (gender.SelectedIndex == 2)
            {
                a = a.Where(x => x.Runner.Gender == "W");
            }
            switch(category.SelectedIndex)
            {
                case 0:
                    a = a.Where(x => x.user3.YearHeld - x.Runner.DateOfBirth.Year < 18);
                    break;
                case 2:
                    a = a.Where(x => x.user3.YearHeld - x.Runner.DateOfBirth.Year > 29);
                    break;
                case 1:
                    a = a.Where(x => x.user3.YearHeld - x.Runner.DateOfBirth.Year >= 18 && x.user3.YearHeld - x.Runner.DateOfBirth.Year <= 29);
                    break;
            }
            a = a.OrderBy(x => x.Time);
            foreach (var r in a.ToArray())
                Runners.Add(r);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Finished)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AvgTime)));
        }
    }
}
