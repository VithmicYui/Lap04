namespace Lap04
{
    partial class frmFaculty
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
            this.gbTTKhoa = new System.Windows.Forms.GroupBox();
            this.txttongGS = new System.Windows.Forms.TextBox();
            this.txttenkhoa = new System.Windows.Forms.TextBox();
            this.txtmakhoa = new System.Windows.Forms.TextBox();
            this.lbltongGS = new System.Windows.Forms.Label();
            this.lbltenkhoa = new System.Windows.Forms.Label();
            this.lblmakhoa = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvFalculty = new System.Windows.Forms.DataGridView();
            this.makhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenkhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongsoGS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btxoa = new System.Windows.Forms.Button();
            this.btthemsua = new System.Windows.Forms.Button();
            this.btdong = new System.Windows.Forms.Button();
            this.gbTTKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFalculty)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTTKhoa
            // 
            this.gbTTKhoa.Controls.Add(this.txttongGS);
            this.gbTTKhoa.Controls.Add(this.txttenkhoa);
            this.gbTTKhoa.Controls.Add(this.txtmakhoa);
            this.gbTTKhoa.Controls.Add(this.lbltongGS);
            this.gbTTKhoa.Controls.Add(this.lbltenkhoa);
            this.gbTTKhoa.Controls.Add(this.lblmakhoa);
            this.gbTTKhoa.ForeColor = System.Drawing.Color.Blue;
            this.gbTTKhoa.Location = new System.Drawing.Point(12, 12);
            this.gbTTKhoa.Name = "gbTTKhoa";
            this.gbTTKhoa.Size = new System.Drawing.Size(308, 204);
            this.gbTTKhoa.TabIndex = 5;
            this.gbTTKhoa.TabStop = false;
            this.gbTTKhoa.Text = "Thông Tin khoa";
            // 
            // txttongGS
            // 
            this.txttongGS.Location = new System.Drawing.Point(110, 143);
            this.txttongGS.Name = "txttongGS";
            this.txttongGS.Size = new System.Drawing.Size(178, 22);
            this.txttongGS.TabIndex = 5;
            // 
            // txttenkhoa
            // 
            this.txttenkhoa.Location = new System.Drawing.Point(110, 84);
            this.txttenkhoa.Name = "txttenkhoa";
            this.txttenkhoa.Size = new System.Drawing.Size(178, 22);
            this.txttenkhoa.TabIndex = 4;
            // 
            // txtmakhoa
            // 
            this.txtmakhoa.Location = new System.Drawing.Point(110, 27);
            this.txtmakhoa.Name = "txtmakhoa";
            this.txtmakhoa.Size = new System.Drawing.Size(178, 22);
            this.txtmakhoa.TabIndex = 3;
            // 
            // lbltongGS
            // 
            this.lbltongGS.AutoSize = true;
            this.lbltongGS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltongGS.Location = new System.Drawing.Point(19, 149);
            this.lbltongGS.Name = "lbltongGS";
            this.lbltongGS.Size = new System.Drawing.Size(79, 16);
            this.lbltongGS.TabIndex = 2;
            this.lbltongGS.Text = "Tổng số GS";
            // 
            // lbltenkhoa
            // 
            this.lbltenkhoa.AutoSize = true;
            this.lbltenkhoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbltenkhoa.Location = new System.Drawing.Point(19, 90);
            this.lbltenkhoa.Name = "lbltenkhoa";
            this.lbltenkhoa.Size = new System.Drawing.Size(65, 16);
            this.lbltenkhoa.TabIndex = 1;
            this.lbltenkhoa.Text = "Tên Khoa";
            // 
            // lblmakhoa
            // 
            this.lblmakhoa.AutoSize = true;
            this.lblmakhoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblmakhoa.Location = new System.Drawing.Point(19, 33);
            this.lblmakhoa.Name = "lblmakhoa";
            this.lblmakhoa.Size = new System.Drawing.Size(60, 16);
            this.lblmakhoa.TabIndex = 0;
            this.lblmakhoa.Text = "Mã Khoa";
            // 
            // dgvFalculty
            // 
            this.dgvFalculty.AllowUserToAddRows = false;
            this.dgvFalculty.AllowUserToDeleteRows = false;
            this.dgvFalculty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFalculty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.makhoa,
            this.tenkhoa,
            this.tongsoGS});
            this.dgvFalculty.Location = new System.Drawing.Point(326, 21);
            this.dgvFalculty.Name = "dgvFalculty";
            this.dgvFalculty.ReadOnly = true;
            this.dgvFalculty.RowHeadersWidth = 51;
            this.dgvFalculty.RowTemplate.Height = 24;
            this.dgvFalculty.Size = new System.Drawing.Size(508, 285);
            this.dgvFalculty.TabIndex = 8;
            this.dgvFalculty.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFalculty_CellClick);
            // 
            // makhoa
            // 
            this.makhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.makhoa.HeaderText = "Mã Khoa";
            this.makhoa.MinimumWidth = 6;
            this.makhoa.Name = "makhoa";
            this.makhoa.ReadOnly = true;
            // 
            // tenkhoa
            // 
            this.tenkhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tenkhoa.HeaderText = "Tên Khoa";
            this.tenkhoa.MinimumWidth = 6;
            this.tenkhoa.Name = "tenkhoa";
            this.tenkhoa.ReadOnly = true;
            // 
            // tongsoGS
            // 
            this.tongsoGS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tongsoGS.HeaderText = "Tổng số GS";
            this.tongsoGS.MinimumWidth = 6;
            this.tongsoGS.Name = "tongsoGS";
            this.tongsoGS.ReadOnly = true;
            // 
            // btxoa
            // 
            this.btxoa.Location = new System.Drawing.Point(230, 272);
            this.btxoa.Name = "btxoa";
            this.btxoa.Size = new System.Drawing.Size(90, 34);
            this.btxoa.TabIndex = 7;
            this.btxoa.Text = "Xóa";
            this.btxoa.UseVisualStyleBackColor = true;
            this.btxoa.Click += new System.EventHandler(this.btxoa_Click);
            // 
            // btthemsua
            // 
            this.btthemsua.Location = new System.Drawing.Point(79, 272);
            this.btthemsua.Name = "btthemsua";
            this.btthemsua.Size = new System.Drawing.Size(90, 34);
            this.btthemsua.TabIndex = 6;
            this.btthemsua.Text = "Thêm/Sửa";
            this.btthemsua.UseVisualStyleBackColor = true;
            this.btthemsua.Click += new System.EventHandler(this.btthemsua_Click);
            // 
            // btdong
            // 
            this.btdong.Location = new System.Drawing.Point(744, 330);
            this.btdong.Name = "btdong";
            this.btdong.Size = new System.Drawing.Size(90, 34);
            this.btdong.TabIndex = 9;
            this.btdong.Text = "Đóng";
            this.btdong.UseVisualStyleBackColor = true;
            this.btdong.Click += new System.EventHandler(this.btdong_Click);
            // 
            // frmFaculty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 409);
            this.Controls.Add(this.gbTTKhoa);
            this.Controls.Add(this.dgvFalculty);
            this.Controls.Add(this.btxoa);
            this.Controls.Add(this.btthemsua);
            this.Controls.Add(this.btdong);
            this.Name = "frmFaculty";
            this.Text = "frmFaculty";
            this.Load += new System.EventHandler(this.frmFaculty_Load);
            this.gbTTKhoa.ResumeLayout(false);
            this.gbTTKhoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFalculty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTTKhoa;
        private System.Windows.Forms.TextBox txttongGS;
        private System.Windows.Forms.TextBox txttenkhoa;
        private System.Windows.Forms.TextBox txtmakhoa;
        private System.Windows.Forms.Label lbltongGS;
        private System.Windows.Forms.Label lbltenkhoa;
        private System.Windows.Forms.Label lblmakhoa;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvFalculty;
        private System.Windows.Forms.Button btxoa;
        private System.Windows.Forms.Button btthemsua;
        private System.Windows.Forms.Button btdong;
        private System.Windows.Forms.DataGridViewTextBoxColumn makhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenkhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongsoGS;
    }
}