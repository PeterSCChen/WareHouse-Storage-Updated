
namespace Assignment7AB
{
    partial class ShowInvoiceDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowInvoiceDialog));
            this.richTextBoxInvoice = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxInvoice
            // 
            this.richTextBoxInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxInvoice.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxInvoice.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxInvoice.Name = "richTextBoxInvoice";
            this.richTextBoxInvoice.ReadOnly = true;
            this.richTextBoxInvoice.Size = new System.Drawing.Size(732, 567);
            this.richTextBoxInvoice.TabIndex = 0;
            this.richTextBoxInvoice.Text = "";
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(669, 585);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // ShowInvoiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(756, 618);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.richTextBoxInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowInvoiceDialog";
            this.Text = "ShowInvoiceDialog";
            this.Load += new System.EventHandler(this.ShowInvoiceDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInvoice;
        private System.Windows.Forms.Button buttonClose;
    }
}