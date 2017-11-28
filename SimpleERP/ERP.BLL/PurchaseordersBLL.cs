using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.DAL;
using ERP.BOL;
using System.Data;

namespace ERP.BLL
{
    public class PurchaseordersBLL : BaseBLL
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
                    qry += "; select LAST_INSERT_ID()";
                    //Int32 primaryID = (int)dbconnect.InsertNonQuery(qry);
                    object o = dbconnect.InsertScalar(qry);
                    //dbconnect.Insert(qry);
                    return Convert.ToInt32(o);
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

