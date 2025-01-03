using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystemUI.Common
{
    public class CommonCode
    {
        public const string baseUrl = "https://localhost:44311/api/";
        public const string AddNewProduct = "AddNewProduct";
        public const string UpdateProduct = "UpdateProduct";
        public const string GetProductById = "GetProductById";
        public const string GetAllProducts = "GetAllProducts";
        public const string DeleteProduct = "DeleteProduct";
        public const string AssignToShipment = "AssignToShipment";
        public const string GetAllShipments = "GetAllShipments";

        public static void ExportDataProductDataToCsv(DataGridView dgv)
        {
            // Create a StringBuilder to build the CSV string
            StringBuilder csvContent = new StringBuilder();

            // Export the header row
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                // Exclude the button column
                if (column.Name != "Edit" && column.Name != "Delete" && column.Name != "Shipment")  // Replace "buttonColumn" with the actual name of the button column
                {
                    csvContent.Append(column.HeaderText + ",");
                }
            }
            csvContent.Length--;  // Remove the last comma
            csvContent.AppendLine();

            // Export the data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)  // Ignore the new row
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Exclude the button column
                        if (cell.OwningColumn.Name != "Edit" && cell.OwningColumn.Name != "Delete" && cell.OwningColumn.Name != "Shipment")  // Replace with actual button column name
                        {
                            csvContent.Append(cell.Value?.ToString().Replace(",", " ") + ",");
                        }
                    }
                    csvContent.Length--;  // Remove the last comma
                    csvContent.AppendLine();
                }
            }

            // Save the CSV content to a file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FileName = "ProductSummary.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                MessageBox.Show("Data exported successfully!");
            }
        }

        public static void ExportDataShipmentDataToCsv(DataGridView dgv)
        {
            // Create a StringBuilder to build the CSV string
            StringBuilder csvContent = new StringBuilder();

            // Export the header row
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                csvContent.Append(column.HeaderText + ",");
            }
            csvContent.Length--;  // Remove the last comma
            csvContent.AppendLine();

            // Export the data rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)  // Ignore the new row
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        csvContent.Append(cell.Value?.ToString().Replace(",", " ") + ",");
                    }
                    csvContent.Length--;  // Remove the last comma
                    csvContent.AppendLine();
                }
            }

            // Save the CSV content to a file
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                FileName = "ShipmentHistory.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                MessageBox.Show("Data exported successfully!");
            }
        }


    }
}
