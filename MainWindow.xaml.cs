using MaraphonSkills.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public DateTime startTime ;
        public MainWindow()
        {
            InitializeComponent();
            startTime = DateTime.Parse("2022-11-21 12:00");

            this.DataContext = this;

            MainFrame.NavigationService.Navigate(new StartingPage());

            Console.WriteLine(Properties.Settings.Default.currentUserEmail.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод таймера
        /// </summary>
        public void TimerDate()
        {
            Timer tmr = new Timer
            {
                Interval = 1000
            };
            tmr.Elapsed += Tmr_Elapsed;

            tmr.Start();
        }

        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            PropertyChange("Time");
        }

        /// <summary>
        /// Проверка изменения значения
        /// </summary>
        /// <param name="name"></param>
        private void PropertyChange(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// Переменная содержащая значение таймера для вывода
        /// </summary>
        public string Time
        {
            get
            {
                TimeSpan timeSpan = startTime - DateTime.Now;

                return string.Format("{0} дней {1} часов и {2} минут до старта марафона", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TimerDate();

            

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.currentUserEmail = "";

            Properties.Settings.Default.Save();
        }
    }
}
