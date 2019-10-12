using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_ESCRITORIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
                if (menu.Width == 250)
                {
                    menu.Width = 57;

                }
                else
                {
                    menu.Width = 250;

                }
            }
        }
        private void Abrirpanel(object formhijo)
        {

            if (this.contenedor.Controls.Count > 0)
                this.contenedor.Controls.RemoveAt(0);

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.contenedor.Controls.Add(fh);
            this.contenedor.Tag = fh;
            fh.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Abrirpanel(new PRODUCTOS());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


            this.WindowState = FormWindowState.Normal;
            pictureBox2.Visible = false;
            maximizar.Visible = true;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
   

        private void cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void contenedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Abrirpanel(new CATEGORIA());
        }

        private void maximizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox2.Visible = true;
            maximizar.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Abrirpanel(new USUARIOS());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Abrirpanel(new BEBIDAS());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Abrirpanel(new Ropa());
        }
    }
}

