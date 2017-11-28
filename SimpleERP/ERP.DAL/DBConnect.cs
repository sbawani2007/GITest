using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Add MySql Library
using MySql.Data.MySqlClient;
using System.Data;

using System.Diagnostics;
using System.IO;

namespace ERP.DAL
{
    public class DBConnect
    {
        private MySqlConnection connection;

        public MySqlConnection GetConnection
        {
            get { return connection; }
            set { connection = value; }
        }
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "simpleerp";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        ////MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        ////MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                //cmd.ExecuteNonQuery();
                cmd.ExecuteScalar();

                //close connection
                this.CloseConnection();
            }
        }
        public object InsertScalar(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                //cmd.ExecuteNonQuery();
                object o = cmd.ExecuteScalar();

                //close connection
                this.CloseConnection();
                return o;
            }
            return null;
        }
        public int InsertNonQuery(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                int retVal = cmd.ExecuteNonQuery();
                //return cmd.ExecuteScalar();

                //close connection
                this.CloseConnection();
                return retVal;
            }
            return 0;
        }
        //Update statement
        public void Update(string query)
        {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(string query)
        {
            //string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public System.Data.DataSet Select(string query)
        {
            DataSet ds = new DataSet();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                
                MySqlDataAdapter adaptar = new MySqlDataAdapter(cmd);
                adaptar.Fill(ds);

                //close Connection
                this.CloseConnection();
                return ds;
            }
            else
            {
                return ds;
            }
        }

        //Count statement
        public int Count(string query)
        {
            //string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
        public int Count(string query, MySqlConnection con, MySqlTransaction trans)
        {
            //string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (con.State == ConnectionState.Open)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Transaction = trans;

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                //MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                //MessageBox.Show("Error , unable to Restore!");
            }
        }

        #region "DataAccess Functions"

        /// <summary>
        /// GetReader Function
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdtype"></param>
        /// <param name="parameters"></param>
        /// <param name="Sql"></param>
        /// <returns></returns>
        private MySqlDataReader GetReader(MySqlConnection conn, MySqlTransaction trans, CommandType cmdtype, Parameters parameters, string Sql)
        {
            MySqlCommand cmd;
            MySqlDataReader reader;

            cmd = new MySqlCommand(Sql, conn);
            cmd.CommandType = cmdtype;

            //set transaction
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            //set parameters
            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters.collection.Values)
                {
                    cmd.Parameters.Add(param);
                }
            }

            reader = cmd.ExecuteReader();

            return reader;
        }
        private DataSet GetDataset(MySqlConnection conn, MySqlTransaction trans, CommandType cmdtype, Parameters parameters, string Sql)
        {
            MySqlCommand cmd;
            //MySqlDataReader reader;

            cmd = new MySqlCommand(Sql, conn);
            cmd.CommandType = cmdtype;

            //set transaction
            if (trans != null)
            {
                cmd.Transaction = trans;
            }

            //set parameters
            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters.collection.Values)
                {
                    cmd.Parameters.Add(param);
                }
            }
            DataSet ds = new DataSet();
            MySqlDataAdapter adaptar = new MySqlDataAdapter(cmd);
            adaptar.Fill(ds);

            return ds;
        }

        public DataSet GetDataset(MySqlConnection conn, MySqlTransaction trans, string Sql)
        {
            return GetDataset(conn, trans, CommandType.Text, null, Sql);
        }

        public MySqlDataReader GetReader(MySqlConnection conn, MySqlTransaction trans, CommandType cmdtype, string Sql)
        {
            return GetReader(conn, trans, cmdtype, null, Sql);
        }

        public MySqlDataReader GetReader(MySqlConnection conn, MySqlTransaction trans, string Sql)
        {
            return GetReader(conn, trans, CommandType.Text, null, Sql);
        }

        public MySqlDataReader GetReader(MySqlConnection conn, string Sql)
        {
            return GetReader(conn, null, CommandType.Text, null, Sql);
        }

        public MySqlDataReader GetReader(MySqlConnection conn, Parameters parameters, string Sql)
        {
            return GetReader(conn, null, CommandType.Text, parameters, Sql);
        }

        public MySqlDataReader GetReader(MySqlConnection conn, CommandType cmdtype, string Sql, Parameters parameters)
        {
            return GetReader(conn, null, cmdtype, parameters, Sql);
        }

        public Object GetScalar(MySqlConnection conn, MySqlTransaction trans, string Sql, Parameters parameters)
        {
            Object obj;
            MySqlCommand cmd;

            cmd = new MySqlCommand(Sql, conn, trans);

            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters.collection.Values)
                {
                    cmd.Parameters.Add(param);
                }
            }

            obj = cmd.ExecuteScalar();

            return obj;
        }

        public Object GetScalar(MySqlConnection conn, string Sql, Parameters parameters)
        {
            return GetScalar(conn, null, Sql, parameters);
        }

        public Object GetScalar(MySqlConnection conn, string Sql)
        {
            return GetScalar(conn, null, Sql, null);
        }
        public Object GetScalar(string Sql)
        {
            return GetScalar(connection, null, Sql, null);
        }
        public int ExecuteNonQuery(MySqlConnection conn, MySqlTransaction trans, string Sql, Parameters parameters)
        {
            return ExecuteNonQuery(conn, trans, CommandType.Text, Sql, parameters);
        }

        public int ExecuteNonQuery(MySqlConnection conn, MySqlTransaction trans, CommandType cmdtype, string Sql, Parameters parameters)
        {
            MySqlCommand cmd;

            cmd = new MySqlCommand(Sql, conn, trans);
            cmd.CommandType = cmdtype;

            if (parameters != null)
            {
                foreach (MySqlParameter param in parameters.collection.Values)
                {
                    cmd.Parameters.Add(param);
                }
            }

            return cmd.ExecuteNonQuery();
        }

        #endregion
    }
}
