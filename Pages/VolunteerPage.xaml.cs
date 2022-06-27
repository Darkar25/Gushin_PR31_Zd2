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
    /// Логика взаимодействия для VolunteerPage.xaml
    /// </summary>
    public partial class VolunteerPage : Page
    {
        Core.user3Entities context;
        public ObservableCollection<Volunteer> Volunteers { get; set; }
        public VolunteerPage()
        {
            context = new user3Entities();
            Volunteers = new ObservableCollection<Volunteer>(context.Volunteer.ToArray());
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Volunteers.Clear();
            var a = context.Volunteer.AsQueryable();
            switch(filter.SelectedIndex)
            {
                case 0:
                    a = a.OrderBy(x => x.Email);
                    break;
                case 1:
                    a = a.OrderBy(x => x.FirstName);
                    break;
                case 2:
                    a = a.OrderBy(x => x.LastName);
                    break;
            }
            foreach(var v in a.ToArray())
            {
                Volunteers.Add(v);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoadVolunteersPage());
        }
    }
}
