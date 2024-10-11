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
            for (int i = 0; i < 6; i++)
            {
                cbProgram.Items.Add(cbProgram.Items[i].ToString());
            }

            string[] ListofGender = new string[]
            {
                "Male",
                "Female"
            };
            for (int i = 0; i < 2; i++)
            {
                cbGender.Items.Add(ListofGender[i].ToString());
            }
        }

        public long StudentNumber(string studNum)
        {
            _StudentNo = long.Parse(studNum);
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"*[0-9]{10,11}"))
                {
                    _ContactNo = long.Parse(Contact)
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                Console.WriteLine("Input 11 index only");
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (!Regex.IsMatch(LastName, @"^(a-zA-Z)+$") || !Regex.IsMatch(FirstName, @"^(a-zA-Z)+$") || Regex.IsMatch(MiddleInitial, @"^(a-zA-Z)+$"))
                {
                    _FullName = LastName + "," + FirstName + "," + MiddleInitial;
                }
                else
                {
                    throw new IndexOutOfRangeException("LastName, FirstName and ");
                }
            }
        }
    }
}
