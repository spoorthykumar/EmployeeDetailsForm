using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetailsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            var response = await RestAPIHelper.GetAllEmployees();
            textBoxResult.Text = RestAPIHelper.FormatJson(response);
        }

        private async void btnView_Click(object sender, EventArgs e)
        {
            var response = await RestAPIHelper.ViewEmployee(txtBoxID.Text);
            textBoxResult.Text = RestAPIHelper.FormatJson(response);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var response = await RestAPIHelper.SearchEmployee(txtBoxFirstName.Text);
            textBoxResult.Text = RestAPIHelper.FormatJson(response);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await RestAPIHelper.SearchPage(txtBoxPageNum.Text);
            textBoxResult.Text = RestAPIHelper.FormatJson(response);
        }
    }
}
