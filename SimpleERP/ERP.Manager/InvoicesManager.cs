﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public class InvoicesManager : BaseManager
    {
        #region properties and variables
        InvoicesBLL objBll = new InvoicesBLL();
        #endregion
        #region Methods

        public bool Insert(InvoicesBOL obj)
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
        public bool Update(InvoicesBOL obj)
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
        public bool Delete(InvoicesBOL obj)
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
        public DataSet Select(InvoicesBOL obj)
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
        public List<InvoicesBOL> LoadInvoicesData(InvoicesBOL obj)
        {
            DataSet dsInvoices = objBll.Select(obj);
            InvoicesBOL objSO = new InvoicesBOL();
            List<InvoicesBOL> lstInvoices = new List<InvoicesBOL>();
            if (dsInvoices != null && dsInvoices.Tables[0] != null && dsInvoices.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsInvoices.Tables[0].Rows)
                {
                    objSO = new InvoicesBOL();
                    objSO.InvoiceID = Convert.ToInt32(dr["InvoiceID"]);
                    objSO.InvoiceNumber = Convert.ToString(dr["InvoiceNumber"]);
                    objSO.InvoiceType = Convert.ToInt32(dr["InvoiceType"]);
                    objSO.OrderID = Convert.ToInt32(dr["OrderID"]);
                    objSO.Refference = Convert.ToString(dr["Refference"]);
                    objSO.PayType = Convert.ToInt32(dr["PayType"]);
                    objSO.ChequeNumber = Convert.ToString(dr["ChequeNumber"]);
                    objSO.TotalAmount = Convert.ToDouble(dr["TotalAmount"]);
                    objSO.OrderAmount = Convert.ToDouble(dr["OrderAmount"]);

                    lstInvoices.Add(objSO);
                }
            }
            return lstInvoices;
        }


        #endregion
    }
}

