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
    /// Логика взаимодействия для MarathonMapPage.xaml
    /// </summary>
    public partial class MarathonMapPage : Page
    {
        public MarathonMapPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку чекпоинта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button item in InteractiveMapCanvas.Children)
            {
                if(item is Button)
                {
                    item.Background = Brushes.Orange;
                }
            }

            Button currentButton = sender as Button;
            currentButton.Background = Brushes.Red;

            CheckPointInfoBorder.Visibility = Visibility.Visible;
            CheckpointDescription(currentButton);
        }

        /// <summary>
        /// Метод для выбора информации для всплывающего окна чекпоинта
        /// </summary>
        /// <param name="currentButton"></param>
        private void CheckpointDescription(Button currentButton)
        {
            switch (currentButton.Content)
            {
                case "1":
                    CheckpointNameLabel.Content = "Checkpoint 1";
                    CheckpointPerksTextBlock.Text = "Стенд для питья\nЭнергетические батончики\nТуалет\nМедецинский Пункт";
                    break;
                case "2":
                    CheckpointNameLabel.Content = "Checkpoint 2";
                    CheckpointPerksTextBlock.Text = "Энергетические батончики\nТуалет\nМедецинский Пункт";
                    break;
                case "3":
                    CheckpointNameLabel.Content = "Checkpoint 3";
                    CheckpointPerksTextBlock.Text = "Стенд для питья\nТуалет\nМедецинский Пункт";
                    break;
                case "4":
                    CheckpointNameLabel.Content = "Checkpoint 4";
                    CheckpointPerksTextBlock.Text = "Стенд для питья\nЭнергетические батончики\nМедецинский Пункт";
                    break;
                case "5":
                    CheckpointNameLabel.Content = "Checkpoint 5";
                    CheckpointPerksTextBlock.Text = "Стенд для питья\nЭнергетические батончики\nТуалет";
                    break;
                case "6":
                    CheckpointNameLabel.Content = "Checkpoint 6";
                    CheckpointPerksTextBlock.Text = "Стенд для питья\nМедецинский Пункт";
                    break;
            }
        }

        /// <summary>
        /// Нажатие на крестик для закрытия всплывающего окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrossImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckPointInfoBorder.Visibility = Visibility.Collapsed;
        }
    }
}
