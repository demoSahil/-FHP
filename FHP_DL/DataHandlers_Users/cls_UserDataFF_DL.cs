using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace FHP_DL
{
    /// <summary>
    /// Class responsible for reading and managing user data from a file.
    /// </summary>
    public class cls_UserDataFF_DL : IDataHandlerUser
    {
        private const string EncryptionKey = "1aB$5cD#9eF!2gH@";

        /// <summary>
        /// Validates user credentials by reading from the user data file.
        /// </summary>
        /// <param name="user">The user object containing credentials to be validated.</param>
        public bool AuthenticateUser(cls_User_VO user)
        {
            string filePath = "C:\\Users\\sahil\\source\\repos\\FHP Application\\FHP_DL\\Resources\\MyUsers.txt";
            List<string> lines = ReadDataFile(filePath);
            bool match = false;

            foreach (var line in lines)
            {
                string[] word = line.Split(' ');

                // Decrypt the password from the file
                string decryptedUserName = EncryptionHelper.Decrypt(word[0]);
                string decryptedPassword = EncryptionHelper.Decrypt(word[1]);
                string decryptedUserRole = EncryptionHelper.Decrypt(word[2]);

                if (user.UserName.ToLower() == decryptedUserName.ToLower() && user.Password == decryptedPassword)
                {
                    match = true;
                    user.UserRole = decryptedUserRole;
                }
            }

            if (!match)
            {
                user.ErrorMessage = "Credential not valid";
            }

            return match;

        }

        /// <summary>
        /// Adds a new user to the user data file with encrypted credentials.
        /// </summary>
        /// <param name="user">The user object containing information to be added.</param>
        public void AddUserData(cls_User_VO user)
        {
            string filePath = "C:\\Users\\sahil\\source\\repos\\FHP Application\\FHP_DL\\Resources\\MyUsers.txt";

            // Encrypt the password before saving to the file



            string encryptedPassword = EncryptionHelper.Encrypt("VISPL");
            string encryptedUsername = EncryptionHelper.
                Encrypt("VISPL");
            string encryptedrole = EncryptionHelper.Encrypt("SUPERADMIN");

            string userData = $"{encryptedUsername} {encryptedPassword} {encryptedrole}";

            try
            {
                File.AppendAllText(filePath, userData + Environment.NewLine);
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while writing to the file: {e.Message}");
            }
        }

        /// <summary>
        /// Reads data from the specified file and returns a list of lines.
        /// </summary>
        /// <param name="filePath">The path to the file to be read.</param>
        /// <returns>A list of strings representing lines read from the file.</returns>
        public List<string> ReadDataFile(string filePath)
        {
            List<string> lines = new List<string>();

            try
            {
                lines.AddRange(File.ReadAllLines(filePath));
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }

            return lines;
        }
    }

    /// <summary>
    /// Helper class for encryption and decryption of strings.
    /// </summary>
    public class EncryptionHelper
    {
        private const string EncryptionKey = "1aB$5cD#9eF!2gH@";

        /// <summary>
        /// Encrypts the specified plain text using AES encryption.
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted.</param>
        /// <returns>The encrypted text as a base64-encoded string.</returns>
        public static string Encrypt(string plainText)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = aesAlg.Key;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }


        /// <summary>
        /// Decrypts the specified cipher text using AES decryption.
        /// </summary>
        /// <param name="cipherText">The cipher text to be decrypted.</param>
        /// <returns>The decrypted plain text.</returns>
        public static string Decrypt(string cipherText)
        {
            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aesAlg.IV = aesAlg.Key;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

    }

}
