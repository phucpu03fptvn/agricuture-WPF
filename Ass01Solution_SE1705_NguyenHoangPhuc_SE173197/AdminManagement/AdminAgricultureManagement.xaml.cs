using Agriculture_BussinessObjects.Models;
using Agriculture_Services;
using Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.AdminManagement;
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

namespace Ass01Solution_SE1705_NguyenHoangPhuc_SE173197
{
    /// <summary>
    /// Interaction logic for AdminAgricultureManagement.xaml
    /// </summary>
    public partial class AdminAgricultureManagement : Window
    {
        private IUserService _userService;
        private IUserRoleService _roleService;
        public AdminAgricultureManagement()
        {
            InitializeComponent();
            _userService = new UserService();
            _roleService = new UserRoleService();
        }


        private void LoadInitData()
        {
            this.dgUser.ItemsSource = _userService.GetAllUsers();
            this.cbRole.ItemsSource = _roleService.GetAllUserRoles();
            this.cbRole.DisplayMemberPath = "RoleName";
            this.cbRole.SelectedValuePath = "RoleId";
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            if (dataGrid.SelectedItem == null)
                return;

            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromItem(dataGrid.SelectedItem);
            if (row == null)
                return;

            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
            if (RowColumn == null)
                return;

            int id = int.Parse(((TextBlock)RowColumn.Content).Text);
            User user = _userService.GetUser(id);
            txtAddress.Text = user.Address.ToString();
            txtEmail.Text = user.Email.ToString();
            txtFullName.Text = user.Name.ToString();
            txtUserId.Text = user.UserId.ToString();
            txtPhone.Text = user.PhoneNumber.ToString();
            cbRole.SelectedValue = user.RoleId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadInitData();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int userId = int.Parse(txtUserId.Text);
            User updatedUser = new User
            {
                UserId = userId,
                Name = txtFullName.Text,
                Email = txtEmail.Text,
                Address = txtAddress.Text,
                RoleId = (int)cbRole.SelectedValue,
            };

            bool isUpdated = _userService.UpdateUser(updatedUser);

            if (isUpdated)
            {
                MessageBox.Show("Cập nhật người dùng thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật người dùng thất bại!");
            }

            this.LoadInitData();
        }

        private void btnCreate_Click_1(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.Show();
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            if (dgUser.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một người dùng để xóa.");
                return;
            }

            DataGridRow row = (DataGridRow)dgUser.ItemContainerGenerator.ContainerFromItem(dgUser.SelectedItem);
            DataGridCell RowColumn = dgUser.Columns[0].GetCellContent(row).Parent as DataGridCell;
            int id = int.Parse(((TextBlock)RowColumn.Content).Text);

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                bool isSuccess = _userService.DeleteUser(id);

                if (isSuccess)
                {
                    MessageBox.Show("Người dùng đã được xóa thành công.");
                    dgUser.ItemsSource = _userService.GetAllUsers();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xóa người dùng.");
                }
            }
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
