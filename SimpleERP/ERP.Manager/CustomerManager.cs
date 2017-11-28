
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public class CustomersManager : BaseManager
    {
        #region properties and variables
        CustomersBLL objBll = new CustomersBLL();
        #endregion
        #region Methods

        public bool Insert(CustomersBOL obj)
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
        public bool Update(CustomersBOL obj)
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
        public bool Delete(CustomersBOL obj)
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
        public DataSet Select(CustomersBOL obj)
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

        
        #endregion
    }
}

