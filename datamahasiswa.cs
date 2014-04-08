using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMahasiswa
{
    class Datamahasiswa
    {
        private MySqlCommand perintah = null;
        MySqlConnection koneksi = new MySqlConnection();
        string koneksidatabase = "Server=localhost;Port=3306;User=root;Password=;Database=datamahasiswa";

        public Datamahasiswa()
        {
            koneksi.ConnectionString = koneksidatabase;
        }
        public DataSet gedData()
        {
            DataSet dts = new DataSet();
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand();
                perintah.Connection = koneksi;
                perintah.CommandType = CommandType.Text;
                perintah.CommandText = "select Nim,Nama,Alamat,Telpon from tbl_mahasiswa";
                MySqlDataAdapter data = new MySqlDataAdapter(perintah);
                data.Fill(dts, "tbl_mahasiswa");
                koneksi.Close();
            }catch (MySqlException )
            {}
            return dts;
             }

        public bool Insert(data dt)
        {
            Boolean nilai = false;
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand();
                perintah.Connection = koneksi;
                perintah.CommandType = CommandType.Text;
                perintah.CommandText = "insert into tbl_mahasiswa values('" + dt.Nim + "','" + dt.Nama + "','" + dt.Alamat + "','" + dt.Telpon + "')";
                perintah.ExecuteNonQuery();
                nilai = true;
                koneksi.Close();
            }
            catch (MySqlException) { }
            return nilai;
        }

        public bool edit(data dt, string nim)
        {
            Boolean nilai = false;
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand();
                perintah.Connection = koneksi;
                perintah.CommandType = CommandType.Text;
                perintah.CommandText = "update tbl_mahasiswa set Nim='" + dt.Nim + "',Nama='" + dt.Nama + "',Alamat='" + dt.Alamat + "',Telpon='" + dt.Telpon + "' where Nim='" + dt.Nim + "'";
                perintah.ExecuteNonQuery();
                nilai = true;
                koneksi.Close();
            }
            catch (MySqlException) { }
            return nilai;
        }

        public bool hapus(string nim)
        {
            Boolean nilai = false;
            try
            {
                koneksi.Open();
                perintah = new MySqlCommand();
                perintah.Connection = koneksi;
                perintah.CommandType = CommandType.Text;
                perintah.CommandText = "Delete from tbl_mahasiswa where Nim='" + nim + "'";
                perintah.ExecuteNonQuery();
                nilai = true;
                koneksi.Close();

            }
            catch (MySqlException) { }
            return nilai;
        }


    }

    }
   

