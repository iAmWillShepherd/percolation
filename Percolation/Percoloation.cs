using System;

namespace Percolation
{
    public class Percoloation
    {
        readonly DisjointSet _uf;
        readonly SiteStatus[] _siteStatuses;
        readonly int _vTop;
        readonly int _vBottom;
        readonly int _numSites;

        /// <summary>
        /// create N-by-N grid, with all sites blocked
        /// </summary>
        public Percoloation(int n)
        {
            _numSites = n;
            _uf = new DisjointSet(n * n + 2); // add vTop and vBottom
            _siteStatuses = new SiteStatus[n * n + 1];
            _vTop = GetSiteId(n, n) + 1;
            _vBottom = GetSiteId(n, n) + 2;
        }

        /// <summary>
        /// Opens site (row i, column j) if it is not open already
        /// </summary>
        public void Open(int i, int j)
        {
            if (IsOpen(i, j))
                return;

            _siteStatuses[GetSiteId(i, j)] = SiteStatus.Open;
            ConnectNeighbors(i, j);
        }

        /// <summary>
        /// Is site (row i, column j) open?
        /// </summary>
        public bool IsOpen(int i, int j)
        {
            IsValidSite(i, j);

            return _siteStatuses[GetSiteId(i, j)] == SiteStatus.Open;
        }

        /// <summary>
        /// Is site (row i, column j) full?
        /// </summary>
        public bool IsFull(int i, int j)
        {
            IsValidSite(i, j);

            var id = GetSiteId(i, j);

            return _uf.Connected(id, _vTop);
        }

        /// <summary>
        /// does the system percolate?
        /// </summary>
        public bool Percolates() => _uf.Connected(_vTop, _vBottom);

        #region Helpers

        void IsValidSite(int i, int j)
        {
            if (i < 0 || i >= _numSites || j < 0 || j >= _numSites)
                throw new ArgumentOutOfRangeException();
        }

        int GetSiteId(int i, int j) => i * _numSites + j;

        void ConnectNeighbors(int i, int j)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
