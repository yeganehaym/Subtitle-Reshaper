using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class StringUtils
    {
        public static string ConvertToMultiLine(String text, int min = 30, int max = 40)
        {
            if (text.Trim() == "")
                return text;

            string[] words = text.Split(new string[] { " " }, StringSplitOptions.None);

            string text1 = "";
            string text2 = "";
            foreach (string w in words)
            {
                if (text1.Length < min)
                {
                    if (text1.Length == 0)
                    {
                        text1 = w;
                        continue;
                    }

                    if (w.Length + text1.Length <= max)
                        text1 += " " + w;
                }
                else
                    text2 += w + " ";

            }
            text1 = text1.Trim();
            text2 = text2.Trim();
            if (text2.Length > 0)
            {
                text1 += Environment.NewLine + ConvertToMultiLine(text2, min, max);
            }
            return text1;
        }
      
    }
}
