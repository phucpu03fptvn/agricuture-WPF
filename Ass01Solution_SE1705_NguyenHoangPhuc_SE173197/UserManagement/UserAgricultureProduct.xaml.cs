using Agriculture_Services;
using Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.UserManagement;
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
    /// Interaction logic for UserAgricultureProduct.xaml
    /// </summary>
    public partial class UserAgricultureProduct : Window
    {
        private IAgricultureProductService _agricultureProductService;
        public UserAgricultureProduct()
        {
            InitializeComponent();
            _agricultureProductService = new AgricultureProductService();
        }
        private void LoadUserControl(UserControl userControl)
        {
            UserContent.Children.Clear(); 
            UserContent.Children.Add(userControl); 
        }
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new HomePage());   
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new ProductPageControl(_agricultureProductService));
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new UserContactControl());
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            LoadUserControl(new UserAboutControl());
        }
    }
}
