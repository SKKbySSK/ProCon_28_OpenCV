using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.google.zxing;
using com.google.zxing.qrcode;
using com.google.zxing.common;

namespace ProCon_28
{
    public partial class MainWindow : Form
    {
        ImageList Images = new ImageList();
        List<QR> QRs = new List<QR>();
        QRCodeReader qrReader = new QRCodeReader();

        public MainWindow()
        {
            InitializeComponent();
            
            Images.ImageSize = new Size(200, 200);
            PieceView.LargeImageList = Images;

            ProCV.CaptureManager.OverlayText = "QR Mode : " + QRTimer.Enabled;
        }

        private void qrB_Click(object sender, EventArgs e)
        {
            QRTimer.Enabled = !QRTimer.Enabled;
            ProCV.CaptureManager.OverlayText = "QR Mode : " + QRTimer.Enabled;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProCV.CaptureManager.StartCapture(false);
        }

        private void TestQRB_Click(object sender, EventArgs e)
        {
            AddQR((Bitmap)Image.FromFile("Sample1.png"));
        }

        void AddQR(Bitmap bmp)
        {
            LuminanceSource source = new RGBLuminanceSource(bmp, bmp.Width, bmp.Height);
            BinaryBitmap bin = new BinaryBitmap(new HybridBinarizer(source));

            Result res = qrReader.decode(bin);
            StatusL.Text = "QR　読み取り成功";
            string ret = res.Text.Sanitize();

            foreach (QR QR in QRs)
            {
                if(QR.RawShapeData == ret)
                {
                    StatusL.Text = "QR　読み取り済み";
                    return;
                }
            }

            QRInputT.Text = ret;

            QR qr = new QR(ret);
            QRs.Add(qr);

            foreach (Shape s in qr.Shapes)
                AddShape(s);

            if (qr.IsFrameAvailable)
            {
                AddShape(qr.Frame, "Frame", Pens.BurlyWood, Brushes.BurlyWood);
            }
        }

        void AddShape(Shape Shape, string Name = "Piece", Pen Pen = null, Brush Brush = null)
        {
            if (Pen == null)
                Pen = Pens.Black;
            if (Brush == null)
                Brush = Brushes.Gray;

            Image img = Shape.GetImage(50, Brush, Pen);
            
            Images.Images.Add(createThumbnail(img, 200, 200));
            PieceView.Items.Add(Name, Images.Images.Count - 1);
        }

        Image createThumbnail(Image image, int w, int h)
        {
            Bitmap canvas = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(canvas);
            g.Clear(Color.White);

            float fw = w / (float)image.Width;
            float fh = h / (float)image.Height;

            float scale = Math.Min(fw, fh);
            fw = image.Width * scale;
            fh = image.Height * scale;

            g.DrawImage(image, (w - fw) / 2, (h - fh) / 2, fw, fh);
            g.Dispose();

            return canvas;
        }

        private void QRTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = ProCV.CaptureManager.Capture();
                AddQR(bmp);
            }
            catch (Exception ex)
            {
                StatusL.Text = "QR　読み取り失敗 : " + ex.Message;
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProCV.CaptureManager.StopCapture();
            ProCV.CaptureManager.Release();
        }

        private void GenPuzzleB_Click(object sender, EventArgs e)
        {

        }
    }
}
