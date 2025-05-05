using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;
using System.IO;

namespace GUI.PdfExporter
{
    public abstract class PdfExportTemplate<T>
    {
        protected BaseFont baseFont;
        protected Font titleFont;
        protected Font headerFont;
        protected Font cellFont;

        // Phương thức để xuất dữ liệu
        public void Export(List<T> data, string fileName)
        {
            SetupFont();
            using (Document doc = new Document(PageSize.A4, 25, 25, 30, 30))
            {
                PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));
                doc.Open();

                // Thêm tiêu đề
                AddTitle(doc);

                // Thêm bảng
                AddTable(doc, data);

                doc.Close();
            }
        }

        protected virtual void SetupFont()
        {
            string fontPath = Path.Combine(Path.GetTempPath(), "times_temp.ttf");
            if (!File.Exists(fontPath))
            {
                using (var fs = new FileStream(fontPath, FileMode.Create))
                {
                    fs.Write(Properties.Resources.TimesFont, 0, Properties.Resources.TimesFont.Length);
                }
            }

            baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            titleFont = new Font(baseFont, 16, Font.BOLD);
            headerFont = new Font(baseFont, 12, Font.BOLD);
            cellFont = new Font(baseFont, 12);
        }

        protected abstract void AddTitle(Document doc);
        protected abstract void AddTable(Document doc, List<T> dataList);
    }
}
