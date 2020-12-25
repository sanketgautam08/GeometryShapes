using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryShapes
{
                                 //Stores the list of errors while parsinga  
    public partial class Form1 : Form
    {
        Bitmap drawBoard;                                         //output bitmap image
        Bitmap cursorBoard;                                        //cursor pointer bitmap image
        Canvas displayCanvas;                                   //canvas for drawing on output bitmap image
        Parse parser;                                           //Parses the command line
        StringBuilder errorList;
        public Form1()
        {
            InitializeComponent();
            drawBoard = new Bitmap(740, 400);
            cursorBoard = new Bitmap(740, 400);
            //initializes the canvas objects
            displayCanvas = new Canvas(Graphics.FromImage(drawBoard));
            //transparentCanvas = new Canvas(Graphics.FromImage(cursorBoard));

            errorList = new StringBuilder();
            drawCursor();
        }

        public void drawCursor()
        {
            Graphics g = Graphics.FromImage(cursorBoard);
            g.Clear(Color.Transparent);
            g.FillEllipse(new SolidBrush(Color.BlueViolet), displayCanvas.x - 5, displayCanvas.y - 5, 10, 10);
        }


        private void singleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cmd = singleCommand.Text.Trim().ToLower();
                if (cmd.Equals("run"))
                    run(true);
                else
                    run(false);
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            String cmd = singleCommand.Text.Trim().ToLower();
            errorList = new StringBuilder();
            if (cmd.Equals("run"))
                run(true);
            else
                run(false);
        }

        public void run(bool cmdRun)
        {
            errorBox.Text = "";
            errorList = new StringBuilder();
            parser = new Parse();
            parser.parseCommand(singleCommand, displayCanvas, errorList);
            if (!multiCommand.Text.Equals("") && cmdRun)                   //if multi command line has text
            {
                parser.parseCommand(multiCommand, displayCanvas, errorList);

            }
            drawCursor();
            displayError();
            Refresh();
        }

        //refreshes the form and output screen
        public void refreshForm()
        {
            displayError();
            drawCursor();
        }

        //display errors caught while parsing
        public void displayError()
        {
            if (!errorList.ToString().Equals(""))
            {
                errorBox.Text = errorList.ToString();
            }
            errorList.Clear();
        }

        private void outputDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(drawBoard, 0, 0);
            g.DrawImageUnscaled(cursorBoard, 0, 0);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = saveFileDialog1.OpenFile();


                using (StreamWriter writer = new StreamWriter(myStream))
                {
                    writer.Write(multiCommand.Text);
                }
                myStream.Close();
            }


        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            String line = "";
            openFileDialog.Filter = "Text files (.txt)| *.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);

                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line == null) break;
                    multiCommand.Text += line;

                    multiCommand.AppendText(Environment.NewLine);
                }
            } 
            


        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Name: Sanket C Gautam\r\nStudent ID:c72002304", "About");
        }

        private void syntaxbtn_Click(object sender, EventArgs e)
        {
            {
                String cmd = singleCommand.Text.Trim().ToLower();
                errorList = new StringBuilder();
                bool cmdRun = cmd.Equals("run");
                errorBox.Text = "";
                errorList = new StringBuilder();
                parser = new Parse();
                parser.parseCommand(singleCommand, displayCanvas, errorList);
                if (!multiCommand.Text.Equals("") && cmdRun)                   //if multi command line has text
                {
                    parser.parseCommand(multiCommand, new Canvas(), errorList);

                }
                drawCursor();
                displayError();
                Refresh();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
