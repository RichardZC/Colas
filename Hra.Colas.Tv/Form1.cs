using Hra.Colas.Datos;
using Hra.Colas.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Hra.Colas.Tv
{
    public partial class Form1 : Form
    {
        //public string CodigoCola { get; set; }
        //public string Servicio{ get; set; }
        public string Ventanilla{ get; set; }
        public string Atendido{ get; set; }
        public Form1()
        {
            InitializeComponent();

            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;
            foreach (var item in Directory.GetFiles(@"C:\videos", "*.mp4"))
            {
                WMPLib.IWMPMedia nueva = axWindowsMediaPlayer1.newMedia(item);
                axWindowsMediaPlayer1.currentPlaylist.appendItem(nueva);
            }
            axWindowsMediaPlayer1.Ctlcontrols.play();

            var bloqueid = int.Parse(ConfigurationManager.AppSettings["Bloque"]);

            var lista = TvBL.ListarTv(bloqueid);

            label1.Text = lista[0].Denominacion;
            label2.Text = lista[1].Denominacion;
            label3.Text = lista[2].Denominacion;
            label4.Text = lista[3].Denominacion;
        }
        //var dQuery = dbContext.CreateQuery<DateTime>("CurrentDateTime() ");
        //DateTime dbDate = dQuery.AsEnumerable().First();
        private void Form1_Load(object sender, EventArgs e)
        {           
           
        }

        public void EncolarTicket(String CodigoCola, String Servicio)
        {
            
        }


    }
}
