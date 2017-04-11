using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCon_28
{
    static class Sanitizer
    {
        public static string Sanitize(this string Text)
        {
            return Text.Replace("　", ";").Replace(" ", ";");
        }
    }
}
