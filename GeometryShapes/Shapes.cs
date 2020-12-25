using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryShapes
{
    /// <summary>
    /// The top most class of the Shape inheritance heriarchy, an interface to be particular.
    /// Contains services(methods) offered by this interface.
    /// </summary>
    public interface Shapes
    {
        /// <summary>
        /// An abstract method 'set' that needs to be overrriden ahead.
        /// Contains some basic properties of shapes like color.
        /// </summary>
        /// <param name="color">The color a shape might have</param>
        /// <param name="fill">A property of shape to decide weather its painted</param>
        /// <param name="list"> An integer array reserved for the shape Measurements </param>
        void set(Color color, bool fill, params int[] list); //array of parameters because command parser will send it as values inside array

        /// <summary>
        /// An abstract method 'draw' that needs to be overrriden ahead.
        /// Method exists for drawing shape in picture box
        /// </summary>
        /// <param name="g">An object of Graphics on which we draw.</param>
        void draw(Graphics g);
        //Graphics g;
    }
}
