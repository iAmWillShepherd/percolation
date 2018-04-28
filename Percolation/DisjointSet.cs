using System;
using System.Text;

namespace Percolation
{
    public class DisjointSet
    {
        readonly int[] _ids;
        readonly int[] _ranks;

        /// <summary>
        /// Gets the number of components
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        public DisjointSet(int numSites)
        {
            _ids = new int[numSites];
            _ranks = new int[numSites];
            Count = numSites;

            for (var i = 0; i < numSites; i++)
            {
                _ids[i] = i;
                _ranks[i] = 1;
            }
        }

        /// <summary>
        /// Merges two components if the two sites are in different components
        /// </summary>
        public void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

            if (pId == qId)
                return;

            int pRank = _ranks[p];
            int qRank = _ranks[q];

            if (pRank > qRank)
            {
                _ids[qId] = pId;
                _ranks[qId]++;
            }
            else
            {
                _ids[pId] = qId;
                _ranks[pId]++;
            }

            Count--;
        }

        /// <summary>
        /// Returns the component identifier for a given site.
        /// </summary>
        public int Find(int p)
        {
            IsValid(p);

            int root = p;

            while (root != _ids[root])
                root = _ids[root];

            // perform path compressions
            while (p != root)
            {
                int child = _ids[p];

                _ids[p] = root;
                _ranks[p]--;
                _ranks[root]++;
                p = child;
            }

            return root;
        }

        /// <summary>
        /// Determines if two sites are in the same component
        /// </summary>
        public bool Connected(int p, int q) => Find(p) == Find(q);

        /// <summary>
        /// Returns a string of key value pairs of the form (index : parent)
        /// </summary>
		public override string ToString()
		{
            var sb = new StringBuilder();

            sb.AppendLine($"Components: {Count}");
            sb.AppendLine();
            sb.AppendLine("(index: parent");

            for (var i = 0; i < _ids.Length; i++) {
                sb.AppendLine($"({i}: {_ids[i]})");
            }

            return sb.ToString();
		}

        void IsValid(int p)
        {
            if (p < 0 || p >= _ids.Length)
                throw new ArgumentOutOfRangeException(nameof(p));
        }
	}
}
