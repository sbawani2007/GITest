using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "products")]
    public class ProductsBOL : BaseBOL
    {
        private int productID;
        [Help(HelpText = "PrimaryKey")]
        public int ProductID { get { return productID; } set { productID = value; } }
        private string productName;
        public string ProductName { get { return productName; } set { productName = value; } }
        private int supplierID;
        public int SupplierID { get { return supplierID; } set { supplierID = value; } }
        private int categoryID;
        public int CategoryID { get { return categoryID; } set { categoryID = value; } }
        private string quantityPerUnit;
        public string QuantityPerUnit { get { return quantityPerUnit; } set { quantityPerUnit = value; } }
        decimal unitPrice;
        public decimal UnitPrice { get { return unitPrice; } set { unitPrice = value; } }
        private int unitsInStock;
        public int UnitsInStock { get { return unitsInStock; } set { unitsInStock = value; } }
        private int unitsOnOrder;
        public int UnitsOnOrder { get { return unitsOnOrder; } set { unitsOnOrder = value; } }
        private int reorderLevel;
        public int ReorderLevel { get { return reorderLevel; } set { reorderLevel = value; } }
        private int discontinued;
        public int Discontinued { get { return discontinued; } set { discontinued = value; } }
    }
}

