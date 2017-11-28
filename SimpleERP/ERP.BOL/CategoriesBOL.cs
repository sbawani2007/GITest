using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericFunctions;

namespace ERP.BOL
{
    [Help(HelpText = "categories")]
    public class CategoriesBOL : BaseBOL
    {
        private int categoryID;
        [Help(HelpText = "PrimaryKey")]
        public int CategoryID { get { return categoryID; } set { categoryID = value; } }
        private string categoryName;
        public string CategoryName { get { return categoryName; } set { categoryName = value; } }
        private string description;
        public string Description { get { return description; } set { description = value; } }

    }
}
