using Agriculture_BussinessObjects.Models;
using Agriculture_Services;
using Ass01Solution_SE1705_NguyenHoangPhuc_SE173197.StaffManagement;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for StaffAgricultureManagement.xaml
    /// </summary>
    public partial class StaffAgricultureManagement : Window
    {
        private IAgricultureProductService _agricultureProductService;
        private IAgricultureCategoryService _agricultureCategoryService;
        public StaffAgricultureManagement()
        {
            InitializeComponent();
            _agricultureProductService = new AgricultureProductService();
            _agricultureCategoryService = new AgricultureCategoryService();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadInitData();
        }


        private void LoadInitData()
        {
            this.dgAgricultureProduct.ItemsSource = _agricultureProductService.GetAgricultureProducts();
            this.cbAgricultureCategory.ItemsSource = _agricultureCategoryService.GetAllAgricultureCategories();
            this.cbAgricultureCategory.DisplayMemberPath = "CategoryName";
            this.cbAgricultureCategory.SelectedValuePath = "CategoryId";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
           CreateAgricultureProduct createAgricultureProduct = new CreateAgricultureProduct();
            createAgricultureProduct.AgricultureCreated += LoadInitData;
            createAgricultureProduct.ShowDialog();
        }

        private void dgAgricultureProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            AgricultureProduct agricultureProductService = _agricultureProductService.GetAgricultureProduct(id);
            txtAgricultureId.Text = agricultureProductService.ProductId.ToString();
            txtAgricultureName.Text = agricultureProductService?.ProductName?.ToString();
            txtAgriculturePrice.Text = agricultureProductService?.Price.ToString();
            txtAgricultureQuantity.Text = agricultureProductService?.StockQuantity.ToString();
            txtDescription.Text = agricultureProductService?.Description?.ToString() ?? string.Empty;
            img_AgricultureProduct.Source = new BitmapImage(new Uri(agricultureProductService.Thumbnail, UriKind.RelativeOrAbsolute));
            cbAgricultureCategory.SelectedValue = agricultureProductService?.CategoryId;
        }

        private void btnUpdate1_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAgricultureId.Text))
            {
                MessageBox.Show("Agriculture ID cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; 
            }

            int productId = int.Parse(txtAgricultureId.Text);
            AgricultureProduct agricultureProduct = new AgricultureProduct
            {
                ProductId = productId,
                ProductName = txtAgricultureName.Text
            };

            if (decimal.TryParse(txtAgriculturePrice.Text, out decimal price))
            {
                agricultureProduct.Price = price;
            }

            agricultureProduct.Description = txtDescription.Text;
            agricultureProduct.StockQuantity = int.Parse(txtAgricultureQuantity.Text);

            if (img_AgricultureProduct.Source is BitmapImage bitmapImage)
            {
                agricultureProduct.Thumbnail = bitmapImage.UriSource.ToString();
            }

            if (cbAgricultureCategory.SelectedValue != null)
            {
                agricultureProduct.CategoryId = int.Parse(cbAgricultureCategory.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return; 
            }

            if (_agricultureProductService.UpdateAgricultureProduct(agricultureProduct))
            {
                MessageBox.Show("Update Successfully");
                this.LoadInitData();
            }
            else
            {
                MessageBox.Show("Fail to update");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgAgricultureProduct.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
                return;
            }

            DataGridRow row = (DataGridRow)dgAgricultureProduct.ItemContainerGenerator.ContainerFromItem(dgAgricultureProduct.SelectedItem);
            DataGridCell RowColumn = dgAgricultureProduct.Columns[0].GetCellContent(row).Parent as DataGridCell;
            int id = int.Parse(((TextBlock)RowColumn.Content).Text);

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                bool isDeleted = _agricultureProductService.DeleteAgricultureProduct(id);

                if (isDeleted)
                {
                    MessageBox.Show("Sản phẩm đã được xóa thành công.");
                    LoadInitData(); 
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm không thành công. Vui lòng thử lại.");
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
