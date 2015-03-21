using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Utils;

namespace UnicodeForPersian
{
    

    public class SubRipServices
    {
        private readonly static Regex regex_srt = new Regex(@"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> " +
            @"(?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?)\r\n\r\n", RegexOptions.Compiled);

        private static readonly Regex regex_tags = new Regex("<.*?>", RegexOptions.Compiled);

        private static readonly Regex unTagetdLettersRegex = new Regex(@"[A-Za-z0-9]+", RegexOptions.Compiled);
        public string ToUnicode(string lines)
        {

        string subtitle= regex_srt.Replace(lines,delegate(Match m)
             {
                 string text = m.Groups["text"].Value;
                 //1.remove tags
                 text = CleanScriptTags(text);
                 text =StringUtils.ConvertToMultiLine(text);

                 //2.replace letters
                 PersianReshape reshaper = new PersianReshape();
                 text = reshaper.reshape(text);
                 string[] splitedlines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                 text = "";
                 foreach (string line in splitedlines)
                 {
                     //3.reverse tags
                     text += ReverseText(reshaper.reshape(line))+Environment.NewLine ;
                 }
                 return
                     string.Format("{0}\r\n{1} --> {2}\r\n", m.Groups["sequence"], m.Groups["start"].Value,
                         m.Groups["end"]) + text + Environment.NewLine+Environment.NewLine ;
             }
            );

            return subtitle;
        }

        private  string CleanScriptTags(string html)
        {
            return regex_tags.Replace(html, string.Empty);
        }

        private string ReverseText(string text)
        {
            char[] chararray = text.ToCharArray();
            string reverseText = "";
            bool prefixcomp = false;
            bool postfixcomp = false;
            string prefix = "";
            string postfix = "";

            #region get prefix symbols
            for (int i = 0; i < chararray.Length; i++)
            {
                if (!prefixcomp)
                {
                    char ch =(char) chararray.GetValue(i) ;
                    if (ch< 130)
                    {
                        prefix += chararray.GetValue(i);
                    }
                    else
                    {
                        prefixcomp = true;
                        break;
                    }
                }
            }
            #endregion

            #region get postfix symbols
            for (int i = chararray.Length - 1; i >-1 ; i--)
            {
                if (!postfixcomp && prefix.Length!=text.Length)
                {
                    char ch = (char)chararray.GetValue(i);
                    if (ch < 130)
                    {
                        postfix += chararray.GetValue(i);
                    }
                    else
                    {
                        postfixcomp = true;
                        break;
                    }
                }
            }
            #endregion

            #region reverse text

            reverseText = Reverse(text, prefix.Length, text.Length-postfix.Length);

        
            reverseText = unTagetdLettersRegex.Replace(reverseText, delegate(Match m)
            {
                return Reverse(m.Value);
            });
            #endregion

          

            return prefix+ reverseText+postfix;
        }

        private string Reverse(string text)
        {
            return Reverse(text,0,text.Length);
        }

        private string Reverse(string text,int start,int end)
        {
            if (end < start)
                return text;
            string reverseText = "";

            for (int i = end-1; i >=start; i--)
            {
                reverseText += text[i];
            }
            return reverseText;
        }

     
    }

}
