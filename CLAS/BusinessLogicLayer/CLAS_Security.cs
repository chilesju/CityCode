namespace CLAS.BusinessLogicLayer
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CLAS_Security
    {
        public static string CleanStringRegex(string inputText)
        {
            RegexOptions options1 = RegexOptions.IgnoreCase;
            return CLAS_Security.ReplaceRegex(inputText, @"[()!$%=?}{/@\;*%]_", options1);
        }

        public static string Decrypt(string encryptedString)
        {
            SymmetricAlgorithm algorithm1 = new TripleDESCryptoServiceProvider();
            algorithm1.GenerateKey();
            Convert.ToBase64String(algorithm1.Key);
            algorithm1.GenerateIV();
            ICryptoTransform transform1 = algorithm1.CreateDecryptor(Convert.FromBase64String("cEdMxYCKScp8fHoS1H+P3Aos/9SO8lMS"), Convert.FromBase64String("E96N9CsLk+s="));
            byte[] buffer1 = Convert.FromBase64String(encryptedString);
            MemoryStream stream1 = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream1, transform1, CryptoStreamMode.Write);
            stream2.Write(buffer1, 0, buffer1.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Encoding.UTF8.GetString(stream1.ToArray());
        }

        public static string Encrypt(string cleanString)
        {
            SymmetricAlgorithm algorithm1 = new TripleDESCryptoServiceProvider();
            algorithm1.GenerateKey();
            Convert.ToBase64String(algorithm1.Key);
            algorithm1.GenerateIV();
            ICryptoTransform transform1 = algorithm1.CreateEncryptor(Convert.FromBase64String("cEdMxYCKScp8fHoS1H+P3Aos/9SO8lMS"), Convert.FromBase64String("E96N9CsLk+s="));
            byte[] buffer1 = Encoding.UTF8.GetBytes(cleanString);
            MemoryStream stream1 = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream1, transform1, CryptoStreamMode.Write);
            stream2.Write(buffer1, 0, buffer1.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Convert.ToBase64String(stream1.ToArray());
        }

        private static string ReplaceRegex(string inputText, string regularExpression, RegexOptions options)
        {
            Regex regex1 = new Regex(regularExpression, options);
            return regex1.Replace(inputText, " ");
        }

    }
}

