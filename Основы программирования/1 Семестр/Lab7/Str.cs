using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Str
    {
        public static int CountLetter(string x)
        {
            int count = 0;
            foreach (char n in x)
            {
                if (Char.IsLetter(n))
                    count++; 
            }
            return count;
        }
        public static float MidLength(string x)
        {
            string res = "";
            int i = 0;
            float countWords = 0;
            while (i < x.Length - 1)
            {
                string word = "";
                while (i < x.Length - 1 && Char.IsLetter(x[i]))
                {
                    word += x[i];
                    i++;
                }
                if (word != "")
                {
                    res += word;
                    countWords++;
                }
                i++;
            }
            return res.Length / countWords;
        }
        public static string Replace(string x, string sub, string rep)
        {
            int i = 0, fp = 0, lp = 0;
            x = x.ToLower();
            sub = sub.ToLower();
            while (i < x.Length)
            {
                fp = i;
                while ((fp < x.Length) && !(Char.IsLetter(x[fp]))) fp++;
                lp = fp;
                while ((lp < x.Length) && (Char.IsLetter(x[lp]))) lp++;
                lp--;
                if (x.Substring(fp, lp - fp + 1) == sub)
                {
                    x = x.Remove(fp, lp - fp + 1);
                    x = x.Insert(fp, rep);
                    i = fp + rep.Length + 1;
                }
                else i = lp + 1;
            }
            return x;
        }
    
        public static int CountString(string x, string y)
        {
            int i = 0;
            int j = -1;
            int c = -1;
            while (i != -1)
            {
                i = x.IndexOf(y, j + 1);
                j = i;
                c++;
            }
            return c;
        }
        public static bool Palindrome(string x)
        {
            string res = "";
            foreach (char n in x)
            {
                if (Char.IsLetter(n))
                    res += n;
            }
            char[] arr = res.ToCharArray();
            Array.Reverse(arr);
            string final = new string(arr);
            if (res.ToLower() == final.ToLower())
                return true;
            else
                return false;
        }
        public static bool Data(string s)
        {
            if (DateTime.TryParse(s, out DateTime m))
            {
                if ((s + " 0:00:00") == m.ToString("dd.MM.yy 0:mm:ss") || (s + " 0:00:00") == m.ToString("dd.MM.yyyy 0:mm:ss"))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
