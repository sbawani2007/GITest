using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "customers")]
    public class CustomersBOL : BaseBOL
    {
        private string customerID;
        [Help(HelpText = "PrimaryKey")]
        public string CustomerID { get { return customerID; } set { customerID = value; } }
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
        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }
        private string fax;
        public string Fax { get { return fax; } set { fax = value; } }
    }
}
