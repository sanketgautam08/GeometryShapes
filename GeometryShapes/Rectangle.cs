using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShapes
{ /// <summary>
  /// Rectangle, a more specific version of Shape, class inherited from it.
  /// Has some unique properties.
  /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// width and height, some unique properties of Rectancle class declared as integers 
        /// </summary>
        public int width, height; //now rectangle, a more specific version has width and height.

        /// <summary>
        /// Method overrides the set method from Shapes class.
        /// All the properties required for creating/drawing rectangle 
        /// all come in the order:color,fill status , width and height
        /// </summary>
        /// <param name="color"> </param>
        /// <param name="fill"></param>
        /// <param name="list"></param>
        public override void set(Color color, bool fill, params int[] list)
        {   /*
             * The three values are already set from the Shape abstract class
             */
            base.set(color, fill, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }

        /// <summary>
        /// Overriding the draw method from Shape class.
        /// Specifically draws a rectangle with the help of Graphics.DrawRectangle method
        /// uses the paramteres set from the set method
        /// </summary>
        /// <param name="g"></param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(this.color, 2);
            g.DrawRectangle(p, xaxis- width/2, yaxis- height/2, width, height);

            if (this.fill)
            {
                SolidBrush sb = new SolidBrush(this.color);
                g.FillRectangle(sb, xaxis- width/2, yaxis- height/2, width, height);
            }

        }
    }
}
