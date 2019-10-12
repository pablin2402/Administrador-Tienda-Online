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
    public partial class PRODUCTOS : Form
    {

        MySqlConnection conexion = new MySqlConnection("Server=31.22.4.94;Port=3306;Database=easybuyi_PROYECTO_FINAL;Uid=easybuyi_pablo;password=vacaslocas123987;");
        DataSet ds;

        BBDDComun v = new BBDDComun();
        public PRODUCTOS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try {        
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
                byte[] img = ms.ToArray();

                MySqlCommand command = new MySqlCommand("INSERT INTO PRODUCTOS (CATEGORIA_ID,NOMBRE,PRECIO,DESCRIPCION,IMAGEN,MARCA,ID_USUARIO) VALUES (@categoria_id,@nombre,@precio,@descripcion,@imagen,@marca,@idusuario)", conexion);

                command.Parameters.Add("@categoria_id", MySqlDbType.Int32).Value = textBox2.Text;
                command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = txtNombre.Text;
                command.Parameters.Add("@precio", MySqlDbType.Int32).Value = precio.Text;
                command.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = genero.Text;
                command.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = img;
                command.Parameters.Add("@marca", MySqlDbType.VarChar).Value = textBox3.Text;
                command.Parameters.Add("@idusuario", MySqlDbType.Int32).Value = iduser.Text;

                ExecMyQuery(command, "Datos Insertados");

                dat.DataSource = BBDDComun.GetMysqltable("SELECT PRODUCTO_ID,CATEGORIA_ID,NOMBRE,PRECIO,DESCRIPCION,IMAGEN,MARCA FROM PRODUCTOS;");

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

        private void button2_Click(object sender, EventArgs e)
        {
            dat.DataSource = BBDDComun.GetMysqltable("SELECT PRODUCTO_ID,CATEGORIA_ID,NOMBRE,PRECIO,DESCRIPCION,IMAGEN,MARCA,ID_USUARIO FROM PRODUCTOS;");


        }

        private void Insertar_load(object sender, EventArgs e) {

      

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
         //  Metodos.fillcb(comboBox1, "SELECT DISTINCT NOMBRE FROM USUARIOS;");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void marca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void genero_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
                pictureBox2.Image = Picture;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox1.Text = ubicacion;

            }
        }

        private void dat_MouseClick(object sender, MouseEventArgs e)
        {
            Byte[] img = (Byte[])dat.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox2.Image = Image.FromStream(ms);
            textBox4.Text = dat.CurrentRow.Cells[0].Value.ToString();

            textBox2.Text = dat.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dat.CurrentRow.Cells[2].Value.ToString();
            precio.Text = dat.CurrentRow.Cells[3].Value.ToString();
            genero.Text = dat.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dat.CurrentRow.Cells[6].Value.ToString();

        }

        private void dat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            string ubicacion;
            OpenFileDialog Open = new OpenFileDialog();
            Open.Title = "Abrir";
            Open.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (Open.ShowDialog() == DialogResult.OK)
            {
                ubicacion = Open.FileName;
                Bitmap Picture = new Bitmap(ubicacion);
                pictureBox2.Image = Picture;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                textBox1.Text = ubicacion;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            byte[] img = ms.ToArray();

            MySqlCommand command = new MySqlCommand("UPDATE PRODUCTOS SET NOMBRE =@tipo_producto, PRECIO =@tipo,IMAGEN=@imagen WHERE PRODUCTO_ID=@id", conexion);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox4.Text;
            command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value = txtNombre.Text;
            command.Parameters.Add("@tipo", MySqlDbType.Int32).Value = precio.Text;
            command.Parameters.Add("@imagen", MySqlDbType.LongBlob).Value = img;

            ExecMyQuery(command, "ACTUALIZADO");


            dat.DataSource = BBDDComun.GetMysqltable("SELECT * FROM PRODUCTOS;");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            MySqlCommand command = new MySqlCommand("DELETE FROM PRODUCTOS WHERE PRODUCTO_ID =@id", conexion);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = textBox4.Text;

            ExecMyQuery(command, "Datos Eliminados");
           
            dat.DataSource = BBDDComun.GetMysqltable("SELECT PRODUCTO_ID,CATEGORIA_ID,NOMBRE,PRECIO,DESCRIPCION,IMAGEN,MARCA FROM PRODUCTOS;");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void iduser_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }
    }
}
