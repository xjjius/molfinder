using System;
using com.epam.indigo;

namespace Szhchem.Chemistry
{
    public static class IndigoHelper
    {
        private static readonly IndigoBase IndigoBase = new IndigoBase();
        public static byte[] RenderToBuffer(string molString)
        {
            return IndigoBase.RenderMolStringToBuffer(molString);
        }

        public static string RenderToDataUrl(string molString)
        {
            byte[] buffer = RenderToBuffer(molString);
            string pngBase64 = Convert.ToBase64String(buffer);
            return $"data:image/png;base64,{pngBase64}";
        }
    }
}