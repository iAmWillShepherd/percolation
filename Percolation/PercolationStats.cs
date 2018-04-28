using System;

namespace Percolation
{
    public class PercolationStats
    {
        readonly Percoloation _percolation;

        /// <summary>
        /// Perform T independent experiments on an N-by-N grid
        /// </summary>
        public PercolationStats(int N, int T)
        {
            _percolation = new Percoloation(N);
        }

        /// <summary>
        /// Sample mean of percolation threshold
        /// </summary>
        public double Mean()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sample standard deviation of percolation threshold
        /// </summary>
        public double StdDev()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Low  endpoint of 95% confidence interval
        /// </summary>
        public double ConfidenceLow()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// High endpoint of 95% confidence interval
        /// </summary>
        public double ConfidenceHigh()
        {
            throw new NotImplementedException();
        }
    }
}
