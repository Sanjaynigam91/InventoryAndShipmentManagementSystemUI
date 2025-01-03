namespace InventoryManagementSystemUI.Shipments
{
    partial class ShipmentHistory
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
            this.shipHistoryGridView = new System.Windows.Forms.DataGridView();
            this.btnShipmentExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.shipHistoryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // shipHistoryGridView
            // 
            this.shipHistoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shipHistoryGridView.Location = new System.Drawing.Point(67, 112);
            this.shipHistoryGridView.Name = "shipHistoryGridView";
            this.shipHistoryGridView.RowHeadersWidth = 62;
            this.shipHistoryGridView.RowTemplate.Height = 28;
            this.shipHistoryGridView.Size = new System.Drawing.Size(1069, 378);
            this.shipHistoryGridView.TabIndex = 0;
            // 
            // btnShipmentExport
            // 
            this.btnShipmentExport.Location = new System.Drawing.Point(67, 52);
            this.btnShipmentExport.Name = "btnShipmentExport";
            this.btnShipmentExport.Size = new System.Drawing.Size(165, 33);
            this.btnShipmentExport.TabIndex = 1;
            this.btnShipmentExport.Text = "Export to Csv";
            this.btnShipmentExport.UseVisualStyleBackColor = true;
            this.btnShipmentExport.Click += new System.EventHandler(this.btnShipmentExport_Click);
            // 
            // ShipmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 550);
            this.Controls.Add(this.btnShipmentExport);
            this.Controls.Add(this.shipHistoryGridView);
            this.Name = "ShipmentHistory";
            this.Text = "Shipment History";
            ((System.ComponentModel.ISupportInitialize)(this.shipHistoryGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView shipHistoryGridView;
        private System.Windows.Forms.Button btnShipmentExport;
    }
}