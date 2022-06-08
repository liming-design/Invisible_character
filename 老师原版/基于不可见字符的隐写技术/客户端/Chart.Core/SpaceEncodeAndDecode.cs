using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace Chart.Core
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
            '\u3000'
        };
        //利用字典将不可见字符可见，键值为不可见字符，值为相应的数值
        readonly Dictionary<char, short> DirAsciiCharacter = new Dictionary<char, short>();
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
        }

        /// <summary>
        /// 隐写成不可见字符
        /// </summary>
        /// <param name="Test">明文（string）</param>
        /// <returns>不可见字符（string）</returns>
        public string SpaceEncode()
        {
            //将待转换信息转换为ascll形式,然后便可以除了
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            char[] TestChar = Test.ToArray();
            byte[] TestByte = new byte[Test.Length];
            TestByte = aSCIIEncoding.GetBytes(TestChar);

            //用于存放转换后的字符
            char[] SpaceByte = new char[Test.Length * 2];
            //记录新创建的秘密字符数量
            int SpaceCount = 0;

            //设计用高4位和低四位除16取整和区域
            for (int i = 0; i < Test.Length; i++)
            {
                //将一个字符对应两个不可见字符
                short high = (short)(TestByte[i] / 16);
                short low = (short)(TestByte[i] % 16);
                //利用字典查询相应的不可见字符（字典的键值和值怎么使用）
                SpaceByte[SpaceCount] = InvoAsciiCharacter[high];
                SpaceByte[SpaceCount + 1] = InvoAsciiCharacter[low];
                SpaceCount += 2;
            }
            return string.Join(string.Empty, SpaceByte);
        }


        /// <summary>
        /// 将不可见字符恢复
        /// </summary>
        /// <param name="Test">不可见字符（string）</param>
        /// <returns>原文（string）</returns>
        //readonly 不能定义在方法内，只能使用在调用的方法外
        readonly Encoding asciiencoding = Encoding.GetEncoding("iso-8859-1");
        //readonly Encoding asciiencoding = Encoding.GetEncoding("gb2312");
        public string SpaceDecode()
        {
            //用于接收转换后的byte字符组
            byte[] ResultByte = new byte[Test.Length / 2];
            int ResultByteCount = 0;

            //设计使用字典保存的对应字符的int值来反过来
            for (int i=0; i<Test.Length; i+=2)
            {
                char highChar = Test[i];
                char lowChar = Test[i + 1];
                if ((int)Test[i]==32)
                {
                    highChar = '\u00A0';
             
                }
                if ((int)Test[i + 1] == 32)
                {
                    lowChar = '\u00A0';
                }
                short high = DirAsciiCharacter[highChar];
                short low = DirAsciiCharacter[lowChar];

                int highbyte = high * 16;
                int lowbyte = (int)low;

                ResultByte[ResultByteCount] = (byte)(highbyte + lowbyte);
                ResultByteCount++;
                              
            }

            //以字符串的形式返回
            return asciiencoding.GetString(ResultByte,0,ResultByte.Length);
        }













    }
}

