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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills.Pages
{

    /// <summary>
    /// Логика взаимодействия для Sponsor.xaml
    /// </summary>
    public partial class Sponsor : Page
    {
        Core.user3Entities context;
        Core.Sponsor sponsor;
        int money;
        public Sponsor()
        {
            context = new Core.user3Entities();
            sponsor = new Core.Sponsor();
            InitializeComponent();
            money = 50;

            MoneyTextBox.Text = money.ToString();
            MoneyScreenTextBlock.Text = String.Format("${0}", money);

            RunnerComboBox.ItemsSource = context.Runner.ToList();
            RunnerComboBox.SelectedValuePath = "RunnerId";
            RunnerComboBox.DisplayMemberPath = "RunnerFIO";

            CharityComboBox.ItemsSource = context.Charity.ToList();
            CharityComboBox.SelectedValuePath = "CharityId";
            CharityComboBox.DisplayMemberPath = "CharityName";

            AboutCharityBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Кнопка заплатить
        /// Происходит сохранение занесённых данных в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                sponsor.CharityId = Convert.ToInt32(CharityComboBox.SelectedValue);
                sponsor.RunnerId = Convert.ToInt32(RunnerComboBox.SelectedValue);
                sponsor.Name = NameTextBox.Text;
                sponsor.CardName = CardNameTextBox.Text;
                sponsor.CardMonth = Convert.ToInt32(CardMonthTextBox.Text);
                sponsor.CardYear = Convert.ToInt32(CardYearTextBox.Text);
                sponsor.CVCCode = Convert.ToInt32(CVCCodeTextBox.Text);
                sponsor.Amount = Convert.ToInt32(MoneyTextBox.Text);

                context.Sponsor.Add(sponsor);
                context.SaveChanges();

                this.NavigationService.Navigate(new ThankPage(Convert.ToInt32(RunnerComboBox.SelectedValue), Convert.ToInt32(CharityComboBox.SelectedValue), money));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Кнопка для увеличения значения пожертвования на 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            money++;
            MoneyTextBox.Text = money.ToString();
        }

        /// <summary>
        /// Кнопка для уменьшения значения пожертвования на 1 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (money > 1)
            {
                money--;
                MoneyTextBox.Text = money.ToString();
            }
        }

        /// <summary>
        /// Изменение отображаемой суммы пожертвования в зависимости от введённого значения пожертвования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoneyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                money = Convert.ToInt32(MoneyTextBox.Text);
                MoneyScreenTextBlock.Text = String.Format("${0}", money);
            }
            catch
            {
                MessageBox.Show("Было введено недопустимое значение");
                money = 50;
                MoneyTextBox.Text = money.ToString();
            }
        }

        /// <summary>
        /// Кнопка для отображения информации о бляготворительной организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharityAbout_Click(object sender, RoutedEventArgs e)
        {
            if (CharityComboBox.SelectedValue != null)
            {
                int selectedCharity = Convert.ToInt32(CharityComboBox.SelectedValue);
                AboutCharityBorder.Visibility = Visibility.Visible;
                CharityNameLabel.Content = context.Charity.Where(x => x.CharityId == selectedCharity).First().CharityName;
                CharityDescriptionTextBlock.Text = context.Charity.Where(x => x.CharityId == selectedCharity).First().CharityDescription;

                MemoryStream ms = new MemoryStream(context.Charity.Where(x => x.CharityId == selectedCharity).First().Logo);
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.EndInit();

                CharityLogoImage.Source = image;
            }
        }

        /// <summary>
        /// Нажатие на крестик для закрытия всплывающего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cross_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AboutCharityBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Нажатие на кнопку отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
