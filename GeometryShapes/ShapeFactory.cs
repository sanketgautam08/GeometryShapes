using System;

namespace GeometryShapes
{
    /// <summary>
    /// Factory pattern is applied here.
    /// This is an independent class, a common interface that creates/produces objects. 
    /// </summary>
    public class ShapeFactory
    {
        /// <summary>
        /// Method that creates Shapes according to the shape type
        /// </summary>
        /// <param name="shapetype">the name of shape provided by user</param>
        /// <returns>An object of a specific shape type </returns>
        public Shape createShape(String shapetype)
        {
            if (shapetype == "rect")
            {
                Rectangle r = new Rectangle();
                return r;
            }
            else if (shapetype == "square")
            {
                Square r = new Square();
                return r;
            }
            else if (shapetype == "triangle")
            {
                Triangle t = new Triangle();
                return t;
            }
            else if (shapetype == "circle")
            {
                Circle c = new Circle();
                return c;
            }
            return null;
        }
    }
}
