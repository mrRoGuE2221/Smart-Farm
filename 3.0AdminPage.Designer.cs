namespace WindowsFormsApp1
{
    partial class AdminPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ViewProductInfo = new System.Windows.Forms.Button();
            this.ConfirmOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.Profile = new System.Windows.Forms.Button();
            this.WorkerDashboard = new System.Windows.Forms.Button();
            this.BuyerDashboard = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "View Orders-";
            // 
            // ViewProductInfo
            // 
            this.ViewProductInfo.BackColor = System.Drawing.Color.PowderBlue;
            this.ViewProductInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewProductInfo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewProductInfo.Location = new System.Drawing.Point(16, 438);
            this.ViewProductInfo.Margin = new System.Windows.Forms.Padding(4);
            this.ViewProductInfo.Name = "ViewProductInfo";
            this.ViewProductInfo.Size = new System.Drawing.Size(243, 73);
            this.ViewProductInfo.TabIndex = 3;
            this.ViewProductInfo.Text = "View Product Info";
            this.ViewProductInfo.UseVisualStyleBackColor = false;
            this.ViewProductInfo.Click += new System.EventHandler(this.ViewProductInfo_Click);
            // 
            // ConfirmOrder
            // 
            this.ConfirmOrder.BackColor = System.Drawing.Color.LightBlue;
            this.ConfirmOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConfirmOrder.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmOrder.Location = new System.Drawing.Point(383, 386);
            this.ConfirmOrder.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmOrder.Name = "ConfirmOrder";
            this.ConfirmOrder.Size = new System.Drawing.Size(156, 30);
            this.ConfirmOrder.TabIndex = 4;
            this.ConfirmOrder.Text = "Confirm Order";
            this.ConfirmOrder.UseVisualStyleBackColor = false;
            this.ConfirmOrder.Click += new System.EventHandler(this.ConfirmOrder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(533, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 33);
            this.label2.TabIndex = 5;
            this.label2.Text = "Welcome Admin!!";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Salmon;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.Color.Black;
            this.Exit.Location = new System.Drawing.Point(1166, 504);
            this.Exit.Margin = new System.Windows.Forms.Padding(4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(83, 37);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Profile
            // 
            this.Profile.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Profile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Profile.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profile.Location = new System.Drawing.Point(1149, 11);
            this.Profile.Margin = new System.Windows.Forms.Padding(4);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(100, 28);
            this.Profile.TabIndex = 7;
            this.Profile.Text = "Profile";
            this.Profile.UseVisualStyleBackColor = false;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // WorkerDashboard
            // 
            this.WorkerDashboard.BackColor = System.Drawing.Color.PowderBlue;
            this.WorkerDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WorkerDashboard.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkerDashboard.Location = new System.Drawing.Point(1018, 82);
            this.WorkerDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.WorkerDashboard.Name = "WorkerDashboard";
            this.WorkerDashboard.Size = new System.Drawing.Size(231, 75);
            this.WorkerDashboard.TabIndex = 8;
            this.WorkerDashboard.Text = "Worker Dashboard";
            this.WorkerDashboard.UseVisualStyleBackColor = false;
            this.WorkerDashboard.Click += new System.EventHandler(this.WorkerDashboard_Click);
            // 
            // BuyerDashboard
            // 
            this.BuyerDashboard.BackColor = System.Drawing.Color.PowderBlue;
            this.BuyerDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BuyerDashboard.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuyerDashboard.Location = new System.Drawing.Point(1018, 304);
            this.BuyerDashboard.Margin = new System.Windows.Forms.Padding(4);
            this.BuyerDashboard.Name = "BuyerDashboard";
            this.BuyerDashboard.Size = new System.Drawing.Size(231, 75);
            this.BuyerDashboard.TabIndex = 9;
            this.BuyerDashboard.Text = "Buyer Dashboard";
            this.BuyerDashboard.UseVisualStyleBackColor = false;
            this.BuyerDashboard.Click += new System.EventHandler(this.BuyerDashboard_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.PowderBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(741, 438);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(219, 73);
            this.button7.TabIndex = 10;
            this.button7.Text = "Finance";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 82);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(468, 250);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(944, 297);
            this.dataGridView1.TabIndex = 11;
            // 
            // AdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 554);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.BuyerDashboard);
            this.Controls.Add(this.WorkerDashboard);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConfirmOrder);
            this.Controls.Add(this.ViewProductInfo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Page";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ViewProductInfo;
        private System.Windows.Forms.Button ConfirmOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button WorkerDashboard;
        private System.Windows.Forms.Button BuyerDashboard;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}