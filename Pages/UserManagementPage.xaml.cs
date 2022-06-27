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
    /// Логика взаимодействия для UserManagementPage.xaml
    /// </summary>
    public partial class UserManagementPage : Page
    {
        Core.user3Entities context;
        public UserManagementPage()
        {
            context = new Core.user3Entities();
            InitializeComponent();

            RoleFilterComboBox.ItemsSource = context.Role.ToList();
            RoleFilterComboBox.DisplayMemberPath = "RoleName";
            RoleFilterComboBox.SelectedValuePath = "RoleId";

            UserCountTextBlock.Text =String.Format("Количество пользователей: {0}",context.User.Count().ToString());

            UsersDataGrid.ItemsSource = context.User.ToList();
        }

        /// <summary>
        /// Кнопка редактирования информации о пользователе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border editButton = sender as Border;
            Core.User currentUser = editButton.DataContext as Core.User;
            this.NavigationService.Navigate(new AddNewUserPage(context, currentUser, false));
        }

        /// <summary>
        /// Кнопка добавления нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewUserButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Core.User newUser = new Core.User();
            context.User.Add(newUser);
            this.NavigationService.Navigate(new AddNewUserPage(context, newUser, true));
        }

        /// <summary>
        /// Кнопка обновления по заданным фильтрам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<Core.User> currentDataGridContext = context.User.ToList();
            if(RoleFilterComboBox.SelectedValue != null)
            {
                currentDataGridContext = currentDataGridContext.Where(x => x.RoleId == Convert.ToInt32(RoleFilterComboBox.SelectedValue)).ToList();
            }

            if(SortComboBox.SelectedValue != null)
            {
                //currentDataGridContext = currentDataGridContext.OrderBy( SortComboBox.SelectedValue);
            }

            if (!String.IsNullOrEmpty(SearchTextBox.Text) || !String.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                currentDataGridContext = currentDataGridContext.Where(x => x.FirstName.ToLower().Contains(SearchTextBox.Text.ToLower())||x.LastName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }
            UserCountTextBlock.Text = String.Format("Количество пользователей: {0}", currentDataGridContext.Count().ToString());
            UsersDataGrid.ItemsSource = currentDataGridContext;
        }
    }
}
