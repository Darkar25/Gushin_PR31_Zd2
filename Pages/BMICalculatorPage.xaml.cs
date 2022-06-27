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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для BMICalculatorPage.xaml
    /// </summary>
    public partial class BMICalculatorPage : Page
    {
        // Переменная со значением выбранного пола (true - мужской/false - женский). По умолчанию выбран мужской пол.
        bool gender;
        public BMICalculatorPage()
        {
            gender = true;

            InitializeComponent();
            ActivityBorder.Visibility = Visibility.Collapsed;
            BMISlider.Minimum = 10;
            BMISlider.Maximum = 50;
            BMISlider.BorderThickness = new Thickness(0);
            PeoplePicture.Source = new BitmapImage(new Uri("../Resources/men.png", UriKind.Relative));


        }

        /// <summary>
        /// Кнопка отмены переводит пользователя на предыдущую страницу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Кнокпка вычисления значения BMI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!String.IsNullOrEmpty(HeightTextBox.Text) && !String.IsNullOrWhiteSpace(HeightTextBox.Text) && !String.IsNullOrEmpty(WeightTextBox.Text) && !String.IsNullOrWhiteSpace(WeightTextBox.Text))
            {
                try
                {
                    double bmiValue = Convert.ToDouble(WeightTextBox.Text) / ((Convert.ToDouble(HeightTextBox.Text) / 100) * (Convert.ToDouble(HeightTextBox.Text) / 100));
                    Console.WriteLine(bmiValue);
                    var lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\", "\\Resources\\BMI.csv"));
                    string[][] normsList = new string[lines.Length][];
                    for (int i = 0; i < normsList.Length; i++) normsList[i] = lines[i].Split(';');
                    int ageNumber = GetAgeNumber();
                    if (bmiValue < Convert.ToDouble(normsList[ageNumber][0]))
                    {
                        StatusTextBlock.Text = "Недостаточный";
                    }
                    else if (bmiValue >= Convert.ToDouble(normsList[ageNumber][0]) && bmiValue < Convert.ToDouble(normsList[ageNumber][1]))
                    {
                        StatusTextBlock.Text = "Здоровый";
                    }
                    else if (bmiValue >= Convert.ToDouble(normsList[ageNumber][1]) && bmiValue < Convert.ToDouble(normsList[ageNumber][2]))
                    {
                        StatusTextBlock.Text = "Избыточный";
                    }
                    else
                    {
                        StatusTextBlock.Text = "Ожирение";
                    }

                    BMISlider.Value = Convert.ToInt32(bmiValue);
                    DiagramStackPanel.Visibility = Visibility.Visible;

                    double bmrValue;
                    if (gender)
                    {
                        bmrValue = 66.47 + (6.24 * Convert.ToInt32(WeightTextBox.Text)) + (12.7 * Convert.ToInt32(HeightTextBox.Text) - (6.755 * Convert.ToInt32(AgeTextBox.Text)));
                    }
                    else
                    {
                        bmrValue = 655.1 + (4.35 * Convert.ToInt32(WeightTextBox.Text)) + (4.7 * Convert.ToInt32(HeightTextBox.Text) - (4.7 * Convert.ToInt32(AgeTextBox.Text)));
                    }
                    BMRValueLabel.Content = Convert.ToInt32(bmrValue);
                    SitCaloryTextBlock.Text = String.Format("Сидячий: {0}", Convert.ToInt32(bmrValue * 1.2));
                    LowCaloryTextBlock.Text = String.Format("Маленькая активность: {0}", Convert.ToInt32(bmrValue * 1.38));
                    AverageCaloryTextBlock.Text = String.Format("Средняя активность: {0}", Convert.ToInt32(bmrValue * 1.56));
                    HighCaloryTextBlock.Text = String.Format("Сильная активность: {0}", Convert.ToInt32(bmrValue * 1.73));
                    MaxCaloryTextBlock.Text = String.Format("Максимальная активность: {0}", Convert.ToInt32(bmrValue * 1.95));



                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }

        /// <summary>
        /// Получение номера строки для выбора норм BMI
        /// </summary>
        /// <returns></returns>
        private int GetAgeNumber()
        {
            int ageNumber;
            if (Convert.ToInt32(AgeTextBox.Text) >= 20 && Convert.ToInt32(AgeTextBox.Text) < 30)
            {
                ageNumber = 1;
            }
            else if (Convert.ToInt32(AgeTextBox.Text) >= 30 && Convert.ToInt32(AgeTextBox.Text) < 40)
            {
                ageNumber = 2;
            }
            else if (Convert.ToInt32(AgeTextBox.Text) >= 40 && Convert.ToInt32(AgeTextBox.Text) < 50)
            {
                ageNumber = 3;
            }
            else if (Convert.ToInt32(AgeTextBox.Text) >= 50 && Convert.ToInt32(AgeTextBox.Text) < 60)
            {
                ageNumber = 4;
            }
            else if (Convert.ToInt32(AgeTextBox.Text) >= 60 && Convert.ToInt32(AgeTextBox.Text) < 70)
            {
                ageNumber = 5;
            }
            else if (Convert.ToInt32(AgeTextBox.Text) >= 70 && Convert.ToInt32(AgeTextBox.Text) < 80)
            {
                ageNumber = 6;
            }
            else if (Convert.ToInt32(AgeTextBox.Text) >= 80)
            {
                ageNumber = 7;
            }
            else
            {
                ageNumber = 0;
            }
            if (!gender)
            {
                ageNumber += 9;
            }

            return ageNumber;
        }

        /// <summary>
        /// Выбор мужского пола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManButton_Click(object sender, RoutedEventArgs e)
        {
            gender = true;
            PeoplePicture.Source = new BitmapImage(new Uri("../Resources/men.png", UriKind.Relative));
            WomanButton.Opacity = 0.5;
            ManButton.Opacity = 1;
        }

        /// <summary>
        /// Выбор женского пола
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WomanButton_Click(object sender, RoutedEventArgs e)
        {
            gender = false;
            PeoplePicture.Source = new BitmapImage(new Uri("../Resources/mowan.png", UriKind.Relative));
            WomanButton.Opacity = 1;
            ManButton.Opacity = 0.5;
        }

        /// <summary>
        /// Крестик для закрытия всплывающего окна 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrossImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ActivityBorder.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Кнопка для открытия всплывающего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            ActivityBorder.Visibility = Visibility.Visible;
        }
    }
}
