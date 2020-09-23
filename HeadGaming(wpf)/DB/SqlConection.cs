using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

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

        public bool IsOpen()
        {
            if (_con.State.Equals("Open"))
            {
                return true;
            } else
            {
                return false;
            }
        }
        public SqlConnection Open(TextBlock feedbackLabel = null)
        {
            this._con = new SqlConnection(this._cs);
            if (feedbackLabel != null)
            {
                try
                {
                    if (this._con.State != System.Data.ConnectionState.Open)
                    {
                        this._con.Open();
                    }
                }
                catch (System.InvalidOperationException)
                {
                    feedbackLabel.Text = "Ein Fehler ist aufgetretten. Die Verbindung zur Datenbank konnte leider nicht hergestellt werden.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
                catch (Exception)
                {
                    feedbackLabel.Text = "Ein unbekannter Fehler ist aufgetretten.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
            } else
            {
                if (this._con.State != System.Data.ConnectionState.Open)
                {
                    this._con.Open();
                }
            }

            return this._con;
        }

        public DataTable GetDataTable(string request)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlCommand sc = new SqlCommand(request, this._con);
                using (var reader = sc.ExecuteReader())
                {
                    dt.Load(reader);
                    return dt;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SetData(string request, TextBlock feedbackLabel = null)
        {
            try
            {
                SqlCommand sc = new SqlCommand(request, this._con);
                if (feedbackLabel != null)
                {
                    feedbackLabel.Text = "Daten wurden erfolgreich gespeichert.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(50, 130, 0));
                }
                return sc.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                if (feedbackLabel != null)
                {
                    feedbackLabel.Text = "Das gewünschte Element existiert bereits, bitte schauen sie in der Tabelle und versuchen es mit einer anderen.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
                return 0;
            }
            catch (Exception)
            {
                if (feedbackLabel != null)
                {
                    feedbackLabel.Text = "Ein unbekannter Fehler ist aufgetretten.";
                    feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                }
                return 0;
            }
        }

        public int DeleteData(string request, TextBlock feedbackLabel)
        {
            try
            {
                SqlCommand sc = new SqlCommand(request, this._con);
                feedbackLabel.Text = "Daten wurden erfolgreich gelöscht.";
                feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(50, 130, 0));
                return sc.ExecuteNonQuery();
            }
            catch (Exception)
            {
                feedbackLabel.Text = "Ein unbekannter Fehler ist aufgetretten.";
                feedbackLabel.Foreground = new SolidColorBrush(Color.FromRgb(130, 0, 0));
                return 0;
            }
        }

        public void Close()
        {
            this._con.Close();
        }

    }
}
