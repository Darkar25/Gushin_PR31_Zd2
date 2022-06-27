using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
using System.ComponentModel;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        public DateTime startTime = DateTime.Parse("2022-11-21 12:00");

        public StartingPage()
        {
            InitializeComponent();
            this.DataContext = this;
            StartDate();
                
        }



        /// <summary>
        /// Преобразование даты марафона
        /// </summary>
        private void StartDate()
        {
            string dayOfWeek = startTime.DayOfWeek.ToString();
            switch (startTime.DayOfWeek.ToString())
            {
                case "Monday":
                    dayOfWeek = "Понедельник";
                    break;
                case "Tuesday":
                    dayOfWeek = "Вторник";
                    break;
                case "Wednesday":
                    dayOfWeek = "Среда";
                    break;
                case "Thursday":
                    dayOfWeek = "Четверг";
                    break;
                case "Friday":
                    dayOfWeek = "Пятница";
                    break;
                case "Saturday":
                    dayOfWeek = "Суббота";
                    break;
                case "Sunday":
                    dayOfWeek = "Воскресенье";
                    break;
            }

            StartDateTextBlock.Text = dayOfWeek + " " + startTime.ToLongDateString();
        }

        /// <summary>
        /// Метод для перехода на страницу навигации 
        /// с передачей информации о нужной странице для перехода
        /// </summary>
        /// <param name="pageNumber"></param>
        private void Navigation(int pageNumber) 
        {
            this.NavigationService.Navigate(new NavigationPage(pageNumber));
        }


        /// <summary>
        /// Действия при нажатии кнопки бегунов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRunnerRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Вызов метода навигации
            Navigation(1);

        }

        /// <summary>
        /// Действия при нажатии кнопки зрителей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonViewerRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Вызов метода навигации
            Navigation(2);

        }

        /// <summary>
        /// Действия при нажатии кнопки спонсоров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSponsorRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Вызов метода навигации
            Navigation(3);

        }

        /// <summary>
        /// Действия при нажатии кнопки информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Вызов метода навигации
            Navigation(4);

        }

        /// <summary>
        /// Нажатие на кнопку перехода к окну логина
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Navigation(5);
        }
    }
}
