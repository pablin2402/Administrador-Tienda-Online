using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ESCRITORIO
{
    public partial class USUARIOS : Form

    {

        MySqlConnection conexion = new MySqlConnection("Server=31.22.4.94;Port=3306;Database=easybuyi_PROYECTO_FINAL;Uid=easybuyi_pablo;password=vacaslocas123987;");
        DataSet ds;
        BBDDComun v = new BBDDComun();
        public USUARIOS()
        {
            InitializeComponent();

            contra.Text = "";
            // The password character is an asterisk.  
            contra.PasswordChar = '*';
            // The control will allow no more than 14 characters.  
            contra.MaxLength = 14;
        }

        private void USUARIOS_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
             dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,NOMBRE,APELLIDO,CORREO,TELEFONO FROM USUARIOS;");

        }

        private void Limpiar()
        {
            id.Clear();
            apellido.Clear();
            txtNombre.Clear();
            contra.Clear();
            correo.Clear();



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
                    MessageBox.Show("Query");

                }
                conexion.Close();

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM USUARIOS WHERE ID =@id", conexion);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id.Text;

            ExecMyQuery(command, "Datos Eliminados");
            Limpiar();
            dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,NOMBRE,APELLIDO,CORREO FROM USUARIOS;");
        }

        private void dat_MouseClick(object sender, MouseEventArgs e)
        {
        
            id.Text = dat.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dat.CurrentRow.Cells[1].Value.ToString();
            apellido.Text = dat.CurrentRow.Cells[2].Value.ToString();
            correo.Text = dat.CurrentRow.Cells[3].Value.ToString();
            telefono.Text = dat.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            MySqlCommand command = new MySqlCommand("UPDATE USUARIOS SET NOMBRE =@tipo_producto, APELLIDO=@apellido,CLAVE=@contra WHERE ID=@id", conexion);

            command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value = txtNombre.Text;

            command.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = apellido.Text;

            command.Parameters.Add("@correo", MySqlDbType.VarChar).Value = correo.Text;

            command.Parameters.Add("@contra", MySqlDbType.VarChar).Value = contra.Text;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id.Text;

            ExecMyQuery(command, "ACTUALIZADO");


            dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,NOMBRE,APELLIDO,CORREO,TELEFONO FROM USUARIOS;");
            Limpiar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              

                MySqlCommand command = new MySqlCommand("INSERT INTO USUARIOS (NOMBRE,APELLIDO,CORREO,CLAVE,TELEFONO) VALUES (@tipo_producto,@apellido,@correo,@contra,@tel)", conexion);

                command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value = txtNombre.Text;

                command.Parameters.Add("@apellido", MySqlDbType.VarChar).Value = apellido.Text;

                command.Parameters.Add("@correo", MySqlDbType.VarChar).Value = correo.Text;

                command.Parameters.Add("@contra", MySqlDbType.VarChar).Value = contra.Text;
                command.Parameters.Add("@tel", MySqlDbType.Int32).Value = telefono.Text;

                ExecMyQuery(command, "Datos Insertados");

                dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,NOMBRE,APELLIDO,CORREO,TELEFONO FROM USUARIOS;");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }
        public static bool Email(string email)
        {

            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        private void correo_Leave(object sender, EventArgs e)
        {
            if (Email(correo.Text)) { }
            else {
                MessageBox.Show("Direccion de correo electronico no valida. "+"Porfavor ingrese un correo valido","Validacion de Correo Electrónico",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                correo.SelectAll();
                correo.Focus();

            }

        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }
    }
}
