using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace veri_tabanı_proje_2_yedek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=proje6; user ID=postgres; Password=Cotanak28;");

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select * from public.\"Stadium\"", baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBox4.DisplayMember = "stadiumname";
            comboBox4.ValueMember = "StadiumID";
            comboBox4.DataSource = dt1;

            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter("select * from public.\"League\"", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            comboBox5.DisplayMember = "leaguename";
            comboBox5.ValueMember = "LeagueID";
            comboBox5.DataSource = dt2;

            NpgsqlDataAdapter da3 = new NpgsqlDataAdapter("select * from public.\"President\"", baglanti);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            comboBox6.DisplayMember = "prename";
            comboBox6.ValueMember = "PresidentID";
            comboBox6.DataSource = dt3;

            NpgsqlDataAdapter da4 = new NpgsqlDataAdapter("select * from public.\"Team\"", baglanti);
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            comboBox1.DisplayMember = "teamname";
            comboBox1.ValueMember = "TeamID";
            comboBox1.DataSource = dt4;
            comboBox10.DisplayMember = "teamname";
            comboBox10.ValueMember = "TeamID";
            comboBox10.DataSource = dt4;

            NpgsqlDataAdapter da5 = new NpgsqlDataAdapter("select * from public.\"Federation\"", baglanti);
            DataTable dt5 = new DataTable();
            da5.Fill(dt5);
            comboBox7.DisplayMember = "fedname";
            comboBox7.ValueMember = "FedID";
            comboBox7.DataSource = dt5;
            comboBox8.DisplayMember = "fedname";
            comboBox8.ValueMember = "FedID";
            comboBox8.DataSource = dt5;

            NpgsqlDataAdapter da6 = new NpgsqlDataAdapter("select * from public.\"NationalTeam\"", baglanti);
            DataTable dt6 = new DataTable();
            da6.Fill(dt6);
            comboBox2.DisplayMember = "nationname";
            comboBox2.ValueMember = "NationalID";
            comboBox2.DataSource = dt6;
            comboBox11.DisplayMember = "nationname";
            comboBox11.ValueMember = "NationalID";
            comboBox11.DataSource = dt6;

            NpgsqlDataAdapter da7 = new NpgsqlDataAdapter("select * from public.\"Footballer\"", baglanti);
            DataTable dt7 = new DataTable();
            da7.Fill(dt7);
            comboBox9.DisplayMember = "fbname";
            comboBox9.ValueMember = "FootballerID";
            comboBox9.DataSource = dt7;

            baglanti.Close();
        }

        private void futbolculistele_Click(object sender, EventArgs e)
        { 
            if (comboBox3.SelectedItem.ToString() == "goalkeeper (gol yenmeyen maç sayısı)")
            {
                baglanti.Open();
                string sorgu = "select * from public.\"Footballer\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                string sorgu2 = "select * from public.\"Goalkeeper\"";
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView12.DataSource = ds2.Tables[0];
                baglanti.Close();

            }
            if (comboBox3.SelectedItem.ToString() == "forward (gol sayısı )")
            {
                baglanti.Open();
                string sorgu = "select * from public.\"Footballer\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                string sorgu2 = "select * from public.\"Forward\"";
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView12.DataSource = ds2.Tables[0];
                baglanti.Close();

            }
            if (comboBox3.SelectedItem.ToString() == "midfielder (asist sayısı)")
            {
                baglanti.Open();
                string sorgu = "select * from public.\"Footballer\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                string sorgu2 = "select * from \"Midfielder\"";
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView12.DataSource = ds2.Tables[0];
                baglanti.Close();

            }
            if (comboBox3.SelectedItem.ToString() == "defence ( top kazanma sayısı )")
            {
                baglanti.Open();
                string sorgu = "select * from public.\"Footballer\"";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                string sorgu2 = "select * from \"Defence\"";
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sorgu2, baglanti);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                dataGridView12.DataSource = ds2.Tables[0];
                baglanti.Close();

            }
        }

        private void futbolcuekle_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedItem.ToString() == "goalkeeper (gol yenmeyen maç sayısı)")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Footballer\" values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                komut.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p6", int.Parse(comboBox2.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p7", textBox6.Text);
                komut.Parameters.AddWithValue("@p8", int.Parse(textBox5.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("insert into public.\"Goalkeeper\" values(@p1,@p2)", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.Parameters.AddWithValue("@p2", int.Parse(textBox7.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(comboBox3.SelectedItem.ToString() == "forward (gol sayısı )")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Footballer\" values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                komut.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p6", int.Parse(comboBox2.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p7", textBox6.Text);
                komut.Parameters.AddWithValue("@p8", int.Parse(textBox5.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("insert into public.\"Forward\" values(@p1,@p2)", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.Parameters.AddWithValue("@p2", int.Parse(textBox7.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(comboBox3.SelectedItem.ToString() == "midfielder (asist sayısı)")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Footballer\" values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                komut.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p6", int.Parse(comboBox2.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p7", textBox6.Text);
                komut.Parameters.AddWithValue("@p8", int.Parse(textBox5.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("insert into public.\"Midfielder\" values(@p1,@p2)", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.Parameters.AddWithValue("@p2", int.Parse(textBox7.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(comboBox3.SelectedItem.ToString() == "defence ( top kazanma sayısı )")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Footballer\" values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.Parameters.AddWithValue("@p3", textBox3.Text);
                komut.Parameters.AddWithValue("@p4", int.Parse(textBox4.Text));
                komut.Parameters.AddWithValue("@p5", int.Parse(comboBox1.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p6", int.Parse(comboBox2.SelectedValue.ToString()));
                komut.Parameters.AddWithValue("@p7", textBox6.Text);
                komut.Parameters.AddWithValue("@p8", int.Parse(textBox5.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("insert into public.\"Defence\" values(@p1,@p2)", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.Parameters.AddWithValue("@p2", int.Parse(textBox7.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void futbolcusil_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "goalkeeper (gol yenmeyen maç sayısı)")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Goalkeeper\" where \"FootballerID\"=@p1;", baglanti);;
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from public.\"Footballer\" where \"FootballerID\"=@p1;", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            }
            if (comboBox3.SelectedItem.ToString() == "forward (gol sayısı )")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Forward\" where \"FootballerID\"=@p1;", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from public.\"Footballer\" where \"FootballerID\"=@p1;", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            }
            if (comboBox3.SelectedItem.ToString() == "midfielder (asist sayısı)")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Midfielder\" where \"FootballerID\"=@p1;", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from public.\"Footballer\" where \"FootballerID\"=@p1;", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            }
            if (comboBox3.SelectedItem.ToString() == "defence ( top kazanma sayısı )")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Defence\" where \"FootballerID\"=@p1;", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from public.\"Footballer\" where \"FootballerID\"=@p1;", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            }

        }

        private void futbolcugüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"Footballer\" set \"fbname\"=@p1, \"fbsurname\"=@p2, \"price\"=@p3, \"country\"=@p4,\"height\"=@p5 " +
                "where \"FootballerID\"=@p6", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@p4", textBox6.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(textBox5.Text));
            komut.Parameters.AddWithValue("@p6", int.Parse(textBox1.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e) //arama yeri
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Footballer\" where \"fbname\" LIKE '%" + textBox2.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void teamlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Team\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void teamekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Team\" values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox8.Text));
            komut.Parameters.AddWithValue("@p2", textBox9.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(comboBox4.SelectedValue.ToString()));
            komut.Parameters.AddWithValue("@p4", int.Parse(comboBox5.SelectedValue.ToString()));
            komut.Parameters.AddWithValue("@p5", textBox10.Text);
            komut.Parameters.AddWithValue("@p6", int.Parse(comboBox6.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void teamsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Team\" where \"TeamID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox8.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void teamguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"Team\" set \"teamname\"=@p1, \"symbol\"=@p2 " +
                "where \"TeamID\"=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox9.Text);
            komut.Parameters.AddWithValue("@p2", textBox10.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox8.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void teamara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Team\" where \"teamname\" LIKE '%" + textBox9.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void stadiumlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Stadium\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void stadiumekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Stadium\" values(@p4,@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox12.Text);
            komut.Parameters.AddWithValue("@p2", textBox13.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox14.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox11.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void stadiumsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Stadium\" where \"StadiumID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox11.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void stadiumguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"Stadium\" set \"stadiumname\"=@p1, \"location\"=@p2, \"capacity\"=@p3 " +
                "where \"StadiumID\"=@p4", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox12.Text);
            komut.Parameters.AddWithValue("@p2", textBox13.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox14.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox11.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void stasiumara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Stadium\" where \"stadiumname\" LIKE '%" + textBox12.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView3.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void leaguelistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"League\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void leagueekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"League\" values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox15.Text));
            komut.Parameters.AddWithValue("@p2", textBox16.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox17.Text));
            komut.Parameters.AddWithValue("@p4", int.Parse(comboBox7.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void leaguesil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"League\" where \"LeagueID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox15.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void leagueguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"League\" set \"leaguename\"=@p1, \"teamcount\"=@p2, \"FedID\"=@p3 " +
                "where \"LeagueID\"=@p4", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox16.Text);
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox17.Text));
            komut.Parameters.AddWithValue("@p3", int.Parse(comboBox7.SelectedValue.ToString()));
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox15.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void leagueara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"League\" where \"leaguename\" LIKE '%" + textBox16.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void federationlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Federation\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView6.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void federationekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Federation\" values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox33.Text));
            komut.Parameters.AddWithValue("@p2", textBox34.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox40.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void federationsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Federation\" where \"FedID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox33.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void federationguncele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"Federation\" set \"fedname\"=@p1 " +
                "where \"FedID\"=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox34.Text);
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox33.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void fedara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Federation\" where \"fedname\" LIKE '%" + textBox34.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView6.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void presidentlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"President\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView5.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void presidentekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"President\" values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox35.Text));
            komut.Parameters.AddWithValue("@p2", textBox36.Text);
            komut.Parameters.AddWithValue("@p3", textBox37.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void presidentsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"President\" where \"PresidentID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox35.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void presidentguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"President\" set \"prename\"=@p1,\"presurname\"=@p2 " +
                "where \"PresidentID\"=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox36.Text);
            komut.Parameters.AddWithValue("@p2", textBox37.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox35.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void presidentara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"President\" where \"prename\" LIKE '%" + textBox36.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView5.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void refreelistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Refree\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView7.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void refreeekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Refree\" values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox18.Text));
            komut.Parameters.AddWithValue("@p2", textBox19.Text);
            komut.Parameters.AddWithValue("@p3", textBox20.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(comboBox8.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void refereesil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Refree\" where \"RefreeID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox18.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void refreeguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"Refree\" set \"refreename\"=@p1,\"refreesurname\"=@p2 " +
                "where \"RefreeID\"=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox19.Text);
            komut.Parameters.AddWithValue("@p2", textBox20.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox18.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void refreeara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Refree\" where \"refreename\" LIKE '%" + textBox19.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView7.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void managerekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"Manager\" values(@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox21.Text));
            komut.Parameters.AddWithValue("@p2", textBox22.Text);
            komut.Parameters.AddWithValue("@p3", textBox38.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(comboBox9.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void managersil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"Manager\" where \"ManagerID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox21.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void managerguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"Manager\" set \"mngrname\"=@p1,\"mngrsurname\"=@p2 " +
                "where \"ManagerID\"=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox22.Text);
            komut.Parameters.AddWithValue("@p2", textBox38.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox21.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void manageerlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Manager\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView8.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void menagerara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"Manager\" where \"mngrname\" LIKE '%" + textBox22.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView8.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void nationallistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"NationalTeam\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView9.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void nationalekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"NationalTeam\" values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox23.Text));
            komut.Parameters.AddWithValue("@p2", textBox24.Text);
            komut.Parameters.AddWithValue("@p3", textBox39.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nationalsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"NationalTeam\" where \"NationalID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox23.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void nationalguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"NationalTeam\" set \"nationname\"=@p1,\"colour\"=@p2 " +
                "where \"NationalID\"=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1", textBox24.Text);
            komut.Parameters.AddWithValue("@p2", textBox39.Text);
            komut.Parameters.AddWithValue("@p3", int.Parse(textBox23.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void nationalteamara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"NationalTeam\" where \"nationname\" LIKE '%" + textBox24.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView9.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void teamfanlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"TeamFan\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView10.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void teamfanekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"TeamFan\" values(@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox25.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox26.Text));
            komut.Parameters.AddWithValue("@p3", textBox27.Text);
            komut.Parameters.AddWithValue("@p4", textBox28.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(comboBox10.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void teamfansil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"TeamFan\" where \"TeamfanID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox25.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void teamfanguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"TeamFan\" set \"memberprice\"=@p1,\"fanname\"=@p2,\"fansurname\"=@p3 " +
                "where \"TeamfanID\"=@p4", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox26.Text));
            komut.Parameters.AddWithValue("@p2", textBox27.Text);
            komut.Parameters.AddWithValue("@p3", textBox28.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox25.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void teamfanara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"TeamFan\" where \"fanname\" LIKE '%" + textBox27.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView10.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void nationalteamfanlistele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"NationalFan\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView11.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void nationalteamfanekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into public.\"NationalFan\" values(@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox32.Text));
            komut.Parameters.AddWithValue("@p2", int.Parse(textBox31.Text));
            komut.Parameters.AddWithValue("@p3", textBox30.Text);
            komut.Parameters.AddWithValue("@p4", textBox29.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(comboBox11.SelectedValue.ToString()));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nationalteamfansil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("delete from public.\"NationalFan\" where \"NationalfanID\"=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox32.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show(" silme işlemi onaylıyor musunuz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        }

        private void nationalteamfanguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update public.\"NationalFan\" set \"natmemberprice\"=@p1,\"natfanname\"=@p2,\"natfansurname\"=@p3 " +
                "where \"NationalfanID\"=@p4", baglanti);
            komut.Parameters.AddWithValue("@p1", int.Parse(textBox31.Text));
            komut.Parameters.AddWithValue("@p2", textBox30.Text);
            komut.Parameters.AddWithValue("@p3", textBox29.Text);
            komut.Parameters.AddWithValue("@p4", int.Parse(textBox32.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void nationalfanara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = "select * from public.\"NationalFan\" where \"natfanname\" LIKE '%" + textBox30.Text + "%'";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView11.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void mevkiguncelle_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "goalkeeper (gol yenmeyen maç sayısı)")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("update public.\"Goalkeeper\" set \"without_goal\"=@p1 where \"FootballerID\"=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
                komut.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("select public.\"totalteam\"()", baglanti);
                NpgsqlDataReader read = komut2.ExecuteReader();
                while(read.Read())
                    countmevki.Text = read[0].ToString();

                MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglanti.Close();

            }
            if (comboBox3.SelectedItem.ToString() == "forward (gol sayısı )")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("update public.\"Forward\" set \"goals\"=@p1 where \"FootballerID\"=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
                komut.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("select public.\"totalforward\"()", baglanti);
                NpgsqlDataReader read = komut2.ExecuteReader();
                while (read.Read())
                    countmevki.Text = read[0].ToString();

                MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglanti.Close();

            }
            if (comboBox3.SelectedItem.ToString() == "midfielder (asist sayısı)")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("update public.\"Midfielder\" set \"assist\"=@p1 where \"FootballerID\"=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
                komut.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("select public.\"totalmidfielder\"()", baglanti);
                NpgsqlDataReader read = komut2.ExecuteReader();
                while (read.Read())
                    countmevki.Text = read[0].ToString();

                MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglanti.Close();

            }
            if (comboBox3.SelectedItem.ToString() == "defence ( top kazanma sayısı )")
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("update public.\"Defence\" set \"top_win\"=@p1 where \"FootballerID\"=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", int.Parse(textBox7.Text));
                komut.Parameters.AddWithValue("@p2", int.Parse(textBox1.Text));
                komut.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("select public.\"totaldefence\"()", baglanti);
                NpgsqlDataReader read = komut2.ExecuteReader();
                while (read.Read())
                    countmevki.Text = read[0].ToString();

                MessageBox.Show(" güncelleme işlemi başarılı oldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglanti.Close();
            }
        }
    }
}
