using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ESCRITORIO
{
    public partial class Ropa : Form
    {
        MySqlConnection conexion = new MySqlConnection("Server=31.22.4.94;Port=3306;Database=easybuyi_PROYECTO_FINAL;Uid=easybuyi_pablo;password=vacaslocas123987;");
        DataSet ds;

        BBDDComun v = new BBDDComun();
        public Ropa()
        {
            InitializeComponent();
        }

        private void Ropa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                MySqlCommand command = new MySqlCommand("INSERT INTO MARCA (NOMBRE,PAIS_ORIGEN) VALUES (@tipo_producto,@pais)", conexion);

                command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value = marca.Text;
                command.Parameters.Add("@pais", MySqlDbType.VarChar).Value = pais.Text;
               

                ExecMyQuery(command, "Datos Insertados");

                dat.DataSource = BBDDComun.GetMysqltable("SELECT ID,NOMBRE,PAIS_ORIGEN FROM MARCA;");

            }
            catch (Exception ex)
            {
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
            dat.DataSource = BBDDComun.GetMysqltable("SELECT *from MARCA;");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("UPDATE MARCA SET NOMBRE =@tipo_producto WHERE ID=@id", conexion);

            command.Parameters.Add("@tipo_producto", MySqlDbType.VarChar).Value =marca.Text;

        
        
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = usuario.Text;

            ExecMyQuery(command, "ACTUALIZADO");


            dat.DataSource = BBDDComun.GetMysqltable("SELECT *FROM MARCA;");
        }

        private void id1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dat_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dat_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void marca_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dat_MouseClick(object sender, MouseEventArgs e)
        {
            marca.Text = dat.CurrentRow.Cells[1].Value.ToString();
            pais.Text = dat.CurrentRow.Cells[2].Value.ToString();
            usuario.Text = dat.CurrentRow.Cells[0].Value.ToString();
        }

        private void pais_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }
    }
}
