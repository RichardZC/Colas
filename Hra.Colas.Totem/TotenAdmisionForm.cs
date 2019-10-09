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

namespace Hra.Colas.Totem
{
    public partial class TotenAdmisionForm : Form
    {

        string imagen = @"C:\GITHUB\Colas\Hra.Colas.Totem\img\logo.png";
        public string Servicio { get; set; }
        public string Codigo { get; set; } 
        
        public TotenAdmisionForm()
        {
            InitializeComponent();
        }
        private void TotenAdmisionForm_Load(object sender, EventArgs e)
        {
            var bloque = int.Parse(ConfigurationManager.AppSettings["Bloque"]);
            var servicios = ServicioBL.Listar(x => x.BloqueId == bloque);
            var i = servicios.Count;
            
            if (i == 1)
            {
                btn1.Visible = true;
                btn1.Text = servicios[0].Denominacion;
                btn1.Tag = servicios[0].Id;

                btn2.Visible = false;
            }
            if (i == 2)
            {
                btn1.Visible = true;
                btn1.Text = servicios[0].Denominacion;
                btn1.Tag = servicios[0].Id;

                btn2.Visible = true;
                btn2.Text = servicios[1].Denominacion;
                btn2.Tag = servicios[1].Id;
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCerrar_MouseEnter(object sender, EventArgs e)
        {

            //btnCerrar.Hide();
            //BackColor = Color.Red;
        }

        private void BtnCerrar_MouseLeave(object sender, EventArgs e)
        {
            //btnCerrar.Show();
            //BackColor = Color.Black;
        }

        private void TotenAdmisionForm_MouseEnter(object sender, EventArgs e)
        {
          
        }

        private void TotenAdmisionForm_MouseLeave(object sender, EventArgs e)
        {
            //btnCerrar.Hide();
            //BackColor = Color.Red;
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            GenerarTikect(int.Parse(btn1.Tag.ToString()), btn1.Text);
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            GenerarTikect(int.Parse(btn2.Tag.ToString()), btn2.Text);
        }

        private void GenerarTikect(int servicioId, string servicio)
        {
            Servicio = servicio;
            var numero = ColaBL.Contar(x => x.Fecha.Year == DateTime.Now.Year
            && x.Fecha.Month == DateTime.Now.Month && x.Fecha.Day == DateTime.Now.Day
            && x.ServicioId == servicioId);// obtener del servidor
            Codigo = servicio.Substring(0, 2) + (numero + 1).ToString();

            // mejorar para que guarde la fecha de servidor
            ColaBL.Crear(new Cola()
            {
                ServicioId = servicioId,
                Fecha = DateTime.Now,
                Codigo = Codigo
            });

            printDocument2 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument2.PrinterSettings = ps;
            printDocument2.PrintPage += Imprimir;
          
           
            var tam = new PaperSize();
            tam.RawKind = 35;
            //tam.Height = 56;
            //tam.Width = 56;
            ps.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", 150,130);
            //ps.DefaultPageSettings.PaperSize = tam;
            //ps.DefaultPageSettings.Landscape = true;
            //ps.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            // printDocument2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("ticket", 240, 350);
            printDocument2.Print();                                          
        }

        private void Imprimir(Object sender, PrintPageEventArgs e)
        {            
            Font font1 = new Font("Arial", 06, FontStyle.Bold, GraphicsUnit.Point);
            Font font2 = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Point);
            int width = 350;
            int y = 5;
            Image img = Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new Rectangle(50, 7, 150, 30));
            e.Graphics.DrawString("" + Servicio, font1, Brushes.Black, new RectangleF(20, y += 50, width, 20));
            e.Graphics.DrawString("Numero de ticket", font1, Brushes.Black, new RectangleF(20, y += 20, 400, 40));
            e.Graphics.DrawString("" + Codigo, font2, Brushes.Black, new RectangleF(65, y += 10, width, 20));
            e.Graphics.DrawString("No pierda su Ticket", font1, Brushes.Black, new RectangleF(20, y += 25, 400, 40));
            e.Graphics.DrawString("" + DateTime.Now.ToString(), font1, Brushes.Black, new RectangleF(85, y += 20, width, 20));
        }

       
    }
}
