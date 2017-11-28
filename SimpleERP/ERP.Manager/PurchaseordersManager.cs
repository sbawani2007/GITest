
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public class PurchaseordersManager : BaseManager
    {
        #region properties and variables
        PurchaseordersBLL objBll = new PurchaseordersBLL();
        #endregion
        #region Methods

        public Int32 Insert(PurchaseordersBOL obj)
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
        public bool Update(PurchaseordersBOL obj)
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
        public bool Delete(PurchaseordersBOL obj)
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
        public DataSet Select(PurchaseordersBOL obj)
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
        public List<PurchaseordersBOL> LoadPurchaseordersData(PurchaseordersBOL obj)
        {
            DataSet dsPurchaseorders = objBll.Select(obj);
            PurchaseordersBOL objSO = new PurchaseordersBOL();
            List<PurchaseordersBOL> lstPurchaseorders = new List<PurchaseordersBOL>();
            if (dsPurchaseorders != null && dsPurchaseorders.Tables[0] != null && dsPurchaseorders.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsPurchaseorders.Tables[0].Rows)
                {
                    objSO = new PurchaseordersBOL();
                    objSO.PurchaseOrderID = Convert.ToInt32(dr["PurchaseOrderID"]);
                    objSO.SupplierID = Convert.ToString(dr["SupplierID"]);
                    objSO.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                    objSO.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                    objSO.RequiredDate = Convert.ToDateTime(dr["RequiredDate"]);
                    objSO.ShipName = Convert.ToString(dr["ShipName"]);
                    objSO.ShipAddress = Convert.ToString(dr["ShipAddress"]);
                    objSO.ShipCity = Convert.ToString(dr["ShipCity"]);
                    objSO.ShipCountry = Convert.ToString(dr["ShipCountry"]);
                    lstPurchaseorders.Add(objSO);
                }
            }
            return lstPurchaseorders;
        }

        #endregion
    }
}

