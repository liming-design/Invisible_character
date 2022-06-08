using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.core
{
    class SpaceEncodeAndDecode
    {
        /// <summary>
        /// 定义数据
        /// </summary>
        //不可见字符组
        public static char[] InvoAsciiCharacter =
        {
            //'\u0020',/* 空格Space*/
            '\u00A0',/*不间断空格*/
            '\u180E',/**/
            '\u2000',
            '\u2001',
            '\u2002',
            '\u2003',
            '\u2004',
            '\u2005',
            '\u2006',
            '\u2007',
            '\u2008',
            '\u2009',
            '\u200A',
            '\u202F',
            '\u205F',
            '\u3000',
            '\u200B'
        };

        //十六进制数组
        public static char[] Hex =
        {
            '0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'
        };
        //利用字典将不可见字符可见，键值为不可见字符，值为相应的数值
        readonly Dictionary<char, short> DirAsciiCharacter = new Dictionary<char, short>();
        readonly Dictionary<char, short> DirHex = new Dictionary<char, short>();
        //待转换信息
        public string Test;
   

        /// <summary>
        /// 对象初始化
        /// </summary>
        public SpaceEncodeAndDecode()
        { }
        public SpaceEncodeAndDecode(String Test)
        {
            this.Test = Test;

            //初始化不可见字符字典
            for (short i = 0; i < InvoAsciiCharacter.Length; i++)
            {
                DirAsciiCharacter[InvoAsciiCharacter[i]] = i;
            }
            //初始化十六进制字典
            for(short i = 0 ; i< Hex.Length;i++)
            {
                DirHex[Hex[i]] = i;
            }
        }

        /// <summary>
        /// 隐写成不可见字符  
        /// </summary>
        /// <param name="Test">明文（string）</param>
        /// <returns>不可见字符（string）</returns>        
        public string SpaceEncode()
        {
            byte[] TestByte = Encoding.Default.GetBytes(Test);
            string textAscii = string.Empty;//用来存储转换过后的ASCII码
            int SpaceCount = 0;           
            //string SpaceByte = ;
            for (int i = 0; i < TestByte.Length; i++)
            {
                textAscii += TestByte[i].ToString("X");
            }
            char[] SpaceByte = new char[TestByte.Length * 2];

            for (int i=0;i<textAscii.Length;i++)
            {
                SpaceByte[SpaceCount++] = InvoAsciiCharacter[DirHex[textAscii[i]]];
            }
            return string.Join(string.Empty, SpaceByte);
        }

        /// <summary>
        /// 将不可见字符恢复
        /// </summary>
        /// <param name="Test">不可见字符（string）</param>
        /// <returns>原文（string）</returns>        
        public string SpaceDecode()
        {
            string textAscii = string.Empty;//用来存储转换过后的ASCII码
            //转换为十六进制字符串
            for (int i = 0; i < Test.Length; i ++)
            {
                textAscii += Hex[DirAsciiCharacter[Test[i]]];
            }

            int k = 0;//字节移动偏移量
            byte[] buffer = new byte[textAscii.Length / 2];//存储变量的字节
            for (int i = 0; i < textAscii.Length / 2; i++)
            {
                //每两位合并成为一个字节
                buffer[i] = byte.Parse(textAscii.Substring(k, 2), System.Globalization.NumberStyles.HexNumber);
                k = k + 2;
            }
            string textStr = Encoding.Default.GetString(buffer);
            return textStr;
        }


    }

}

