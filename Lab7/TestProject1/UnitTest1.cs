using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab7;
using System.Collections;

namespace TestProject1
{
    [TestClass]

    public class UnitTest1
    {
        public static Vertex[] array4 = new Vertex[]
        {
            new Vertex(0, 0),
            new Vertex(2, 4),
            new Vertex(2, 0),
            new Vertex(2,-3)

        };
        public static Vertex[] array2 = new Vertex[]
        {
            new Vertex(0, 0),
            new Vertex(2, 4),
        };

        public static Vertex[] array3 = new Vertex[]
        {
            new Vertex(0, 0),
            new Vertex(2, 4),
            new Vertex(2, 0),

        };

        public static Vertex[] array1=new Vertex[] 
        {
            new Vertex(0, 0),
        };
        LinkedList<Vertex> vertices1 = new LinkedList<Vertex>(array4);

        //[TestMethod()]
        //public void TestMethod1()
        //{
        //    double actual = Polygon.GetSquare(vertices1);
        //    Assert.AreEqual(21, actual);
        //}
        //[TestMethod()]
        //public void TestMethod2()
        //{
        //    double actual = Polygon.GetSquare(new LinkedList<Vertex>(array2));
        //    Assert.AreEqual(0, actual);
        //}
        //[TestMethod()]
        //public void TestMethod3()
        //{
        //    double actual = Polygon.GetSquare(new LinkedList<Vertex>(array1));
        //    Assert.AreEqual(0, actual);
        //}

        //[DataTestMethod]
        //[DynamicData(nameof(PolygonData), DynamicDataSourceType.Method)]
        //public void TestMethod(LinkedList<Vertex> vertices, double expected)
        //{
        //    double actual = Polygon.GetSquare(vertices);
        //    Assert.AreEqual(expected, actual);
        //}

        //static IEnumerable<object[]> PolygonData()
        //{
        //    LinkedList<Vertex> vertices1 = new LinkedList<Vertex>(array4);
        //    LinkedList<Vertex> vertices2 = new LinkedList<Vertex>(array2);
        //    LinkedList<Vertex> vertices3 = new LinkedList<Vertex>(array1);
        //    yield return new object[] { vertices1, 21 };
        //    yield return new object[] { vertices2, 0 };
        //    yield return new object[] { vertices3, 0 };

        //}

        [DataTestMethod]
        [DynamicData(nameof(PolygonData1), DynamicDataSourceType.Method)]
        public void EquivalPartTest(LinkedList<Vertex> vertices, double expected)
        {
            double actual = Polygon.GetSquare(vertices);
            Assert.AreEqual(expected, actual);
        }
        static IEnumerable<object[]> PolygonData1()
        {
            LinkedList<Vertex> vertices1 = new LinkedList<Vertex>(array4);
            LinkedList<Vertex> vertices3 = new LinkedList<Vertex>(array1);
            yield return new object[] { vertices1, 21 };
            yield return new object[] { vertices3, 0 };
        }

        [DataTestMethod]
        [DynamicData(nameof(PolygonData2), DynamicDataSourceType.Method)]
        public void BoundaryValuesTest(LinkedList<Vertex> vertices, double expected)
        {
            double actual = Polygon.GetSquare(vertices);
            Assert.AreEqual(expected, actual);
        }
        static IEnumerable<object[]> PolygonData2()
        {
            LinkedList<Vertex> vertices1 = new LinkedList<Vertex>(array2);
            LinkedList<Vertex> vertices3 = new LinkedList<Vertex>(array3);
            yield return new object[] { vertices1, 0 };
            yield return new object[] { vertices3, 12 };
        }

        [DataTestMethod]
        [DynamicData(nameof(PolygonData3), DynamicDataSourceType.Method)]
        public void CauseEffectTest(LinkedList<Vertex> vertices, double expected)
        {
            double actual = Polygon.GetSquare(vertices);
            Assert.AreEqual(expected, actual);
        }
        static IEnumerable<object[]> PolygonData3()
        {
            LinkedList<Vertex> vertices1 = new LinkedList<Vertex>(array4);
            LinkedList<Vertex> vertices3 = new LinkedList<Vertex>(array2);
            yield return new object[] { vertices1, 21 };
            yield return new object[] { vertices3, 0 };
        }

    }
}
