
namespace GeometryShapes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.multiCommand = new System.Windows.Forms.RichTextBox();
            this.errorBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.singleCommand = new System.Windows.Forms.RichTextBox();
            this.runBtn = new System.Windows.Forms.Button();
            this.outputDisplay = new System.Windows.Forms.PictureBox();
            this.syntaxbtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.aboutUSToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1498, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(125, 26);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(125, 26);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem2_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(14, 24);
            // 
            // aboutUSToolStripMenuItem
            // 
            this.aboutUSToolStripMenuItem.Name = "aboutUSToolStripMenuItem";
            this.aboutUSToolStripMenuItem.Size = new System.Drawing.Size(14, 24);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutUsToolStripMenuItem1
            // 
            this.aboutUsToolStripMenuItem1.Name = "aboutUsToolStripMenuItem1";
            this.aboutUsToolStripMenuItem1.Size = new System.Drawing.Size(153, 26);
            this.aboutUsToolStripMenuItem1.Text = "About Us";
            this.aboutUsToolStripMenuItem1.Click += new System.EventHandler(this.aboutUsToolStripMenuItem1_Click);
            // 
            // multiCommand
            // 
            this.multiCommand.BackColor = System.Drawing.SystemColors.Info;
            this.multiCommand.Location = new System.Drawing.Point(43, 69);
            this.multiCommand.Name = "multiCommand";
            this.multiCommand.Size = new System.Drawing.Size(380, 371);
            this.multiCommand.TabIndex = 2;
            this.multiCommand.Text = "";
            // 
            // errorBox
            // 
            this.errorBox.Location = new System.Drawing.Point(481, 510);
            this.errorBox.Name = "errorBox";
            this.errorBox.ReadOnly = true;
            this.errorBox.Size = new System.Drawing.Size(891, 75);
            this.errorBox.TabIndex = 3;
            this.errorBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Multi line command";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(478, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Canvas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 443);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Single Line Command";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PeachPuff;
            this.label4.Location = new System.Drawing.Point(491, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "!! Error Box !!";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // singleCommand
            // 
            this.singleCommand.Location = new System.Drawing.Point(43, 463);
            this.singleCommand.Name = "singleCommand";
            this.singleCommand.Size = new System.Drawing.Size(380, 75);
            this.singleCommand.TabIndex = 11;
            this.singleCommand.Text = "";
            this.singleCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singleCommand_KeyDown);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(176, 548);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 37);
            this.runBtn.TabIndex = 12;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // outputDisplay
            // 
            this.outputDisplay.BackColor = System.Drawing.Color.Silver;
            this.outputDisplay.Location = new System.Drawing.Point(481, 69);
            this.outputDisplay.Name = "outputDisplay";
            this.outputDisplay.Size = new System.Drawing.Size(891, 400);
            this.outputDisplay.TabIndex = 15;
            this.outputDisplay.TabStop = false;
            this.outputDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.outputDisplay_Paint);
            // 
            // syntaxbtn
            // 
            this.syntaxbtn.BackColor = System.Drawing.Color.Chartreuse;
            this.syntaxbtn.Location = new System.Drawing.Point(276, 548);
            this.syntaxbtn.Name = "syntaxbtn";
            this.syntaxbtn.Size = new System.Drawing.Size(147, 37);
            this.syntaxbtn.TabIndex = 17;
            this.syntaxbtn.Text = "Syntax Check";
            this.syntaxbtn.UseVisualStyleBackColor = false;
            this.syntaxbtn.Click += new System.EventHandler(this.syntaxbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.ClientSize = new System.Drawing.Size(1498, 615);
            this.Controls.Add(this.syntaxbtn);
            this.Controls.Add(this.outputDisplay);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.singleCommand);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorBox);
            this.Controls.Add(this.multiCommand);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUSToolStripMenuItem;
        private System.Windows.Forms.RichTextBox multiCommand;
        private System.Windows.Forms.RichTextBox errorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox singleCommand;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.PictureBox outputDisplay;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.Button syntaxbtn;
    }
}

