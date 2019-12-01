using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;

namespace Stallus
{
    public class QRcode
    {
        public string QrString { get; private set; }
        public QRcode(string qrString)
        {
            QrString = qrString;
        }
        
        public Bitmap GenerateQrCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator(); // Create a QR with the generatedString.
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("#" + QrString + "%", QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }


    }
}
