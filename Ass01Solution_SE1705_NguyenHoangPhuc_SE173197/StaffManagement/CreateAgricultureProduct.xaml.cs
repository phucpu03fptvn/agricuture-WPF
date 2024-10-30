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

namespace Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.StaffManagement
{
    /// <summary>
    /// Interaction logic for CreateAgricultureProduct.xaml
    /// </summary>
    public partial class CreateAgricultureProduct : Window
    {
        private IAgricultureProductService _agricultureProductService;
        private IAgricultureCategoryService _agricultureCategoryService;
        public CreateAgricultureProduct()
        {
            InitializeComponent();
            _agricultureProductService = new AgricultureProductService();
            _agricultureCategoryService = new AgricultureCategoryService();

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            StaffAgricultureManagement staffAgricultureManagement = new StaffAgricultureManagement();
            AgricultureProduct agricultureProduct = new AgricultureProduct();
            agricultureProduct.ProductName = txtAgricultureName.Text;
            if (decimal.TryParse(txtAgriculturePrice.Text, out decimal price))
            {
                agricultureProduct.Price = price;
            }
            agricultureProduct.Description = txtDescription.Text;
            agricultureProduct.StockQuantity = int.Parse(txtAgricultureQuantity.Text);
            agricultureProduct.CategoryId = int.Parse(this.cbAgricultureCategory.SelectedValue.ToString());
            if (img_AgricultureProduct.Source is BitmapImage bitmapImage)
            {
                agricultureProduct.Thumbnail = bitmapImage.UriSource.ToString();
            }
            if (_agricultureProductService.AddAgricultureProduct(agricultureProduct))
            {
                MessageBox.Show("Add Successfully");
                this.Close();
                staffAgricultureManagement.Show();
            }
            else
            {
                MessageBox.Show("Fail to add");
                this.Close();
                staffAgricultureManagement.Show();
            };
        }

        private void BrowseImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select a Product Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                img_AgricultureProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.cbAgricultureCategory.ItemsSource = _agricultureCategoryService.GetAllAgricultureCategories();
            this.cbAgricultureCategory.DisplayMemberPath = "CategoryName";
            this.cbAgricultureCategory.SelectedValuePath = "CategoryId";
        }
    }
}
