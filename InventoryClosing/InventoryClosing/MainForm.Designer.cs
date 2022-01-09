namespace InventoryClosing
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.FileOpenButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InventoryCloseButton = new System.Windows.Forms.Button();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Location = new System.Drawing.Point(12, 60);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.ReadOnly = true;
            this.FilePathTextBox.Size = new System.Drawing.Size(325, 23);
            this.FilePathTextBox.TabIndex = 0;
            // 
            // FileOpenButton
            // 
            this.FileOpenButton.Location = new System.Drawing.Point(343, 60);
            this.FileOpenButton.Name = "FileOpenButton";
            this.FileOpenButton.Size = new System.Drawing.Size(29, 23);
            this.FileOpenButton.TabIndex = 1;
            this.FileOpenButton.Text = "...";
            this.FileOpenButton.UseVisualStyleBackColor = true;
            this.FileOpenButton.Click += new System.EventHandler(this.FileOpenButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "File kiválasztása:";
            // 
            // InventoryCloseButton
            // 
            this.InventoryCloseButton.Location = new System.Drawing.Point(150, 125);
            this.InventoryCloseButton.Name = "InventoryCloseButton";
            this.InventoryCloseButton.Size = new System.Drawing.Size(75, 23);
            this.InventoryCloseButton.TabIndex = 3;
            this.InventoryCloseButton.Text = "Zárás";
            this.InventoryCloseButton.UseVisualStyleBackColor = true;
            this.InventoryCloseButton.Click += new System.EventHandler(this.InventoryCloseButton_Click);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Location = new System.Drawing.Point(12, 97);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 15);
            this.ErrorLabel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 176);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.InventoryCloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileOpenButton);
            this.Controls.Add(this.FilePathTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leltár zárás";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox FilePathTextBox;
        private Button FileOpenButton;
        private Label label1;
        private Button InventoryCloseButton;
        private Label ErrorLabel;
    }
}