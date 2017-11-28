using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "purchaseorders")]
    public class PurchaseordersBOL : BaseBOL
    {
        private int purchaseOrderID;
        [Help(HelpText = "PrimaryKey")]
        public int PurchaseOrderID { get { return purchaseOrderID; } set { purchaseOrderID = value; } }
        private string supplierID;
        public string SupplierID { get { return supplierID; } set { supplierID = value; } }
        private int employeeID;
        public int EmployeeID { get { return employeeID; } set { employeeID = value; } }
        private DateTime orderDate;
        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }
        private DateTime requiredDate;
        public DateTime RequiredDate { get { return requiredDate; } set { requiredDate = value; } }
        private string shipName;
        public string ShipName { get { return shipName; } set { shipName = value; } }
        private string shipAddress;
        public string ShipAddress { get { return shipAddress; } set { shipAddress = value; } }
        private string shipCity;
        public string ShipCity { get { return shipCity; } set { shipCity = value; } }
        private string shipCountry;
        public string ShipCountry { get { return shipCountry; } set { shipCountry = value; } }
        List<OrdedetailsBOL> lstOrdedetailsBOL = new List<OrdedetailsBOL>();
        [Help(HelpText = "Exclude")]
        public List<OrdedetailsBOL> LstOrdedetailsBOL
        {
            get { return lstOrdedetailsBOL; }
            set { lstOrdedetailsBOL = value; }
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
