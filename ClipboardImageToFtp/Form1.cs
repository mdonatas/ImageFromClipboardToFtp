using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Jelovic.FtpLib;

namespace ClipboardImageToFtp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string? ImagePath { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            AcceptButton = buttonSelect;

            textBoxPrefix.Text = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);

            if (TryGetImagePath(out var imagePath))
            {
                ImagePath = imagePath!;
                textBoxSuffix.Text = Path.GetFileName(imagePath)![..^new FileInfo(imagePath).Extension.Length];
                statusLabel.Text = $"Image: {imagePath}";
            }
            else if (Clipboard.ContainsImage())
            {
                statusLabel.Text = "Image: from clipboard";
            }
            else
            {
                Close();
            }

            textBoxSuffix.Select();
        }

        private bool TryGetImagePath([NotNullWhen(true)] out string? imagePath)
        {
            imagePath = null;

            if (Clipboard.ContainsText())
            {
                var text = Clipboard.GetText();
                if (text.Length >= 300)
                    return false;

                text = text.Trim(' ', '"');

                if ((text.EndsWith(".png") || text.EndsWith(".jpg") || text.EndsWith(".jpeg") || text.EndsWith(".gif")) &&
                    File.Exists(text))
                {
                    imagePath = text;
                    return true;
                }
            }

            return false;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            Logic();
            Close();
        }

        private void Logic()
        {
            var settings = ConfigurationManager.AppSettings;

            var imageFullPath = string.Empty;
            var imageName = default(string?);
            var tempImageFile = false;

            string GetImageName(string extension)
            {
                var imageName = default(string?);

                if (string.IsNullOrEmpty(textBoxPrefix.Text) || string.IsNullOrEmpty(textBoxSuffix.Text))
                    imageName = $"{textBoxPrefix.Text.Trim()}{textBoxSuffix.Text.Trim()}{extension}";
                else
                    imageName = $"{textBoxPrefix.Text}_{textBoxSuffix.Text}{extension}";

                foreach (var chr in Path.GetInvalidFileNameChars())
                    imageName = imageName!.Replace(chr, '_');

                return imageName;
            }

            if (File.Exists(ImagePath ?? string.Empty))
            {
                imageFullPath = ImagePath!;
                imageName = GetImageName(new FileInfo(imageFullPath).Extension);
            }
            else if (Clipboard.ContainsImage())
            {
                imageName = GetImageName(".png");

                using (var image = Clipboard.GetImage()!)
                {
                    imageFullPath = Path.Combine(Path.GetTempPath(), imageName);
                    image.Save(imageFullPath, System.Drawing.Imaging.ImageFormat.Png);
                    tempImageFile = true;
                }
            }
            else
            {
                Close();
            }

            using (var internetAccess = new InternetAccess())
            {
                using (var connection = internetAccess.FtpConnect(settings["FtpUrl"], 21, settings["Username"], settings["Password"], true))
                {
                    connection.UploadFile(imageFullPath, "/" + imageName, TransferType.Binary, CachingFlags.None);
                }
            }

            if (tempImageFile)
                File.Delete(imageFullPath);

            Clipboard.SetText(settings["HttpUrl"] + imageName.Replace(" ", "%20"));
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxPrefix.Clear();
        }

        private void textBoxSuffix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }

        private void textBoxPrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }
    }
}
