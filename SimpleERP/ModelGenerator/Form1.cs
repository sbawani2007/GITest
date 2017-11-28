using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP.DAL;
using System.IO;

namespace ModelGenerator
{
    public partial class Form1 : Form
    {
        #region properties and variables
        DBConnect dbconnect = new DBConnect();
        string template = @"";
        string tableName = "users";
        string GClassName = "Users";
        #endregion
        public Form1()
        {
            InitializeComponent();
            LoadTables();
        }
        public void LoadTables()
        {
            #region code
            DataSet ds = dbconnect.Select("SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'simpleerp'");
            cmbEntity.DisplayMember = "TABLE_NAME";
            cmbEntity.ValueMember = "TABLE_NAME";
            cmbEntity.DataSource = ds.Tables[0];
            
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region code
            string template = string.Empty;
            //tableName = "users";
            string className = GClassName + "BOL";
            string bol = "BOL";
            string bll = "BLL";
            DataSet ds = dbconnect.Select("SHOW COLUMNS FROM " + tableName);
            string path = className + ".txt";
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                //generate BOL
                StringBuilder sb = new StringBuilder();
                sb.Append(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

                        namespace ERP.BOL
                        {
                            [Help(HelpText = """);
                sb.Append(tableName);
                sb.Append(@""" )]
                            public class " + className + @" :BaseBOL
                            {");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    //private
                    if (Convert.ToString(dr["Type"]).Contains("int"))
                    {
                        sb.Append("private int ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("varchar"))
                    {
                        sb.Append("private string ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("datetime"))
                    {
                        sb.Append("private DateTime ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("decimal"))
                    {
                        sb.Append("private decimal ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("double"))
                    {
                        sb.Append("private double ");
                    }
                    sb.Append(Convert.ToString(dr["Field"]));
                    sb.Append(";");
                    sb.Append(System.Environment.NewLine);
                    //public
                    if ((Convert.ToString(dr["Key"]).Contains("PRI")))
                    {
                        sb.Append(@"[Help(HelpText = """);
                        sb.Append(@"PrimaryKey""");
                        sb.Append(")]");
                    }
                    if (Convert.ToString(dr["Type"]).Contains("int"))
                    {
                        sb.Append("public int ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("varchar"))
                    {
                        sb.Append("public string ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("datetime"))
                    {
                        sb.Append("public DateTime ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("decimal"))
                    {
                        sb.Append("public decimal ");
                    }
                    else if (Convert.ToString(dr["Type"]).Contains("double"))
                    {
                        sb.Append("public double ");
                    }
                    //sb.Append("Prp_");
                    string propertyName = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                    sb.Append(Convert.ToString(propertyName));
                    sb.Append("{");
                    sb.Append(" get { return " + Convert.ToString(dr["Field"]) + "; }");
                    sb.Append(" set { " + Convert.ToString(dr["Field"]) + " = value; }");
                    sb.Append("}");
                    sb.Append(System.Environment.NewLine);
                }
                sb.Append(@"}
                    }");
                template = sb.ToString();
                string createText = template + Environment.NewLine;
                File.WriteAllText(path, createText);
                MessageBox.Show(className + ".cs generated successfully");
            }
            #endregion
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region code
            string template = string.Empty;
            string className = GClassName + "BLL";
            string path = className + ".txt";
            {
                //generate BOL
                StringBuilder sb = new StringBuilder();
                sb.Append(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.DAL;
using ERP.BOL;
using System.Data;

namespace ERP.BLL
{
    public class " + className + @":BaseBLL
    {
        #region properties and variables        
        DAL.DBConnect dbconnect = new DBConnect();       

        #endregion

        #region methods
        
        public Int32 Insert(BOL.BaseBOL obj)
        {            
            if (obj != null)
            {
                try
                {
                    string qry = this.InsertSQL(obj);
                    dbconnect.Insert(qry);
                    return 1;
                }
                catch
                {

                }
            }
            return 0;
        }
        public Int32 Update(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                try
                {
                    string qry = this.UpdateSQL(obj);
                    dbconnect.Update(qry);
                    return 1;
                }
                catch
                {

                }
            }
            return 0;
        }

        public Int32 Delete(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                try
                {
                    string qry = this.DeleteSQL(obj);
                    dbconnect.Delete(qry);
                    return 1;
                }
                catch
                {

                }
            }
            return 0;
        }
        public DataSet Select(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                string qry = this.SelectSQL(obj);
                return dbconnect.Select(qry.ToString());

            }
            return null;
        }
        #endregion
    }
}
");
                template = sb.ToString();
                string createText = template + Environment.NewLine;
                File.WriteAllText(path, createText);
                MessageBox.Show(className + ".cs generated successfully");
            }
            #endregion

        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region code
            string template = string.Empty;
            string pClassName = GClassName;
            string className = GClassName + "Manager";
            string path = className + ".txt";
            {
                //generate BOL
                StringBuilder sb = new StringBuilder();
                sb.Append(@"
                               using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public class "+className+@":BaseManager
    {
        #region properties and variables
        " + pClassName + @"BLL objBll = new " + pClassName + @"BLL();
        #endregion
        #region Methods

        public bool Insert("+pClassName+@"BOL obj)
        {            
            if (obj != null)
            {
                try
                {
                    int retVal = objBll.Insert(obj);                    
                    if (retVal > 0)
                        return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool Update("+pClassName+@"BOL obj)
        {
            if (obj != null)
            {
                try
                {
                    int retVal = objBll.Update(obj);
                    if (retVal > 0)
                        return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool Delete("+pClassName+@"BOL obj)
        {
            if (obj != null)
            {
                try
                {
                    int retVal = objBll.Delete(obj);
                    if (retVal > 0)
                        return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public DataSet Select("+pClassName+@"BOL obj)
        {
            try
            {
                DataSet ds = objBll.Select(obj);
                return ds;
            }
            catch
            {

            }
            return null;
        }
        public List<"+pClassName+@"BOL> Load"+pClassName+@"Data("+pClassName+@"BOL obj)
        {
            DataSet ds"+pClassName+@" = objBll.Select(obj);
            "+pClassName+@"BOL objSO = new "+pClassName+@"BOL();
            List<"+pClassName+@"BOL> lst"+pClassName+@" = new List<"+pClassName+@"BOL>();
            if (ds"+pClassName+@" != null && ds"+pClassName+@".Tables[0] != null && ds"+pClassName+@".Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds"+pClassName+@".Tables[0].Rows)
                {
                    objSO = new "+pClassName+@"BOL();");
                    
                
                    //objSO.CustomerID = Convert.ToString(dr[""CustomerID""]);
                DataSet ds = dbconnect.Select("SHOW COLUMNS FROM " + tableName);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        string propertyName = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        sb.Append(Environment.NewLine);
                        if (Convert.ToString(dr["Type"]).Contains("int"))
                        {
                            sb.Append("objSO." + propertyName + @" =  Convert.ToInt32(dr["""); 
                            sb.Append(propertyName + @"""");
                            sb.Append("]);");
                        }
                        else if (Convert.ToString(dr["Type"]).Contains("varchar"))
                        {
                            sb.Append("objSO." + propertyName + @" =  Convert.ToString(dr[""");
                            sb.Append(propertyName + @"""");
                            sb.Append("]);");
                        }
                        else if (Convert.ToString(dr["Type"]).Contains("datetime"))
                        {
                            sb.Append("objSO." + propertyName + @" =  Convert.ToDateTime(dr[""");
                            sb.Append(propertyName + @"""");
                            sb.Append("]);");                            
                        }
                        else if (Convert.ToString(dr["Type"]).Contains("decimal"))
                        {
                            sb.Append("objSO." + propertyName + @" =  Convert.ToDecimal(dr[""");
                            sb.Append(propertyName + @"""");
                            sb.Append("]);");                            
                        }
                        else if (Convert.ToString(dr["Type"]).Contains("double"))
                        {
                            sb.Append("objSO." + propertyName + @" =  Convert.ToDouble(dr[""");
                            sb.Append(propertyName + @"""");
                            sb.Append("]);");                            
                        }
                    }
                }
                sb.Append(@"   
                    lst" + pClassName + @".Add(objSO);
                }
            }
            return lst" + pClassName + @";
        }

        
        #endregion
    }
}
 ");
                template = sb.ToString();
                string createText = template + Environment.NewLine;
                File.WriteAllText(path, createText);
                MessageBox.Show(className + ".cs generated successfully");

            }
            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region code
            string template = string.Empty;
            //string tableName = "users";
            string className = GClassName;
            DataSet ds = dbconnect.Select("SHOW COLUMNS FROM " + tableName);
            string path = className + "_aspx.txt";
            string primaryKey = string.Empty;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                //generate BOL
                StringBuilder sb = new StringBuilder();
                sb.Append(@"<form id=""form1"" runat=""server"">
                                <div>
                                    <table>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!(Convert.ToString(dr["Key"]).Contains("PRI")))
                    {
                        dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        sb.Append(@"<tr>
                            <td>" + dr["Field"].ToString() + @":</td>
                            <td><asp:TextBox ID=""" + "txt" + dr["Field"].ToString() + @""" runat=""server""></asp:TextBox></td>
                            </tr>");
                    }
                    else
                    {
                        dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        primaryKey = dr["Field"].ToString();
                    }
                }
                sb.Append(@" <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID=""btnSubmit"" runat=""server"" Text=""Submit"" OnClick=""btnSubmit_Click"" /></td>
                                </tr>");
                sb.Append(@"</table>
                                </div>");
                sb.Append(@"<div>
            <asp:GridView ID=""gv" +className+ @""" runat=""server"" AutoGenerateColumns=""false"" DataKeyNames=""" + primaryKey + @""">
                <Columns>");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                    sb.Append(@"<asp:BoundField DataField=""" + dr["Field"].ToString() + @""" HeaderText=""" + dr["Field"].ToString() + @""" ItemStyle-Width=""100"" />");
                }
                sb.Append(@" </Columns>
                            </asp:GridView>
                        </div>
                    </form>");


                template = sb.ToString();
                string createText = template + Environment.NewLine;
                File.WriteAllText(path, createText);
                MessageBox.Show(className + " generated successfully");
            }
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            #region code
            string template = string.Empty;
            //string tableName = "users";
            string className = GClassName;
            string objClassName = "obj" + className;
            DataSet ds = dbconnect.Select("SHOW COLUMNS FROM " + tableName);
            string path = className + "_aspx_cs.txt";
            string primaryKey = string.Empty;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                //generate BOL
                StringBuilder sb = new StringBuilder();
                sb.Append(@" #region Properties and variables
        " + className + @"BOL " + objClassName + @"BOL = new " + className + @"BOL();
       " + className + @"Manager " + objClassName + @"Manager = new " + className + @"Manager();
        #endregion");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!(Convert.ToString(dr["Key"]).Contains("PRI")))
                    {
                        dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        sb.Append(@"");
                    }
                    else
                    {
                        dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        primaryKey = dr["Field"].ToString();
                    }
                }
                sb.Append(Environment.NewLine);
                sb.Append(@"#region Methods and Events
                        protected void Page_Load(object sender, EventArgs e)
                        {                            
                            if (!Page.IsPostBack)
                                LoadData();
                        }");
                sb.Append(@" public void LoadData()
                            {
                                gv" + className + @".DataSource = " + objClassName + @"Manager.Select(new " + className + @"BOL());
                                gv" + className + @".DataBind();
                            }");
                sb.Append(@"public void GetData()
                                {          ");

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!(Convert.ToString(dr["Key"]).Contains("PRI")))
                    {
                        dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        if (Convert.ToString(dr["Type"]).Contains("int"))
                        {
                            sb.Append(@"" + objClassName + @"BOL." + dr["Field"].ToString() + " = Convert.ToInt32( txt" + dr["Field"].ToString() + ".Text);");
                            sb.Append(Environment.NewLine);
                        }
                        if (Convert.ToString(dr["Type"]).Contains("decimal"))
                        {
                            sb.Append(@"" + objClassName + @"BOL." + dr["Field"].ToString() + " = Convert.ToDecimal( txt" + dr["Field"].ToString() + ".Text);");
                            sb.Append(Environment.NewLine);
                        }
                        if (Convert.ToString(dr["Type"]).Contains("double"))
                        {
                            sb.Append(@"" + objClassName + @"BOL." + dr["Field"].ToString() + " = Convert.ToDouble( txt" + dr["Field"].ToString() + ".Text);");
                            sb.Append(Environment.NewLine);
                        }
                        if (Convert.ToString(dr["Type"]).Contains("varchar") || Convert.ToString(dr["Type"]).Contains("text") || Convert.ToString(dr["Type"]).Contains("date"))
                        {
                            sb.Append(@"" + objClassName + @"BOL." + dr["Field"].ToString() + " = Convert.ToString( txt" + dr["Field"].ToString() + ".Text);");
                            sb.Append(Environment.NewLine);
                        }
                            
                    }                   
                }
                sb.Append(@"}
                        public void SetData()
                        {");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (!(Convert.ToString(dr["Key"]).Contains("PRI")))
                    {
                        dr["Field"] = dr["Field"].ToString().First().ToString().ToUpper() + dr["Field"].ToString().Substring(1, dr["Field"].ToString().Length - 1);
                        sb.Append("txt" + dr["Field"].ToString() + ".Text = Convert.ToString( " + objClassName + @"BOL." + dr["Field"].ToString() + ");");
                        sb.Append(Environment.NewLine);
                    }
                }
                sb.Append(@"}
                            protected void btnSubmit_Click(object sender, EventArgs e)
                            {
                                GetData();
                                " + objClassName + @"Manager.Insert(" + objClassName + @"BOL);
                                LoadData();
                            }");
                sb.Append(Environment.NewLine);
                sb.Append("#endregion");
                template = sb.ToString();
                string createText = template + Environment.NewLine;
                File.WriteAllText(path, createText);
                MessageBox.Show(className + " generated successfully");
            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableName = cmbEntity.SelectedValue.ToString();
            GClassName = cmbEntity.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(GClassName))
                GClassName = GClassName.First().ToString().ToUpper() + GClassName.Substring(1, GClassName.Length - 1);

        }
    }
}

