/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE440_Expected_Behavior_Violation__basic_Exception_15.cs
Label Definition File: CWE440_Expected_Behavior_Violation__basic.label.xml
Template File: point-flaw-15.tmpl.cs
*/
/*
* @description
* CWE: 440 Expected Behavior Violation
* Sinks: Exception
*    GoodSink: Ensure user input is an integer
*    BadSink : Don't ensure that the user input is an integer, thus possibly causing unexepected behavior
* Flow Variant: 15 Control flow: switch(7)
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE440_Expected_Behavior_Violation
{
class CWE440_Expected_Behavior_Violation__basic_Exception_15 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        switch (7)
        {
        case 7:
            IO.WriteLine("Please enter an integer:");
            string userInput = Console.ReadLine();
            /* FLAW: Don't ensure that the user input is an integer, thus possibly causing unexepected behavior */
            string x = string.Format("{0:0000}", userInput);
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() change the switch to switch(8) */
    private void Good1()
    {
        switch (8)
        {
        case 7:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        default:
            IO.WriteLine("Please enter an integer:");
            string userInput = Console.ReadLine();
            /* FIX: Ensure user input is an integer. */
            try
            {
                int.Parse(userInput);
                string x = string.Format("{0:0000}", userInput);
            }
            catch (FormatException formatException)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with int parsing", formatException);
            }
            break;
        }
    }

    /* Good2() reverses the blocks in the switch  */
    private void Good2()
    {
        switch (7)
        {
        case 7:
            IO.WriteLine("Please enter an integer:");
            string userInput = Console.ReadLine();
            /* FIX: Ensure user input is an integer. */
            try
            {
                int.Parse(userInput);
                string x = string.Format("{0:0000}", userInput);
            }
            catch (FormatException formatException)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with int parsing", formatException);
            }
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
