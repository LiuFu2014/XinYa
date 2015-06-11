using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing;

namespace XinYaBarCodePrinter
{
    class PrintHelp : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        //private DataTable LoadSalesData()
        //{
        //    DataSet dataSet = new DataSet();
        //    dataSet.ReadXml("data.xml");
        //    return dataSet.Tables[0];
        //}

        private Object LoadSalesData()
        {
            try
            {
                return Image.FromFile("D://BarCode.jpg");
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private Stream CreateStream(string name, string fileNameExtension,
          Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension,
              FileMode.Create);
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>8.5in</PageWidth>" +
              "  <PageHeight>11in</PageHeight>" +
              "  <MarginTop>0.25in</MarginTop>" +
              "  <MarginLeft>0.25in</MarginLeft>" +
              "  <MarginRight>0.25in</MarginRight>" +
              "  <MarginBottom>0.25in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage =
              new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, 0, 0);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            const string printerName =
              "Zebra ZM400 (203 dpi) - ZPL";

            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            if (!printDoc.PrinterSettings.IsValid)
            {
                string msg = String.Format("Can't find printer \"{0}\".",
                  printerName);
                Debug.WriteLine(msg);
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }

        public void Run()
        {
            LocalReport report = new LocalReport();
            report.ReportPath = @"D:\项目资料\鑫亚\开发\XinYaBarCodePrinter\XinYaBarCodePrinter\Report1.rdlc";
            report.DataSources.Add(new ReportDataSource("Sales", LoadSalesData()));

            Export(report);

            m_currentPageIndex = 0;
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        //public static int Main(string[] args)
        //{
        //    using (PrintHelp demo = new PrintHelp())
        //    {
        //        demo.Run();
        //    }
        //    return 0;
        //}

    }
}
