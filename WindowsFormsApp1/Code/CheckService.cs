using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    class CheckService
    {
        OleDbConnection myConnection;
        public CheckService()
        {
            string connectionString = Connect.GetConnectionString();
            myConnection = new OleDbConnection(connectionString);
        }
        public void NewCheck(Check p)
        {
            string name = p.Name;
            int o = p.User;
            int price = p.Price;
            DateTime date = p.Date;
            int type = p.Type;
            try
            {
                myConnection.Open();
                string sSql = "INSERT INTO Checks(CheckName, CheckUser, CheckPrice, CheckDate, CheckType) VALUES('" + name + "'," + o + "," + price + ",#" + date + "#," + type + ")";
                OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
                myCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                myConnection.Close();
            }
        }
    }
}
