/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE259_Hard_Coded_Password__NetworkCredential_68a.cs
Label Definition File: CWE259_Hard_Coded_Password.label.xml
Template File: sources-sink-68a.tmpl.cs
*/
/*
 * @description
 * CWE: 259 Hard Coded Password
 * BadSource: hardcodedPassword Set data to a hardcoded string
 * GoodSource: Read data from the console using readLine()
 * BadSink: NetworkCredential data used as password in NetworkCredential()
 * Flow Variant: 68 Data flow: data passed as a member variable in the "a" class, which is used by a method in another class in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.IO;

namespace testcases.CWE259_Hard_Coded_Password
{

class CWE259_Hard_Coded_Password__NetworkCredential_68a : AbstractTestCase
{

    public static string data;
#if (!OMITBAD)
    public override void Bad()
    {
        /* FLAW: Set data to a hardcoded string */
        data = "7e5tc4s3";
        CWE259_Hard_Coded_Password__NetworkCredential_68b.BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        data = ""; /* init data */
        /* FIX: Read data from the console using ReadLine() */
        try
        {
            /* POTENTIAL FLAW: Read data from the console using ReadLine */
            data = Console.ReadLine();
        }
        catch (IOException exceptIO)
        {
            IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
        }
        CWE259_Hard_Coded_Password__NetworkCredential_68b.GoodG2BSink();
    }
#endif //omitgood
}
}
