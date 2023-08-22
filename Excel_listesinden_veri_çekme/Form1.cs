using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;

namespace Excel_listesinden_veri_çekme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\melis\OneDrive\Masaüstü\kitap veri listesi.xlsx;Extended Properties= 'Excel 12.0 Xml;HDR=YES;'");

        void Veriler()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [Sayfa1$]", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Veriler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veriler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand Komut = new OleDbCommand("insert into [Sayfa1$] (Kitap Adı,Yazar,Tür,Fiyat) values (@p1,@p2,@p3,@p4)", baglanti);
            Komut.Parameters.AddWithValue("@p1", textBox1.Text);
            Komut.Parameters.AddWithValue("@p2", textBox2.Text);
            Komut.Parameters.AddWithValue("@p3", textBox3.Text);
            Komut.Parameters.AddWithValue("@p4", textBox4.Text);
            Komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Kaydedildi");
            Veriler();
        }
    }
}