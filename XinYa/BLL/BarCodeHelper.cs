using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace XinYa.BLL
{
    /// <summary>
    ///生成39码和128码条码图片
    /// </summary>
    public class BarCodeHelper
    {
        // CODE39码的编码规则是： 
        //1、 每五条线表示一个字符； 
        //2、 粗线表示1，细线表示0； 
        //3、 线条间的间隙宽的表示1，窄的表示0； 
        //4、 五条线加上它们之间的四条间隙就是九位二进制编码，而且这九位中必定有三位是1，所以称为39码； 
        //5、 条形码的首尾各一个＊标识开始和结束,字符之间以0隔开
        /// <summary>
        ///  生成CODE39码条码图片
        /// </summary>
        /// <param name="InputData">要生成的字符串</param>
        /// <param name="FontSize">条码下方文字大小</param>
        /// <param name="BarWeight">条码粗度</param>
        /// <param name="BarHeight">条码高度</param>
        /// <param name="Margin_Top">上边际</param>
        /// <param name="Margin_Left">左边距</param>
        /// <returns></returns>
        public static Image Create39Code(string InputData, int FontSize, int BarWeight, int BarHeight, int Margin_Top, int Margin_Left)
        {
            //編碼字串 初值為 起始符號 * 
            StringBuilder sb = new StringBuilder();
            sb.Append("010010100");
            //Code39的字母  
            string AlphaBet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*";
            // 39码是头尾符号加中间的数据，3个1和6个0以及间隔符0，所以图片宽度为条码宽度 + 间距
            int Width = (3 * 2 + 7) * BarWeight * (InputData.Length + 2) + Margin_Left * 2;
            int Height = BarHeight + FontSize + 5 + Margin_Top * 2;
            InputData = InputData.ToUpper();
            //實作圖片，绘制的图片参数长度（10*字符长度 + 10），高度（BarCode高度 + 10）    
            Image BarCodeImg = new Bitmap(Width, Height);
            using (Graphics Gr = Graphics.FromImage(BarCodeImg))
            {
                //宣告GDI+繪圖介面      
                //填上底色      
                Gr.FillRectangle(Brushes.White, 0, 0, Width, Height);
                for (int i = 0; i < InputData.Length; i++)
                {
                    //檢查是否有非法字元          
                    if (AlphaBet.IndexOf(InputData[i]) == -1 || InputData[i] == '*')
                    {
                        Gr.DrawString("含有非法字元", SystemFonts.DefaultFont, Brushes.Red, Margin_Left, Margin_Top);
                        return BarCodeImg;
                    }
                    //查表編碼   
                    sb.Append("0");
                    sb.Append(Code39[AlphaBet.IndexOf(InputData[i])]);
                }
                //補上結束符號 * 
                sb.Append("0");
                sb.Append("010010100");
                string strEncode = sb.ToString();
                int Cursor = Margin_Left;
                //依碼畫出Code39 BarCode      
                for (int i = 0; i < strEncode.Length; i++)
                {
                    int BarWidth = strEncode[i] == '1' ? BarWeight * 2 : BarWeight;
                    if (i % 2 == 0)
                    {
                        Gr.FillRectangle(Brushes.Black, Cursor, Margin_Top, BarWidth, BarHeight);
                    }
                    Cursor += BarWidth;
                }
                Cursor = (Width - InputData.Length * FontSize) / 2;
                Gr.DrawString(InputData, new Font("Arial", FontSize), Brushes.Black, new PointF(Cursor, Margin_Top + BarHeight + 5));
            }
            return BarCodeImg;
        }

        /// <summary>
        /// 产生一个128条码图片
        /// </summary>
        /// <param name="InputData">要生成的条码的字符串</param>
        /// <param name="FontSize">字体大小</param>
        /// <param name="BarWeight">条码粗度</param>
        /// <param name="BarWeight">条码高度</param>
        /// <param name="Margin_Top">条码上间距</param>
        /// <param name="Margin_Left">条码左间距</param>
        /// <returns>生成的条码的图片</returns>
        public static Image Create128Code(string InputData, int FontSize, int BarWeight, int BarHeight, int Margin_Top, int Margin_Left)
        {
            byte[] AsciiBytes = Encoding.ASCII.GetBytes(InputData);
            int[] CodeNumber = GetCodeNumber(AsciiBytes);

            int Width = CodeNumber.Length * 11 * BarWeight + 2 + Margin_Left * 2;
            int Height = BarHeight + FontSize + 5 + Margin_Top * 2;
            Image BarCodeImg = new Bitmap(Width, Height);
            using (Graphics gr = Graphics.FromImage(BarCodeImg))
            {
                // 先画一块白布
                gr.FillRectangle(System.Drawing.Brushes.White, 0, 0, Width, Height);
                int Cursor = Margin_Left;
                foreach (int Item in CodeNumber)
                {
                    for (int i = 0; i < 8; i += 2)
                    {
                        int Black = Code128[Item, i] * BarWeight;
                        int White = Code128[Item, i + 1] * BarWeight;
                        //绘制黑色线条
                        if (Black > 0)
                        {
                            gr.FillRectangle(System.Drawing.Brushes.Black, Cursor, Margin_Top, Black, BarHeight);
                        }
                        //记录已经绘制的位置
                        Cursor += (Black + White);
                    }
                }
                Cursor = (Width - AsciiBytes.Length * FontSize) / 2;
                gr.DrawString(InputData, new Font("Arial", FontSize), Brushes.Black, new PointF(Cursor, Margin_Top + BarHeight + 5));
            }
            return BarCodeImg;
        }

        /// <summary>
        /// 根据Ascii码返回128码的序号
        /// </summary>
        /// <param name="CharAscii">字符的ASCII值</param>
        /// <returns>128码的序号</returns>
        public static int[] GetCodeNumber(byte[] CharAscii)
        {
            //条码的长度,一个字符是11个线条，还要算上开始、验证、结束等字符
            int[] CodeNumber = new int[CharAscii.Length + 3];
            int CheckCode = 0;
            //开始位的设置为StartB编码
            CodeNumber[0] = 104;
            for (int i = 0; i < CharAscii.Length; i++)
            {
                if (CharAscii[i] < 32)
                {
                    //如果有特殊符号，则开始位的设置为StartA编码
                    CodeNumber[0] = 103;
                    //如果ASCII值小于32，则加64刚好为码值表的序号
                    CodeNumber[i + 1] = CharAscii[i] + 64;
                }
                else
                {
                    //如果ASCII值不于32，则减32刚好为码值表的序号
                    CodeNumber[i + 1] = CharAscii[i] - 32;
                }
                //验证码为 （开始位对应的ID值 ＋ 每位数据在整个数据中的位置×每位数据对应的ID值）% 103
                CheckCode += (i + 1) * CodeNumber[i + 1];
            }
            CheckCode = (CheckCode + CodeNumber[0]) % 103;
            CodeNumber[CodeNumber.Length - 2] = CheckCode;
            CodeNumber[CodeNumber.Length - 1] = 106;
            return CodeNumber;
        }

        /// <summary>
        /// Code39的各字母對應碼 
        /// </summary>
        private static readonly string[] Code39 = {      
                                                    /**//* 0 */ "000110100",       
                                                    /**//* 1 */ "100100001",      
                                                    /**//* 2 */ "001100001",       
                                                    /**//* 3 */ "101100000",      
                                                    /**//* 4 */ "000110001",       
                                                    /**//* 5 */ "100110000",       
                                                    /**//* 6 */ "001110000",       
                                                    /**//* 7 */ "000100101",      
                                                    /**//* 8 */ "100100100",       
                                                    /**//* 9 */ "001100100",       
                                                    /**//* A */ "100001001",       
                                                    /**//* B */ "001001001",      
                                                    /**//* C */ "101001000",       
                                                    /**//* D */ "000011001",       
                                                    /**//* E */ "100011000",       
                                                    /**//* F */ "001011000",      
                                                    /**//* G */ "000001101",       
                                                    /**//* H */ "100001100",       
                                                    /**//* I */ "001001100",       
                                                    /**//* J */ "000011100",      
                                                    /**//* K */ "100000011",       
                                                    /**//* L */ "001000011",       
                                                    /**//* M */ "101000010",       
                                                    /**//* N */ "000010011",      
                                                    /**//* O */ "100010010",       
                                                    /**//* P */ "001010010",       
                                                    /**//* Q */ "000000111",       
                                                    /**//* R */ "100000110",      
                                                    /**//* S */ "001000110",       
                                                    /**//* T */ "000010110",       
                                                    /**//* U */ "110000001",       
                                                    /**//* V */ "011000001",      
                                                    /**//* W */ "111000000",       
                                                    /**//* X */ "010010001",       
                                                    /**//* Y */ "110010000",       
                                                    /**//* Z */ "011010000",      
                                                    /**//* - */ "010000101",       
                                                    /**//* . */ "110000100",       
                                                    /**//*' '*/ "011000100",      
                                                    /**//* $ */ "010101000",      
                                                    /**//* / */ "010100010",       
                                                    /**//* + */ "010001010",       
                                                    /**//* % */ "000101010",       
                                                    /**//* * */ "010010100"  
                                                   };

        /// <summary>
        /// 128码的编码，第1、3、5、7位为黑线，第2、4、6位为白线
        /// </summary>
        private static readonly int[,] Code128 = {
                                                        {2,1,2,2,2,2,0,0},  // 0
                                                        {2,2,2,1,2,2,0,0},  // 1
                                                        {2,2,2,2,2,1,0,0},  // 2
                                                        {1,2,1,2,2,3,0,0},  // 3
                                                        {1,2,1,3,2,2,0,0},  // 4
                                                        {1,3,1,2,2,2,0,0},  // 5
                                                        {1,2,2,2,1,3,0,0},  // 6
                                                        {1,2,2,3,1,2,0,0},  // 7
                                                        {1,3,2,2,1,2,0,0},  // 8
                                                        {2,2,1,2,1,3,0,0},  // 9
                                                        {2,2,1,3,1,2,0,0},  // 10
                                                        {2,3,1,2,1,2,0,0},  // 11
                                                        {1,1,2,2,3,2,0,0},  // 12
                                                        {1,2,2,1,3,2,0,0},  // 13
                                                        {1,2,2,2,3,1,0,0},  // 14
                                                        {1,1,3,2,2,2,0,0},  // 15
                                                        {1,2,3,1,2,2,0,0},  // 16
                                                        {1,2,3,2,2,1,0,0},  // 17
                                                        {2,2,3,2,1,1,0,0},  // 18
                                                        {2,2,1,1,3,2,0,0},  // 19
                                                        {2,2,1,2,3,1,0,0},  // 20
                                                        {2,1,3,2,1,2,0,0},  // 21
                                                        {2,2,3,1,1,2,0,0},  // 22
                                                        {3,1,2,1,3,1,0,0},  // 23
                                                        {3,1,1,2,2,2,0,0},  // 24
                                                        {3,2,1,1,2,2,0,0},  // 25
                                                        {3,2,1,2,2,1,0,0},  // 26
                                                        {3,1,2,2,1,2,0,0},  // 27
                                                        {3,2,2,1,1,2,0,0},  // 28
                                                        {3,2,2,2,1,1,0,0},  // 29
                                                        {2,1,2,1,2,3,0,0},  // 30
                                                        {2,1,2,3,2,1,0,0},  // 31
                                                        {2,3,2,1,2,1,0,0},  // 32
                                                        {1,1,1,3,2,3,0,0},  // 33
                                                        {1,3,1,1,2,3,0,0},  // 34
                                                        {1,3,1,3,2,1,0,0},  // 35
                                                        {1,1,2,3,1,3,0,0},  // 36
                                                        {1,3,2,1,1,3,0,0},  // 37
                                                        {1,3,2,3,1,1,0,0},  // 38
                                                        {2,1,1,3,1,3,0,0},  // 39
                                                        {2,3,1,1,1,3,0,0},  // 40
                                                        {2,3,1,3,1,1,0,0},  // 41
                                                        {1,1,2,1,3,3,0,0},  // 42
                                                        {1,1,2,3,3,1,0,0},  // 43
                                                        {1,3,2,1,3,1,0,0},  // 44
                                                        {1,1,3,1,2,3,0,0},  // 45
                                                        {1,1,3,3,2,1,0,0},  // 46
                                                        {1,3,3,1,2,1,0,0},  // 47
                                                        {3,1,3,1,2,1,0,0},  // 48
                                                        {2,1,1,3,3,1,0,0},  // 49
                                                        {2,3,1,1,3,1,0,0},  // 50
                                                        {2,1,3,1,1,3,0,0},  // 51
                                                        {2,1,3,3,1,1,0,0},  // 52
                                                        {2,1,3,1,3,1,0,0},  // 53
                                                        {3,1,1,1,2,3,0,0},  // 54
                                                        {3,1,1,3,2,1,0,0},  // 55
                                                        {3,3,1,1,2,1,0,0},  // 56
                                                        {3,1,2,1,1,3,0,0},  // 57
                                                        {3,1,2,3,1,1,0,0},  // 58
                                                        {3,3,2,1,1,1,0,0},  // 59
                                                        {3,1,4,1,1,1,0,0},  // 60
                                                        {2,2,1,4,1,1,0,0},  // 61
                                                        {4,3,1,1,1,1,0,0},  // 62
                                                        {1,1,1,2,2,4,0,0},  // 63
                                                        {1,1,1,4,2,2,0,0},  // 64
                                                        {1,2,1,1,2,4,0,0},  // 65
                                                        {1,2,1,4,2,1,0,0},  // 66
                                                        {1,4,1,1,2,2,0,0},  // 67
                                                        {1,4,1,2,2,1,0,0},  // 68
                                                        {1,1,2,2,1,4,0,0},  // 69
                                                        {1,1,2,4,1,2,0,0},  // 70
                                                        {1,2,2,1,1,4,0,0},  // 71
                                                        {1,2,2,4,1,1,0,0},  // 72
                                                        {1,4,2,1,1,2,0,0},  // 73
                                                        {1,4,2,2,1,1,0,0},  // 74
                                                        {2,4,1,2,1,1,0,0},  // 75
                                                        {2,2,1,1,1,4,0,0},  // 76
                                                        {4,1,3,1,1,1,0,0},  // 77
                                                        {2,4,1,1,1,2,0,0},  // 78
                                                        {1,3,4,1,1,1,0,0},  // 79
                                                        {1,1,1,2,4,2,0,0},  // 80
                                                        {1,2,1,1,4,2,0,0},  // 81
                                                        {1,2,1,2,4,1,0,0},  // 82
                                                        {1,1,4,2,1,2,0,0},  // 83
                                                        {1,2,4,1,1,2,0,0},  // 84
                                                        {1,2,4,2,1,1,0,0},  // 85
                                                        {4,1,1,2,1,2,0,0},  // 86
                                                        {4,2,1,1,1,2,0,0},  // 87
                                                        {4,2,1,2,1,1,0,0},  // 88
                                                        {2,1,2,1,4,1,0,0},  // 89
                                                        {2,1,4,1,2,1,0,0},  // 90
                                                        {4,1,2,1,2,1,0,0},  // 91
                                                        {1,1,1,1,4,3,0,0},  // 92
                                                        {1,1,1,3,4,1,0,0},  // 93
                                                        {1,3,1,1,4,1,0,0},  // 94
                                                        {1,1,4,1,1,3,0,0},  // 95
                                                        {1,1,4,3,1,1,0,0},  // 96
                                                        {4,1,1,1,1,3,0,0},  // 97
                                                        {4,1,1,3,1,1,0,0},  // 98
                                                        {1,1,3,1,4,1,0,0},  // 99
                                                        {1,1,4,1,3,1,0,0},  // 100
                                                        {3,1,1,1,4,1,0,0},  // 101
                                                        {4,1,1,1,3,1,0,0},  // 102
                                                        {2,1,1,4,1,2,0,0},  // 103
                                                        {2,1,1,2,1,4,0,0},  // 104
                                                        {2,1,1,2,3,2,0,0},  // 105
                                                        {2,3,3,1,1,1,2,0}   // 106
                                                       };



        //public static Bitmap GetCode39(string strSource)
        //{
        //    int x = 10; //左邊界      
        //    int y = 10; //上邊界      
        //    int WidLength = 4; //粗BarCode長度      
        //    int NarrowLength = 2; //細BarCode長度      
        //    int BarCodeHeight = 50; //BarCode高度      
        //    int intSourceLength = strSource.Length;
        //    string strEncode = "010010100"; //編碼字串 初值為 起始符號 *       
        //    string AlphaBet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*"; //Code39的字母      
        //    string[] Code39 = //Code39的各字母對應碼 
        //                    {      
        //                        /**//* 0 */ "000110100",       
        //                        /**//* 1 */ "100100001",      
        //                        /**//* 2 */ "001100001",       
        //                        /**//* 3 */ "101100000",      
        //                        /**//* 4 */ "000110001",       
        //                        /**//* 5 */ "100110000",       
        //                        /**//* 6 */ "001110000",       
        //                        /**//* 7 */ "000100101",      
        //                        /**//* 8 */ "100100100",       
        //                        /**//* 9 */ "001100100",       
        //                        /**//* A */ "100001001",       
        //                        /**//* B */ "001001001",      
        //                        /**//* C */ "101001000",       
        //                        /**//* D */ "000011001",       
        //                        /**//* E */ "100011000",       
        //                        /**//* F */ "001011000",      
        //                        /**//* G */ "000001101",       
        //                        /**//* H */ "100001100",       
        //                        /**//* I */ "001001100",       
        //                        /**//* J */ "000011100",      
        //                        /**//* K */ "100000011",       
        //                        /**//* L */ "001000011",       
        //                        /**//* M */ "101000010",       
        //                        /**//* N */ "000010011",      
        //                        /**//* O */ "100010010",       
        //                        /**//* P */ "001010010",       
        //                        /**//* Q */ "000000111",       
        //                        /**//* R */ "100000110",      
        //                        /**//* S */ "001000110",       
        //                        /**//* T */ "000010110",       
        //                        /**//* U */ "110000001",       
        //                        /**//* V */ "011000001",      
        //                        /**//* W */ "111000000",       
        //                        /**//* X */ "010010001",       
        //                        /**//* Y */ "110010000",       
        //                        /**//* Z */ "011010000",      
        //                        /**//* - */ "010000101",       
        //                        /**//* . */ "110000100",       
        //                        /**//*' '*/ "011000100",      
        //                        /**//* $ */ "010101000",      
        //                        /**//* / */ "010100010",       
        //                        /**//* + */ "010001010",       
        //                        /**//* % */ "000101010",       
        //                        /**//* * */ "010010100"  
        //                    };
        //    strSource = strSource.ToUpper();
        //    //實作圖片，绘制的图片参数长度（10*字符长度 + 10），高度（BarCode高度 + 10）    
        //    Bitmap objBitmap = new Bitmap(((WidLength * 3 + NarrowLength * 7) * (intSourceLength + 2)) + (x * 2), BarCodeHeight + (y * 2));
        //    Graphics objGraphics = Graphics.FromImage(objBitmap);
        //    //宣告GDI+繪圖介面      
        //    //填上底色      
        //    objGraphics.FillRectangle(Brushes.White, 0, 0, objBitmap.Width, objBitmap.Height);
        //    for (int i = 0; i < intSourceLength; i++)
        //    {
        //        //檢查是否有非法字元          
        //        if (AlphaBet.IndexOf(strSource[i]) == -1 || strSource[i] == '*')
        //        {
        //            objGraphics.DrawString("含有非法字元", SystemFonts.DefaultFont, Brushes.Red, x, y);
        //            return objBitmap;
        //        }
        //        //查表編碼          
        //        strEncode = string.Format("{0}0{1}", strEncode, Code39[AlphaBet.IndexOf(strSource[i])]);
        //    }
        //    strEncode = string.Format("{0}0010010100", strEncode);
        //    //補上結束符號 *       
        //    int intEncodeLength = strEncode.Length;
        //    //編碼後長度      
        //    int intBarWidth;
        //    for (int i = 0; i < intEncodeLength; i++)
        //    //依碼畫出Code39 BarCode      
        //    {
        //        intBarWidth = strEncode[i] == '1' ? WidLength : NarrowLength;
        //        objGraphics.FillRectangle(i % 2 == 0 ? Brushes.Black : Brushes.White, x, y, intBarWidth, BarCodeHeight);
        //        x += intBarWidth;
        //    }
        //    return objBitmap;
        //}


    }
}