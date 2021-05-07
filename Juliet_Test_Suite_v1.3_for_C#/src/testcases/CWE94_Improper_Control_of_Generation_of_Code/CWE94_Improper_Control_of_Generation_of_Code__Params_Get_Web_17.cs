/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE94_Improper_Control_of_Generation_of_Code__Params_Get_Web_17.cs
Label Definition File: CWE94_Improper_Control_of_Generation_of_Code.label.xml
Template File: sources-sinks-17.tmpl.cs
*/
/*
* @description
* CWE: 94 Improper Control of Generation of Code
* BadSource: Params_Get_Web Read data from a querystring using Params.Get()
* GoodSource: Set data to an integer represented as a string
* Sinks:
*    GoodSink: Validate user input prior to compiling
*    BadSink : Compile sourceCode containing unvalidated user input
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System.Web;


namespace testcases.CWE94_Improper_Control_of_Generation_of_Code
{
class CWE94_Improper_Control_of_Generation_of_Code__Params_Get_Web_17 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* We need to have one source outside of a for loop in order
         * to prevent the compiler from generating an error because
         * data is uninitialized
         */
        /* POTENTIAL FLAW: Read data from a querystring using Params.Get */
        data = req.Params.Get("name");
        for (int j = 0; j < 1; j++)
        {
            StringBuilder sourceCode = new StringBuilder("");
            sourceCode.Append("public class Calculator \n{\n");
            sourceCode.Append("\tpublic int Sum()\n\t{\n");
            sourceCode.Append("\t\treturn (10 + " + data.ToString() + ");\n");
            sourceCode.Append("\t}\n");
            sourceCode.Append("}\n");
            /* POTENTIAL FLAW: Compile sourceCode containing unvalidated user input */
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode.ToString());
            Assembly a = cr.CompiledAssembly;
            object calculator = a.CreateInstance("Calculator");
            Type calculatorType = calculator.GetType();
            MethodInfo mi = calculatorType.GetMethod("Sum");
            int s = (int)mi.Invoke(calculator, new object[] {});
            IO.WriteLine("Result: " + s.ToString());
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Set data to an integer represented as a string */
        data = "10";
        for (int j = 0; j < 1; j++)
        {
            StringBuilder sourceCode = new StringBuilder("");
            sourceCode.Append("public class Calculator \n{\n");
            sourceCode.Append("\tpublic int Sum()\n\t{\n");
            sourceCode.Append("\t\treturn (10 + " + data.ToString() + ");\n");
            sourceCode.Append("\t}\n");
            sourceCode.Append("}\n");
            /* POTENTIAL FLAW: Compile sourceCode containing unvalidated user input */
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode.ToString());
            Assembly a = cr.CompiledAssembly;
            object calculator = a.CreateInstance("Calculator");
            Type calculatorType = calculator.GetType();
            MethodInfo mi = calculatorType.GetMethod("Sum");
            int s = (int)mi.Invoke(calculator, new object[] {});
            IO.WriteLine("Result: " + s.ToString());
        }
    }

    /* goodB2G() - use badsource and goodsink*/
    private void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* POTENTIAL FLAW: Read data from a querystring using Params.Get */
        data = req.Params.Get("name");
        for (int k = 0; k < 1; k++)
        {
            int? parsedNum = null;
            /* FIX: Validate user input prior to compiling */
            try
            {
                parsedNum = int.Parse(data);
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing number.");
            }
            if (parsedNum != null)
            {
                StringBuilder sourceCode = new StringBuilder("");
                sourceCode.Append("public class Calculator \n{\n");
                sourceCode.Append("\tpublic int Sum()\n\t{\n");
                sourceCode.Append("\t\treturn (10 + " + data.ToString() + ");\n");
                sourceCode.Append("\t}\n");
                sourceCode.Append("}\n");
                CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters cp = new CompilerParameters();
                CompilerResults cr = provider.CompileAssemblyFromSource(cp, sourceCode.ToString());
                Assembly a = cr.CompiledAssembly;
                object calculator = a.CreateInstance("Calculator");
                Type calculatorType = calculator.GetType();
                MethodInfo mi = calculatorType.GetMethod("Sum");
                int s = (int)mi.Invoke(calculator, new object[] {});
                IO.WriteLine("Result: " + s.ToString());
            }
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }
#endif //omitgood
}
}
