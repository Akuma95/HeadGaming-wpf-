using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace HeadGaming_wpf_.DB
{
    class SqlConection
    {
        public SqlConnection Connection
        {
            get 
            {
                return (this._con == null) ? this.Open() : this._con;
            }
        }
        private SqlConnection _con;
        private string _cs;

        public SqlConection(string cs)
        {
            _cs = cs;
        }

        public SqlConnection Open()
        {
            this._con = new SqlConnection(this._cs);

            if (this._con.State != System.Data.ConnectionState.Open)
            {
                this._con.Open();
            }

            return this._con;
        }

        public DataTable GetDataTable(string request)
        {
            DataTable dt = new DataTable();

            SqlCommand sc = new SqlCommand(request, this._con);
            using (var reader = sc.ExecuteReader())
            {
                dt.Load(reader);
                return dt;
            }
        }

        public int SetData(string request)
        {
            SqlCommand sc = new SqlCommand(request, this._con);
            return sc.ExecuteNonQuery();
        }

        public void Close()
        {
            this._con.Close();
        }
        
    }
}
