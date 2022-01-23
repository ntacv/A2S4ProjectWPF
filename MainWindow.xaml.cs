using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QRCoder;
using System.Drawing;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int nbClick1;
        public string path = "../../../File/";


        public MainWindow()
        {

            

            int nbClick1 = 0;
            InitializeComponent();

            imgOutput.Source = new BitmapImage(new Uri(path+"Black.png", UriKind.Relative));


            //txtQRCode.Visibility = Visibility.Visible;
            gridQrcode.Visibility = Visibility.Hidden;
            gridIntro.Visibility = Visibility.Visible;

            imgOutput.Stretch = Stretch.Uniform;
        }

        private void ButtonQR_Click(object sender, RoutedEventArgs e)
        {
            
            gridQrcode.Visibility = Visibility.Visible;
            gridIntro.Visibility = Visibility.Hidden;

            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(txtQRCode.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Bitmap img = code.GetGraphic(5);

            img.Save(path + "imageOut.bmp", ImageFormat.Bmp);
            BitmapImage Qrcode = new BitmapImage(new Uri(path + "img.bmp", UriKind.Relative));
            BitmapImage imgBlack = new BitmapImage(new Uri(path + "Black.png", UriKind.Relative));

            imgOutput2.Source = imgBlack;
            

        }

            private void Button_Click(object sender, RoutedEventArgs e)
        {
            nbClick1++;
            Label2.Content = nbClick1.ToString();

            BitmapImage imgBlack = new BitmapImage(new Uri(path + "Black.png", UriKind.Relative));
            BitmapImage Qrcode = new BitmapImage(new Uri(path + "img.bmp", UriKind.Relative));

            if (nbClick1 % 2 == 0)
            {
                imgOutput.Source = imgBlack;
            }else imgOutput.Source = Qrcode;
        }

        private void GoToPage(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            ImageEditor editor = new ImageEditor();
            editor.Show();

        }
    }
}
