using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Chart.Core
{
    public class Cores
    {
        /// <summary>
        /// “嵌入算法”
        /// </summary>
        /// <param name="opentest"></param>
        /// <param name=invtest></param>
        public static string InvInTest(string opentest, string invtest)
        {
            string AfterOpenTest = null;
            string BeforeOpenTest = null;
            string OpenTest = opentest;
            string InvTest = invtest;
            int i = 0;
            try
            {
                //将读到的信息转换为ascii值
                CharEnumerator ce = OpenTest.GetEnumerator();
                ce.MoveNext();
                //循环找出隐藏信息
                int index = 0;
                for (i = 0; i < OpenTest.Length; i++)
                {
                    byte[] TestByte = System.Text.Encoding.ASCII.GetBytes(ce.Current.ToString());
                    int TestAscii = (short)TestByte[0];
                    if (TestAscii == 46)
                    {

                        AfterOpenTest = OpenTest.Substring(index + 1);
                        BeforeOpenTest += OpenTest[i];
                        break;

                    }
                    BeforeOpenTest += OpenTest[i];
                    ce.MoveNext();
                    index++;
                }
                if (i == OpenTest.Length)
                {
                    string notice = "文本中没有插入点“.”，请保持文本最少有一个“.”";
                    return "1" + ";" + notice;
                }
                else
                {
                    string message = BeforeOpenTest + InvTest + " " + AfterOpenTest;
                    return "2" + ";" + message;
                }

            }
            catch (IOException m)
            {
                return "0" + ";" + m;
            }



        }

        /// <summary>
        /// “提取算法”
        /// </summary>
        /// <param name="opentest"></param>
        public static string InvFromTest(string opentest)
        {
            string AfterOpenTest = null;
            string OpenTest = opentest;
            string InvTest = null;
            int i = 0;
         
                //将读到的信息转换为ascii值
                CharEnumerator ce = OpenTest.GetEnumerator();
                ce.MoveNext();
                //循环找出隐藏信息
                int index = 0;
                for (i = 0; i < OpenTest.Length; i++)
                {
                    byte[] TestByte = System.Text.Encoding.ASCII.GetBytes(ce.Current.ToString());
                    int TestAscii = (short)TestByte[0];
                    if (TestAscii == 46)
                    {
                        int j;
                        AfterOpenTest = OpenTest.Substring(index + 1);
                        CharEnumerator ce1 = AfterOpenTest.GetEnumerator();
                        ce1.MoveNext();

                        for (j = 0; j < AfterOpenTest.Length; j++)
                        {
                            TestByte = System.Text.Encoding.ASCII.GetBytes(ce1.Current.ToString());
                            TestAscii = (short)TestByte[0];
                            if (TestAscii == 32)
                            {
                                //当前虽然是“32”，但是不一定是结束的，因为网页将“00a0转换为0020”，所以应该往下判断
                                ce1.MoveNext();
                                TestByte = System.Text.Encoding.ASCII.GetBytes(ce1.Current.ToString());
                                TestAscii = (short)TestByte[0];
                                int c;
                                //看看下一个是否是编码表里的
                                for (c = 0; c < SpaceEncodeAndDecode.InvoAsciiCharacter.Length; c++)
                                {
                                    if (ce1.Current == SpaceEncodeAndDecode.InvoAsciiCharacter[c])
                                    {
                                        break;
                                    }
                                }
                                //不是编码表
                                if (c == SpaceEncodeAndDecode.InvoAsciiCharacter.Length)
                                {
                                    //但还是“32”，往下看
                                    if (TestAscii == 32)
                                    {
                                        //因为已经是下一个，所以不要再Next了，只需要把“32”加上
                                        InvTest += AfterOpenTest[j];
                                        continue;
                                    }
                                    //也不是“32”，那就是结尾了
                                    else
                                    {
                                         break;
                                    }
                                }
                                //是编码表里的，往下看
                                else
                                {
                                    //因为已经是下一个，所以不要再Next了，只需要把“32”加上
                                    InvTest += AfterOpenTest[j];
                                    continue;
                                }
                               
                            }
                            ce1.MoveNext();
                            InvTest += AfterOpenTest[j];//最后的加密信息
                                                        //m++;

                        }
                        if (j != AfterOpenTest.Length)
                        {
                            break;
                        }
                    }
                    ce.MoveNext();
                    index++;
                }
                if (index == OpenTest.Length)
                {
                    string message = "该文件不存在隐藏信息！";
                    return "0" + ";" + message;
                }
                else
                    return "1" + ";" + InvTest;
            
          
        }

        /// <summary>
        /// “不可见字符编码算法”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string TestToInv(bool check, string key, string test)
        {
            bool Check = check;
            string Key = key;
            string Test = test;
            string InvTest;
            //判断是否使用AES加密
            if (Check == true)
            {
                //AES加密
                AES aes = new AES(Test, Key);
                Test = aes.Encode();
            }
            //直接转换为不可见滋味
            SpaceEncodeAndDecode spaceencode = new SpaceEncodeAndDecode(Test);
            //添加到窗体上
            InvTest = spaceencode.SpaceEncode();
            return "1" + ";"+InvTest;
        }


        /// <summary>
        /// “不可见字符解码算法”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static string InvToTest(bool check, string key, string invtest)
        {
            bool Check = check;
            string Key = key;
            string InvTest = invtest;
            string Test;
            //先将不可见字符恢复
            SpaceEncodeAndDecode spaceEncodeAndDecode = new SpaceEncodeAndDecode(InvTest);
            Test = spaceEncodeAndDecode.SpaceDecode();
            //判断是否选用AES加密
            if (Check == true)
            {
                AES aes = new AES(Test, key);
                Test = aes.Decode();
            }
            //将解密后的明文信息输出
            return "1" + ";"+Test;
        }
    } 
}
