using SM.SA.Domain.Entities;
using SM.SA.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace SM.SA.WithPrinciples
{
    public partial class Form1 : Form
    {
        private readonly IStudentService _studentService;
        public Form1(IStudentService studentService)
        {
            InitializeComponent();
            _studentService = studentService;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            var tmp = _studentService.FindStudent(NameTextBox.Text.Trim());
            if (tmp != null)
            {
                IdTextBox.Text = tmp.Id.ToString();
                NameTextBox.Text = tmp.Name.ToString();
                DoBDateTimePicker.Value = tmp.DOB;
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {

            Student s = new Student
            {
                Name = NameTextBox.Text.Trim(),
                DOB = DoBDateTimePicker.Value
            };

            try
            {
                _studentService.SaveStudent(s);

                ResetForm();
                LoadAllStudents();
            }
            catch (Exception)
            {

                MessageBox.Show("حدث خطأ في حفظ البيانات الرجاء اعادة المحاولة");
                ResetForm();
            }

        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var tmp = _studentService.FindStudent(NameTextBox.Text.Trim());
            if (tmp != null)
            {
                _studentService.DeleteStudent(tmp);
                ResetForm();
                LoadAllStudents();
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
            StudentsDataGridView.DataSource = _studentService.GetAllStudents();
        }


    }
}
