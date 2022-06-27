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
    /// Логика взаимодействия для CharityManagementPage.xaml
    /// </summary>
    public partial class CharityManagementPage : Page
    {
        Core.user3Entities context;
        public CharityManagementPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            CharityDataGrid.ItemsSource = context.Charity.ToList();
            CharityCountTextBlock.Text = String.Format("Благотворительные организации:  {0}", context.Charity.Count());
            int allDonationsCount = 0;
            foreach (var item in context.Charity.ToList())
            {
                allDonationsCount += item.MoneyCount;
            }
            CharityMoneyCountTextBlock.Text = String.Format("Всего спонсорских взносов:  ${0}", allDonationsCount);
            SortComboBox.ItemsSource = new List<string>
            {
                "Наименование",
                "Сумма"
            };
        }

        /// <summary>
        /// Нажатие на кнопку сортировки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            switch (SortComboBox.SelectedIndex)
            {
                case 0:
                    CharityDataGrid.ItemsSource = context.Charity.OrderBy(x=>x.CharityName).ToList();
                    break;
                case 1:
                    CharityDataGrid.ItemsSource = context.Charity.OrderBy(x=>x.MoneyCount).ToList();
                    break;
            }
        }
    }
}
