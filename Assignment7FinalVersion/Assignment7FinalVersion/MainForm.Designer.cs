
namespace Assignment7AB
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonEditRecord = new System.Windows.Forms.Button();
            this.labelTotalYTDSales = new System.Windows.Forms.Label();
            this.labelCreditHoldCount = new System.Windows.Forms.Label();
            this.labelTotalYTDSalesResult = new System.Windows.Forms.Label();
            this.labelCreditHoldCountResult = new System.Windows.Forms.Label();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelYTDDifference = new System.Windows.Forms.Label();
            this.buttonNewClient = new System.Windows.Forms.Button();
            this.labelRecordCountResult = new System.Windows.Forms.Label();
            this.labelTotalRecordCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxConfirmDeletion = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditRecord.Location = new System.Drawing.Point(793, 462);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.Size = new System.Drawing.Size(75, 23);
            this.buttonEditRecord.TabIndex = 5;
            this.buttonEditRecord.Text = "Edit Record";
            this.buttonEditRecord.UseVisualStyleBackColor = true;
            this.buttonEditRecord.Click += new System.EventHandler(this.buttonEditRecord_Click);
            // 
            // labelTotalYTDSales
            // 
            this.labelTotalYTDSales.AutoSize = true;
            this.labelTotalYTDSales.Location = new System.Drawing.Point(678, 31);
            this.labelTotalYTDSales.Name = "labelTotalYTDSales";
            this.labelTotalYTDSales.Size = new System.Drawing.Size(88, 13);
            this.labelTotalYTDSales.TabIndex = 1;
            this.labelTotalYTDSales.Text = "Total YTD Sales:";
            // 
            // labelCreditHoldCount
            // 
            this.labelCreditHoldCount.AutoSize = true;
            this.labelCreditHoldCount.Location = new System.Drawing.Point(678, 57);
            this.labelCreditHoldCount.Name = "labelCreditHoldCount";
            this.labelCreditHoldCount.Size = new System.Drawing.Size(89, 13);
            this.labelCreditHoldCount.TabIndex = 3;
            this.labelCreditHoldCount.Text = "Total Credit Hold:";
            // 
            // labelTotalYTDSalesResult
            // 
            this.labelTotalYTDSalesResult.AutoSize = true;
            this.labelTotalYTDSalesResult.Location = new System.Drawing.Point(772, 31);
            this.labelTotalYTDSalesResult.Name = "labelTotalYTDSalesResult";
            this.labelTotalYTDSalesResult.Size = new System.Drawing.Size(94, 13);
            this.labelTotalYTDSalesResult.TabIndex = 1;
            this.labelTotalYTDSalesResult.Text = "<Total YTDSales>";
            // 
            // labelCreditHoldCountResult
            // 
            this.labelCreditHoldCountResult.AutoSize = true;
            this.labelCreditHoldCountResult.Location = new System.Drawing.Point(772, 57);
            this.labelCreditHoldCountResult.Name = "labelCreditHoldCountResult";
            this.labelCreditHoldCountResult.Size = new System.Drawing.Size(98, 13);
            this.labelCreditHoldCountResult.TabIndex = 3;
            this.labelCreditHoldCountResult.Text = "<Total Credit Hold>";
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(27, 84);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(843, 358);
            this.dataGridViewClients.TabIndex = 6;
            this.dataGridViewClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClients_CellClick);
            this.dataGridViewClients.DoubleClick += new System.EventHandler(this.buttonEditRecord_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(703, 462);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(84, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "&Delete Client";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelYTDDifference
            // 
            this.labelYTDDifference.AutoSize = true;
            this.labelYTDDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYTDDifference.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelYTDDifference.Location = new System.Drawing.Point(155, 467);
            this.labelYTDDifference.Name = "labelYTDDifference";
            this.labelYTDDifference.Size = new System.Drawing.Size(12, 16);
            this.labelYTDDifference.TabIndex = 12;
            this.labelYTDDifference.Text = "\\";
            // 
            // buttonNewClient
            // 
            this.buttonNewClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewClient.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNewClient.Location = new System.Drawing.Point(622, 462);
            this.buttonNewClient.Name = "buttonNewClient";
            this.buttonNewClient.Size = new System.Drawing.Size(75, 23);
            this.buttonNewClient.TabIndex = 19;
            this.buttonNewClient.Text = "&New Client";
            this.buttonNewClient.UseVisualStyleBackColor = true;
            this.buttonNewClient.Click += new System.EventHandler(this.buttonNewClient_Click);
            // 
            // labelRecordCountResult
            // 
            this.labelRecordCountResult.AutoSize = true;
            this.labelRecordCountResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecordCountResult.Location = new System.Drawing.Point(155, 31);
            this.labelRecordCountResult.Name = "labelRecordCountResult";
            this.labelRecordCountResult.Size = new System.Drawing.Size(138, 16);
            this.labelRecordCountResult.TabIndex = 21;
            this.labelRecordCountResult.Text = "<Total Record Count>";
            // 
            // labelTotalRecordCount
            // 
            this.labelTotalRecordCount.AutoSize = true;
            this.labelTotalRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalRecordCount.Location = new System.Drawing.Point(22, 31);
            this.labelTotalRecordCount.Name = "labelTotalRecordCount";
            this.labelTotalRecordCount.Size = new System.Drawing.Size(127, 16);
            this.labelTotalRecordCount.TabIndex = 22;
            this.labelTotalRecordCount.Text = "Total Record Count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Current VS Average:";
            // 
            // checkBoxConfirmDeletion
            // 
            this.checkBoxConfirmDeletion.AutoSize = true;
            this.checkBoxConfirmDeletion.Location = new System.Drawing.Point(513, 466);
            this.checkBoxConfirmDeletion.Name = "checkBoxConfirmDeletion";
            this.checkBoxConfirmDeletion.Size = new System.Drawing.Size(103, 17);
            this.checkBoxConfirmDeletion.TabIndex = 24;
            this.checkBoxConfirmDeletion.Text = "&Confirm Deletion";
            this.checkBoxConfirmDeletion.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonEditRecord;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 493);
            this.Controls.Add(this.checkBoxConfirmDeletion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTotalRecordCount);
            this.Controls.Add(this.labelRecordCountResult);
            this.Controls.Add(this.buttonNewClient);
            this.Controls.Add(this.labelYTDDifference);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewClients);
            this.Controls.Add(this.labelCreditHoldCountResult);
            this.Controls.Add(this.labelCreditHoldCount);
            this.Controls.Add(this.labelTotalYTDSalesResult);
            this.Controls.Add(this.labelTotalYTDSales);
            this.Controls.Add(this.buttonEditRecord);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Client Data Collection";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEditRecord;
        private System.Windows.Forms.Label labelTotalYTDSales;
        private System.Windows.Forms.Label labelCreditHoldCount;
        private System.Windows.Forms.Label labelTotalYTDSalesResult;
        private System.Windows.Forms.Label labelCreditHoldCountResult;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelYTDDifference;
        private System.Windows.Forms.Button buttonNewClient;
        private System.Windows.Forms.Label labelRecordCountResult;
        private System.Windows.Forms.Label labelTotalRecordCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxConfirmDeletion;
    }
}