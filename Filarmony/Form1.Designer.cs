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
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("Выберите дату");
            this.lkBtn = new System.Windows.Forms.Button();
            this.conDatePicker = new System.Windows.Forms.DateTimePicker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.concertInfoBox = new System.Windows.Forms.GroupBox();
            this.buyBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.startDateLab = new System.Windows.Forms.Label();
            this.concertNameLab = new System.Windows.Forms.Label();
            this.endDatePut = new System.Windows.Forms.Label();
            this.startDatePut = new System.Windows.Forms.Label();
            this.endDateLab = new System.Windows.Forms.Label();
            this.ratingLab = new System.Windows.Forms.Label();
            this.concertDiscBox = new System.Windows.Forms.GroupBox();
            this.briefBox = new System.Windows.Forms.RichTextBox();
            this.markLab = new System.Windows.Forms.Label();
            this.markView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seatBox = new System.Windows.Forms.GroupBox();
            this.seatView = new System.Windows.Forms.ListView();
            this.backToCon = new System.Windows.Forms.Button();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.concertInfoBox.SuspendLayout();
            this.concertDiscBox.SuspendLayout();
            this.seatBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lkBtn
            // 
            this.lkBtn.BackgroundImage = global::Filarmony.Properties.Resources._1675895563_grizly_club_p_lichnii_kabinet_klipart_14;
            this.lkBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lkBtn.Location = new System.Drawing.Point(891, 33);
            this.lkBtn.Name = "lkBtn";
            this.lkBtn.Size = new System.Drawing.Size(65, 61);
            this.lkBtn.TabIndex = 3;
            this.lkBtn.UseVisualStyleBackColor = true;
            this.lkBtn.Click += new System.EventHandler(this.lkBtn_Click);
            // 
            // conDatePicker
            // 
            this.conDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conDatePicker.Location = new System.Drawing.Point(354, 111);
            this.conDatePicker.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.conDatePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.conDatePicker.Name = "conDatePicker";
            this.conDatePicker.Size = new System.Drawing.Size(300, 38);
            this.conDatePicker.TabIndex = 4;
            this.conDatePicker.CloseUp += new System.EventHandler(this.conDatePicker_CloseUp);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem13});
            this.listView1.Location = new System.Drawing.Point(12, 164);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(954, 676);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(426, 42);
            this.label2.TabIndex = 9;
            this.label2.Text = "Пермская филармония";
            // 
            // concertInfoBox
            // 
            this.concertInfoBox.Controls.Add(this.ratingLab);
            this.concertInfoBox.Controls.Add(this.endDateLab);
            this.concertInfoBox.Controls.Add(this.startDatePut);
            this.concertInfoBox.Controls.Add(this.endDatePut);
            this.concertInfoBox.Controls.Add(this.concertNameLab);
            this.concertInfoBox.Controls.Add(this.startDateLab);
            this.concertInfoBox.Controls.Add(this.BackBtn);
            this.concertInfoBox.Controls.Add(this.buyBtn);
            this.concertInfoBox.Controls.Add(this.backToCon);
            this.concertInfoBox.Controls.Add(this.seatBox);
            this.concertInfoBox.Controls.Add(this.concertDiscBox);
            this.concertInfoBox.Enabled = false;
            this.concertInfoBox.Location = new System.Drawing.Point(12, 12);
            this.concertInfoBox.Name = "concertInfoBox";
            this.concertInfoBox.Size = new System.Drawing.Size(954, 828);
            this.concertInfoBox.TabIndex = 10;
            this.concertInfoBox.TabStop = false;
            this.concertInfoBox.Text = "d";
            this.concertInfoBox.Visible = false;
            // 
            // buyBtn
            // 
            this.buyBtn.BackColor = System.Drawing.Color.Yellow;
            this.buyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buyBtn.Location = new System.Drawing.Point(569, 60);
            this.buyBtn.Name = "buyBtn";
            this.buyBtn.Size = new System.Drawing.Size(178, 103);
            this.buyBtn.TabIndex = 0;
            this.buyBtn.Text = "Купить";
            this.buyBtn.UseVisualStyleBackColor = false;
            this.buyBtn.Click += new System.EventHandler(this.buyBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.Color.LightCoral;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackBtn.Location = new System.Drawing.Point(764, 60);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(178, 103);
            this.BackBtn.TabIndex = 1;
            this.BackBtn.Text = "Назад";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // startDateLab
            // 
            this.startDateLab.AutoSize = true;
            this.startDateLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDateLab.Location = new System.Drawing.Point(10, 120);
            this.startDateLab.Name = "startDateLab";
            this.startDateLab.Size = new System.Drawing.Size(136, 25);
            this.startDateLab.TabIndex = 2;
            this.startDateLab.Text = "Дата начала:";
            // 
            // concertNameLab
            // 
            this.concertNameLab.AutoSize = true;
            this.concertNameLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.concertNameLab.Location = new System.Drawing.Point(6, 29);
            this.concertNameLab.Name = "concertNameLab";
            this.concertNameLab.Size = new System.Drawing.Size(172, 39);
            this.concertNameLab.TabIndex = 3;
            this.concertNameLab.Text = "Название";
            // 
            // endDatePut
            // 
            this.endDatePut.AutoSize = true;
            this.endDatePut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endDatePut.Location = new System.Drawing.Point(196, 152);
            this.endDatePut.Name = "endDatePut";
            this.endDatePut.Size = new System.Drawing.Size(64, 25);
            this.endDatePut.TabIndex = 4;
            this.endDatePut.Text = "label4";
            // 
            // startDatePut
            // 
            this.startDatePut.AutoSize = true;
            this.startDatePut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.startDatePut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startDatePut.Location = new System.Drawing.Point(196, 120);
            this.startDatePut.Name = "startDatePut";
            this.startDatePut.Size = new System.Drawing.Size(64, 25);
            this.startDatePut.TabIndex = 5;
            this.startDatePut.Text = "label5";
            // 
            // endDateLab
            // 
            this.endDateLab.AutoSize = true;
            this.endDateLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endDateLab.Location = new System.Drawing.Point(10, 152);
            this.endDateLab.Name = "endDateLab";
            this.endDateLab.Size = new System.Drawing.Size(169, 25);
            this.endDateLab.TabIndex = 6;
            this.endDateLab.Text = "Дата окончания:";
            // 
            // ratingLab
            // 
            this.ratingLab.AutoSize = true;
            this.ratingLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ratingLab.Location = new System.Drawing.Point(11, 68);
            this.ratingLab.Name = "ratingLab";
            this.ratingLab.Size = new System.Drawing.Size(82, 22);
            this.ratingLab.TabIndex = 7;
            this.ratingLab.Text = "Рейтинг:";
            // 
            // concertDiscBox
            // 
            this.concertDiscBox.Controls.Add(this.markView);
            this.concertDiscBox.Controls.Add(this.markLab);
            this.concertDiscBox.Controls.Add(this.briefBox);
            this.concertDiscBox.Location = new System.Drawing.Point(6, 254);
            this.concertDiscBox.Name = "concertDiscBox";
            this.concertDiscBox.Size = new System.Drawing.Size(942, 568);
            this.concertDiscBox.TabIndex = 8;
            this.concertDiscBox.TabStop = false;
            // 
            // briefBox
            // 
            this.briefBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.briefBox.Location = new System.Drawing.Point(0, 21);
            this.briefBox.Name = "briefBox";
            this.briefBox.Size = new System.Drawing.Size(936, 198);
            this.briefBox.TabIndex = 0;
            this.briefBox.Text = "";
            // 
            // markLab
            // 
            this.markLab.AutoSize = true;
            this.markLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.markLab.Location = new System.Drawing.Point(-6, 253);
            this.markLab.Name = "markLab";
            this.markLab.Size = new System.Drawing.Size(118, 32);
            this.markLab.TabIndex = 1;
            this.markLab.Text = "Отзывы";
            // 
            // markView
            // 
            this.markView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.markView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.markView.HideSelection = false;
            this.markView.LabelWrap = false;
            this.markView.Location = new System.Drawing.Point(0, 297);
            this.markView.MultiSelect = false;
            this.markView.Name = "markView";
            this.markView.Size = new System.Drawing.Size(942, 264);
            this.markView.TabIndex = 2;
            this.markView.UseCompatibleStateImageBehavior = false;
            this.markView.View = System.Windows.Forms.View.Tile;
            // 
            // seatBox
            // 
            this.seatBox.Controls.Add(this.seatView);
            this.seatBox.Enabled = false;
            this.seatBox.Location = new System.Drawing.Point(6, 254);
            this.seatBox.Name = "seatBox";
            this.seatBox.Size = new System.Drawing.Size(942, 568);
            this.seatBox.TabIndex = 9;
            this.seatBox.TabStop = false;
            this.seatBox.Visible = false;
            // 
            // seatView
            // 
            this.seatView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.seatView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seatView.FullRowSelect = true;
            this.seatView.HideSelection = false;
            this.seatView.Location = new System.Drawing.Point(9, 21);
            this.seatView.Name = "seatView";
            this.seatView.Size = new System.Drawing.Size(927, 540);
            this.seatView.TabIndex = 0;
            this.seatView.TileSize = new System.Drawing.Size(700, 150);
            this.seatView.UseCompatibleStateImageBehavior = false;
            this.seatView.View = System.Windows.Forms.View.Tile;
            this.seatView.ItemActivate += new System.EventHandler(this.seatView_ItemActivate);
            // 
            // backToCon
            // 
            this.backToCon.BackColor = System.Drawing.Color.LightCoral;
            this.backToCon.Enabled = false;
            this.backToCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToCon.Location = new System.Drawing.Point(764, 60);
            this.backToCon.Name = "backToCon";
            this.backToCon.Size = new System.Drawing.Size(178, 103);
            this.backToCon.TabIndex = 10;
            this.backToCon.Text = "Назад";
            this.backToCon.UseVisualStyleBackColor = false;
            this.backToCon.Visible = false;
            this.backToCon.Click += new System.EventHandler(this.backToCon_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(978, 852);
            this.Controls.Add(this.concertInfoBox);
            this.Controls.Add(this.conDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lkBtn);
            this.Name = "Form1";
            this.Text = "Покупатель";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.concertInfoBox.ResumeLayout(false);
            this.concertInfoBox.PerformLayout();
            this.concertDiscBox.ResumeLayout(false);
            this.concertDiscBox.PerformLayout();
            this.seatBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button lkBtn;
        private System.Windows.Forms.DateTimePicker conDatePicker;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox concertInfoBox;
        private System.Windows.Forms.GroupBox concertDiscBox;
        private System.Windows.Forms.Label markLab;
        private System.Windows.Forms.RichTextBox briefBox;
        private System.Windows.Forms.Label ratingLab;
        private System.Windows.Forms.Label endDateLab;
        private System.Windows.Forms.Label startDatePut;
        private System.Windows.Forms.Label endDatePut;
        private System.Windows.Forms.Label concertNameLab;
        private System.Windows.Forms.Label startDateLab;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button buyBtn;
        private System.Windows.Forms.ListView markView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox seatBox;
        private System.Windows.Forms.ListView seatView;
        private System.Windows.Forms.Button backToCon;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
    }
}

