using System.Security.Cryptography;
using System.Text;

namespace AppCriptografia.Services
{
    public static class CriptografiaService
    {
        //Uma vez usado, não alterar mais
        private const string chave = "PM2";
        public static string Codificar(string entrada)
        {
            TripleDESCryptoServiceProvider tripledescryptoserviceprovider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();

            try
            {
                if (entrada.Trim() != "")
                {
                    tripledescryptoserviceprovider.Key = md5cryptoserviceprovider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(chave));
                    tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                    ICryptoTransform desdencrypt = tripledescryptoserviceprovider.CreateEncryptor();
                    ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
                    byte[] buff = Encoding.ASCII.GetBytes(entrada);

                    return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));

                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                tripledescryptoserviceprovider = null;
                md5cryptoserviceprovider = null;
            }
        }

        public static string Decodificar(string entrada)
        {
            TripleDESCryptoServiceProvider tripledescryptoserviceprovider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5cryptoserviceprovider = new MD5CryptoServiceProvider();

            try
            {
                if (entrada.Trim() != "")
                {
                    tripledescryptoserviceprovider.Key = md5cryptoserviceprovider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(chave));
                    tripledescryptoserviceprovider.Mode = CipherMode.ECB;
                    ICryptoTransform desdencrypt = tripledescryptoserviceprovider.CreateDecryptor();
                    byte[] buff = Convert.FromBase64String(entrada);

                    return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                tripledescryptoserviceprovider = null;
                md5cryptoserviceprovider = null;
            }
        }
    }
}
