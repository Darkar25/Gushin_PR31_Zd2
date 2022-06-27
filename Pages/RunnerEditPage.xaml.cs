using Microsoft.Win32;
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
    /// Логика взаимодействия для RunnerEditPage.xaml
    /// </summary>
    public partial class RunnerEditPage : Page
    {
        Core.user3Entities context;
        public RunnerEditPage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Нажатие на кнопку выбора изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Filter = "PNG file(*.png)|*.png|JPG file(*.jpg)|*.jpg|JPEG file(*.jpeg)|*.jpeg";
            openImage.Title = "Выберите изображение";

            if (openImage.ShowDialog() == true)
            {
                byte[] imageByte = File.ReadAllBytes(openImage.FileName);
                if (imageByte.Length / 1024 / 1024 > 2)
                {
                    MessageBox.Show("Выбранное изображение слишком большое");
                }
                else
                {
                    RunnerPicture.Source = new BitmapImage(new Uri(openImage.FileName));
                    PhotoPathTextBox.Text = openImage.FileName;
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

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
