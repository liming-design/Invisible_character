using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;//aes
using System.IO;

namespace Client.core
{
    public class AES
    {
        //AES加密所需参数
        public string Test, Key;
        private byte[] iv = {0x30, 0x31, 0x32, 0x33,
                    0x34, 0x35, 0x36, 0x37,
                    0x38, 0x39, 0x61, 0x62,
                    0x63, 0x64, 0x65, 0x66};

        public byte[] Iv
        {
            get
            {
                return iv;
            }
        }

        /// <summary>
        /// 初始化对象
        /// </summary>
        public AES()
        { }
        public AES(string test, string key)
        {
            this.Test = test;
            this.Key = key;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="=Test">明文（string）</param>
        /// <param name="Key">密钥（string）</param>
        /// <returns>密文srting</returns>
        public string Encode()
        {
            //将密钥转换为byte类型，然后才能使用AES模块
            ASCIIEncoding CharToByte = new ASCIIEncoding();
            char[] CharKey = this.Key.ToArray();
            byte[] Key = new byte[this.Key.Length];
            Key = CharToByte.GetBytes(CharKey);

            //接收aes加密后的信息。
            byte[] EncodeTest;

            Aes aes = Aes.Create();
            try
            {
                aes.Key = Key;//byte类型
                aes.IV = Iv;
                //创建加密器对象
                ICryptoTransform encode = aes.CreateEncryptor(aes.Key, aes.IV);
                //开辟一块内存流
                MemoryStream memoryStream = new MemoryStream();
                try
                {
                    //内存流转换为加密流
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encode, CryptoStreamMode.Write);
                    try
                    {
                        //将明文写入加密流
                        StreamWriter streamWriter = new StreamWriter(cryptoStream);
                        try
                        {
                            streamWriter.Write(Test);
                        }
                        finally
                        {
                            streamWriter.Close();
                        }
                        EncodeTest = memoryStream.ToArray();//得到得到是字节数组
                    }
                    finally
                    {
                        cryptoStream.Close();
                    }
                }
                finally
                {
                    memoryStream.Close();
                }

            }
            finally
            {
                aes.Clear();
            }
            return Convert.ToBase64String(EncodeTest);//以字符串形式返回
            //Convert.FromBase64String
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param  name="Test">密文（string）</param>
        /// <param name="Key">密钥（string）</param>
        /// <returns>明文（string）</returns>
        public string Decode()
        {
            //将Key转换为byte类型
            ASCIIEncoding CharToByte = new ASCIIEncoding();
            char[] KeyChar = this.Key.ToArray();
            Byte[] Key = new byte[this.Key.Length];
            Key = CharToByte.GetBytes(KeyChar);

            //将密文转为byte类型
            byte[] TestByte = Convert.FromBase64String(Test);

            //接收解密后的明文
            string TestString;

            //使用AES库对加密byte进行解密密
            Aes aes = Aes.Create();
            try
            {
                aes.Key = Key;//byte类型
                aes.IV = Iv;
                ICryptoTransform decode = aes.CreateDecryptor(aes.Key, aes.IV);
                //将密文写进内存流
                MemoryStream memoryStream = new MemoryStream(TestByte);
                try
                {
                    //将内存流转换为解密流
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decode, CryptoStreamMode.Read);
                    try
                    {
                        //解密得到明文
                        StreamReader streamReader = new StreamReader(cryptoStream);
                        try
                        {
                            TestString = streamReader.ReadToEnd();//得到明文
                        }
                        finally
                        {
                            streamReader.Close();
                        }

                    }
                    finally
                    {
                        cryptoStream.Close();
                    }
                }
                finally
                {
                    memoryStream.Close();
                }

            }
            finally
            {
                aes.Clear();
            }
            return TestString;//以字符串形式返回




        }
    }
}
