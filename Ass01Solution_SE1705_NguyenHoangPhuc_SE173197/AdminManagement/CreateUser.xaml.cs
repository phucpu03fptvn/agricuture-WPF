using Agriculture_BussinessObjects.Models;
using Agriculture_Services;
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
using System.Windows.Shapes;

namespace Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.AdminManagement
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private IUserService _userService;
        private IUserRoleService _roleService;
        public CreateUser()
        {
            InitializeComponent();
            _userService = new UserService();
            _roleService = new UserRoleService();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            int roleId = int.Parse(cbRole.SelectedValue.ToString());
            DateTime dateOfBirth = DateTime.Parse(dpBirthday.Text);

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Tất cả các trường đều phải được điền.");
                return;
            }

            User newUser = new User
            {
                Name = fullName,
                Email = email,
                Password = password,
                Address = address,
                PhoneNumber = phoneNumber,
                RoleId = roleId,
                DateOfBirth = dateOfBirth
            };

            bool isSuccess = _userService.AddUser(newUser);

            if (isSuccess)
            {
                MessageBox.Show("Người dùng đã được tạo thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình tạo người dùng.");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbRole.ItemsSource = _roleService.GetAllUserRoles();
            this.cbRole.DisplayMemberPath = "RoleName";
            this.cbRole.SelectedValuePath = "RoleId";
        }
    }
}
