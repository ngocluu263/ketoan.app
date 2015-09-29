using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Security
/// </summary>
public class Security
{
	public Security()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    /// <summary>
    /// Encrypt string by string salt
    /// </summary>
    /// <param name="grv">Encrypt string by string clean and string salt</param>
    public static string Encrypt(string cleanString, string salt)
    {
        System.Text.Encoding encoding;
        byte[] clearBytes = null;
        byte[] hashedBytes = null;
        encoding = System.Text.Encoding.GetEncoding("unicode");
        clearBytes = encoding.GetBytes(salt.ToLower().Trim() + cleanString.Trim());
        hashedBytes = MD5hash(clearBytes);
        return BitConverter.ToString(hashedBytes);
    }
    /// <summary>
    /// Create string salt
    /// </summary>
    /// <param name="grv">Create string salt</param>
    public static string CreateSalt()
    {
        byte[] bytSalt = new byte[9];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytSalt);
        return Convert.ToBase64String(bytSalt);
    }
    public static string CreateAppcode()
    {
        const byte LENGTH = 20;
        // using array key chars, you can add
        const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        string strWebCode = "";
        Random rand = new Random();
        for (int i = 0; i < LENGTH; i++)
        {
            // Lấy kí tự ngẫu nhiên từ mảng chars
            strWebCode += chars[rand.Next(chars.Length)].ToString();
        }
        return strWebCode;
    }
    /// <summary>
    /// Encrypt byte[] by byte[]
    /// </summary>
    /// <param name="grv">Encrypt byte[] by byte[]</param>
    public static byte[] MD5hash(byte[] data)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] result = md5.ComputeHash(data);
        return result;
    }
}