using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM.SA.NoPrinciples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            using (var db = new SAContext())
            {
                var tmp = db.Students.FirstOrDefault(x=>x.Name.Contains(NameTextBox.Text.Trim()));
                if (tmp != null)
                {
                    IdTextBox.Text = tmp.Id.ToString();
                    NameTextBox.Text = tmp.Name.ToString();
                    DoBDateTimePicker.Value = tmp.DOB;
                }
                else
                {
                    MessageBox.Show("لا يوجد طالب بهذا الاسم.");
                }

            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var db = new SAContext())
            {
                Student s = new Student
                {
                    Name = NameTextBox.Text.Trim(),
                    DOB = DoBDateTimePicker.Value
                };
                db.Students.Add(s);
                try
                {
                    db.SaveChanges();

                    ResetForm();
                    LoadAllStudents();
                }
                catch (Exception)
                {

                    MessageBox.Show("حدث خطأ في حفظ البيانات الرجاء اعادة المحاولة");
                   ResetForm();
                }

            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            using (var db = new SAContext())
            {
                var id = int.Parse(IdTextBox.Text);
                var tmp = db.Students.FirstOrDefault(x=>x.Id == id);
                if (tmp != null)
                {
                    db.Students.Remove(tmp);
                    db.SaveChanges() ;
                    ResetForm();
                    LoadAllStudents();
                }
            }
        }
        private void ResetForm()
        {
            IdTextBox.Text = string.Empty;
            NameTextBox.Text = string.Empty;
            DoBDateTimePicker.Value = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllStudents();
        }

        private void LoadAllStudents()
        {
            using (var db = new SAContext())
            {
                var tmp = db.Students.ToList();
                StudentsDataGridView.DataSource = tmp;
            }
        }
    }
}
