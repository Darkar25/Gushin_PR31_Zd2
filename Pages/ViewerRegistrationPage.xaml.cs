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
    /// Логика взаимодействия для ViewerRegistrationPage.xaml
    /// </summary>
    public partial class ViewerRegistrationPage : Page
    {
        Core.user3Entities context;
        public ViewerRegistrationPage()
        {
            context = new Core.user3Entities();
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
        /// Метод задания стандартных значений границ полей
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
        }

        /// <summary>
        /// Нажатие на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SetBorders();
            string errorMessage = null;
            List<string> errorsList = new List<string>();
            if (String.IsNullOrEmpty(EmailTextBox.Text) || String.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                errorsList.Add("Email");
                EmailTextBox.BorderThickness = new Thickness(3);
                EmailTextBox.BorderBrush = Brushes.Red;

            }

            if (String.IsNullOrEmpty(PasswordTextBox.Password) || String.IsNullOrWhiteSpace(PasswordTextBox.Password))
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

            if (GenderComboBox.SelectedValue == null)
            {
                errorsList.Add("Пол");
                GenderComboBox.BorderThickness = new Thickness(3);
                GenderComboBox.BorderBrush = Brushes.Red;
            }

            if (CountryComboBox.SelectedValue == null)
            {
                errorsList.Add("Страна");
                CountryComboBox.BorderThickness = new Thickness(3);
                CountryComboBox.BorderBrush = Brushes.Red;
            }


            if (String.IsNullOrEmpty(FirstNameTextBox.Text) || String.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                errorsList.Add("Имя");
                FirstNameTextBox.BorderThickness = new Thickness(3);
                FirstNameTextBox.BorderBrush = Brushes.Red;
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

            if (errorsList.Count > 0)
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
                        Core.Volunteer volunteer = new Core.Volunteer();
                        Core.User user = new Core.User();

                        user.Email = EmailTextBox.Text;
                        user.Password = PasswordTextBox.Password;
                        user.FirstName = FirstNameTextBox.Text;
                        user.LastName = LastNameTextBox.Text;
                        user.RoleId = 3;

                        volunteer.FirstName = FirstNameTextBox.Text;
                        volunteer.LastName = LastNameTextBox.Text;
                        volunteer.Email = EmailTextBox.Text;
                        volunteer.Gender = GenderComboBox.SelectedValue.ToString();
                        volunteer.CountryCode = CountryComboBox.SelectedValue.ToString();

                        context.User.Add(user);
                        context.Volunteer.Add(volunteer);

                        context.SaveChanges();
                        Properties.Settings.Default.currentUserEmail = EmailTextBox.Text;
                        this.NavigationService.Navigate(new ViewerMenuPage());

                        

                        MessageBox.Show("Регистрация прошла успешно");
                        
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

        private void CancelButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
