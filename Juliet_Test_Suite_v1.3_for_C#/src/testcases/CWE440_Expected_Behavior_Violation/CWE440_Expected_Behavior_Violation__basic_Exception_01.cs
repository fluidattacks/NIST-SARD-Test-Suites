/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE440_Expected_Behavior_Violation__basic_Exception_01.cs
Label Definition File: CWE440_Expected_Behavior_Violation__basic.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 440 Expected Behavior Violation
* Sinks: Exception
*    GoodSink: Ensure user input is an integer
*    BadSink : Don't ensure that the user input is an integer, thus possibly causing unexepected behavior
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE440_Expected_Behavior_Violation
{
class CWE440_Expected_Behavior_Violation__basic_Exception_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        IO.WriteLine("Please enter an integer:");
        string userInput = Console.ReadLine();
        /* FLAW: Don't ensure that the user input is an integer, thus possibly causing unexepected behavior */
        string x = string.Format("{0:0000}", userInput);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
    {
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
    }
#endif //omitgood
}
}
