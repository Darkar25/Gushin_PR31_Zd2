using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoadVolunteersPage.xaml
    /// </summary>
    public partial class LoadVolunteersPage : Page
    {
        public LoadVolunteersPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VolunteerPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var f = new OpenFileDialog() { Filter = "CSV file|*.csv" };
            if(f.ShowDialog() == DialogResult.OK)
            {
                file.Text = f.FileName;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Core.user3Entities context = new Core.user3Entities();
            StreamReader sr = new StreamReader(file.Text);
            bool flag = false;
            while (!sr.EndOfStream)
            {
                if (flag)
                {
                    string line = sr.ReadLine();
                    if (line == "")
                        break;
                    string[] temp = line.Split(',');
                    context.Volunteer.Add(new Core.Volunteer() { FirstName = temp[1].Trim(), LastName = temp[2].Trim(), CountryCode = temp[3].Trim(), Gender = temp[4].Trim() });
                }
                flag = true;
            }
            sr.Close();
            context.SaveChanges();
        }
    }
}
