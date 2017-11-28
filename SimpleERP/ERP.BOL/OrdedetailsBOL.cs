using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "ordedetails")]
    public class OrdedetailsBOL : BaseBOL , ICloneable
    {
        private int orderDetailID;
        [Help(HelpText = "PrimaryKey")]
        public int OrderDetailID { get { return orderDetailID; } set { orderDetailID = value; } }
        private int orderID;
        public int OrderID { get { return orderID; } set { orderID = value; } }
        private int productID;
        public int ProductID { get { return productID; } set { productID = value; } }
        private decimal unitPrice;
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
        private int quantity;
        public int Quantity { get { return quantity; } set { quantity = value; } }
        private double discount;
        public double Discount { get { return discount; } set { discount = value; } }
        private int orderType;
        public int OrderType { get { return orderType; } set { orderType = value; } }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
