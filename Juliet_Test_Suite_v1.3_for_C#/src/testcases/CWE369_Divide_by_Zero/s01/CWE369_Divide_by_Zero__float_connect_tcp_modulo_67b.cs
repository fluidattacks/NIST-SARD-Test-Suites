/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_connect_tcp_modulo_67b.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: connect_tcp Read data using an outbound tcp connection
 * GoodSource: A hardcoded non-zero number (two)
 * Sinks: modulo
 *    GoodSink: Check for zero before modulo
 *    BadSink : Modulo by a value that may be zero
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_connect_tcp_modulo_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE369_Divide_by_Zero__float_connect_tcp_modulo_67a.Container dataContainer )
    {
        float data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Possibly modulo by zero */
        int result = (int)(100.0 % data);
        IO.WriteLine(result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE369_Divide_by_Zero__float_connect_tcp_modulo_67a.Container dataContainer )
    {
        float data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Possibly modulo by zero */
        int result = (int)(100.0 % data);
        IO.WriteLine(result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE369_Divide_by_Zero__float_connect_tcp_modulo_67a.Container dataContainer )
    {
        float data = dataContainer.containerOne;
        /* FIX: Check for value of or near zero before modulo */
        if (Math.Abs(data) > 0.000001)
        {
            int result = (int)(100.0 % data);
            IO.WriteLine(result);
        }
        else
        {
            IO.WriteLine("This would result in a modulo by zero");
        }
    }
#endif
}
}
