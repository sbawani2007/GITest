using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.DAL;
using ERP.BOL;
using System.Data;

namespace ERP.BLL
{
    public class SalesordersBLL : BaseBLL
    {
        #region properties and variables
        DAL.DBConnect dbconnect = new DBConnect();

        #endregion

        #region methods

        public Int32 Insert(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                try
                {
                    string qry = this.InsertSQL(obj);
                    qry += "; select LAST_INSERT_ID()";
                    //Int32 primaryID = (int)dbconnect.InsertNonQuery(qry);
                    object o = dbconnect.InsertScalar(qry);
                    //dbconnect.Insert(qry);
                    return Convert.ToInt32(o);
                }
                catch
                {

                }
            }
            return 0;
        }
        public Int32 Update(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                try
                {
                    string qry = this.UpdateSQL(obj);
                    dbconnect.Update(qry);
                    return 1;
                }
                catch
                {

                }
            }
            return 0;
        }
        public DataSet Select(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                string qry = this.SelectSQL(obj);
                return dbconnect.Select(qry.ToString());

            }
            return null;
        }
        public Int32 Delete(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                try
                {
                    string qry = this.DeleteSQL(obj);
                    dbconnect.Delete(qry);
                    return 1;
                }
                catch
                {

                }
            }
            return 0;
        }
        //test shahid
        public DataSet SelectCashReport(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                string qry = "SELECT `invoiceNumber`,`invoiceDate`,`refference`,`chequeNumber`,`debit`,`credit` FROM `cashflowreport` WHERE 1";
                /*@"CREATE OR REPLACE VIEW cashflowreport AS SELECT i.invoiceNumber, i.invoiceDate, i.refference, i.chequeNumber,
                 * (SELECT IFNULL(CONVERT(SUM(`unitPrice`*`quantity`) USING utf8),i.totalAmount) FROM ordedetails od WHERE od.orderID = i.orderID) AS debit,
                 * ('0.00') AS credit FROM invoices i WHERE `invoiceType`= 1
                 * UNION ALL
                 * SELECT i.invoiceNumber, i.invoiceDate, i.refference, 
                 * i.chequeNumber, ('0.00') AS debit, (SELECT IFNULL(CONVERT(SUM(`unitPrice`*`quantity`) USING utf8),i.totalAmount) 
                 * FROM ordedetails od WHERE od.orderID = i.orderID) AS credit FROM invoices i WHERE `invoiceType`= 2 ";*/
                return dbconnect.Select(qry.ToString());

            }
            return null;
        }
        public DataSet SelectInventoryReport(BOL.BaseBOL obj)
        {
            if (obj != null)
            {
                string qry = "SELECT * FROM `inventoryreport`";
                /*;
                         * @"CREATE OR REPLACE VIEW InventoryReport AS
SELECT *, (unitsInStock + (debit-credit)) AS Remaining FROM (
SELECT p.`productName`, c.categoryName, p.unitsInStock, 
(SELECT IFNULL(CONVERT(SUM(`quantity`) USING utf8),0.00) FROM ordedetails od WHERE od.productID = P.productID AND
od.orderType = 2) AS debit, 
(SELECT IFNULL(CONVERT(SUM(`quantity`) USING utf8),0.00) FROM ordedetails od WHERE od.productID = P.productID AND
od.orderType = 1) AS credit
FROM products p
LEFT JOIN categories c on c.categoryID = p.categoryID) TEMP*/
                return dbconnect.Select(qry.ToString());

            }
            return null;
        }
        /*
        
         */
        #endregion
    }
}

