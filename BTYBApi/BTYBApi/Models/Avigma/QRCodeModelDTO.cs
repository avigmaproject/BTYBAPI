using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTYBApi.Models.Avigma
{
    public class QRCodeModelDTO
    {
        public string QRCodeText { get; set; }
        public string? QRCodeImagePath { get; set; }
        public int QRCodeWidth { get; set; }
        public int QRCodeHeigth { get; set; }
    }
}