
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public class SalesordersManager : BaseManager
    {
        #region properties and variables
        SalesordersBLL objBll = new SalesordersBLL();
        #endregion
        #region Methods

        public int Insert(SalesordersBOL obj)
        {
            if (obj != null)
            {
                try
                {
                    int retVal = objBll.Insert(obj);
                    if (retVal > 0)
                        return retVal;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
        public bool Update(SalesordersBOL obj)
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
        public bool Delete(SalesordersBOL obj)
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
        public DataSet Select(SalesordersBOL obj)
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
        public DataSet SelectCashReport(SalesordersBOL obj)
        {
            try
            {
                DataSet ds = objBll.SelectCashReport(obj);
                return ds;
            }
            catch
            {

            }
            return null;
        }
        public DataSet SelectInventoryReport(SalesordersBOL obj)
        {
            try
            {
                DataSet ds = objBll.SelectInventoryReport(obj);
                return ds;
            }
            catch
            {

            }
            return null;
        }
        public List<SalesordersBOL> LoadSalesOrdersData(SalesordersBOL obj)
        {
            DataSet dsSalesOrder = objBll.Select(obj);
            SalesordersBOL objSO = new SalesordersBOL();
            List<SalesordersBOL> lstSalesordersBOL = new List<SalesordersBOL>();
            if (dsSalesOrder != null && dsSalesOrder.Tables[0] != null && dsSalesOrder.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsSalesOrder.Tables[0].Rows)
                {
                    objSO = new SalesordersBOL();
                    objSO.CustomerID = Convert.ToString(dr["CustomerID"]);
                    objSO.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    objSO.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                    objSO.RequiredDate = Convert.ToDateTime(dr["RequiredDate"]);
                    objSO.SalesOrderID = Convert.ToInt32(dr["SalesOrderID"]);
                    objSO.ShipAddress = Convert.ToString(dr["ShipAddress"]);
                    objSO.ShipCity = Convert.ToString(dr["ShipCity"]);
                    objSO.ShipCountry = Convert.ToString(dr["ShipCountry"]);
                    objSO.ShipName = Convert.ToString(dr["ShipName"]);
                    lstSalesordersBOL.Add(objSO);
                }
            }
            return lstSalesordersBOL;
        }

        #endregion
    }
}

