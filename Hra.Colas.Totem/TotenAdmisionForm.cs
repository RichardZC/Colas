using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hra.Colas.Totem
{
    public partial class TotenAdmisionForm : Form
    {
        public TotenAdmisionForm()
        {
            InitializeComponent();
        }

        private void TotenAdmisionForm_Load(object sender, EventArgs e)
        {
            var bloque = int.Parse(ConfigurationManager.AppSettings["Bloque"]);
            var servicios = ServicioBL.Listar(x => x.BloqueId == bloque); 

            var i = servicios.Count;

            if (i==1)
            {
                btn1.Visible = true;
                btn1.Text = servicios[0].Denominacion;
            }
            if (i == 2)
            {
                btn1.Visible = true;
                btn1.Text = servicios[0].Denominacion;

                btn2.Visible = true;
                btn2.Text = servicios[1].Denominacion;
            }
            //for (int i = 0; i < servicios.Count; i++)
            //{
            //    Button btn1 = new Button();
            //    btn1.Location = new System.Drawing.Point((i * 350), 60);
            //    btn1.Size = new System.Drawing.Size(200, 25);
            //    btn1.Text = servicios[i].Denominacion;
            //    btn1.Click += new EventHandler(button1_Click);

            //    panel1.Controls.Add(btn1);
            //}



        }
        //private void button1_Click(object sender, System.EventArgs e)
        //{
        //    MessageBox.Show("click");

        //}

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {

        }
    }
}
