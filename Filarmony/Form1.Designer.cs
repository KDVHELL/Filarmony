namespace Filarmony
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lkBtn = new System.Windows.Forms.Button();
            this.conDatePicker = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lkBtn
            // 
            this.lkBtn.BackgroundImage = global::Filarmony.Properties.Resources._1675895563_grizly_club_p_lichnii_kabinet_klipart_14;
            this.lkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lkBtn.Location = new System.Drawing.Point(765, 14);
            this.lkBtn.Name = "lkBtn";
            this.lkBtn.Size = new System.Drawing.Size(65, 61);
            this.lkBtn.TabIndex = 3;
            this.lkBtn.UseVisualStyleBackColor = true;
            // 
            // conDatePicker
            // 
            this.conDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conDatePicker.Location = new System.Drawing.Point(12, 34);
            this.conDatePicker.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.conDatePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.conDatePicker.Name = "conDatePicker";
            this.conDatePicker.Size = new System.Drawing.Size(232, 30);
            this.conDatePicker.TabIndex = 4;
            this.conDatePicker.CloseUp += new System.EventHandler(this.conDatePicker_CloseUp);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 95);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(818, 635);
            this.listView1.TabIndex = 5;
            this.listView1.TileSize = new System.Drawing.Size(700, 200);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(842, 742);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.conDatePicker);
            this.Controls.Add(this.lkBtn);
            this.Name = "Form1";
            this.Text = "Покупатель";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button lkBtn;
        private System.Windows.Forms.DateTimePicker conDatePicker;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

