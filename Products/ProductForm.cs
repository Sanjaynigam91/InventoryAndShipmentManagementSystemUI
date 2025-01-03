using InventoryManagementSystemUI.ApiServices;
using InventoryManagementSystemUI.Common;
using InventoryManagementSystemUI.Model;
using InventoryManagementSystemUI.Shipments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemUI
{
    public partial class ProductForm : Form
    {
        private readonly ProductService productService;
        private List<ProductResponse> productData;
        /// <summary>
        /// Constructor of Product Form class
        /// </summary>
        public ProductForm(bool isComingFromDelete)
        {
            productService = new ProductService();
            productData = new List<ProductResponse>();
            InitializeComponent();
            var data = LoadAllProductsAsync(isComingFromDelete);

        }
        /// <summary>
        /// Load product details into product data grid 
        /// </summary>
        /// <returns></returns>
        public async Task LoadAllProductsAsync(bool isComingFromDelete)
        {
            try
            {
                if (!isComingFromDelete)
                {
                    productGridView.DataSource = null;
                    productGridView.Columns.Clear();

                }
                var products = await productService.GetProductsAsync();
                productData = products.data;
                if (products.statusCode == 200 && products.status)
                {
                    // Defineing the data Column for data grid
                    DataTable proudctTable = new DataTable();
                    proudctTable.Columns.Add("ProductId", typeof(int));
                    proudctTable.Columns.Add("ProductName", typeof(string));
                    proudctTable.Columns.Add("Quantity", typeof(int));
                    proudctTable.Columns.Add("Price", typeof(decimal));
                    proudctTable.Columns.Add("CreatedDate", typeof(DateTime));
                    proudctTable.Columns.Add("CreatedBy", typeof(string));

                    foreach (var produtItem in products.data)
                    {
                        proudctTable.Rows.Add(produtItem.productId, produtItem.productName, produtItem.quantity, produtItem.price, produtItem.createdDate, produtItem.createdBy);
                    }
                    productGridView.DataSource = proudctTable;
                    AddActionColumns();
                    productGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //Define the HeaderText of Each column
                    productGridView.Columns[0].HeaderText = "Product Id";
                    productGridView.Columns[1].HeaderText = "Product Name";
                    productGridView.Columns[2].HeaderText = "Quantity";
                    productGridView.Columns[3].HeaderText = "Price";
                    productGridView.Columns[4].HeaderText = "Created Date";
                    productGridView.Columns[5].HeaderText = "Created By";

                    productGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Used for go to New product form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNewProduct_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2          
            frmAddEditProduct newProduct = new frmAddEditProduct(0, this);
            // Show Form2
            newProduct.Show();
        }
        /// <summary>
        /// // Assuming you have a DataGridView named 'productGridView'
        /// </summary>
        public void AddActionColumns()
        {

            // Add 'Edit' button column
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                HeaderText = "Actions",
                UseColumnTextForButtonValue = true

            };
            // Add 'Delete' button column
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                HeaderText = "",
                UseColumnTextForButtonValue = true
            };
            // Add 'Delete' button column
            DataGridViewButtonColumn assignShipment = new DataGridViewButtonColumn
            {
                Name = "Shipment",
                Text = "Shipment",
                HeaderText = "",
                UseColumnTextForButtonValue = true
            };
            productGridView.Columns.Add(editColumn);
            productGridView.Columns.Add(deleteColumn);
            productGridView.Columns.Add(assignShipment);


            // Add the DataGridView to the form
            this.Controls.Add(productGridView);


        }
        /// <summary>
        /// Cell click event to used for Edit and Delete Command for the product in product Grid View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ProductResponse response = new ProductResponse();
                // Retrieve the Product object from the clicked row
                response = productData[e.RowIndex];
                if (e.RowIndex >= 0)
                {
                    if (productGridView.Columns[e.ColumnIndex].Name == "Edit")
                    {
                        //   MessageBox.Show($"Edit {productResponse.productId}");
                        // Create an instance of New Product Page          
                        frmAddEditProduct newProduct = new frmAddEditProduct(response.productId, this);
                        // Show Form2
                        newProduct.Show();
                    }
                    else if (productGridView.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        // Confirm the delete action
                        var confirmResult = MessageBox.Show("Are you sure you want to delete this product?",
                            "Confirm Delete", MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            // Delete product By Id
                            _ = DeleteProductAsync(response.productId);

                        }
                    }
                    else if (productGridView.Columns[e.ColumnIndex].Name == "Shipment")
                    {
                        //   MessageBox.Show($"Edit {productResponse.productId}");
                        // Create an instance of New Product Page
                        ProductShipmentAssign shipmentAssign = new ProductShipmentAssign(response.productId, this);
                        // Show Form2
                        shipmentAssign.Show();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Used for delete the product details
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                ProductRequest productRequest = new ProductRequest();
                var result = await productService.DeleteProductAsync(productId);
                if (result.statusCode == 200 && result.status)
                {
                    MessageBox.Show($"Success: {result.responseMessage}");
                    _ = LoadAllProductsAsync(false);

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

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            CommonCode.ExportDataProductDataToCsv(productGridView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShipmentHistory shipmentHistory = new ShipmentHistory();
            shipmentHistory.Show();
        }
    }
}


