using Xunit;
using Percolation;

namespace Percolation.Test
{
    public class DisjointSetTests
    {
        const int Num_Sites = 10;

        readonly DisjointSet _sut;

        public DisjointSetTests()
        {
            _sut = new DisjointSet(Num_Sites);
        }

        [Fact]
        public void EachSiteShouldBeAComponentOnInit()
        {
            //Act
            var numRoots = _sut.Count;

            //Assert
            Assert.Equal(Num_Sites, numRoots);

            for (var i = 0; i < Num_Sites; i++)
                Assert.Equal(i, _sut.Find(i));
        }

        [Fact]
        public void UnionShouldDecreaseNumberOfComponentsByOne()
        {
            //Act
            _sut.Union(0, 1);

            //Assert
            Assert.True(_sut.Count == Num_Sites - 1);
        }

        [Fact]
        public void TwoComponentsShouldBeConnectedAfterUnion()
        {
            //Arrange
            _sut.Union(0, 1);

            //Act
            var areConnected = _sut.Connected(0, 1);

            //Assert
            Assert.True(areConnected);
        }

        [Fact]
        public void ConnectedComponentsAreReflexive()
        {
            //Act
            var isReflexive = _sut.Connected(0, 0); // p -> p

            //Assert
            Assert.True(isReflexive);
        }

        [Fact]
        public void ConnectedComponentsAreSymmetric()
        {
            //Arrange
            _sut.Union(0, 1);   // p -> q

            //Act
            var pToQ = _sut.Connected(0, 1);    // p -> q
            var qToP = _sut.Connected(1, 0);    // q -> p

            //Assert
            Assert.True(pToQ);
            Assert.True(qToP);
        }

        [Fact]
        public void ConnectedComponentsAreTransitive()
        {
            //Arrange
            _sut.Union(0, 1);   // p -> q
            _sut.Union(1, 2);   // q -> r

            //Act
            var pToR = _sut.Connected(0, 2);

            //Assert
            Assert.True(pToR);
        }

        [Fact]
        public void UnionAvoidsCyclesBySkippingComponentsWhichAreAlreadyConnected()
        {
            //Arrange
            _sut.Union(4, 3);
            _sut.Union(3, 8);
            _sut.Union(6, 5);
            _sut.Union(9, 4);
            _sut.Union(2, 1);
            _sut.Union(8, 9);   // this pair is already connected
            _sut.Union(5, 0);
            _sut.Union(7, 2);
            _sut.Union(6, 1);
            _sut.Union(1, 0);   // this pair is already connected
            _sut.Union(6, 7);   // this pair is already connected

            //Assert
            Assert.Equal(2, _sut.Count);
        }

        [Fact]
        public void MergedComponentsPathToRootIsCompressed()
        {
            //Arrange
            _sut.Union(4, 3);   // 4 -> 3
            _sut.Union(3, 8);   // 8 -> 9
            _sut.Union(6, 5);   // 5 -> 6
            _sut.Union(9, 4);   // 4 -> 9
            _sut.Union(2, 1);   // 1 -> 2
            _sut.Union(8, 9);   // this pair is already connected
            _sut.Union(5, 0);   // 0 -> 6
            _sut.Union(7, 2);   // 2
            _sut.Union(6, 1);
            _sut.Union(1, 0);   // this pair is already connected
            _sut.Union(6, 7);   // this pair is already connected
        }
    }
}
