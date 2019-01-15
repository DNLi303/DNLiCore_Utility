
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace DNLiCore_Utility.Qrcode
{
    public static class QrCodeHelper
    {
        /// <summary>
        /// 创造二维码
        /// </summary>
        /// <param name="msg">二维码内容</param>
        /// <returns></returns>
        public static Bitmap CreateQrCode(string msg)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(msg, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

    }
}