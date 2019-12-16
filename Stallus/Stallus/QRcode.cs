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
        private string qrString;
        public string QrString
        {
            get { return qrString; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    qrString = value;
                }
            }
        }
        public QRcode(string qrString)
        {
            if (!string.IsNullOrWhiteSpace(qrString))
            {
                QrString = qrString;
            }
            else
            {
                throw new ArgumentOutOfRangeException("qrString");
            }

            
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
