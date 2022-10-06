using Lap04.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lap04
{
    public partial class SearchStudent : Form
    {
        StudentDbContext db = new StudentDbContext();
        public SearchStudent()
        {
            InitializeComponent();
        }

        private void BindGrid(List<Student1> listStudent)
        {
            dgvTimKiem.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvTimKiem.Rows.Add();
                dgvTimKiem.Rows[index].Cells[0].Value = item.StudentID;
                dgvTimKiem.Rows[index].Cells[1].Value = item.FullName;
                dgvTimKiem.Rows[index].Cells[2].Value = item.Faculty1.FacultyName;
                dgvTimKiem.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }
        private void FillFalcultyCombobox(List<Faculty1> listFalculty)
        {
            this.cbKhoa.DataSource = listFalculty;
            this.cbKhoa.DisplayMember = "FacultyName";
            this.cbKhoa.ValueMember = "FacultyID";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //List<Student1> listStudent = db.Student1.ToList();
            //if (txtMSSV.Text == "" || txtHoTen.Text == "")
            //{
            //    List<Student1> listFindStudent = (from s in listStudent
            //                                     where
            //                s.StudentID == txtMSSV.Text ||
            //                s.FullName == txtHoTen.Text ||
            //                s.Faculty1.FacultyID == Convert.ToInt32(cbKhoa.SelectedValue)
            //                                     select s).ToList();
            //    txtKetQua.Text = (listFindStudent.Count).ToString();
            //    BindGrid(listFindStudent);
            //}
            //if (txtMSSV.Text != "" || txtHoTen.Text != "")
            //{
            //    List<Student1> listFindStudent2 = (from s in listStudent
            //                                      where
            //                s.StudentID == txtMSSV.Text ||
            //                s.FullName == txtHoTen.Text
            //                                      select s).ToList();
            //    txtKetQua.Text = (listFindStudent2.Count).ToString();
            //    BindGrid(listFindStudent2);
            //}

            //if (false)
            //{
            //    List<Student1> listFindStudent3 = (from s in listStudent
            //                                      where
            //                 s.StudentID == txtMSSV.Text ||
            //                 s.FullName == txtHoTen.Text ||
            //                 s.Faculty1.FacultyID == Convert.ToInt32(cbKhoa.SelectedValue)
            //                                      select s).ToList();
            //    txtKetQu a.Text = (listFindStudent3.Count).ToString();
            //    BindGrid(listFindStudent3);
            //}
            List<Student1> result = db.Student1.Where(x => x.FullName.Contains(txtHoTen.Text) && x.StudentID.Contains(txtMSSV.Text) && x.FacultyID == (int)cbKhoa.SelectedValue).ToList();
            dgvTimKiem.DataSource = result.Select(x => new
            {
                
                StudentID = x.StudentID,
                FullName = x.FullName,
                FacultyName = x.Faculty1.FacultyName,
                AverageScore = x.AverageScore,
                
            }).ToList();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtMSSV.Focus();
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnTimKiem.PerformClick();
        }

        private void txtMSSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnTimKiem.PerformClick();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            List<Faculty1> listFalcultys = db.Faculty1.ToList();
            List<Student1> listStudent = db.Student1.ToList();
            FillFalcultyCombobox(listFalcultys);
            BindGrid(listStudent);
            txtKetQua.Text = "0";
        }

        private void dgvTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvTimKiem.Rows[e.RowIndex];
            txtMSSV.Text = Convert.ToString(row.Cells["MSSV"].Value);
            txtHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value);
        }
    }
}
