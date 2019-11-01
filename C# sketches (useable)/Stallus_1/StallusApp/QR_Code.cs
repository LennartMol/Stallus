using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using QRCoder;

namespace StallusApp
{
    class QR_Code
    {
        public Image GenerateQR_Code(string text)
        {
            QRCodeGenerator generator = new QRCodeGenerator();
            //string nowDate = DateTime.Now.ToString("dd/MM/yy");
            //string nowTime = DateTime.Now.ToString("hh:mm:ss");
            QRCodeData data = generator.CreateQrCode("#" + text + /*";MOMENT:" + nowDate + "@" + nowTime +*/ "%", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(data);
            return qrCode.GetGraphic(5);
        }
    }
}
