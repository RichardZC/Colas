using Hra.Colas.Negocio;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hra.Colas.Web.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ReporteUsuario()
        {
            var data = UsuarioBL.Listar().Select(x => new { x.Id, x.NombreCompleto }).ToList();


            var rd = new ReportDataSource("dsUsuario", data);
            
            return Reporte("PDF", "rptUsuario.rdlc", rd, "A4Vertical0.25", null);
        }

        public ActionResult Reporte(string pTipoReporte, string rdlc, ReportDataSource rds, string pPapel, List<ReportParameter> pParametros = null)
        {
            var lr = new LocalReport();
            lr.ReportPath = Path.Combine(Server.MapPath("~/Reporte"), rdlc);

            if (rds != null) lr.DataSources.Add(rds);
            if (pParametros != null) lr.SetParameters(pParametros);

            string reportType = pTipoReporte;
            string mimeType;
            string encoding;
            string fileNameExtension;

            var deviceInfo = ObtenerPapel(pPapel).Replace("[TipoReporte]", pTipoReporte);
            Warning[] warnings;
            string[] streams;

            byte[] renderedBytes = lr.Render(reportType, deviceInfo, out mimeType, out encoding,
                                             out fileNameExtension, out streams, out warnings);

            return File(renderedBytes, mimeType);
        }

        private static string ObtenerPapel(string pPapel)
        {
            switch (pPapel)
            {
                case "A4Horizontal":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>11in</PageWidth>" +
                           "  <PageHeight>8.5in</PageHeight>" +
                           "  <MarginTop>0in</MarginTop>" +
                           "  <MarginLeft>0in</MarginLeft>" +
                           "  <MarginRight>0in</MarginRight>" +
                           "  <MarginBottom>0in</MarginBottom>" +
                           "</DeviceInfo>";
                case "A4Vertical":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>8.5in</PageWidth>" +
                           "  <PageHeight>11in</PageHeight>" +
                           "  <MarginTop>0in</MarginTop>" +
                           "  <MarginLeft>0in</MarginLeft>" +
                           "  <MarginRight>0in</MarginRight>" +
                           "  <MarginBottom>0in</MarginBottom>" +
                           "</DeviceInfo>";
                case "A4Horizontal0.25":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>11in</PageWidth>" +
                           "  <PageHeight>8.5in</PageHeight>" +
                           "  <MarginTop>0.25in</MarginTop>" +
                           "  <MarginLeft>0.25in</MarginLeft>" +
                           "  <MarginRight>0.25in</MarginRight>" +
                           "  <MarginBottom>0.25in</MarginBottom>" +
                           "</DeviceInfo>";
                case "A4Vertical0.25":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>8.5in</PageWidth>" +
                           "  <PageHeight>11in</PageHeight>" +
                           "  <MarginTop>0.25in</MarginTop>" +
                           "  <MarginLeft>0.25in</MarginLeft>" +
                           "  <MarginRight>0.25in</MarginRight>" +
                           "  <MarginBottom>0.25in</MarginBottom>" +
                           "</DeviceInfo>";
                case "TicketCaja":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>3.5in</PageWidth>" +
                           "  <PageHeight>5.0in</PageHeight>" +
                           "  <MarginTop>0in</MarginTop>" +
                           "  <MarginLeft>0.1in</MarginLeft>" +
                           "  <MarginRight>0in</MarginRight>" +
                           "  <MarginBottom>0in</MarginBottom>" +
                           "</DeviceInfo>";
                case "VoucherCaja":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>8.5in</PageWidth>" +
                           "  <PageHeight>11in</PageHeight>" +
                           "  <MarginTop>0in</MarginTop>" +
                           "  <MarginLeft>0in</MarginLeft>" +
                           "  <MarginRight>0in</MarginRight>" +
                           "  <MarginBottom>0in</MarginBottom>" +
                           "</DeviceInfo>";
                case "CodigoBarras":
                    return "<DeviceInfo>" +
                           "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                           "  <PageWidth>4.13in</PageWidth>" +
                           "  <PageHeight>2.76in</PageHeight>" +
                           "  <MarginTop>0in</MarginTop>" +
                           "  <MarginLeft>0in</MarginLeft>" +
                           "  <MarginRight>0in</MarginRight>" +
                           "  <MarginBottom>0in</MarginBottom>" +
                           "</DeviceInfo>";

            }

            return "<DeviceInfo>" +
                   "  <OutputFormat>[TipoReporte]</OutputFormat>" +
                   "  <PageWidth>8.5in</PageWidth>" +
                   "  <PageHeight>11in</PageHeight>" +
                   "  <MarginTop>0in</MarginTop>" +
                   "  <MarginLeft>0in</MarginLeft>" +
                   "  <MarginRight>0in</MarginRight>" +
                   "  <MarginBottom>0in</MarginBottom>" +
                   "</DeviceInfo>";
        }
    }
}