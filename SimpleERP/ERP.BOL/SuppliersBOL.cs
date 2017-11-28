using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "suppliers")]
    public class SuppliersBOL : BaseBOL
    {
        private int supplierID;
        [Help(HelpText = "PrimaryKey")]
        public int SupplierID { get { return supplierID; } set { supplierID = value; } }
        private string companyName;
        public string CompanyName { get { return companyName; } set { companyName = value; } }
        private string contactName;
        public string ContactName { get { return contactName; } set { contactName = value; } }
        private string contactTitle;
        public string ContactTitle { get { return contactTitle; } set { contactTitle = value; } }
        private string address;
        public string Address { get { return address; } set { address = value; } }
        private string city;
        public string City { get { return city; } set { city = value; } }
        private string country;
        public string Country { get { return country; } set { country = value; } }
        private string mobile;
        public string Mobile { get { return mobile; } set { mobile = value; } }
        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }
        private string homePage;
        public string HomePage { get { return homePage; } set { homePage = value; } }
    }
}
