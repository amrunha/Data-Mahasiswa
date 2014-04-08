using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Web;
using MySql.Data.MySqlClient;
 

namespace DataMahasiswa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Datamahasiswa dma = new Datamahasiswa();

        private void Form1_Load(object sender, EventArgs e)
        {
            tampildata();
            bersihkangrid();
        }
        void tampildata()
        {
            DataSet data = dma.gedData();
            dataGridView1.DataSource= data;
            dataGridView1.DataMember = "tbldataamikom";
        }

        private void button1_Click(object sender, EventArgs e) //tombol Simpan
        {
            data dt = new data();
            dt.Nim = nim1.Text;
            dt.Nama = nama.Text;
            dt.Alamat = alamat.Text;
            dt.Telpon = telpon.Text;
            dma.Insert(dt);
            MessageBox.Show ("Data berhasil disimpan", "Pemberitahuan",MessageBoxButtons.OK);
            tampildata();
            bersihkangrid();
        }

        string nim;
        private void button2_Click(object sender, EventArgs e) //Tombol Edit
        {
            data dt = new data();
            dt.Nim = nim1.Text;
            dt.Nama = nama.Text;
            dt.Alamat = alamat.Text;
            dt.Telpon = telpon.Text;
            dma.edit(dt, nim);
            MessageBox.Show("Data berhasil diubah", "Pemberitahuan", MessageBoxButtons.OK);
            tampildata();
        }

       
        void bersihkangrid()
        {
            nim1.Text = "";
            nama.Text = "";
            alamat.Text = "";
            telpon.Text = "";
            nim1.Focus();
        }

        private void button3_Click(object sender, EventArgs e) //Tombol hapus
        {
            dma.hapus(nim);
            MessageBox.Show("Data Berhasil dihapus","Pemberitahuan",MessageBoxButtons.OK);
            tampildata();
            nim1.Focus();

            bersihkangrid();
            }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            nim1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            nama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            alamat.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            telpon.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            nim = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

         
            }
}
