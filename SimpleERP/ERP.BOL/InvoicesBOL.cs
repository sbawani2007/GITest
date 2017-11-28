using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "invoices")]
    public class InvoicesBOL : BaseBOL
    {
        private int invoiceID;
        [Help(HelpText = "PrimaryKey")]
        public int InvoiceID { get { return invoiceID; } set { invoiceID = value; } }
        private string invoiceNumber;
        public string InvoiceNumber { get { return invoiceNumber; } set { invoiceNumber = value; } }
        private int invoiceType;
        public int InvoiceType { get { return invoiceType; } set { invoiceType = value; } }
        private int orderID;
        public int OrderID { get { return orderID; } set { orderID = value; } }
        private string refference;
        public string Refference { get { return refference; } set { refference = value; } }
        private int payType;
        public int PayType { get { return payType; } set { payType = value; } }
        private string chequeNumber;
        public string ChequeNumber { get { return chequeNumber; } set { chequeNumber = value; } }
        private double totalAmount;
        public double TotalAmount { get { return totalAmount; } set { totalAmount = value; } }
        private double orderAmount;
        public double OrderAmount { get { return orderAmount; } set { orderAmount = value; } }
        DateTime invoiceDate;
        public DateTime InvoiceDate { get { return invoiceDate; } set { invoiceDate = value; } }
    }
}
