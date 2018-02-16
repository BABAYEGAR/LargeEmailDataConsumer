﻿using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LargeDataEmailConsumer.Models.Encryption
{
    public class Md5Ecryption
    {
        private readonly Random random = new Random();
        /// <summary>
        ///     This method converts a string to a MD5 hash algorith, string
        /// </summary>
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        public string ConvertStringToMd5Hash(string originalPassword)
        {
            return string.Join("",
                MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(originalPassword)).Select(s => s.ToString("x2")));
        }
   
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}