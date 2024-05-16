using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Generate RSA key pair
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Get the recipient's public key
            string publicKey = rsa.ToXmlString(false); // This will give you the XML representation of the public key

            // Convert the data to bytes
            string data = "welcome mansoor";
            Console.WriteLine("Orignal data: " + data);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            // Encrypt the data using the public key
            byte[] encryptedData = EncryptData(dataBytes, publicKey);

            // Store or transmit the encrypted data
            Console.WriteLine("Encrypted data: " + Convert.ToBase64String(encryptedData));
        }

        Console.ReadLine();
    }

    static byte[] EncryptData(byte[] dataBytes, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Import the recipient's public key
            rsa.FromXmlString(publicKey);

            // Encrypt the data using the public key
            byte[] encryptedData = rsa.Encrypt(dataBytes, true);

            return encryptedData;
        }
    }
}