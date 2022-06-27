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
    /// Логика взаимодействия для MyResultsPage.xaml
    /// </summary>
    public partial class MyResultsPage : Page
    {
        public class ResultEntry {
            public RunnerMarathon Data { get; set; }
            public string Marathon { get; set; }
            public string Distance { get; set; }
            public TimeSpan? Time { get; set; }
            public int GlobalPosition { get; set; }
            public int CategoryPosition { get; set; }
        }
        public Runner run { get; set; }
        public string category { get; set; }
        user3Entities context;
        public MyResultsPage()
        {
            context = new Core.user3Entities();
            var email = Properties.Settings.Default.currentUserEmail;
            run = context.Runner.Where(x => x.Email == email).First();
            int runid = run.RunnerId;
            int runbirth = run.DateOfBirth.Year;
            category = DateTime.Now.Year - runbirth < 18 ? "До 18" :
                    DateTime.Now.Year - runbirth >= 18 && DateTime.Now.Year - runbirth <= 29 ? "18-29" :
                    "От 30";
            InitializeComponent();
            var a = context.RunnerMarathon.Where(x => x.Runner.RunnerId == runid).Select(x => new ResultEntry {
                Data = x,
                Marathon = x.user3.YearHeld + " " + x.user3.Country.CountryName,
                Distance = x.user3.MarathonName,
                Time = x.Time
            }).ToArray();
            foreach(var b in a)
            {
                b.GlobalPosition = b.Data.user3.RunnerMarathon.OrderBy(y => y.Time).ToList().IndexOf(b.Data) + 1;
                b.CategoryPosition = b.Data.user3.RunnerMarathon.Where(y =>
                    y.user3.YearHeld - runbirth < 18 ? y.user3.YearHeld - y.Runner.DateOfBirth.Year < 18 :
                    y.user3.YearHeld - runbirth >= 18 && y.user3.YearHeld - runbirth <= 29 ? y.user3.YearHeld - y.Runner.DateOfBirth.Year >= 18 && y.user3.YearHeld - y.Runner.DateOfBirth.Year <= 29 :
                    y.user3.YearHeld - y.Runner.DateOfBirth.Year > 29
                ).OrderBy(y => y.Time).ToList().IndexOf(b.Data) + 1;
            }
            results.ItemsSource = a;
        }
    }
}
