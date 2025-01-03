using InventoryManagementSystemUI.ApiServices;
using InventoryManagementSystemUI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystemUI.Shipments
{
    public partial class ShipmentHistory : Form
    {
        private readonly ProductService productService;
        public ShipmentHistory()
        {
            productService = new ProductService();
            InitializeComponent();
            var shipdata = LoadShipmentHistory();

        }

        /// <summary>
        /// Load product details into product data grid 
        /// </summary>
        /// <returns></returns>
        public async Task LoadShipmentHistory()
        {
            try
            {
                shipHistoryGridView.DataSource = null;
                var shipmentHistory = await productService.GetShipmentsAsync();
                if (shipmentHistory.statusCode == 200 && shipmentHistory.status)
                {
                    // Defineing the data Column for data grid
                    DataTable shipmentsTable = new DataTable();
                    shipmentsTable.Columns.Add("ProductId", typeof(int));
                    shipmentsTable.Columns.Add("ProductName", typeof(string));
                    shipmentsTable.Columns.Add("Quantity", typeof(int));
                    shipmentsTable.Columns.Add("ShipmentId", typeof(int));
                    shipmentsTable.Columns.Add("ShipmentName", typeof(string));
                    shipmentsTable.Columns.Add("ShipmentDate", typeof(DateTime));

                    foreach (var shipItem in shipmentHistory.data)
                    {
                        shipmentsTable.Rows.Add(shipItem.productId, shipItem.productName, shipItem.quantity, shipItem.shipmentId, shipItem.shipmentName, shipItem.shipmentDate);
                    }
                    shipHistoryGridView.DataSource = shipmentsTable;
                    shipHistoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    //Define the HeaderText of Each column
                    shipHistoryGridView.Columns[0].HeaderText = "Product Id";
                    shipHistoryGridView.Columns[1].HeaderText = "Product Name";
                    shipHistoryGridView.Columns[2].HeaderText = "Quantity";
                    shipHistoryGridView.Columns[3].HeaderText = "Shipment Id";
                    shipHistoryGridView.Columns[4].HeaderText = "Shipment Name";
                    shipHistoryGridView.Columns[5].HeaderText = "Shipment Date";

                    shipHistoryGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

      
        private void btnShipmentExport_Click(object sender, EventArgs e)
        {
            CommonCode.ExportDataShipmentDataToCsv(shipHistoryGridView);
        }
    }
}
