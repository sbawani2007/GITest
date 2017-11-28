using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP.BOL;
using ERP.Manager;

namespace WinSimpleERP
{
    public partial class Form1 : Form
    {
        #region Properties and variables
        UsersBOL objUsersBOL = new UsersBOL();
        UsersManager objUsersManager = new UsersManager();
        #endregion
        #region Methods and Events
       
        public void LoadData()
        {
            //gvUsers.DataSource = objUsersManager.Select(new UsersBOL());
            //gvUsers.DataBind();
        }
        public void GetData()
        {
            objUsersBOL = new UsersBOL();
            objUsersBOL.UserName = txtUserName.Text;
            objUsersBOL.FirstName = txtFirstName.Text;
            objUsersBOL.LastName = txtLastName.Text;
            objUsersBOL.CreatedOn = DateTime.Now; //Convert.ToDateTime(txtCreatedOn.Text);
        }
        public void SetData()
        {
            txtUserName.Text = objUsersBOL.UserName;
            txtFirstName.Text = objUsersBOL.FirstName;
            txtLastName.Text = objUsersBOL.LastName;
            //txtCreatedOn.Text = objUsersBOL.CreatedOn.ToShortDateString();
        }
        
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            GC.Collect();
            GetData();
            objUsersManager.Insert(objUsersBOL);
        }

    }
}
