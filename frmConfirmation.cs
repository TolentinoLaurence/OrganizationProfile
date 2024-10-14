using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            label1.Text = StudentInformationClass.SetStudentNo.ToString();
            label2.Text = StudentInformationClass.SetFullName;
            label3.Text = StudentInformationClass.SetProgran;
            label4.Text = StudentInformationClass.SetAge.ToString();
            label5.Text = StudentInformationClass.SetBirthday;
            label6.Text = StudentInformationClass.SetGender;
            label7.Text = StudentInformationClass.SetContactNo.ToString();
        }
    }
}
