using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "users")]
    public class UsersBOL : BaseBOL
    {
        private int userid;
        [Help(HelpText = "PrimaryKey")]
        public int Userid { get { return userid; } set { userid = value; } }
        private string userName;
        public string UserName { get { return userName; } set { userName = value; } }
        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }
        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }
        private DateTime createdOn;
        public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    }
}
