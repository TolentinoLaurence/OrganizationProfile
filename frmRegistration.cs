using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListofProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            cbProgram.Items.AddRange(ListofProgram);

            string[] ListofGender = new string[]
            {
                "Male",
                "Female"
            };
            cbGender.Items.AddRange(ListofGender);
        }

        public long StudentNumber(string studNum)
        {
            _StudentNo = long.Parse(studNum);
            return _StudentNo;
        }

        public long ContactNo(string contact)
        {
            try
            {
                if (Regex.IsMatch(contact, @"^\d{10,11}$"))
                {
                    _ContactNo = long.Parse(contact);
                }
                else
                {
                    throw new FormatException("Contact number must be 10 or 11 digits.");
                }
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
            return _ContactNo;
        }

        public string FullName(string lastName, string firstName, string middleInitial)
        {
            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(middleInitial))
            {
                throw new ArgumentException("Last name, first name, and middle initial cannot be empty.");
            }

            _FullName = $"{lastName}, {firstName} {middleInitial}";
            return _FullName;
        }

        public int Age(string ageText)
        {
            if (int.TryParse(ageText, out _Age) && _Age >= 0)
            {
                return _Age;
            }
            else
            {
                throw new ArgumentException("Please enter a valid age.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgran = cbProgram.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = dateTimePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frmcon = new frmConfirmation();
                frmcon.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}



