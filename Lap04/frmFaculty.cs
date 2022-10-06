using Lap04.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap04
{
    public partial class frmFaculty : Form
    {
        StudentDbContext db = new StudentDbContext();
        public frmFaculty()
        {
            InitializeComponent();
        }

        private void btdong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFaculty_Load(object sender, EventArgs e)
        {
            List<Faculty1> listFaculty = db.Faculty1.ToList();
            FillFalculty(listFaculty);  
        }

        private void FillFalculty(List<Faculty1> listFalcultys)
        {
            dgvFalculty.Rows.Clear();
            foreach (var item in listFalcultys)
            {
                int index = dgvFalculty.Rows.Add();
                dgvFalculty.Rows[index].Cells[0].Value = item.FacultyID;
                dgvFalculty.Rows[index].Cells[1].Value = item.FacultyName;
                dgvFalculty.Rows[index].Cells[2].Value = item.TotalProfessor;
            }
        }

        private void btthemsua_Click(object sender, EventArgs e)
        {
            if(Checkvalidate())
            {
                if(GetSelectedRow(txtmakhoa.Text) == -1)
                {
                    Faculty1 newfaculty = new Faculty1();
                    newfaculty.FacultyID = Convert.ToInt32(txtmakhoa.Text);
                    newfaculty.FacultyName = txttenkhoa.Text;
                    newfaculty.TotalProfessor = Convert.ToInt32(txttongGS.Text);

                    db.Faculty1.AddOrUpdate(newfaculty);
                    db.SaveChanges();

                    loadDgv();
                    loadform();

                    MessageBox.Show($"Thêm khoa {newfaculty.FacultyName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Faculty1 newfaculty = new Faculty1();
                    newfaculty.FacultyID = Convert.ToInt32(txtmakhoa.Text);
                    newfaculty.FacultyName = txttenkhoa.Text;
                    newfaculty.TotalProfessor = Convert.ToInt32(txttongGS.Text);

                    db.Faculty1.AddOrUpdate(newfaculty);
                    db.SaveChanges();

                    loadDgv();
                    loadform();
                    MessageBox.Show($"Chỉnh sữa dữ liệu Khoa{newfaculty.FacultyName} thành công", "Thông Báo", MessageBoxButtons.OK);

                }
            }
        }

        private void loadform()
        {
            txtmakhoa.Clear();
            txttenkhoa.Clear();
            txttongGS.Clear();

        }

        private void loadDgv()
        {
            List<Faculty1> newListFaculty = db.Faculty1.ToList();
            FillFalculty(newListFaculty);
        }
        private int GetSelectedRow(string idnewfalculty)
        {
            int length = dgvFalculty.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvFalculty.Rows[i].Cells[0].Value != null)
                    if (dgvFalculty.Rows[i].Cells[0].Value.ToString() == idnewfalculty)
                        return i;
            }
            return -1;
        }
       private bool Checkvalidate()
        {
            if (txtmakhoa.Text == "" || txttenkhoa.Text == "" || txttongGS.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khoa");
                return false;
            }
            else
            {
                float kq = 0;
                bool ketqua = float.TryParse(txttongGS.Text, out kq);
                if (!ketqua)
                {
                    MessageBox.Show("Tổng số giáo sư chưa đúng!", "Thông Báo", MessageBoxButtons.OK);
                    return false;
                }
            }
            return true;
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            int idKhoa = int.Parse(txtmakhoa.Text);
            Faculty1 deleteFaculty = db.Faculty1.FirstOrDefault(p => p.FacultyID == idKhoa);
            if (deleteFaculty != null)
            {
                DialogResult result = MessageBox.Show($"Bạn có đồng ý xóa Khoa {deleteFaculty.FacultyName} không ?", "Thông báo cho bạn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    db.Faculty1.Remove(deleteFaculty);
                    db.SaveChanges();

                    loadform();
                    loadDgv();

                    MessageBox.Show($"Xóa Khoa {deleteFaculty.FacultyName} thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void dgvFalculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvFalculty.Rows[e.RowIndex];
            txtmakhoa.Text = Convert.ToString(row.Cells["MaKhoa"].Value);
            txttenkhoa.Text = Convert.ToString(row.Cells["TenKhoa"].Value);
            txttongGS.Text = Convert.ToString(row.Cells["TongSoGS"].Value);
        }
    }
}
