using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace AI_TEST_2
{
    public partial class Form1 : Form
    {
        private Bitmap _originalImage;
        private Bitmap _processedImage;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            cmbAlgorithm.Items.Add("Contrast");
            cmbAlgorithm.Items.Add("Gradient");
            picOriginal.SizeMode = PictureBoxSizeMode.StretchImage;
            picProcessed.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Код обработчика событий для кнопки "Open"
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _originalImage = new Bitmap(ofd.FileName);
                picOriginal.Image = _originalImage;
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            // Код обработчика событий для кнопки "Process"
            if (_originalImage == null)
            {
                MessageBox.Show("Please open an image first.");
                return;
            }

            if (cmbAlgorithm.SelectedItem == null)
            {
                MessageBox.Show("Please select an algorithm first.");
                return;
            }

            string algorithm = cmbAlgorithm.SelectedItem.ToString();

            button2.Enabled = false;

            if (algorithm == "Contrast")
            {
                _processedImage = await Task.Run(() => ProcessContrast(_originalImage));
            }
            else if (algorithm == "Gradient")
            {
                _processedImage = await Task.Run(() => ProcessGradient(_originalImage));
            }

            picProcessed.Image = _processedImage;

            button2.Enabled = true;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
             
        }

        private void OriginalImage_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Код алгоритма контрастирования.
        private unsafe Bitmap ProcessContrast(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, result.PixelFormat);

            byte* ptr = (byte*)bitmapData.Scan0;
            byte* resPtr = (byte*)resultData.Scan0;

            int bytesPerPixel = Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;

            for (int y = 0; y < bitmapData.Height; y++)
            {
                byte* row = ptr + (y * bitmapData.Stride);
                byte* resRow = resPtr + (y * resultData.Stride);

                for (int x = 0; x < bitmapData.Width; x++)
                {
                    byte* pixel = row + x * bytesPerPixel;
                    byte* resPixel = resRow + x * bytesPerPixel;

                    for (int i = 0; i < bytesPerPixel; i++)
                    {
                        int newValue = pixel[i] + 50; // Увеличиваем контрастность
                        resPixel[i] = (byte)Math.Min(255, Math.Max(0, newValue));
                    }
                }
            }

            image.UnlockBits(bitmapData);
            result.UnlockBits(resultData);

            return result;
        }
        // Код алгоритма градиента.
        private unsafe Bitmap ProcessGradient(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);
            BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height), ImageLockMode.WriteOnly, result.PixelFormat);

            byte* ptr = (byte*)bitmapData.Scan0;
            byte* resPtr = (byte*)resultData.Scan0;

            int bytesPerPixel = Bitmap.GetPixelFormatSize(image.PixelFormat) / 8;

            for (int y = 1; y < bitmapData.Height - 1; y++)
            {
                byte* row = ptr + (y * bitmapData.Stride);
                byte* resRow = resPtr + (y * resultData.Stride);

                for (int x = 1; x < bitmapData.Width - 1; x++)
                {
                    byte* pixel = row + x * bytesPerPixel;
                    byte* resPixel = resRow + x * bytesPerPixel;

                    int gradientX = (row[(x + 1) * bytesPerPixel] - row[(x - 1) * bytesPerPixel]) / 2;
                    int gradientY = (ptr[(y + 1) * bitmapData.Stride + x * bytesPerPixel] - ptr[(y - 1) * bitmapData.Stride + x * bytesPerPixel]) / 2;

                    int gradientMagnitude = (int)Math.Sqrt(gradientX * gradientX + gradientY * gradientY);

                    for (int i = 0; i < bytesPerPixel; i++)
                    {
                        resPixel[i] = (byte)Math.Min(255, gradientMagnitude);
                    }
                }
            }

            image.UnlockBits(bitmapData);
            result.UnlockBits(resultData);

            return result;
        }
    }


}
