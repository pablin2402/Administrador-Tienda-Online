using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ESCRITORIO
{
    class BBDDComun
    {
        public static MySqlConnection Obtenerconexion() {
            const string connMysql = "Server = 31.22.4.94; Port = 3306; Database = easybuyi_PROYECTO_FINAL; Uid = easybuyi_pablo; password = vacaslocas123987; ";
            MySqlConnection conectar = new MySqlConnection(connMysql);
            try
            {
                conectar.Open();
            }
            catch(MySqlException ex) {
                int errorcode = ex.Number;
                MessageBox.Show(ex.Message +"Error"+ errorcode );
            }
            return conectar;
        }

        public void solonumeros(KeyPressEventArgs e) {
            try
            {
                if (Char.IsNumber (e.KeyChar)) {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar)) {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar)) {
                    e.Handled = true;

                }
                else {
                    e.Handled = true;

                }

            }
            catch (Exception ex){


            }

        }
        public void sololetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = true;

                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Solo se admiten números","Validacion de número",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {


            }

        }
        public static bool Email(string email) {

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


        public static MySqlDataReader reader(string _string, MySqlConnection conexion)
        {
            MySqlCommand _comando = new MySqlCommand(_string,conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            return _reader;
        }



        public static DataTable GetMysqltable(string _string)
        {
            MySqlConnection conexion = Obtenerconexion();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(_string, conexion);
            MySqlCommandBuilder commanBuilder = new MySqlCommandBuilder(dataAdapter);

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
            return reporte;
        }

        public static int SendCommand(string _string) {
            int retorno = 0;
            MySqlConnection conexion = BBDDComun.Obtenerconexion();
            MySqlCommand comando = new MySqlCommand(_string,conexion);
            try {
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            } catch (MySqlException ex) {
                int errocode = ex.Number;
                MessageBox.Show(ex.Message+"N error:"+errocode);
            }
            return retorno;}



    }
    }

