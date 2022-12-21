using System;
using System.Collections;
using System.Collections.Generic;

namespace DeteksiHama.Class.C45
{
    public sealed class SequenceComparator : IComparer, IComparer<int>, IComparer<string>
    {
        public int Compare(object o1, object o2)
        {
            string str1 = (string)o1;
            string str2 = (string)o2;
            return String.Compare(str1, str2, StringComparison.Ordinal);
        }

        public int Compare(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int Compare(string x, string y)
        {
            var str1 = x;
            var str2 = y;
            return String.Compare(str1, str2, StringComparison.Ordinal);
        }
    }
}
