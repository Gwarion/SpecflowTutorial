using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specflow.DomainModel.Util
{
    public static class StringUtil
    {
        public static T ToEnum<T>(this string s)
            where T : struct, Enum
        {
            return (T)Enum.Parse(typeof(T), s, true);
        }
    }
}
