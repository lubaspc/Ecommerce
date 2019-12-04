using Ecommerce.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ecommerce.Reportes
{
    public class ComprasReport
    {
        #region Declaracion de variables
        int _totalColumn = 4;
        Document _document;
        Font _fontstyle;
        PdfPTable _pdfTable = new PdfPTable(4);
        PdfPCell _pdfPCell;
        MemoryStream _memoryStream=new MemoryStream();
        List<DetalleCompras> _detalles = new List<DetalleCompras>();
        Compras _compra = new Compras();
        #endregion

        public byte[] PrepararReport(List<DetalleCompras> detalles, Compras compra)
        {
            _detalles = detalles;
            _compra = compra;
            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontstyle = FontFactory.GetFont("Arial",12f,1);
            PdfWriter.GetInstance(_document,_memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 200f, 100f, 100f ,100f});
            #endregion
            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();
        }
        private void ReportHeader()
        {
            _fontstyle = FontFactory.GetFont("Arial", 12f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Champam Reporte de Compras", _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Arial", 9f, 1);
            _pdfPCell = new PdfPCell(new Phrase("Lista de compra", _fontstyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Numero de compra: ", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Colspan = 1;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_compra.Id+"", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Fecha de compra: ", _fontstyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_compra.FechaCompra + "", _fontstyle));
            _pdfPCell.Colspan = 3;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase("Proveedor: ", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase(_compra.Provedores.Nombre+"", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            

            _pdfPCell = new PdfPCell(new Phrase("Total: ", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("$"+_compra.Total + "", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
        }
        private void ReportBody()
        {
            #region Table header
            _fontstyle = FontFactory.GetFont("Arial", 8f, 1);

            _pdfPCell = new PdfPCell(new Phrase("Producto", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Cantidad", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("SubTotal", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);

            _pdfPCell = new PdfPCell(new Phrase("Fecha de vencimiento", _fontstyle));
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfPCell);
            _pdfTable.CompleteRow();
            #endregion
            #region Table Body
            _fontstyle = FontFactory.GetFont("Arial", 8f, 1);
            foreach(DetalleCompras detalle in _detalles)
            {
                _pdfPCell = new PdfPCell(new Phrase(detalle.Productos.Nombre, _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detalle.Cantidad + "", _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detalle.SubTotal+"", _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detalle.Fecha_vencimiento + "", _fontstyle));
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfPCell);
                _pdfTable.CompleteRow();
            }
            #endregion
        }
    }
}