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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.UserManagement
{
    /// <summary>
    /// Interaction logic for ProductPageControl.xaml
    /// </summary>
    public partial class ProductPageControl : UserControl
    {
        private readonly IAgricultureProductService _Services;
        public ProductPageControl(IAgricultureProductService agricultureProductService)
        {
            InitializeComponent();
            _Services = agricultureProductService;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var input = txtSearchBox.Text.ToLower();
            if (input != null) {
              this.dgAgricultureProduct.ItemsSource = _Services.GetAgricultureProducts().Where(product => product.ProductName.ToLower().Contains(input.ToLower())).ToList();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgAgricultureProduct.ItemsSource = _Services.GetAgricultureProducts();
        }
    }
}
