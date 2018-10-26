namespace Game777
{
    using System;

    public static class Gaussian
    {
        private static readonly Random Random = new Random();

        private static bool _haveNextNextGaussian;
        private static double _nextNextGaussian;

        public static int GaussianInRange(double from, double mean, double to)
        {
            if (!(from < mean && mean < to))
                throw new ArgumentOutOfRangeException();

            var p = Convert.ToInt32(Random.NextDouble()*100);
            double retval;
            if (p < mean*Math.Abs(@from - to))
            {
                var interval1 = NextGaussian()*(mean - @from);
                retval = from + (float) interval1;
            }
            else
            {
                var interval2 = NextGaussian()*(to - mean);
                retval = mean + (float) interval2;
            }
            while (retval < from || retval > to)
            {
                if (retval < from)
                    retval = @from - retval + from;
                if (retval > to)
                    retval = to - (retval - to);
            }
            return (int)Math.Round(retval,MidpointRounding.AwayFromZero);
        }

        private static double NextGaussian()
        {
            if (_haveNextNextGaussian)
            {
                _haveNextNextGaussian = false;
                return _nextNextGaussian;
            }
            double v1, v2, s;
            do
            {
                v1 = 2*Random.NextDouble() - 1;
                v2 = 2*Random.NextDouble() - 1;
                s = v1*v1 + v2*v2;
            } while (s >= 1 || s == 0);
            var multiplier = Math.Sqrt(-2*Math.Log(s)/s);
            _nextNextGaussian = v2*multiplier;
            _haveNextNextGaussian = true;
            return v1*multiplier;
        }
    }
}