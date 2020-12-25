using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryShapes;
using drawing = System.Drawing;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        /// <summary>
        /// Tests if a Rectangle class validly forms
        /// </summary>
       
        public void TestRectangleDimensions()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.set(drawing.Color.Blue, true, 0, 0, 10, 15);

            int[] expectedValues = { 10, 15 };
            int[] obtainedValues = { rectangle.width, rectangle.height };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Rectangle did not correctly set its width!");
            Assert.IsTrue(expectedValues[1] == obtainedValues[1], "Rectangle did not correclty set its height!");
        }

        [TestMethod]

        public void TestParseDrawTo()
        {
            //   parseLine(String line, Canvas displayCanvas, StringBuilder errorList, int numLine)

            Canvas myCanvas = new Canvas();
            Parse parser = new Parse();

            parser.parseLine(new StringBuilder(), myCanvas, "drawto 200,100", 1);

            int[] expectedValues = { 200, 100 };
            int[] obtainedValues = { myCanvas.x, myCanvas.y };

            //run test
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Parser did not correctly draw the point in the specified x coordinate!");
            Assert.IsTrue(expectedValues[1] == obtainedValues[1], "Parser did not correctly draw the point in the specified y coordinate!");
        }

        [TestMethod]

        public void TestCircleDimensions()
        {
            Circle rectangle = new Circle();
            rectangle.set(drawing.Color.Blue, true, 0, 0, 10);

            int[] expectedValues = { 10 };
            int[] obtainedValues = { rectangle.radius };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Circle did not correctly set its radius!");
        }

        [TestMethod]

        public void TestShapeFactoryReturnTypes()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Shape rectShape = shapeFactory.createShape("rect");
            Shape circleShape = shapeFactory.createShape("circle");
            Shape squareShape = shapeFactory.createShape("square");
            Shape triangleShape = shapeFactory.createShape("triangle");

            // validate results
            Assert.IsTrue(rectShape is Rectangle, "ShapeFactory did not return Rectangle correctly.");
            Assert.IsTrue(circleShape is Circle, "ShapeFactory did not return Circle correctly.");
            Assert.IsTrue(squareShape is Square, "ShapeFactory did not return Square correctly.");
            Assert.IsTrue(triangleShape is Triangle, "ShapeFactory did not return Triangle correctly.");
        }

        [TestMethod]

        public void TestSquareDimensions()
        {
            Square square = new Square();
            square.set(drawing.Color.Blue, true, 0, 0, 10);

            int[] expectedValues = { 10 };
            int[] obtainedValues = { square.width };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Square did not correctly set its width!");
        }

        [TestMethod]

        public void TestTriangleDimensions()
        {
            Triangle triangle = new Triangle();
            triangle.set(drawing.Color.Blue, true, 0, 0, 10, 15, 20);

            int[] expectedValues = { 10, 15, 20 };
            int[] obtainedValues = { triangle.hypotenuse, triangle.breadth, triangle.perpendicular };

            // validate results
            Assert.IsTrue(expectedValues[0] == obtainedValues[0], "Triangle did not correclty set its hypotenuse!");
            Assert.IsTrue(expectedValues[1] == obtainedValues[1], "Triangle did not correclty set its breadth!");
            Assert.IsTrue(expectedValues[2] == obtainedValues[2], "Triangle did not correclty set its perpendicular!");
        }

    }
}
