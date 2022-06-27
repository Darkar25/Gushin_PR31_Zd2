using System;
using System.Windows.Forms.DataVisualization.Charting;
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
    /// Логика взаимодействия для AddReviewPage.xaml
    /// </summary>
    public partial class AddReviewPage : Page
    {
        Core.Review currentReview;
        Core.user3Entities context;
        public AddReviewPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            SetBorders();

            MarathonComboBox.ItemsSource = context.user3.ToList();
            MarathonComboBox.DisplayMemberPath = "MarathonName";
            MarathonComboBox.SelectedValuePath = "MarathonId";
        }

        /// <summary>
        /// Метод для задания стандартных значений для MarathonComboBox и CommentTextBox
        /// </summary>
        void SetBorders()
        {
            MarathonComboBox.BorderThickness = new Thickness(1);
            MarathonComboBox.BorderBrush = Brushes.Black;

            CommentTextBox.BorderThickness = new Thickness(1);
            CommentTextBox.BorderBrush = Brushes.Black;
        }

        /// <summary>
        /// Нажатие на кнопку отправки отзыва
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentReview = new Core.Review();
            SetBorders();
            ErrorTextBlock.Text = String.Empty;
            currentReview.VolunteerId = context.Volunteer.Where(x => x.Email == Properties.Settings.Default.currentUserEmail).First().VolunteerId;
            Console.WriteLine(context.Volunteer.Where(x => x.Email == Properties.Settings.Default.currentUserEmail).First().VolunteerId);
            List<string> errorsList = new List<string>();
            // Проверка выбранной оценки
            if (Mark1RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 1;
            }
            else if (Mark2RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 2;
            }
            else if (Mark3RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 3;
            }
            else if (Mark4RadioButton.IsChecked == true)
            {
                currentReview.ReviewMark = 4;
            }
            else
            {
                currentReview.ReviewMark = 5;
            }
            if (MarathonComboBox.SelectedValue != null)
            {
                currentReview.MarathonId = Convert.ToInt32(MarathonComboBox.SelectedValue);
            }
            else
            {
                MarathonComboBox.BorderThickness = new Thickness(3);
                MarathonComboBox.BorderBrush = Brushes.Red;
                errorsList.Add("Не выбран марафон\n");
            }
            if (String.IsNullOrEmpty(CommentTextBox.Text) || String.IsNullOrWhiteSpace(CommentTextBox.Text))
            {
                CommentTextBox.BorderThickness = new Thickness(3);
                CommentTextBox.BorderBrush = Brushes.Red;

                errorsList.Add("Комментарий не заполнен\n");
            }

            if (errorsList.Count > 0)
            {
                foreach (string error in errorsList)
                {
                    ErrorTextBlock.Text += error;
                }
            }
            else
            {
                currentReview.ReviewDateTime = DateTime.Now;

                currentReview.ReviewDescription = CommentTextBox.Text;

                context.Review.Add(currentReview);
                context.SaveChanges();

                MessageBox.Show("Спасибо\nВаше мнение очень важно для нас");
                this.NavigationService.GoBack();
            }
        }
    }
}
