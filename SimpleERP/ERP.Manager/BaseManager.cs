using System.Linq;
using System.Text;
using ERP.BOL;
using ERP.BLL;
using System.Data;

namespace ERP.Manager
{
    public abstract class BaseManager
    {
        #region properties and variables
        public BaseBLL objBLL = new BaseBLL();
        #endregion
        #region Methods
        public bool Insert(BaseBOL obj)
        {
            //if (obj != null)
            //{
            //    try
            //    {
            //        objBLL.InsertSQL(obj);
            //            return true;
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //}
            return false;
        }
        #endregion
    }
}
