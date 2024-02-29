using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Test
    {
        public static string Replace1(string x, string y, string z)
        {
            x = " " + x + " ";
            string[] mas1 = { " ", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "@", "\"", "#", "$", "%", "&", "(", ")", "_", "-", "+", "=", "|", "/", ".", ",", "<", ">", "~", "`" };
            string[] mas2 = mas1;
            foreach (string elem1 in mas1)
                foreach (string elem2 in mas2)
                    x = x.Replace(elem1 + y + elem2, elem1 + z + elem2, StringComparison.OrdinalIgnoreCase);
            return x;
        }
        public static string Replace(string x, string y, string z)
        {
            int i = 0;
            string res = "";
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
                    if (String.Compare(word, y, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        res += z;
                    }
                    else
                        res += word;
                }
                else
                    res += x[i - 1];
                i++;
            }
            return res;
        }
        public static string ReplaceStr(string x, string sub, string rep)
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
        public bool Data(string s)
        {
            DateTime num = new DateTime();
            bool res;
            if (DateTime.TryParse(s, out num)) res = true;
            else res = false;
            return res;
        }
    }
}
