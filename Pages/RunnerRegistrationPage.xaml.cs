using System;
using Microsoft.Win32;
using MaraphonSkills.Core;
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
using System.IO;
using MarathonLibrary;

namespace MaraphonSkills.Pages
{
    /// <summary>
    /// Логика взаимодействия для RunnerRegistrationPage.xaml
    /// </summary>
    public partial class RunnerRegistrationPage : Page
    {
        byte[] imageByte;
        user3Entities context;
        public RunnerRegistrationPage()
        {
            
            context = new user3Entities();
            InitializeComponent();

            SetBorders();

            // Задние значений для CountryComboBox
            CountryComboBox.ItemsSource = context.Country.ToList();
            CountryComboBox.SelectedValuePath = "CountryCode";
            CountryComboBox.DisplayMemberPath = "CountryName";

            // Задание значений для GenderComboBox
            GenderComboBox.ItemsSource = context.Gender.ToList();
            GenderComboBox.SelectedValuePath = "Gender1";
            GenderComboBox.DisplayMemberPath = "Gender1";


        }

        /// <summary>
        /// Действия при нажатии на кнопку Подробнее 
        /// для выбора изображения пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.Title = "Выберите фотографию";
            openImage.Filter = "PNG file(*.png)|*.png|JPEG file(*.jpeg)|*.jpeg|JPG file(*.jpg)|*.jpg";

            if (openImage.ShowDialog() == true)
            {
                imageByte = File.ReadAllBytes(openImage.FileName);

                if(imageByte.Length / 1024 / 1024 > 2)
                {
                    MessageBox.Show("Выбранное изображение слишком большое");
                }
                else
                {
                    ProfilePicture.Source = new BitmapImage(new Uri(openImage.FileName));
                    PhotoPathTextBox.Text = openImage.FileName;


                }
            }
        }

        /// <summary>
        /// Задание стандартных значений отображения для заполняемых полей
        /// </summary>
        void SetBorders()
        {
            EmailTextBox.BorderThickness = new Thickness(1);
            EmailTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(1);
            FirstNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(1);
            LastNameTextBox.BorderBrush = Brushes.Black;
            PasswordTextBox.BorderThickness = new Thickness(1);
            PasswordTextBox.BorderBrush = Brushes.Black;
            PasswordRepeatTextBox.BorderThickness = new Thickness(1);
            PasswordRepeatTextBox.BorderBrush = Brushes.Black;

            GenderComboBox.BorderThickness = new Thickness(1);
            GenderComboBox.BorderBrush = Brushes.Black;
            CountryComboBox.BorderThickness = new Thickness(1);
            CountryComboBox.BorderBrush = Brushes.Black;
            
            DateOfBirthDatePicker.BorderThickness = new Thickness(1);
            DateOfBirthDatePicker.BorderBrush = Brushes.Black;


        }

        /// <summary>
        /// Действия при нажатии на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetBorders();

            StringCheck stringCheck = new StringCheck();
            string errorMessage = null;
            List<string> errorsList = new List<string>();
            if (String.IsNullOrEmpty(EmailTextBox.Text) || String.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                errorsList.Add("Email");
                EmailTextBox.BorderThickness = new Thickness(3);
                EmailTextBox.BorderBrush = Brushes.Red;

            }
            else
            {
                if (stringCheck.EmailCheck(EmailTextBox.Text) == false)
                {
                    errorsList.Add("Email введён неверно");
                    EmailTextBox.BorderThickness = new Thickness(3);
                    EmailTextBox.BorderBrush = Brushes.Red;
                }
            }

            if (String.IsNullOrEmpty(PasswordTextBox.Password)||String.IsNullOrWhiteSpace(PasswordTextBox.Password))
            {
                errorsList.Add("Пароль");
                PasswordTextBox.BorderThickness = new Thickness(3);
                PasswordTextBox.BorderBrush = Brushes.Red;
            }

            if (String.IsNullOrEmpty(PasswordRepeatTextBox.Password) || String.IsNullOrWhiteSpace(PasswordRepeatTextBox.Password))
            {
                errorsList.Add("Повторите пароль");
                PasswordRepeatTextBox.BorderThickness = new Thickness(3);
                PasswordRepeatTextBox.BorderBrush = Brushes.Red;
            }

            if (GenderComboBox.SelectedValue==null)
            {
                errorsList.Add("Пол");
                GenderComboBox.BorderThickness = new Thickness(3);
                GenderComboBox.BorderBrush = Brushes.Red;
            }

            if (CountryComboBox.SelectedValue==null)
            {
                errorsList.Add("Страна");
                CountryComboBox.BorderThickness = new Thickness(3);
                CountryComboBox.BorderBrush = Brushes.Red;
            }

            if (DateOfBirthDatePicker.SelectedDate==null)
            {
                errorsList.Add("Дата рождения");
                DateOfBirthDatePicker.BorderThickness = new Thickness(3);
                DateOfBirthDatePicker.BorderBrush = Brushes.Red;
            }
            
            if (String.IsNullOrEmpty(FirstNameTextBox.Text) || String.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                errorsList.Add("Имя");
                FirstNameTextBox.BorderThickness = new Thickness(3);
                FirstNameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
            }
            
            if (String.IsNullOrEmpty(LastNameTextBox.Text) || String.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                errorsList.Add("Фамилия");
                LastNameTextBox.BorderThickness = new Thickness(3);
                LastNameTextBox.BorderBrush = Brushes.Red;
            }

            if (PasswordTextBox.Password != PasswordRepeatTextBox.Password)
            {
                errorMessage = "Пароли не совпадают\n";
                PasswordTextBox.BorderThickness = new Thickness(3);
                PasswordTextBox.BorderBrush = Brushes.Red;
                PasswordRepeatTextBox.BorderThickness = new Thickness(3);
                PasswordRepeatTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                if (stringCheck.PasswordCheck(PasswordTextBox.Password)==false)
                {
                    errorMessage = "Пароль введён неправильно";
                    PasswordTextBox.BorderThickness = new Thickness(3);
                    PasswordTextBox.BorderBrush = Brushes.Red;
                    PasswordRepeatTextBox.BorderThickness = new Thickness(3);
                    PasswordRepeatTextBox.BorderBrush = Brushes.Red;
                }
            }

            if(errorsList.Count>0)
                errorMessage += "Пропущены обязательные к заполнению поля:\n";

            if (errorsList.Count > 0 || PasswordTextBox.Password != PasswordRepeatTextBox.Password)
            {
                string errorsString = String.Join(", ", errorsList);
                ErrorsTextBlock.Text = errorMessage + errorsString;
                ErrorsTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                try
                {
                    int newUser = context.User.Where(x => x.Email == EmailTextBox.Text).Count();
                    if (newUser == 0)
                    {
                        SaveRunnerData();

                        MessageBox.Show("Регистрация прошла успешно");
                        Properties.Settings.Default.currentUserEmail = EmailTextBox.Text;
                        this.NavigationService.Navigate(new RunnerMenuPage());
                    }
                    else
            {
                throw new Exception("Пользователь с таким Email уже существует");
            }
        }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
}
        }

        private void SaveRunnerData()
        {
            Runner runner = new Runner();
            User user = new User();

            user.Email = EmailTextBox.Text;
            user.Password = PasswordTextBox.Password;
            user.FirstName = FirstNameTextBox.Text;
            user.LastName = LastNameTextBox.Text;
            user.RoleId = 1;

            runner.Email = EmailTextBox.Text;
            runner.Gender = GenderComboBox.SelectedValue.ToString();
            runner.DateOfBirth = DateOfBirthDatePicker.SelectedDate.Value;
            runner.CountryCode = CountryComboBox.SelectedValue.ToString();
            runner.Img = imageByte;

            context.User.Add(user);
            context.Runner.Add(runner);

            context.SaveChanges();
        }

        /// <summary>
        /// Нажатие на кнопку выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
