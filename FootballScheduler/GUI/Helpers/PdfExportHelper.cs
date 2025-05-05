using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GUI.Helpers
{
    public static class PdfExportHelper
    {
        /// <summary>
        /// Xuất danh sách ra file PDF, xem trước trước khi lưu
        /// </summary>
        public static void ExportToPdf<T>(List<T> items, string title, List<string> headers, List<Func<T, string>> extractors)
        {
            try
            {
                // Khởi tạo font từ resource
                var font = LoadTimesNewRomanFont();

                // Tạo file tạm để xem trước
                string tempPath = Path.Combine(Path.GetTempPath(), $"preview_{Guid.NewGuid()}.pdf");

                using (var stream = new FileStream(tempPath, FileMode.Create))
                using (var doc = new Document(PageSize.A4, 25, 25, 30, 30))
                {
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    // Thêm tiêu đề
                    doc.Add(new Paragraph(title, new Font(font, 18, Font.BOLD)) { Alignment = Element.ALIGN_CENTER });
                    doc.Add(new Paragraph(" ")); // Dòng trống

                    // Tạo bảng dữ liệu
                    var table = new PdfPTable(headers.Count) { WidthPercentage = 100 };

                    // Thêm header
                    foreach (var header in headers)
                    {
                        var cell = new PdfPCell(new Phrase(header, new Font(font, 12, Font.BOLD)))
                        {
                            BackgroundColor = new BaseColor(230, 230, 250)
                        };
                        table.AddCell(cell);
                    }

                    // Tính toán chiều rộng cột dựa trên chiều dài của header và nội dung dữ liệu
                    float[] columnWidths = new float[headers.Count];

                    for (int i = 0; i < headers.Count; i++)
                    {
                        int maxLength = headers[i].Length;  // Bắt đầu với chiều dài header

                        // Duyệt qua tất cả các mục để tìm chiều dài tối đa trong cột
                        foreach (var item in items)
                        {
                            string cellValue = extractors[i](item);
                            if (cellValue.Length > maxLength)
                            {
                                maxLength = cellValue.Length;
                            }
                        }

                        // Tạo độ rộng cho cột dựa trên độ dài tối đa
                        columnWidths[i] = maxLength + 5; // Tăng thêm một chút để tránh cột quá chật
                    }

                    // Áp dụng độ rộng cột đã tính toán
                    table.SetWidths(columnWidths);

                    // Thêm dữ liệu
                    foreach (var item in items)
                    {
                        foreach (var extractor in extractors)
                        {
                            table.AddCell(new Phrase(extractor(item), new Font(font, 12)));
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                // Mở file xem trước
                using (var saveDialog = new SaveFileDialog { Filter = "PDF files (*.pdf)|*.pdf", Title = "Lưu file PDF" })
                {
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(tempPath, saveDialog.FileName, true);
                        Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải font Times New Roman từ resource
        /// </summary>
        private static BaseFont LoadTimesNewRomanFont()
        {
            byte[] fontData = Properties.Resources.TimesFont; // Font đã thêm vào Resource (TimesNewRoman.ttf)
            using (var stream = new MemoryStream(fontData))
            {
                return BaseFont.CreateFont("TimesNewRoman.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, true, stream.ToArray(), null);
            }
        }
    }
}
