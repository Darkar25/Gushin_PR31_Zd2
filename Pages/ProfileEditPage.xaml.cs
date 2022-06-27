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
    /// Логика взаимодействия для ProfileEditPage.xaml
    /// </summary>
    public partial class ProfileEditPage : Page
    {
        Core.user3Entities context;
        Core.Runner currentRunner;
        Core.User currentUser;
        public ProfileEditPage()
        {


            context = new Core.user3Entities();
            InitializeComponent();

            EmailTextBox.Text = Properties.Settings.Default.currentUserEmail.ToString();

            currentRunner = context.Runner.Where(x => x.Email == EmailTextBox.Text).First();
            currentUser = context.User.Where(x=>x.Email == EmailTextBox.Text).First();

            FirstNameTextBox.Text = currentUser.FirstName.ToString();
            LastNameTextBox.Text = currentUser.LastName.ToString();

            GenderComboBox.ItemsSource = context.Gender.ToList();
            GenderComboBox.SelectedValuePath = "Gender1";
            GenderComboBox.DisplayMemberPath = "Gender1";
            GenderComboBox.SelectedValue = currentRunner.Gender;

            CountryComboBox.ItemsSource = context.Country.ToList();
            CountryComboBox.SelectedValuePath = "CountryCode";
            CountryComboBox.DisplayMemberPath = "CountryName";
            CountryComboBox.SelectedValue = currentRunner.CountryCode;

            DateOfBirthDatePicker.SelectedDate = currentRunner.DateOfBirth;

            MemoryStream ms = new MemoryStream(currentRunner.RunnerPicture);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.EndInit();
            RunnerImage.Source = image;
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

            if (openImage.ShowDialog()==true)
            {
                byte[] imageByte = File.ReadAllBytes(openImage.FileName);
                if (imageByte.Length / 1024 / 1024 > 2)
                {
                    MessageBox.Show("Выбранное изображение слишком большое");
                }
                else
                {
                    RunnerImage.Source = new BitmapImage(new Uri(openImage.FileName));
                    PhotoPathTextBox.Text = openImage.FileName;
                    currentRunner.Img = imageByte;
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
            try
            {
                if (!String.IsNullOrWhiteSpace(PasswordTextBox.Password))
                {
                    if (PasswordTextBox.Password == PasswordRepeatTextBox.Password)
                    {
                        currentUser.Password = PasswordTextBox.Password;
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают\nПароль не изменён");
                    }
                }

                currentUser.FirstName = FirstNameTextBox.Text;
                currentUser.LastName = LastNameTextBox.Text;
                currentRunner.Gender = GenderComboBox.SelectedValue.ToString();
                currentRunner.DateOfBirth = DateOfBirthDatePicker.SelectedDate.Value;

                context.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
