using InventoryManagementSystemUI.ApiServices;
using InventoryManagementSystemUI.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InventoryManagementSystemUI
{
    public partial class frmAddEditProduct : Form
    {
        private readonly ProductService productService;
        private int productId;
        private ProductForm productListForm;
        /// <summary>
        /// Constructor for New Product Form
        /// </summary>
        /// <param name="productId"></param>
        public frmAddEditProduct(int prdId, ProductForm productListPage)
        {
            productService = new ProductService();
            productId = prdId;
            productListForm = productListPage;
            InitializeComponent();
            if (productId > 0)
            {
                var result = GetProductById(productId);
                btnProductUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnSave.Visible = true;
                btnProductUpdate.Visible = false;
            }
        }
        /// <summary>
        /// To Save the product detials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
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
                else if (txtPrice.Text == "" || txtPrice.Text == "0")
                {
                    MessageBox.Show($"Error: Please enter the valid price!");
                }
                else
                {
                    var result = AddNewProductAsync();
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
        public async Task AddNewProductAsync()
        {
            try
            {
                ProductRequest productRequest = new ProductRequest();
                productRequest.ProductName = txtProductName.Text;
                productRequest.Quantity = Convert.ToInt32(txtQuantity.Text);
                productRequest.Price = Convert.ToDecimal(txtPrice.Text);
                productRequest.CreatedBy = "Sanjay Nigam";
                var result = await productService.CreateProductAsync(productRequest);
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
        /// <summary>
        /// To Update the product detials
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProductUpdate_Click(object sender, EventArgs e)
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
                else if (txtPrice.Text == "" || txtPrice.Text == "0")
                {
                    MessageBox.Show($"Error: Please enter the valid price!");
                }
                else
                {
                    var result = UpdateProductAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Used for Calling the Update API method from product service
        /// </summary>
        /// <returns></returns>
        public async Task UpdateProductAsync()
        {
            try
            {
                ProductRequest productRequest = new ProductRequest();
                productRequest.ProductId = productId; // need to pass the product Id dynamically
                productRequest.ProductName = txtProductName.Text;
                productRequest.Quantity = Convert.ToInt32(txtQuantity.Text);
                productRequest.Price = Convert.ToDecimal(txtPrice.Text);
                productRequest.CreatedBy = "Sanjay Nigam";
                var result = await productService.UpdateProductAsync(productRequest);
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
                    txtPrice.Text = response.data.price.ToString();
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
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, control keys (e.g., Backspace), and a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Reject the input
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, control keys (e.g., Backspace), and a single decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Reject the input
            }
        }
    }
}
