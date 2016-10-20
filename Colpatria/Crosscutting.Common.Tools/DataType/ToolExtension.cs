using System;
using System.Security.Cryptography;
using System.Text;

namespace Crosscutting.Common.Tools.DataType
{
    public static class ToolExtension
    {
        private static readonly char[] BaseDictionary = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public static string GenSemiUniqueId(int lenght = 6)
        {
            var rngCsp = new RNGCryptoServiceProvider();

            var str = new StringBuilder(lenght);
            for (var i = 0; i < lenght; i++)
            {
                var bytes = new byte[8];
                rngCsp.GetBytes(bytes);
                var seed = BitConverter.ToInt32(bytes, 0);
                str.Append(BaseDictionary[new Random(seed).Next(0, 35)]);
            }
            return str.ToString();
        }
    }
}