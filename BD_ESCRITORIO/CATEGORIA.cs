using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ESCRITORIO
{
    public partial class CATEGORIA : Form
    {
        MySqlConnection conexion = new MySqlConnection("Server=31.22.4.94;Port=3306;Database=easybuyi_PROYECTO_FINAL;Uid=easybuyi_pablo;password=vacaslocas123987;");
        DataSet ds;
        public CATEGORIA()
        {

            InitializeComponent();


        }

        private void button2_Click(object sender, EventArgs e) 
        {
            /*
            conexion.Open();
            MySqlCommand mostrar = new MySqlCommand("SELECT * FROM TIPO_PRODUCTOS", conexion);

            MySqlDataAdapter m_datos = new MySqlDataAdapter(mostrar);
            ds = new DataSet();

            m_datos.Fill(ds);
            dat.DataSource = ds.Tables[0];
            conexion.Close();
        
    
    */
            dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,CATEGORIA,IMAGEN FROM TIPO_PRODUCTOS;");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();

                MySqlCommand command = new MySqlCommand("INSERT INTO TIPO_PRODUCTOS(CATEGORIA,IMAGEN) VALUES (@tipo_producto,@imagen)", conexion);

                command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value = txtNombre.Text;
                command.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = img;
                ExecMyQuery(command, "Datos Insertados");

                dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,CATEGORIA,IMAGEN FROM TIPO_PRODUCTOS;");

            }catch (Exception ex) {
                throw new Exception(ex.Message);

            }

            }

        public void ExecMyQuery(MySqlCommand mcomd, string myMsg)
        {
            try
            {
                conexion.Open();
                if (mcomd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(myMsg);
                }
                else
                {
                    MessageBox.Show("y");

                }
                conexion.Close();

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        /*
        private Categorias returnCategoria() {

            Categorias _categoria;
            try
            {
                if (validarTxtSs(txtNombre))
                {
                    _categoria =
                        new Categorias(3000,
                        txtNombre.Text
                    );
                    return _categoria;
                }
                else return null;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
                return null;
            }
        }
        */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string ubicacion;
            OpenFileDialog Open = new OpenFileDialog();
            Open.Title = "Abrir";
            Open.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (Open.ShowDialog() == DialogResult.OK)
            {
                ubicacion = Open.FileName;
                Bitmap Picture = new Bitmap(ubicacion);
                pictureBox1.Image = Picture;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox2.Text = ubicacion;

            }
        }

        private void txtSolonumeros(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;

            else e.Handled = true;


        }


        private bool validarTxtSs(TextBox txt)
        {

            if (string.IsNullOrEmpty(txt.Text))
            {
                MessageBox.Show("Complete el campo" + txt.AccessibleName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;


        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void dat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CATEGORIA_Load(object sender, EventArgs e)
        {

        }

        private void dat_Click(object sender, EventArgs e)
        {
            try{
                Byte[] img = (Byte[])dat.CurrentRow.Cells[2].Value;
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);

            }catch (Exception ex) {
                throw new Exception(ex.Message);

            }
            }
        
        private void dat_DoubleClick(object sender, EventArgs e)
        {/*
            string ubicacion;
            OpenFileDialog Open = new OpenFileDialog();
            Open.Title = "Abrir";
            Open.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (Open.ShowDialog()==DialogResult.OK) {
                ubicacion = Open.FileName;
                Bitmap Picture = new Bitmap(ubicacion);
                pictureBox1.Image = Picture;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox2.Text = ubicacion;
                
            }
            */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ubicacion;
            OpenFileDialog Open = new OpenFileDialog();
            Open.Title = "Abrir";
            Open.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (Open.ShowDialog() == DialogResult.OK)
            {
                ubicacion = Open.FileName;
                Bitmap Picture = new Bitmap(ubicacion);
                pictureBox1.Image = Picture;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox2.Text = ubicacion;

            }
        }

        private void dat_MouseClick(object sender, MouseEventArgs e)
        {

            Byte[] img = (Byte[])dat.CurrentRow.Cells[2].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            textBox1.Text = dat.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dat.CurrentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("UPDATE TIPO_PRODUCTOS SET CATEGORIA =@tipo_producto,IMAGEN=@imagen WHERE ID=@id", conexion);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox1.Text;
            command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value = txtNombre.Text;
            command.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = img;

            ExecMyQuery(command,"ACTUALIZADO");


            dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,CATEGORIA,IMAGEN FROM TIPO_PRODUCTOS;");
            Limpiar();
        }





        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM TIPO_PRODUCTOS WHERE ID =@id", conexion);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox1.Text;
           
            ExecMyQuery(command, "Datos Eliminados");
            Limpiar();
            dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,CATEGORIA,IMAGEN FROM TIPO_PRODUCTOS;");

        }

        private void Limpiar() {
            textBox1.Clear();
            txtNombre.Clear();
            textBox2.Clear();
            


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

     

        public void fill(string value) {
            MySqlCommand command = new MySqlCommand("SELECT* FROM TIPO_PRODUCTOS WHERE CONCAT(ID,CATEGORIA,IMAGEN) LIKE '%"+value+"'%", conexion);
            
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable reporte = new DataTable();
            try
            {
                reporte.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(reporte);
                conexion.Close();


            }
            catch (MySqlException ex)
            {
                int errorcode = ex.Number;
                MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT* FROM TIPO_PRODUCTOS WHERE ID=#@id", conexion);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox1.Text;
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable reporte = new DataTable();
            dataAdapter.Fill(reporte);
            if (reporte.Rows.Count <= 0)
            {
                MessageBox.Show("No existen los datos ingresados");

            }
            else
            {
                textBox1.Text = reporte.Rows[0][0].ToString();
                txtNombre.Text = reporte.Rows[0][1].ToString();

                byte[] img = (byte[])reporte.Rows[0][2];
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }
    }
    }
    