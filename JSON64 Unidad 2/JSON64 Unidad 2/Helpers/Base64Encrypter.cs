using System;
using System.Collections.Generic;
using System.Text;

namespace JSON64_Unidad_2.Helpers
{
    class Base64Encrypter
    {
        public static string Encriptar(string dato)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(dato))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(dato);
                result = Convert.ToBase64String(byteArray);
            }
            return result;
        }
    }
}
