using InventoryManagementSystemUI.ApiServices;
using InventoryManagementSystemUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemUI
{
    public partial class ProductShipmentAssign : Form
    {
        private readonly ProductService productService;
        private ProductForm productListForm;
        private int shmtProductId;
        public ProductShipmentAssign(int prdId, ProductForm productListPage)
        {
            shmtProductId = prdId;
            productService = new ProductService();
            var result = GetProductById(prdId);
            InitializeComponent();
            productListForm = productListPage;
        }

        /// <summary>
        /// Call the API from product service to get the product details by Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task GetProductById(int productId)
        {
            try
            {
                ProductModel response = new ProductModel();
                response = await productService.GetProductById(productId);
                if (response.status && response.statusCode == 200)
                {
                    txtProductName.Text = response.data.productName;
                    txtQuantity.Text = response.data.quantity.ToString();
                }
                else
                {
                    MessageBox.Show($"Error: {response.responseMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        /// <summary>
        /// Used for Calling the Save API method from product service
        /// </summary>
        /// <returns></returns>
        public async Task ProductAssignToShipmentAsync()
        {
            try
            {
                ShipmentRequest shipmentRequest = new ShipmentRequest();

                shipmentRequest.ProductId = shmtProductId;
                shipmentRequest.Quantity = Convert.ToInt32(txtQuantity.Text);
                shipmentRequest.ShipmentName = txtShipmentName.Text;
                var result = await productService.ProductAssignToShipment(shipmentRequest);
                if (result.statusCode == 200 && result.status)
                {
                    MessageBox.Show($"Success: {result.responseMessage}");
                    // After adding the product, refresh the ProductListPage
                    var productResult = productListForm.LoadAllProductsAsync(false);
                    // Close the new product form
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Error: {result.responseMessage}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnProductAssignToShipment_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text))
                {
                    MessageBox.Show($"Error: Please enter the product name!");
                }
                else if (txtQuantity.Text == "" || txtQuantity.Text == "0")
                {
                    MessageBox.Show($"Error: Please enter the valid quantity!");
                }
                else if (string.IsNullOrEmpty(txtShipmentName.Text))
                {
                    MessageBox.Show($"Error: Please enter the shipment name!");
                }
                else
                {
                    var result = ProductAssignToShipmentAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, control keys (e.g., Backspace), and a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Reject the input
            }
        }
    }
}
