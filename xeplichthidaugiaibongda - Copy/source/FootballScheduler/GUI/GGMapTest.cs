using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace GUI
{
    public partial class GGMapTest : Form
    {
        private WebView2 webView;
        private TextBox latTextBox;
        private TextBox lngTextBox;

        public GGMapTest()
        {
            InitializeComponent();

            // Khởi tạo WebView2
            webView = new WebView2
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(webView);

            // Tạo các ô nhập liệu để hiển thị tọa độ
            latTextBox = new TextBox { Left = 10, Top = 10, Width = 200 };
            lngTextBox = new TextBox { Left = 10, Top = 40, Width = 200 };

            this.Controls.Add(latTextBox);
            this.Controls.Add(lngTextBox);

            Load += GGMapTest_Load;
        }

        private async void GGMapTest_Load(object sender, EventArgs e)
        {
            try
            {
                var options = new CoreWebView2EnvironmentOptions(
                    "--disable-gpu --no-sandbox --disable-background-networking --disable-sync");

                var env = await CoreWebView2Environment.CreateAsync(null, null, options);
                await webView.EnsureCoreWebView2Async(env);

                var settings = webView.CoreWebView2.Settings;
                settings.IsStatusBarEnabled = false;
                settings.AreDefaultContextMenusEnabled = false;
                settings.IsZoomControlEnabled = false;
                settings.AreDefaultScriptDialogsEnabled = false;
                settings.AreDevToolsEnabled = false;
                settings.IsWebMessageEnabled = true;

                // Nhận tọa độ gửi từ Leaflet
                webView.CoreWebView2.WebMessageReceived += (s, args) =>
                {
                    string coords = args.TryGetWebMessageAsString();
                    // Hiển thị tọa độ trong các ô TextBox
                    string[] splitCoords = coords.Split(',');
                    if (splitCoords.Length == 2)
                    {
                        latTextBox.Text = splitCoords[0];  // Gán vĩ độ vào TextBox lat
                        lngTextBox.Text = splitCoords[1];  // Gán kinh độ vào TextBox lng
                    }

                    // Hiển thị thông báo với tọa độ
                    MessageBox.Show($"Tọa độ click: {coords}", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                // HTML để hiển thị bản đồ với Leaflet.js
                string html = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8' />
    <title>Leaflet Map</title>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <style>
        html, body, #map { height: 100%; margin: 0; padding: 0; }
    </style>
    <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css' />
    <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
</head>
<body>
    <div id='map'></div>
    <script>
        var map = L.map('map').setView([21.0285, 105.8542], 13);  // Vị trí mặc định (Hà Nội)

        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);

        var marker;

        map.on('click', function(e) {
            var lat = e.latlng.lat.toFixed(6);  // Lấy vĩ độ
            var lng = e.latlng.lng.toFixed(6);  // Lấy kinh độ

            // Thêm marker tại vị trí click
            if (marker) map.removeLayer(marker);
            marker = L.marker([lat, lng]).addTo(map);

            // Gửi tọa độ tới ứng dụng WinForms qua WebView2
            if (window.chrome && window.chrome.webview) {
                window.chrome.webview.postMessage(lat + ',' + lng);
            }
        });
    </script>
</body>
</html>";

                // Mở trang HTML trong WebView2
                webView.NavigateToString(html);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo WebView2:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
