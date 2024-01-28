namespace qly_NhanKhau
{
    partial class qlyPhuong
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
            this.textBoxMaP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSDTP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTenP = new System.Windows.Forms.TextBox();
            this.buttonThemP = new System.Windows.Forms.Button();
            this.dataGridViewPhuong = new System.Windows.Forms.DataGridView();
            this.buttonXoaP = new System.Windows.Forms.Button();
            this.buttonSuaP = new System.Windows.Forms.Button();
            this.buttonTimPh = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhuong)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMaP
            // 
            this.textBoxMaP.Location = new System.Drawing.Point(69, 20);
            this.textBoxMaP.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMaP.Name = "textBoxMaP";
            this.textBoxMaP.Size = new System.Drawing.Size(68, 20);
            this.textBoxMaP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "SDT";
            // 
            // textBoxSDTP
            // 
            this.textBoxSDTP.Location = new System.Drawing.Point(69, 83);
            this.textBoxSDTP.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxSDTP.Name = "textBoxSDTP";
            this.textBoxSDTP.Size = new System.Drawing.Size(68, 20);
            this.textBoxSDTP.TabIndex = 2;
            this.textBoxSDTP.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxSDTP_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên";
            // 
            // textBoxTenP
            // 
            this.textBoxTenP.Location = new System.Drawing.Point(69, 49);
            this.textBoxTenP.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTenP.Name = "textBoxTenP";
            this.textBoxTenP.Size = new System.Drawing.Size(68, 20);
            this.textBoxTenP.TabIndex = 4;
            // 
            // buttonThemP
            // 
            this.buttonThemP.Location = new System.Drawing.Point(18, 119);
            this.buttonThemP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonThemP.Name = "buttonThemP";
            this.buttonThemP.Size = new System.Drawing.Size(117, 25);
            this.buttonThemP.TabIndex = 6;
            this.buttonThemP.Text = "Thêm";
            this.buttonThemP.UseVisualStyleBackColor = true;
            this.buttonThemP.Click += new System.EventHandler(this.buttonThemP_Click);
            // 
            // dataGridViewPhuong
            // 
            this.dataGridViewPhuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhuong.Location = new System.Drawing.Point(165, 24);
            this.dataGridViewPhuong.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewPhuong.Name = "dataGridViewPhuong";
            this.dataGridViewPhuong.RowHeadersWidth = 62;
            this.dataGridViewPhuong.RowTemplate.Height = 28;
            this.dataGridViewPhuong.Size = new System.Drawing.Size(383, 257);
            this.dataGridViewPhuong.TabIndex = 7;
            this.dataGridViewPhuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPhuong_CellContentClick);
            // 
            // buttonXoaP
            // 
            this.buttonXoaP.Location = new System.Drawing.Point(16, 177);
            this.buttonXoaP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonXoaP.Name = "buttonXoaP";
            this.buttonXoaP.Size = new System.Drawing.Size(120, 25);
            this.buttonXoaP.TabIndex = 8;
            this.buttonXoaP.Text = "Xóa";
            this.buttonXoaP.UseVisualStyleBackColor = true;
            this.buttonXoaP.Click += new System.EventHandler(this.buttonXoaP_Click);
            // 
            // buttonSuaP
            // 
            this.buttonSuaP.Location = new System.Drawing.Point(16, 148);
            this.buttonSuaP.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSuaP.Name = "buttonSuaP";
            this.buttonSuaP.Size = new System.Drawing.Size(117, 25);
            this.buttonSuaP.TabIndex = 9;
            this.buttonSuaP.Text = "Sửa";
            this.buttonSuaP.UseVisualStyleBackColor = true;
            this.buttonSuaP.Click += new System.EventHandler(this.buttonSuaP_Click);
            // 
            // buttonTimPh
            // 
            this.buttonTimPh.Location = new System.Drawing.Point(18, 206);
            this.buttonTimPh.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTimPh.Name = "buttonTimPh";
            this.buttonTimPh.Size = new System.Drawing.Size(120, 25);
            this.buttonTimPh.TabIndex = 10;
            this.buttonTimPh.Text = "Tìm Kiếm";
            this.buttonTimPh.UseVisualStyleBackColor = true;
            this.buttonTimPh.Click += new System.EventHandler(this.buttonTimPh_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(16, 235);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(120, 25);
            this.btnBaoCao.TabIndex = 11;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(16, 264);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 25);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // qlyPhuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 292);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.buttonTimPh);
            this.Controls.Add(this.buttonSuaP);
            this.Controls.Add(this.buttonXoaP);
            this.Controls.Add(this.dataGridViewPhuong);
            this.Controls.Add(this.buttonThemP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTenP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSDTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMaP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "qlyPhuong";
            this.Text = "qlyPhuong";
            this.Load += new System.EventHandler(this.qlyPhuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMaP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSDTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTenP;
        private System.Windows.Forms.Button buttonThemP;
        private System.Windows.Forms.DataGridView dataGridViewPhuong;
        private System.Windows.Forms.Button buttonXoaP;
        private System.Windows.Forms.Button buttonSuaP;
        private System.Windows.Forms.Button buttonTimPh;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnReset;
    }
}