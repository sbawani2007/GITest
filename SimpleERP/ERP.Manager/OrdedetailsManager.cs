
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public class OrdedetailsManager : BaseManager
    {
        #region properties and variables
        OrdedetailsBLL objBll = new OrdedetailsBLL();
        #endregion
        #region Methods

        public bool Insert(OrdedetailsBOL obj)
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
        public bool Update(OrdedetailsBOL obj)
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
        public bool Delete(OrdedetailsBOL obj)
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
        public DataSet Select(OrdedetailsBOL obj)
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
        public List<OrdedetailsBOL> LoadOrdedetailsData(OrdedetailsBOL obj)
        {
            DataSet dsOrdedetails = objBll.Select(obj);
            OrdedetailsBOL objSO = new OrdedetailsBOL();
            List<OrdedetailsBOL> lstOrdedetails = new List<OrdedetailsBOL>();
            if (dsOrdedetails != null && dsOrdedetails.Tables[0] != null && dsOrdedetails.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsOrdedetails.Tables[0].Rows)
                {
                    objSO = new OrdedetailsBOL();
                    objSO.OrderDetailID = Convert.ToInt32(dr["OrderDetailID"]);
                    objSO.OrderID = Convert.ToInt32(dr["OrderID"]);
                    objSO.ProductID = Convert.ToInt32(dr["ProductID"]);
                    objSO.UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
                    objSO.Quantity = Convert.ToInt32(dr["Quantity"]);
                    objSO.Discount = Convert.ToDouble(dr["Discount"]);
                    objSO.OrderType = Convert.ToInt32(dr["OrderType"]);
                    lstOrdedetails.Add(objSO);
                }
            }
            return lstOrdedetails;
        }


        #endregion
    }
}
 

