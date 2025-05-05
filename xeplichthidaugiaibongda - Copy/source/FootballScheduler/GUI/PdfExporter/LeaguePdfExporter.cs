using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using DTO;

namespace GUI.PdfExporter
{
    public class LeaguePdfExporter : PdfExportTemplate<LeagueDTO>
    {
        protected override void AddTitle(Document doc)
        {
            // Tiêu đề cho danh sách giải đấu
            Paragraph title = new Paragraph("DANH SÁCH GIẢI ĐẤU", titleFont)
            {
                Alignment = Element.ALIGN_CENTER
            };
            doc.Add(title);
            doc.Add(new Paragraph(" "));
        }

        protected override void AddTable(Document doc, List<LeagueDTO> leagues)
        {
            // Khởi tạo bảng với 4 cột
            PdfPTable table = new PdfPTable(4)
            {
                WidthPercentage = 100
            };
            table.SetWidths(new float[] { 1, 3, 2, 2 }); // Đặt chiều rộng cột

            // Thêm tiêu đề cột
            table.AddCell(CreateHeaderCell("Mã Giải Đấu"));
            table.AddCell(CreateHeaderCell("Tên Giải Đấu"));
            table.AddCell(CreateHeaderCell("Ngày Bắt Đầu"));
            table.AddCell(CreateHeaderCell("Ngày Kết Thúc"));

            // Duyệt qua danh sách giải đấu và thêm dữ liệu vào bảng
            foreach (var league in leagues)
            {
                string startDate = league.StartDate.ToString("dd/MM/yyyy");
                string endDate = league.EndDate.ToString("dd/MM/yyyy");

                table.AddCell(new PdfPCell(new Phrase(league.LeagueID, cellFont)));
                table.AddCell(new PdfPCell(new Phrase(league.LeagueName, cellFont)));
                table.AddCell(new PdfPCell(new Phrase(startDate, cellFont)));
                table.AddCell(new PdfPCell(new Phrase(endDate, cellFont)));
            }

            // Thêm bảng vào tài liệu PDF
            doc.Add(table);
        }

        private PdfPCell CreateHeaderCell(string text)
        {
            return new PdfPCell(new Phrase(text, headerFont))
            {
                BackgroundColor = new BaseColor(230, 230, 250),
                HorizontalAlignment = Element.ALIGN_CENTER
            };
        }
    }
}
