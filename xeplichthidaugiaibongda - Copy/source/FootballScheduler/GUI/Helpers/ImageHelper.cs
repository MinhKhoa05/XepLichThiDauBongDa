using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI.Helpers
{
    public static class ImageHelper
    {
        private const int DefaultWidth = 50;  // Kích thước mặc định cho ảnh
        private const int DefaultHeight = 50;

        private static readonly string _folderAssets = "Assets";  // Tên thư mục chứa ảnh
        private static readonly string _assetsDirectory;         // Đường dẫn đến thư mục Assets
        private static readonly Bitmap _defaultImage;            // Hình ảnh mặc định khi không có ảnh

        static ImageHelper()
        {
            // Khởi tạo thư mục Assets và ảnh mặc định
            _assetsDirectory = Path.Combine(GetBaseDirectory(), _folderAssets);
            EnsureDirectoryExists(_assetsDirectory);
            _defaultImage = Properties.Resources.default_logo;  // Dùng hình ảnh mặc định từ Resources
        }

        /// <summary>
        /// Lưu ảnh vào thư mục chỉ định dưới dạng PNG.
        /// </summary>
        public static string SaveImageToFile(string folderName, string fileName, Image image)
        {
            if (image == null) return null;

            try
            {
                // Đường dẫn đầy đủ để lưu ảnh
                string savePath = GetFullPath(folderName, $"logo_{fileName}.png");
                EnsureDirectoryExists(Path.GetDirectoryName(savePath));  // Đảm bảo thư mục tồn tại

                image.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);  // Lưu ảnh
                return Path.Combine(folderName, Path.GetFileName(savePath));  // Trả về đường dẫn ảnh đã lưu
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Tải ảnh từ thư mục và resize nếu cần.
        /// </summary>
        public static Image GetImageFromFile(string relativePath, int width = DefaultWidth, int height = DefaultHeight)
        {
            if (string.IsNullOrEmpty(relativePath))
                return ResizeImage(_defaultImage, width, height);  // Nếu không có ảnh, dùng ảnh mặc định

            string fullPath = GetFullPath(relativePath);
            if (!File.Exists(fullPath))
                return ResizeImage(_defaultImage, width, height);  // Nếu không tồn tại file ảnh, dùng ảnh mặc định

            try
            {
                using (var original = Image.FromFile(fullPath))  // Tải ảnh từ file
                {
                    return ResizeImage(new Bitmap(original), width, height);  // Resize ảnh về kích thước yêu cầu
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ảnh từ file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ResizeImage(_defaultImage, width, height);  // Trường hợp lỗi, trả ảnh mặc định
            }
        }

        /// <summary>
        /// Mở hộp thoại để người dùng chọn ảnh từ máy tính.
        /// </summary>
        public static Image SelectImageFromFile()
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg;*.jpeg;*.png"  // Chỉ chọn ảnh JPG, JPEG, PNG
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return Image.FromFile(dialog.FileName);  // Trả về ảnh đã chọn
                }
            }

            return null;  // Trả về null nếu người dùng không chọn ảnh
        }

        #region Helper Methods

        /// <summary>
        /// Lấy đường dẫn thư mục gốc của ứng dụng.
        /// </summary>
        private static string GetBaseDirectory()
        {
            var parent = Directory.GetParent(Application.StartupPath);
            return parent?.Parent?.FullName ?? Application.StartupPath;  // Trả về thư mục gốc của ứng dụng
        }

        /// <summary>
        /// Đảm bảo thư mục tồn tại. Nếu không, tạo mới.
        /// </summary>
        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);  // Tạo thư mục nếu chưa tồn tại
            }
        }

        /// <summary>
        /// Lấy đường dẫn đầy đủ của file ảnh trong thư mục Assets.
        /// </summary>
        private static string GetFullPath(string folder, string file = "")
        {
            return Path.Combine(_assetsDirectory, folder, file).TrimEnd('\\');  // Trả về đường dẫn đầy đủ của file ảnh
        }

        /// <summary>
        /// Resize ảnh về kích thước mong muốn.
        /// </summary>
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var resized = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(image, 0, 0, width, height);  // Resize ảnh
            }

            return resized;
        }

        #endregion
    }
}
