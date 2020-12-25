using System.Drawing;

namespace GeometryShapes
{
    /// <summary>
    /// Triangle, a more specific version of Shape, class inherited from it.
    /// Has some unique properties.
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// height,breadth and perpendicular a unique property of Triangle, declared as integer
        /// </summary>
        public int hypotenuse, breadth, perpendicular;

        /// <summary>
        /// ///Method overrides the set method from Shapes class.
        /// All the properties required for creating/drawing triangle 
        /// all come in the order:color,fill status and radius
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fill"></param>
        /// <param name="list"></param>
        public override void set(Color color, bool fill, params int[] list)
        {
            base.set(color, fill, list[0], list[1]);
            this.hypotenuse = list[2];
            this.breadth = list[3];
            this.perpendicular = list[4];
        }

        /// <summary>
        /// Overriding the draw method from Shape class.
        /// Specifically draws a triangle with the help of Graphics.DrawPolygon method
        /// uses the paramteres set from the set method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(this.color, 2);
            Point[] points = {  new Point(this.xaxis, this.yaxis+perpendicular), new Point(this.xaxis+breadth, this.yaxis+this.perpendicular),
                                new Point(this.xaxis, this.yaxis)};

            g.DrawPolygon(p, points);
            if (this.fill)
            {
                SolidBrush sb = new SolidBrush(this.color);
                g.FillPolygon(sb, points);
            }

        }
    }
}
