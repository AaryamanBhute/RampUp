namespace Library
{
    public class StringLibrary
    {
        public static bool isNumeric(string s)
        {
            if(s.Length == 0) { return false; }

            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0 && s[i] == '-') continue;
                if(!Char.IsDigit(s[i])) return false;
            }

            return true;
        }

        public static bool startsWith(string s, string p)
        {
            if(s.Length < p.Length) return false;

            for(int i = 0; i < p.Length; i++) {
                if (s[i] != p[i]) { return false; }
            }

            return true;
        }

        public static List<string> split(string s, string delimeter)
        {
            List<string> ret = new List<string>();

            if(delimeter.Length == 0)
            {
                throw new InvalidOperationException("delimeter cannot be empty");
            }
            string cur = "";

            while(s.Length > 0)
            {
                if(startsWith(s, delimeter))
                {
                    if(cur.Length > 0)
                    {
                        ret.Add(cur);
                        cur = "";
                    }

                    s = s.Remove(0, delimeter.Length);
                }
                else
                {
                    cur += s[0];
                    s = s.Remove(0, 1);
                }
            }
            if (cur.Length > 0)
            {
                ret.Add(cur);
                cur = "";
            }

            return ret;
        }

        public static string capitalize(string s)
        {
            string ret = "";

            for (int i = 0; i < s.Length; i++) {

                if (i == 0)
                {
                    if (Char.IsLetter(s[i]))
                    {
                        ret += Char.ToUpper(s[i]);
                    }
                    else
                    {
                        ret += s[i];
                    }
                    continue;
                }

                if (!Char.IsLetter(s[i])) {
                    ret += s[i];
                    continue;
                }

                if (!Char.IsLetter(s[i - 1]))
                {
                    ret += Char.ToUpper(s[i]);
                    continue;
                }

                ret += Char.ToLower(s[i]);
            }

            return ret;
        }

        public static int toInt(string s)
        {
            int val = 0;

            if(!isNumeric(s)) { throw new InvalidOperationException("string must be numeric"); }

            bool negative = s[0] == '-';

            int i = 0;

            if (negative)
            {
                i += 1;
            }

            for (; i < s.Length; i++)
            {
                val *= 10;
                val += s[i] - '0';
            }

            if( negative)
            {
                val *= -1;
            }

            return val;
        }
    }
}
