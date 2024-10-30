using Agriculture_BussinessObjects.Models;
using Agriculture_Services;
using Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.UserManagement;
using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ass01Solution_SE1705_NguyenHoangPhuc_SE173197
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUserService userService;
        public MainWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            User userAccount = userService.GetUser(txtEmail.Text);
            if (userAccount != null && txtPassword.Password.Equals(userAccount.Password) && userAccount.RoleId == 2)
            {
                UserAgricultureProduct userAgricultureProduct = new UserAgricultureProduct();
                HomePage userHomePage = new HomePage();
                userAgricultureProduct.UserContent.Children.Add(userHomePage);
                userAgricultureProduct.Show();
                this.Close();
            }
            else if (userAccount != null && txtPassword.Password.Equals(userAccount.Password) && userAccount.RoleId == 3)
            {

                StaffAgricultureManagement staffAgricultureManagement = new StaffAgricultureManagement();
                staffAgricultureManagement.ShowDialog();
            } else if (userAccount != null && txtPassword.Password.Equals(userAccount.Password) && userAccount.RoleId == 1)
            {
                AdminAgricultureManagement adminAgricultureManagement = new AdminAgricultureManagement();
                adminAgricultureManagement.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login fail!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}