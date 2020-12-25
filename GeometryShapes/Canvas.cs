using System;
using System.Drawing;

namespace GeometryShapes
{
    public class Canvas
    {
        //constants for color strings
        const String RED = "red";
        const String GREEN = "green";
        const String BLUE = "blue";
        const String WHITE = "white";
        const String BLACK = "black";
        const String YELLOW = "yellow";

        //graphics to draw on
        public Graphics g;
        //x and y position
        public int x, y;
        //fill status for shapes
        public bool fill;
        //pen and fill color
        public Color color;     

        public Canvas()
        {
            Bitmap b = new Bitmap(700,400);         
            //deafult bitmap
            g = Graphics.FromImage(b);
            x = y = 0;
            color = Color.Black;
            fill = false;
        }

        //graphics of canvas set by caller
        public Canvas(Graphics g)
        {
            this.g = g;                 
            x = y = 0;
            color = Color.Black;
            fill = false;
        }

        //moves the cursor pointer to defined positions
        public bool moveTo(int[] param)
        {
            if (param.Length != 4)              
                //if invalid param length
                return false;
            x = param[2];
            y = param[3];
            return true;
        }

        //draws line to defined positions, returns false if error found
        public bool drawTo(int[] param)
        {
            if (param.Length != 4)              
                //if invalid param length
                return false;
            g.DrawLine(new Pen(color, 2), x, y, param[2], param[3]);
            x = param[2];
            y = param[3];
            return true;
        }

        //set color for fill and pen, returns false if error found
        public bool setColor(String[] param)
        {
            param[0] = param[0].Trim().ToLower();       
            
            //trim and lowercase parameter
            if (param.Length != 1)                      
                //if invalid param length
                return false;
            //set color as defined
            if (param[0].Equals(RED))                   
                color = Color.Red;
            if (param[0].Equals(BLUE))
                color = Color.Blue;
            if (param[0].Equals(GREEN))
                color = Color.Green;
            if (param[0].Equals(BLACK))
                color = Color.Black;
            if (param[0].Equals(WHITE))
                color = Color.White;
            if (param[0].Equals(YELLOW))
                color = Color.Yellow;
            return true;                    
        }

        //sets fill status for shapes,  returns false if error found
        public bool setFill(String[] param)
        {
            if (param.Length != 1)
                return false;
            param[0] = param[0].Trim().ToLower();
            if (param[0].Equals("on"))
                fill = true;
            else if (param[0].Equals("off"))
                fill = false;
            else
                return false;

            return true;
        }

        //clears the graphics to white color
        public void clear()
        {
            g.Clear(Color.White);
        }
        //clears the graphics to white color
        public void reset()
        {
            g.Clear(Color.White);
            x = y = 0;
            fill = false;
            color = Color.Black;
        }
    }
}
