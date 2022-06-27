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
    /// Логика взаимодействия для ThankPage.xaml
    /// </summary>
    public partial class ThankPage : Page
    {
        Core.user3Entities context;
        /// <summary>
        /// Страница для вывода благодарности за пожертвование
        /// </summary>
        /// <param name="runner"></param>
        /// <param name="charity"></param>
        /// <param name="money"></param>
        public ThankPage(int runner, int charity, int money)
        {
            context = new Core.user3Entities();
            InitializeComponent();
            // В переменную заносится результат поиска в LINQ запросе имени бегуна
            string currentRunnerFIO = context.Runner.Where(x => x.RunnerId == runner).First().RunnerFIO;
            // В переменную заносится результат поиска в LINQ запросе названия страны бегуна
            string currentRunnerCountry = context.Runner.Where(x => x.RunnerId == runner).First().Country.CountryName;
            // В переменную заносится результат поиска в LINQ запросе названия благотворительной организации
            string currentCharityName = context.Charity.Where(x => x.CharityId == charity).First().CharityName;

            RunnerInfoLabel.Content = String.Format("{0} из {1}", currentRunnerFIO, currentRunnerCountry);
            CharityLabel.Content = currentCharityName;
            MoneyLabel.Content = String.Format("${0}", money);
        }

        /// <summary>
        /// Кнопка перехода назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
            NavigationService.GoBack();
        }
    }
}
