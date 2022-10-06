using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lap04.Model;
namespace Lap04
{
    public partial class frmStudent : Form
    {
        StudentDbContext db;
        

        public frmStudent()
        {
            InitializeComponent();
            db = new StudentDbContext();
        }

        


        private int GetSelectedRow(string studentID)
        {
            for(int i = 0; i<dgvStudent.Rows.Count; i++)
            {
                if (dgvStudent.Rows[i].Cells[0].Value.ToString() == studentID)
                {
                    return i;
                }
            }
            return -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckValidate())
            {
                if(GetSelectedRow(txtMssv.Text) == -1)
                {
                    Student1 newStudent = new Student1();
                    {
                        newStudent.StudentID = txtMssv.Text;
                        newStudent.FullName = txtName.Text;
                        newStudent.AverageScore = Convert.ToDouble(txtScore.Text);
                        newStudent.FacultyID = Convert.ToInt32(cmbKhoa.SelectedValue.ToString());
                    };
                    db.Student1.AddOrUpdate(newStudent);
                    db.SaveChanges();
                    loadDgv();
                    loadform();
                    MessageBox.Show($"Thêm sinh viên {newStudent.FullName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MessageBox.Show($"Sinh viên có mã số {txtMssv.Text} đã tồn tại!", "Thông báo", MessageBoxButtons.OK);
                  
                }

            }
            

            //var studentdb = db.student1.firstordefault(c => c.studentid == txtmssv.text);
            //if (studentdb == null)
            //{
            //    student1 newstudent = new student1();
            //    newstudent.studentid = txtmssv.text;
            //    newstudent.fullname = txtname.text;
            //    newstudent.facultyid = (int)combobox1.selectedvalue;


            //    float parsefloat = 0;
            //    bool successful = float.tryparse(txtscore.text, out parsefloat);

            //    if (successful)
            //    {
            //        newstudent.averagescore = parsefloat;
            //    }

            //    db.student1.add(newstudent);

            //    db.savechanges();
            //    refreshdatagridview();
            //}
            //else
            //{
            //    studentDb.FullName = txtName.Text;
            //    studentDb.FacultyID = (int)comboBox1.SelectedValue;
            //    MessageBox.Show("Thêm Sinh Viên Thành Công");
            //}
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                StudentDbContext db = new StudentDbContext();
                List<Student1> listStudent = db.Student1.ToList();
                List<Faculty1> listFaculty = db.Faculty1.ToList();
                FillFacultyCmb(listFaculty);
                BindGrid(listStudent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillFacultyCmb(List<Faculty1> listFaculty)
        {
            this.cmbKhoa.DataSource = listFaculty;
            this.cmbKhoa.DisplayMember = "FacultyName";
            this.cmbKhoa.ValueMember = "FacultyID";
        }
        private void loadform()
        {
            txtMssv.Clear();
            txtName.Clear();
            txtScore.Clear();
        }
        private void BindGrid(List<Student1> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach(var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                dgvStudent.Rows[index].Cells[2].Value = item.Faculty1.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }
        private void loadDgv()
        {
            List < Student1 > newListSudent = db.Student1.ToList();
            BindGrid(newListSudent);
        }
        //private void RefreshDatagridview()
        //{
        //    dgvStudent.DataSource = db.Student1.Select(c => new
        //    {
        //        StudentID = c.StudentID,
        //        FullName = c.FullName,
        //        FacultyName = c.Faculty1.FacultyName,
        //        AverageScore = c.AverageScore,

        //    }).ToList();
        //    comboBox1.DataSource = db.Faculty1.ToList();
        //    comboBox1.DisplayMember = "FacultyName";
        //    comboBox1.ValueMember = "FacultyID";
        //}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(CheckValidate())
            {
                Student1 dbUpdate = db.Student1.FirstOrDefault(p => p.StudentID == txtMssv.Text);
                if (dbUpdate != null)
                {
                    dbUpdate.FullName = txtName.Text;
                    dbUpdate.AverageScore = double.Parse(txtScore.Text);
                    dbUpdate.FacultyID = Convert.ToInt32(cmbKhoa.SelectedValue.ToString());

                    db.SaveChanges();
                    reloadDgv();
                    refresh();
                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy MSSV cần sửa!", "Thông báo", MessageBoxButtons.OK);

                }
            }
        }


        private void reloadDgv()
        {
            List<Student1> listStudent = db.Student1.ToList();
            BindGrid(listStudent);
        }

        private void refresh()
        {
            txtMssv.Text = "";
            txtName.Text = "";
            txtScore.Text = "";
            cmbKhoa.SelectedIndex = 0;
        }
        private bool CheckValidate()
        {
            if (txtMssv.Text == "" || txtName.Text == "" | txtScore.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            else if(txtMssv.TextLength != 10)
                {
                MessageBox.Show("Mã số sinh viên phải 10 ký tự", "Thông Báo", MessageBoxButtons.OK);
                return false;
            }
            else
            {
                float kq = 0;
                bool ketqua = float.TryParse(txtScore.Text, out kq);
                if (!ketqua)
                {
                    MessageBox.Show("điểm sinh viên chưa đúng!", "Thông Báo", MessageBoxButtons.OK);
                    return false;
                }

                return true;
            }
               

            }

        private void button3_Click(object sender, EventArgs e)
        {

            Student1 dbDelete = db.Student1.FirstOrDefault(p => p.StudentID == txtMssv.Text);
            if(dbDelete != null)
            {
                db.Student1.Remove(dbDelete);
                db.SaveChanges();
                reloadDgv();
                refresh();
                MessageBox.Show("Xoá sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Không tìm thấy MSSV cần xoá!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvStudent.CurrentRow.Selected = true;

                    txtMssv.Text = dgvStudent.Rows[e.RowIndex].Cells["StudentID"].FormattedValue.ToString();
                    txtName.Text = dgvStudent.Rows[e.RowIndex].Cells["FullName"].FormattedValue.ToString();
                    txtScore.Text = dgvStudent.Rows[e.RowIndex].Cells["AverageScore"].FormattedValue.ToString();
                    cmbKhoa.SelectedIndex = cmbKhoa.FindString(dgvStudent.Rows[e.RowIndex].Cells["FacultyName"].FormattedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmFaculty qlKhoa = new frmFaculty();
            qlKhoa.ShowDialog();
            Close();
        }

        private void tsTimKiem_Click(object sender, EventArgs e)
        {
            SearchStudent tk = new SearchStudent();
            tk.ShowDialog();
            Close();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaculty ql = new frmFaculty();
            ql.ShowDialog();
            Close();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchStudent tk = new SearchStudent();
            tk.ShowDialog();
            Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiem_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl1_Click(object sender, EventArgs e)
        {

        }

        private void txtMssv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
