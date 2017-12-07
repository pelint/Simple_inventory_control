using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok
{
    public partial class Form1 : Form
    {
        static string conString = "server=PELIN\\SQLEXPRESS; Initial Catalog=stokKontrol; Integrated Security=SSPI";
        SqlConnection conn = new SqlConnection(conString);

        private void MyTabs()
        {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = "select*from kategori";
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;

                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader["kategori_adi"]);
                    }
                    reader.Close();

                    SqlCommand command2 = new SqlCommand();
                    command2.CommandText = "select*from marka";
                    command2.Connection = conn;
                    command2.CommandType = CommandType.Text;

                    SqlDataReader reader2;
                    reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        comboBox2.Items.Add(reader2["marka_adi"]);
                    }
                    reader2.Close();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
                }

            listele();

        }

        public Form1()
        {
            InitializeComponent();
            MyTabs();


        }

        


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string kategori_adi = comboBox1.Text;
                string marka_adi = comboBox2.Text;

                string kategori = "select*from kategori where kategori_adi= '" + kategori_adi + "'";
                SqlCommand command = new SqlCommand(kategori,conn);
                SqlDataReader result = command.ExecuteReader();
                result.Read();
                int kategori_id = Convert.ToInt32(result["kategori_id"]);
                result.Close();

                string marka = "select*from marka where marka_adi= '" + marka_adi + "'";
                SqlCommand command2 = new SqlCommand(marka, conn);
                SqlDataReader result2 = command2.ExecuteReader();
                result2.Read();
                int marka_id = Convert.ToInt32(result2["marka_id"]);
                result2.Close();

                string newProduct = "insert into urun(urun_kodu,urun_adi,kategori_id,marka_id,miktar) values(@urun_kodu,@urun_adi,@kategori_id,@marka_id,@miktar)";
                SqlCommand command3 = new SqlCommand(newProduct, conn);
                command3.Parameters.AddWithValue("@urun_kodu", textBox1.Text);
                command3.Parameters.AddWithValue("@urun_adi", textBox2.Text);
                command3.Parameters.AddWithValue("@kategori_id", kategori_id);
                command3.Parameters.AddWithValue("@marka_id", marka_id);
                command3.Parameters.AddWithValue("@miktar",numericUpDown1.Value);
                command3.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Ürün Başarılı Bir Şekilde Kaydedildi.");


            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }                                                                


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                
                string newCategory = "insert into kategori(kategori_adi) values(@kategori_adi)";
                SqlCommand command = new SqlCommand(newCategory, conn);
                command.Parameters.AddWithValue("@kategori_adi", textBox3.Text);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Kategori Başarılı Bir Şekilde Kaydedildi.");
                kategoriListele();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string newCategory = "insert into marka(marka_adi) values(@marka_adi)";
                SqlCommand command = new SqlCommand(newCategory, conn);
                command.Parameters.AddWithValue("@marka_adi", textBox4.Text);
                command.ExecuteNonQuery();      
                conn.Close();
                MessageBox.Show("Marka Başarılı Bir Şekilde Kaydedildi.");
                markaListele();


            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "select*from kategori";
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                SqlDataReader reader;
                reader = command.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["kategori_adi"]);
                }
                reader.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "select*from marka";
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                SqlDataReader reader;
                reader = command.ExecuteReader();
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["marka_adi"]);
                }
                reader.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string urun = "SELECT u.urun_kodu AS ÜRÜN_KODU ,u.urun_adi AS ÜRÜN_ADI,u.miktar AS ADET,k.kategori_adi AS KATEGORİ ,m.marka_adi AS MARKA from urun u inner join marka m on u.marka_id = m.marka_id inner join kategori k on u.kategori_id = k.kategori_id where urun_adi=@urun_adi";
                SqlCommand command = new SqlCommand(urun, conn);
                command.Parameters.AddWithValue("@urun_adi", textBox6.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                textBox6.Clear();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string urun = "SELECT u.urun_kodu AS ÜRÜN_KODU ,u.urun_adi AS ÜRÜN_ADI,u.miktar AS ADET,k.kategori_adi AS KATEGORİ ,m.marka_adi AS MARKA from urun u inner join marka m on u.marka_id = m.marka_id inner join kategori k on u.kategori_id = k.kategori_id where urun_kodu=@urun_kodu";
                SqlCommand command = new SqlCommand(urun, conn);
                command.Parameters.AddWithValue("@urun_kodu", textBox5.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                textBox5.Clear();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string urun = "SELECT u.urun_kodu AS ÜRÜN_KODU ,u.urun_adi AS ÜRÜN_ADI,u.miktar AS ADET,k.kategori_adi AS KATEGORİ ,m.marka_adi AS MARKA from urun u inner join marka m on u.marka_id = m.marka_id inner join kategori k on u.kategori_id = k.kategori_id where k.kategori_adi = @kategori_adi";
                SqlCommand command = new SqlCommand(urun, conn);
                command.Parameters.AddWithValue("@kategori_adi", textBox7.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                textBox7.Clear();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string urun = "SELECT u.urun_kodu AS ÜRÜN_KODU ,u.urun_adi AS ÜRÜN_ADI,u.miktar AS ADET,k.kategori_adi AS KATEGORİ ,m.marka_adi AS MARKA from urun u inner join marka m on u.marka_id = m.marka_id inner join kategori k on u.kategori_id = k.kategori_id where m.marka_adi = @marka_adi";
                SqlCommand command = new SqlCommand(urun, conn);
                command.Parameters.AddWithValue("@marka_adi", textBox8.Text);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
                textBox8.Clear();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void listele()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string urun = "SELECT u.urun_id AS urun_id, u.urun_kodu AS ÜRÜN_KODU ,u.urun_adi AS ÜRÜN_ADI,u.miktar AS ADET,k.kategori_adi AS KATEGORİ ,m.marka_adi AS MARKA from urun u inner join marka m on u.marka_id=m.marka_id inner join kategori k on u.kategori_id=k.kategori_id";
                SqlCommand command = new SqlCommand(urun, conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void kategoriListele()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string kategori = "SELECT*FROM kategori";
                SqlCommand command = new SqlCommand(kategori, conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void markaListele()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string marka = "SELECT*FROM marka";
                SqlCommand command = new SqlCommand(marka, conn);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView3.DataSource = dt;

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            listele();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Ögeyi Güncellemek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string delete = "update from where urun_kodu=@urun_kodu";
                    SqlCommand command = new SqlCommand(delete, conn);
                    command.Parameters.AddWithValue("@urun_kodu", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Silme İşlemi Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
                }

            }
            else
            {

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string delete = "delete from urun where urun_id=@urun_id";
                    SqlCommand command = new SqlCommand(delete, conn);
                    command.Parameters.AddWithValue("@urun_id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Silme İşlemi Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
                }
                
            }
            else
            {

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                if (textBox9.Text.Trim() != "" && textBox11.Text.Trim() != "")
                {
                    string update = "update urun set urun_kodu='" + textBox9.Text + "',urun_adi='" + textBox11.Text + "',miktar='" + numericUpDown2.Value + "' WHERE urun_id=@id";
                    SqlCommand command = new SqlCommand(update, conn);
                    command.Parameters.AddWithValue("@id", label20.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Güncelleme İşlemi Başarılı !");
                    textBox9.Clear();
                    textBox11.Clear();
                    numericUpDown2.Value = 0;
                    label17.Text = "";
                    label18.Text = "";
                    label20.Text = "";
                    listele();
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmayınız !");
                }
                conn.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label20.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            numericUpDown2.Value =(Int32)dataGridView1.CurrentRow.Cells[3].Value;
            label17.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            label18.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            kategoriListele();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string delete = "delete from kategori where kategori_id=@id";
                    SqlCommand command = new SqlCommand(delete, conn);
                    command.Parameters.AddWithValue("@id", dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Silme İşlemi Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    kategoriListele();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Bu kategoriye ait ürünler bulunduğundan silme işlemi gerçekleştirilemez!");
                }

            }
            else
            {

            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            markaListele();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string delete = "delete from marka where marka_id=@id";
                    SqlCommand command = new SqlCommand(delete, conn);
                    command.Parameters.AddWithValue("@id", dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Silme İşlemi Başarılı", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    markaListele();

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Bu markaya ait ürünler bulunduğundan silme işlemi gerçekleştirilemez!!");
                }

            }
            else
            {

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "select*from marka";
                command.Connection = conn;
                command.CommandType = CommandType.Text;

                SqlDataReader reader;
                reader = command.ExecuteReader();
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader["marka_adi"]);
                }
                reader.Close();

            }
            catch (Exception exp)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu Tekrar Deneyin!" + exp.Message);
            }
        }
    }
}
