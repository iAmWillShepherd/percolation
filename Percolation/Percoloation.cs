using System;

namespace Percolation
{
    public class Percoloation
    {
        readonly DisjointSet _grid;
        readonly bool[] _openCells;
        readonly int _vTop;
        readonly int _vBottom;
        readonly int _numSites;

        /// <summary>
        /// create N-by-N grid, with all sites blocked
        /// </summary>
        public Percoloation(int n)
        {
            _numSites = n;
            _grid = new DisjointSet(n * n + 2);
            _openCells = new bool[n * n + 1];
            _vTop = CellId(n, n) + 1;
            _vBottom = CellId(n, n) + 2;
        }

        /// <summary>
        /// Opens site (row i, column j) if it is not open already
        /// </summary>
        public void Open(int i, int j)
        {
            if (IsOpen(i, j))
                return;

            _openCells[CellId(i, j)] = true;
            ConnectNeighbors(i, j);
        }

        /// <summary>
        /// Is site (row i, column j) open?
        /// </summary>
        public bool IsOpen(int i, int j)
        {
            IsValidSite(i, j);

            return _openCells[CellId(i, j)];
        }

        /// <summary>
        /// Is site (row i, column j) full?
        /// </summary>
        public bool IsFull(int i, int j)
        {
            IsValidSite(i, j);

            var id = CellId(i, j);

            return _grid.Connected(id, _vTop);
        }

        /// <summary>
        /// does the system percolate?
        /// </summary>
        public bool Percolates() => _grid.Connected(_vTop, _vBottom);

        #region Helpers

        void IsValidSite(int i, int j)
        {
            if (i < 0 || i >= _numSites || j < 0 || j >= _numSites)
                throw new ArgumentOutOfRangeException();
        }

        int CellId(int i, int j) => i * _numSites + j;

        void ConnectNeighbors(int i, int j)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
