using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryShapes
{
    public class Parse
    {
        DataTable dt;   
        //used to compute expressions
        Dictionary<String, String> variables;
        int[,] loopRecorder;        
        //number of loop and its starting and ending line (basically stores the desired line number)
        String[] loopCondiition;    
        //stores the condition of the loop according to index order of recorder
        Dictionary<String, String> methodParameters;
        ArrayList uniqueMethodName;
        Dictionary<ArrayList, Dictionary<String, String>> methods;  //stores the index/ID,name of method and its variable dictionary
        int[,] methodRecorder;       
        //number of method and its starting and ending line (basically stores the desired line number)
        int methodCount;           
        //number of methods
        RichTextBox rtb;
        StringBuilder errorList;
        Canvas displayCanvas;            
        int totalLines;
        bool ifRunning;         
        //stops the parsing of line if if block is iterating and condition was false
        bool loopRunning;          
        //stops the parsing of line if while block is running
        bool methodRunning;      
        //stops the parsing of line if method block is running

        //default constructor
        public Parse()
        {
            ifRunning = false;
            loopCondiition = new String[10];        
            //stores the condition of the loop according to index order of recorder
            ifRunning = false;
            methodRunning = false;
            dt = new DataTable();
            this.variables = new Dictionary<String, String>();
            methods = new Dictionary<ArrayList, Dictionary<String, String>>();
            this.methodCount = 0;
            this.methodRecorder = new int[10, 2];        
            //number of loop and its starting and ending line
            this.loopRecorder = new int[10, 2];         
            //number of loop and its starting and ending line
            for (int i = 0; i < 10; i++)
            {
                this.loopRecorder[i, 0] = 0;
                this.loopRecorder[i, 1] = 0;
            }
        }


        public object computeExpression(String expression)
        {
            return this.dt.Compute(expression, "");
        }

        public String swapVarValuesInExpression(String expression, Dictionary<String, String> varDict)
        {
            foreach (String key in varDict.Keys)
            {
                expression = Regex.Replace(expression, @"\b" + key + @"\b", this.variables[key]);
            }
            return expression;
        }
        public void parseCommand(RichTextBox rtb, Canvas displayCanvas, StringBuilder errorList)
        {
            dt = new DataTable();
            variables = new Dictionary<String, String>();
            this.totalLines = rtb.Lines.Length;
            this.errorList = errorList;
            this.displayCanvas = displayCanvas;
            this.rtb = rtb;

            for (int i = 1; i <= this.totalLines; i++)
            {
                preParser(i);
            }
        }

        public void preParser(params object[] parameters)
        {
            int lineNo = Convert.ToInt32(parameters[0]);
            String line;
            if (parameters.Length > 1)
                line = parameters[1].ToString();
            else
                line = rtb.Lines[lineNo - 1].Trim().ToLower();

            if (line.Equals(""))
            {
                return;
            }
            if (this.methodRunning && (!line.Equals("endmethod")))
                return;
            if (this.loopRunning && (!line.Equals("endloop")))
                return;
            if (this.ifRunning && (!line.Equals("endif")))
                return;
            String command = line.Split(' ')[0].Trim();

            if (command.Equals("square") || command.Equals("circle") || command.Equals("rect") || command.Equals("triangle")
                 || command.Equals("clear") || command.Equals("fill") || command.Equals("color") || command.Equals("moveto")
                 || command.Equals("drawto") || command.Equals("reset") || command.Equals("run"))
            {
                parseLine(this.errorList, this.displayCanvas, line, lineNo);
                return;
            }
            runCommand(line, lineNo);
        }


        public void runCommand(String line, int lineNo)
        {
            String command = line.Split(' ')[0].ToLower().Trim();
            switch (command)
            {
                case "if":
                    try
                    {
                        bool result = (bool)computeExpression(swapVarValuesInExpression(line.Split(' ')[1], this.variables) );
                        if (result) { }//do nothing 
                        else { this.ifRunning = true; }
                    }
                    catch (Exception)
                    {
                        this.errorList.Append("Error!! Invalid if syntax or wrong conditional expression at " + lineNo);
                    }
                    break;

                case "endif":
                    this.ifRunning = false;
                    break;

                case "loop":
                    loopRunning = true;
                    for (int i = 0; i < 10; i++)
                    {
                        if (this.loopRecorder[i, 0] == 0)
                        {
                            this.loopRecorder[i, 0] = lineNo + 1;     //set starting line num of loop block
                            this.loopCondiition[i] = line.Split(' ')[1]; //set loop condition
                            break;
                        }
                    }
                    break;

                case "endloop":
                    loopRunning = false;
                    for (int i = 0; i < 10; i++)
                    {
                        if (this.loopRecorder[i, 0] != 0)
                        {
                            this.loopRecorder[i, 1] = lineNo - 1;   //set last line num of loop block
                            try
                            {
                                bool result = (bool)computeExpression(swapVarValuesInExpression(this.loopCondiition[i],this.variables));//computing condition of loop
                                while (result)
                                {  
                                    for (int lineNum = this.loopRecorder[i, 0]; lineNum <= this.loopRecorder[i, 1]; lineNum++)
                                    {
                                        preParser(lineNum);
                                    }
                                    result = (bool)computeExpression(swapVarValuesInExpression(this.loopCondiition[i], this.variables));
                                }
                                this.loopRecorder[i, 0] = 0;
                                this.loopRecorder[i, 1] = 0;
                                break;
                            }
                            catch (Exception)
                            {
                                this.errorList.Append("Error!! Invalid loop syntax or wrong conditional expression at" + lineNo);
                            }
                            break;
                        }
                    }
                    break;

                case "method":
                    methodRunning = true;
                    line = line.Substring(6, line.Length - 6).Trim();  //removes the method token
                    String methodName = line.Split('(')[0].Trim();
                    String parameters = line.Split('(')[1].Trim(')');
                    uniqueMethodName = new ArrayList();
                    this.methodParameters = new Dictionary<String, String>();
                    uniqueMethodName.Add(methodCount);
                    uniqueMethodName.Add(methodName);

                    foreach (String par in parameters.Split(','))
                    {
                        if (!par.Trim().Equals(""))
                            this.methodParameters.Add(par.Trim(), "");    
                        //parameter name with empty value for now
                    }
                    methods.Add(uniqueMethodName, this.methodParameters); 
                    //Add method to dictionary   
                    methodRecorder[methodCount, 0] = lineNo + 1; 
                    //record its starting line with matching index(methodCount) num of method
                    break;

                case "endmethod":
                    methodRunning = false;
                    methodRecorder[methodCount, 1] = lineNo - 1;    
                    ////record ending line for a unique method count
                    methodCount++;
                    break;
                default:    //check for variable or method name
                    //check for variable name
                    if (line.Split('=').Length == 2)
                    {
                        String varName = line.Split('=')[0].Trim();
                        String rhs = line.Split('=')[1].Trim();         
                        //right hand side expression or a number 
                        rhs = swapVarValuesInExpression(rhs,this.variables);       
                        //replace variable values in expression
                        int rhsResult = 0;
                        try
                        {
                            rhsResult = Convert.ToInt32(computeExpression(rhs));
                        }
                        catch (Exception)
                        {
                            this.errorList.Append("Error!! Error in computing expression at line " + lineNo);
                        }
                        rhs = rhsResult.ToString();
                        
                        if (this.variables.ContainsKey(varName))  
                            //Reassign a existing variable
                            this.variables[varName] = rhs;
                        else                                
                            //create and store a new variable
                            this.variables.Add(varName, rhs);
                        return;
                    }
                    
                    else if (line.Split('(').Length == 2)          
                        //check for method call
                    {
                        String calledMethodName = line.Split('(')[0].Trim();
                        bool match = false;
                        int uniqueMethodId, startLine = 0, endLine = 0;
                        foreach (ArrayList key1 in methods.Keys)
                        {
                            if (key1[1].Equals(calledMethodName))     
                                //if method name matches with any stored method
                            {
                                match = true;
                                uniqueMethodId = Convert.ToInt32(key1[0]);         
                                //unique method id of methodcount
                                this.methodParameters = methods[key1];        
                                //parameters dictionary
                                startLine = methodRecorder[uniqueMethodId, 0];    
                                //start line of method
                                endLine = methodRecorder[uniqueMethodId, 1];      
                                //end line of method
                                break;
                            }
                            if (match) break;
                        }
                        if (match)       //the name of the method matched
                        {
                            String mCallParameters = line.Trim(')').Split('(')[1];    
                            //stores the parameters in array
                            String[] callParameters = mCallParameters.Split(',');
                            if (this.methodParameters.Count == 0)
                            {
                                if (callParameters.Length == 1 && callParameters[0].Equals(""))
                                { } //do nothing 
                                else
                                {
                                    this.errorList.Append("Error!! Number of parameters mismatched in method call and definition!! " + lineNo);
                                    return;
                                }
                            }
                            else if (this.methodParameters.Count == callParameters.Length)
                            {
                                //put the values from called parameters to method parameters
                                String[] tempParams = new string[this.methodParameters.Count];
                                int count = 0;
                                foreach (String key in this.methodParameters.Keys)
                                {
                                    tempParams[count] = key;
                                    count++;
                                }
                                int noOfParameters = this.methodParameters.Count;
                                for (int i = 0; i < noOfParameters; i++)
                                    this.methodParameters[tempParams[i]] = callParameters[i].Trim();
                            }
                            else
                            {
                                this.errorList.Append("Parameter number mismatch in method call");
                                return;
                            }
                            // run the method statements
                            if (this.methodParameters.Count > 0)
                            {
                                String methodLine = "";
                                for (int i = startLine; i <= endLine; i++)
                                {
                                    methodLine = rtb.Lines[i - 1];
                                    methodLine = swapVarValuesInExpression(methodLine, this.methodParameters);
                                    preParser(i, methodLine);
                                }
                            }
                            else
                            {
                                String methodLine = "";
                                for (int i = startLine; i <= endLine; i++)
                                {
                                    methodLine = rtb.Lines[i - 1];
                                    preParser(i, methodLine);
                                }
                            }
                        }
                        else
                        {
                            this.errorList.Append("\r\n Invalid command !! " + lineNo);
                        }
                    }
                    else
                    {
                        this.errorList.Append("\r\n Invalid command !! " + lineNo);
                        return;
                    }
                    break;
            }
        }

        public bool checkVariableName(String key)
        {
            if (variables.ContainsKey(key.Trim()))
                return true;
            return false;
        }

        //check if line is empty
        public bool checkEmptyLine(String line)
        {
            if (line.Equals(""))       
                //empty line
                return true;
            else
                return false;
        }

        //check if command is invalid
        public bool checkValidCommand(String line)
        {
            line = line.Trim().ToLower();              
            //remove trail spaces and convert to lower
            String[] words = line.Split(' ');          
            //splits the line by spaces between

            //check invalid command
            if (words.Length > 0 && !(words[0].Equals("square") || words[0].Equals("circle") || words[0].Equals("rect") || words[0].Equals("triangle")
                 || words[0].Equals("clear") || words[0].Equals("fill") || words[0].Equals("color") || words[0].Equals("moveto") || words[0].Equals("drawto") || words[0].Equals("reset")
                 || words[0].Equals("run")
                 || words[0].Equals("if") || words[0].Equals("endif") || words[0].Equals("loop") || words[0].Equals("endloop")
                 || words[0].Equals("method") || words[0].Equals("endmethod")))
            {
                return false;
            }
            return true;
        }



        //parses the line and calls the appropriate method if valid or records error 
        public void parseLine(StringBuilder errorList, Canvas displayCanvas, String line,  int numLine)
        {

            line = swapVarValuesInExpression(line,this.variables);  
            if (line.Equals(""))        //empty line
                return;
            line = line.Trim().ToLower();              
            //remove trail spaces and convert to lower
            String[] words = line.Split(' ');         
            //splits the line by spaces between

          

            if (words.Length > 2)
            {
                errorList.Append("ERROR!! Invalid Syntax at line: "+numLine+"\r\n");
                return;
            }
                
            else if(words.Length == 2)
            {
                //commands that takes string parameters
                String[] param = words[1].Split(',');
                if(words[0].Equals("color"))
                {
                    if(!displayCanvas.setColor(param))
                    {
                        errorList.Append("ERROR!! Invalid Color provided at line: " + numLine + "\r\n");
                        return;
                    }
                    return;
                }
                if (words[0].Equals("fill"))
                {
                    if(!displayCanvas.setFill(param))
                    {
                        errorList.Append("ERROR!! Invalid fill option at line: " + numLine + "\r\n");
                        return;
                    }
                    return;
                }


               
                int[] intParam = new int[param.Length + 2];         
                //2 additional length for defining cursor position
                intParam[0] = displayCanvas.x;
                intParam[1] = displayCanvas.y;
                //check number of parameters for all shapes
                if (((words[0].Equals("square") || words[0].Equals("circle")) && intParam.Length != 3)
                || ((words[0].Equals("rect") || words[0].Equals("drawto") || words[0].Equals("moveto")) && intParam.Length != 4)
                || (words[0].Equals("triangle") && intParam.Length != 5))
                { 
                    errorList.Append("Invalid parameter numbers at line: " + numLine + "\r\n");
                    return;
                }

                for (int i = 2; i < intParam.Length; i++)
                {
                    //for parameters that takes integer parameters
                    try
                    {
                        intParam[i] = int.Parse(param[i-2]);       
                        //convert string param to int
                    }
                    catch (Exception)
                    {
                        errorList.Append("Invalid parameter format at line: " + numLine + "\r\n");
                        return;
                    }
                }
               
                if (words[0].Equals("drawto"))
                {
                    if (!displayCanvas.drawTo(intParam))
                    {
                        errorList.Append("Invalid parameter numbers at line: " + numLine + "\r\n");
                        return;
                    }
                    else
                        return;
                }
               if (words[0].Equals("moveto"))
                {
                    if (!displayCanvas.moveTo(intParam))
                    {
                        errorList.Append("Invalid parameter numbers at line: " + numLine + "\r\n");
                        return;
                    }
                    else
                        return;
                }

                if (words[0].Equals("square") || words[0].Equals("circle") ||  words[0].Equals("rect") || words[0].Equals("triangle"))
                {

                    ShapeFactory factory = new ShapeFactory();
                    Shape s = (Shape)factory.createShape(words[0]);
                    s.set(displayCanvas.color, displayCanvas.fill, intParam);
                    s.draw(displayCanvas.g);
                    return;
                }
            }
            else
            {
                if (words[0].Equals("clear"))
                {
                    displayCanvas.clear();
                    return;
                }
                if (words[0].Equals("reset"))
                {
                    displayCanvas.reset();
                    return;
                }
            }
            return;
        }
    }
}
