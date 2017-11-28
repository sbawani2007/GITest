using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.BOL
{
    public class UsersBOL //:BaseBOL
    {
        private int userid;
        public int Prp_userid { get { return userid; } set { userid = value; } }
        private string userName;
        private string Prp_userName { get { return userName; } set { userName = value; } }
        private string firstName;
        private string Prp_firstName { get { return firstName; } set { firstName = value; } }
        private string lastName;
        private string Prp_lastName { get { return lastName; } set { lastName = value; } }
        private DateTime createdOn;
        private DateTime Prp_createdOn { get { return createdOn; } set { createdOn = value; } }
    }
}
                                

