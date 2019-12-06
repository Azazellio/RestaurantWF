namespace Restaurant1
{
    partial class Form1
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
            this.menu = new System.Windows.Forms.ListView();
            this.SubmitOrderButton = new System.Windows.Forms.Button();
            this.Bucket = new System.Windows.Forms.ListView();
            this.Dish = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textB = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.serializeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TempB3 = new System.Windows.Forms.Button();
            this.TempB2 = new System.Windows.Forms.Button();
            this.tempB1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RemoveDishLabel = new System.Windows.Forms.Label();
            this.RemoveB = new System.Windows.Forms.Button();
            this.TempOrderTimeLabel = new System.Windows.Forms.Label();
            this.TempOrderTimeCheck = new System.Windows.Forms.Button();
            this.TimeNeededToCookLabel = new System.Windows.Forms.Label();
            this.SubmitOrderLabel = new System.Windows.Forms.Label();
            this.BucketLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ReadyOrdersList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrdersList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OrderTimeLabel = new System.Windows.Forms.Label();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.menuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu.HideSelection = false;
            this.menu.Location = new System.Drawing.Point(745, 94);
            this.menu.MultiSelect = false;
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(127, 419);
            this.menu.TabIndex = 0;
            this.menu.UseCompatibleStateImageBehavior = false;
            this.menu.View = System.Windows.Forms.View.List;
            this.menu.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Menu_ItemDrag);
            this.menu.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Menu_ItemSelectionChanged);
            // 
            // SubmitOrderButton
            // 
            this.SubmitOrderButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.SubmitOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitOrderButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.SubmitOrderButton.Location = new System.Drawing.Point(35, 288);
            this.SubmitOrderButton.Name = "SubmitOrderButton";
            this.SubmitOrderButton.Size = new System.Drawing.Size(75, 39);
            this.SubmitOrderButton.TabIndex = 1;
            this.SubmitOrderButton.Text = "\r\n";
            this.SubmitOrderButton.UseVisualStyleBackColor = false;
            this.SubmitOrderButton.Click += new System.EventHandler(this.SubmitOrderButton_Click);
            // 
            // Bucket
            // 
            this.Bucket.AllowDrop = true;
            this.Bucket.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Dish,
            this.time1,
            this.Price});
            this.Bucket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bucket.GridLines = true;
            this.Bucket.HideSelection = false;
            this.Bucket.Location = new System.Drawing.Point(159, 36);
            this.Bucket.Name = "Bucket";
            this.Bucket.Size = new System.Drawing.Size(511, 411);
            this.Bucket.TabIndex = 2;
            this.Bucket.UseCompatibleStateImageBehavior = false;
            this.Bucket.View = System.Windows.Forms.View.Details;
            this.Bucket.DragDrop += new System.Windows.Forms.DragEventHandler(this.Bucket_DragDrop);
            this.Bucket.DragEnter += new System.Windows.Forms.DragEventHandler(this.Bucket_DragEnter);
            // 
            // Dish
            // 
            this.Dish.Text = "Dish";
            this.Dish.Width = 250;
            // 
            // time1
            // 
            this.time1.Text = "Time";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            // 
            // textB
            // 
            this.textB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textB.Location = new System.Drawing.Point(132, 72);
            this.textB.Multiline = true;
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(535, 375);
            this.textB.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 28);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(917, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serializeToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(917, 28);
            this.menuStrip2.TabIndex = 5;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // serializeToolStripMenuItem
            // 
            this.serializeToolStripMenuItem.Name = "serializeToolStripMenuItem";
            this.serializeToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.serializeToolStripMenuItem.Text = "Serialize";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 482);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabControl1_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TempB3);
            this.tabPage1.Controls.Add(this.TempB2);
            this.tabPage1.Controls.Add(this.tempB1);
            this.tabPage1.Controls.Add(this.textB);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(673, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dishes Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TempB3
            // 
            this.TempB3.Location = new System.Drawing.Point(34, 341);
            this.TempB3.Name = "TempB3";
            this.TempB3.Size = new System.Drawing.Size(75, 23);
            this.TempB3.TabIndex = 6;
            this.TempB3.Text = "temp3";
            this.TempB3.UseVisualStyleBackColor = true;
            this.TempB3.Click += new System.EventHandler(this.TempB3_Click);
            // 
            // TempB2
            // 
            this.TempB2.Location = new System.Drawing.Point(34, 242);
            this.TempB2.Name = "TempB2";
            this.TempB2.Size = new System.Drawing.Size(75, 23);
            this.TempB2.TabIndex = 5;
            this.TempB2.Text = "temp2";
            this.TempB2.UseVisualStyleBackColor = true;
            this.TempB2.Click += new System.EventHandler(this.TempB2_Click);
            // 
            // tempB1
            // 
            this.tempB1.Location = new System.Drawing.Point(34, 152);
            this.tempB1.Name = "tempB1";
            this.tempB1.Size = new System.Drawing.Size(75, 23);
            this.tempB1.TabIndex = 4;
            this.tempB1.Text = "temp1";
            this.tempB1.UseVisualStyleBackColor = true;
            this.tempB1.Click += new System.EventHandler(this.TempB1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RemoveDishLabel);
            this.tabPage2.Controls.Add(this.RemoveB);
            this.tabPage2.Controls.Add(this.TempOrderTimeLabel);
            this.tabPage2.Controls.Add(this.TempOrderTimeCheck);
            this.tabPage2.Controls.Add(this.TimeNeededToCookLabel);
            this.tabPage2.Controls.Add(this.SubmitOrderLabel);
            this.tabPage2.Controls.Add(this.BucketLabel);
            this.tabPage2.Controls.Add(this.Bucket);
            this.tabPage2.Controls.Add(this.SubmitOrderButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create Order";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RemoveDishLabel
            // 
            this.RemoveDishLabel.AutoSize = true;
            this.RemoveDishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveDishLabel.Location = new System.Drawing.Point(6, 36);
            this.RemoveDishLabel.Name = "RemoveDishLabel";
            this.RemoveDishLabel.Size = new System.Drawing.Size(128, 25);
            this.RemoveDishLabel.TabIndex = 10;
            this.RemoveDishLabel.Text = "Remove Dish";
            // 
            // RemoveB
            // 
            this.RemoveB.BackColor = System.Drawing.Color.Maroon;
            this.RemoveB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RemoveB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveB.Location = new System.Drawing.Point(35, 75);
            this.RemoveB.Name = "RemoveB";
            this.RemoveB.Size = new System.Drawing.Size(75, 36);
            this.RemoveB.TabIndex = 9;
            this.RemoveB.Text = "-";
            this.RemoveB.UseVisualStyleBackColor = false;
            this.RemoveB.Click += new System.EventHandler(this.RemoveB_Click);
            // 
            // TempOrderTimeLabel
            // 
            this.TempOrderTimeLabel.AutoSize = true;
            this.TempOrderTimeLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TempOrderTimeLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TempOrderTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TempOrderTimeLabel.Location = new System.Drawing.Point(63, 175);
            this.TempOrderTimeLabel.Name = "TempOrderTimeLabel";
            this.TempOrderTimeLabel.Size = new System.Drawing.Size(21, 24);
            this.TempOrderTimeLabel.TabIndex = 8;
            this.TempOrderTimeLabel.Text = "0";
            // 
            // TempOrderTimeCheck
            // 
            this.TempOrderTimeCheck.Location = new System.Drawing.Point(35, 202);
            this.TempOrderTimeCheck.Name = "TempOrderTimeCheck";
            this.TempOrderTimeCheck.Size = new System.Drawing.Size(75, 41);
            this.TempOrderTimeCheck.TabIndex = 7;
            this.TempOrderTimeCheck.Text = "Check";
            this.TempOrderTimeCheck.UseVisualStyleBackColor = true;
            this.TempOrderTimeCheck.Click += new System.EventHandler(this.TempOrderTimeCheck_Click);
            // 
            // TimeNeededToCookLabel
            // 
            this.TimeNeededToCookLabel.AutoSize = true;
            this.TimeNeededToCookLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeNeededToCookLabel.Location = new System.Drawing.Point(6, 150);
            this.TimeNeededToCookLabel.Name = "TimeNeededToCookLabel";
            this.TimeNeededToCookLabel.Size = new System.Drawing.Size(130, 25);
            this.TimeNeededToCookLabel.TabIndex = 6;
            this.TimeNeededToCookLabel.Text = "Time Needed";
            // 
            // SubmitOrderLabel
            // 
            this.SubmitOrderLabel.AutoSize = true;
            this.SubmitOrderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitOrderLabel.Location = new System.Drawing.Point(6, 260);
            this.SubmitOrderLabel.Name = "SubmitOrderLabel";
            this.SubmitOrderLabel.Size = new System.Drawing.Size(128, 25);
            this.SubmitOrderLabel.TabIndex = 4;
            this.SubmitOrderLabel.Text = "Submit Order";
            // 
            // BucketLabel
            // 
            this.BucketLabel.AutoSize = true;
            this.BucketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BucketLabel.Location = new System.Drawing.Point(351, 8);
            this.BucketLabel.Name = "BucketLabel";
            this.BucketLabel.Size = new System.Drawing.Size(118, 25);
            this.BucketLabel.TabIndex = 3;
            this.BucketLabel.Text = "Your Bucket";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.ReadyOrdersList);
            this.tabPage3.Controls.Add(this.OrdersList);
            this.tabPage3.Controls.Add(this.OrderTimeLabel);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(673, 453);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Check Order";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ready Orders";
            // 
            // ReadyOrdersList
            // 
            this.ReadyOrdersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadyOrdersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.ReadyOrdersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadyOrdersList.GridLines = true;
            this.ReadyOrdersList.HideSelection = false;
            this.ReadyOrdersList.Location = new System.Drawing.Point(6, 49);
            this.ReadyOrdersList.Name = "ReadyOrdersList";
            this.ReadyOrdersList.Size = new System.Drawing.Size(146, 398);
            this.ReadyOrdersList.TabIndex = 2;
            this.ReadyOrdersList.UseCompatibleStateImageBehavior = false;
            this.ReadyOrdersList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Id";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Price";
            // 
            // OrdersList
            // 
            this.OrdersList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OrdersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6});
            this.OrdersList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrdersList.GridLines = true;
            this.OrdersList.HideSelection = false;
            this.OrdersList.Location = new System.Drawing.Point(158, 49);
            this.OrdersList.Name = "OrdersList";
            this.OrdersList.Size = new System.Drawing.Size(509, 398);
            this.OrdersList.TabIndex = 1;
            this.OrdersList.UseCompatibleStateImageBehavior = false;
            this.OrdersList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Id";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time Needed";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Dishes Count";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Price";
            // 
            // OrderTimeLabel
            // 
            this.OrderTimeLabel.AutoSize = true;
            this.OrderTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderTimeLabel.Location = new System.Drawing.Point(456, 12);
            this.OrderTimeLabel.Name = "OrderTimeLabel";
            this.OrderTimeLabel.Size = new System.Drawing.Size(99, 25);
            this.OrderTimeLabel.TabIndex = 0;
            this.OrderTimeLabel.Text = "All Orders";
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuLabel.Location = new System.Drawing.Point(777, 56);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(62, 25);
            this.MenuLabel.TabIndex = 7;
            this.MenuLabel.Text = "Menu";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 539);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView menu;
        private System.Windows.Forms.Button SubmitOrderButton;
        private System.Windows.Forms.ListView Bucket;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem serializeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label SubmitOrderLabel;
        private System.Windows.Forms.Label BucketLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label TimeNeededToCookLabel;
        private System.Windows.Forms.ColumnHeader Dish;
        private System.Windows.Forms.ColumnHeader time1;
        private System.Windows.Forms.Button TempOrderTimeCheck;
        private System.Windows.Forms.Label TempOrderTimeLabel;
        private System.Windows.Forms.Label RemoveDishLabel;
        private System.Windows.Forms.Button RemoveB;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.Label OrderTimeLabel;
        private System.Windows.Forms.ListView OrdersList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button tempB1;
        private System.Windows.Forms.Button TempB2;
        private System.Windows.Forms.Button TempB3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ReadyOrdersList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader Price;
    }
}

