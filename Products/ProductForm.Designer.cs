namespace InventoryManagementSystemUI
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productGridView = new System.Windows.Forms.DataGridView();
            this.btnAddNewProduct = new System.Windows.Forms.Button();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // productGridView
            // 
            this.productGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGridView.Location = new System.Drawing.Point(29, 148);
            this.productGridView.Name = "productGridView";
            this.productGridView.RowHeadersWidth = 62;
            this.productGridView.RowTemplate.Height = 28;
            this.productGridView.Size = new System.Drawing.Size(1298, 370);
            this.productGridView.TabIndex = 0;
            this.productGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productGridView_CellContentClick);
            // 
            // btnAddNewProduct
            // 
            this.btnAddNewProduct.Location = new System.Drawing.Point(38, 76);
            this.btnAddNewProduct.Name = "btnAddNewProduct";
            this.btnAddNewProduct.Size = new System.Drawing.Size(166, 48);
            this.btnAddNewProduct.TabIndex = 1;
            this.btnAddNewProduct.Text = "Add New Product";
            this.btnAddNewProduct.UseVisualStyleBackColor = true;
            this.btnAddNewProduct.Click += new System.EventHandler(this.btnAddNewProduct_Click);
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExportToCsv.Location = new System.Drawing.Point(258, 77);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(151, 47);
            this.btnExportToCsv.TabIndex = 2;
            this.btnExportToCsv.Text = "Export To Csv";
            this.btnExportToCsv.UseVisualStyleBackColor = false;
            this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "View Shipments";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1475, 592);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExportToCsv);
            this.Controls.Add(this.btnAddNewProduct);
            this.Controls.Add(this.productGridView);
            this.Name = "ProductForm";
            this.Text = "Inventory And Shipment Management System";
            ((System.ComponentModel.ISupportInitialize)(this.productGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView productGridView;
        private System.Windows.Forms.Button btnAddNewProduct;
        private System.Windows.Forms.Button btnExportToCsv;
        private System.Windows.Forms.Button button1;
    }
}

