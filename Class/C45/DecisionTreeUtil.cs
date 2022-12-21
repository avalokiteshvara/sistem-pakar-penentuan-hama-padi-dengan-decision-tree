using System;

namespace DeteksiHama.Class.C45
{
    public static class DecisionTreeUtil
    {
        public static double info(int x, int total)
        {
            if (x == 0)
            {
                return 0;
            }
            var x_pi = getPi(x, total);
            return -(x_pi * logYBase2(x_pi));
        }

        private static double logYBase2(double y)
        {
            return Math.Log(y) / Math.Log(2);
        }

        public static double getPi(int x, int total)
        {
            return x / (double)total;
        }

    }
}
