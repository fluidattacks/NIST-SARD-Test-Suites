/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE606_Unchecked_Loop_Condition__Environment_42.cs
Label Definition File: CWE606_Unchecked_Loop_Condition.label.xml
Template File: sources-sinks-42.tmpl.cs
*/
/*
 * @description
 * CWE: 606 Unchecked Input for Loop Condition
 * BadSource: Environment Read data from an environment variable
 * GoodSource: hardcoded int in string form
 * Sinks:
 *    GoodSink: validate loop variable
 *    BadSink : loop variable not validated
 * Flow Variant: 42 Data flow: data returned from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE606_Unchecked_Loop_Condition
{
class CWE606_Unchecked_Loop_Condition__Environment_42 : AbstractTestCase
{
#if (!OMITBAD)
    private static string BadSource()
    {
        string data;
        /* get environment variable ADD */
        /* POTENTIAL FLAW: Read data from an environment variable */
        data = Environment.GetEnvironmentVariable("ADD");
        return data;
    }

    public override void Bad()
    {
        string data = BadSource();
        int numberOfLoops;
        try
        {
            numberOfLoops = int.Parse(data);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.WriteLine("Invalid response. Numeric input expected. Assuming 1.");
            IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Invalid response. Numeric input expected. Assuming 1.");
            numberOfLoops = 1;
        }
        for (int i = 0; i < numberOfLoops; i++)
        {
            /* POTENTIAL FLAW: user supplied input used for loop counter test */
            IO.WriteLine("hello world");
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private static string GoodG2BSource()
    {
        string data;
        /* FIX: Use a hardcoded int as a string */
        data = "5";
        return data;
    }

    private static void GoodG2B()
    {
        string data = GoodG2BSource();
        int numberOfLoops;
        try
        {
            numberOfLoops = int.Parse(data);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.WriteLine("Invalid response. Numeric input expected. Assuming 1.");
            IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Invalid response. Numeric input expected. Assuming 1.");
            numberOfLoops = 1;
        }
        for (int i = 0; i < numberOfLoops; i++)
        {
            /* POTENTIAL FLAW: user supplied input used for loop counter test */
            IO.WriteLine("hello world");
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private static string GoodB2GSource()
    {
        string data;
        /* get environment variable ADD */
        /* POTENTIAL FLAW: Read data from an environment variable */
        data = Environment.GetEnvironmentVariable("ADD");
        return data;
    }

    private static void GoodB2G()
    {
        string data = GoodB2GSource();
        int numberOfLoops;
        try
        {
            numberOfLoops = int.Parse(data);
        }
        catch (FormatException exceptNumberFormat)
        {
            IO.WriteLine("Invalid response. Numeric input expected. Assuming 1.");
            IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Invalid response. Numeric input expected. Assuming 1.");
            numberOfLoops = 1;
        }
        /* FIX: loop number thresholds validated */
        if (numberOfLoops >= 0 && numberOfLoops <= 5)
        {
            for (int i = 0; i < numberOfLoops; i++)
            {
                IO.WriteLine("hello world");
            }
        }
    }

    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }
#endif //omitgood
}
}
