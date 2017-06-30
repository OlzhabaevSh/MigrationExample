using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationProj.Models
{
    class EmailProvider
    {
        static Dictionary<char, string> Chars;
        static void RegistChars()
        {
            if (Chars != null)
                return;

            Chars = new Dictionary<char, string>();

            Chars.Add('а', "a");
            Chars.Add('б', "b");
            Chars.Add('в', "v");
            Chars.Add('г', "g");
            Chars.Add('д', "d");
            Chars.Add('е', "e");
            Chars.Add('ё', "yo");
            Chars.Add('ж', "zh");
            Chars.Add('з', "z");
            Chars.Add('и', "i");

            Chars.Add('й', "");
            Chars.Add('к', "k");
            Chars.Add('л', "l");
            Chars.Add('м', "m");
            Chars.Add('н', "n");
            Chars.Add('о', "o");
            Chars.Add('п', "p");
            Chars.Add('р', "r");
            Chars.Add('с', "s");
            Chars.Add('т', "t");

            Chars.Add('у', "u");
            Chars.Add('ф', "ph");
            Chars.Add('х', "h");
            Chars.Add('ц', "c");
            Chars.Add('ч', "ch");
            Chars.Add('ш', "sh");
            Chars.Add('щ', "zsh");
            Chars.Add('ъ', "");
            Chars.Add('ы', "y");
            Chars.Add('ь', "");

            Chars.Add('э', "e");
            Chars.Add('ю', "u");
            Chars.Add('я', "ya");
        }

        public static string GetEmail(string lastName, string firstName)
        {
            RegistChars();

            StringBuilder email = new StringBuilder();

            foreach (var item in lastName)
            {
                var small = Char.ToLower(item);
                if (Chars.Any(x => x.Key == small))
                {
                    email.Append(Chars[small]);
                }
            }

            email.Append('.');

            foreach (var item in firstName)
            {
                var small = Char.ToLower(item);
                if (Chars.Any(x => x.Key == small))
                {
                    email.Append(Chars[small]);
                }
            }

            email.Append("@kaizen.kz");

            return email.ToString();
        }

    }
}
