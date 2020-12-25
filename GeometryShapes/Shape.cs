using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShapes
{
    /// <summary>
    /// An abstract class Shape inherited from Shapes interface
    /// Contains methods that need to be overerriden.
    /// Also, some more specific properties of Shape like xaxis and yaxis.
    /// </summary>
    public abstract class Shape : Shapes
    {
        /// <summary>
        /// Some specific properties of Shape class
        /// Making these accessable throughout the namespace
        /// </summary>
        protected int xaxis, yaxis;
        protected Color color;
        protected bool fill;

        /// <summary>
        /// The draw method is yet again declared abstract.
        /// postponing this method definition for more specific child version.
        /// </summary>
        /// <param name="g"></param>
        public abstract void draw(Graphics g);

        /// <summary>
        /// Some properties of Shape class is reserved in the order in which they arrive.
        /// ie Color, fill, xaxis and yaxis
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fill"></param>
        /// <param name="list"></param>
        public virtual void set(Color color, bool fill, params int[] list)
        {
            this.color = color; 
            //any shape will have a color of its outline, x axis position, yaxis position   
            this.fill = fill;
            this.xaxis = list[0]; 
            //hence, we are setting these properties here beforehand
            this.yaxis = list[1];
            // xaxis and yaxis set acc to the general Cartesian rule.
        }
    }
}
