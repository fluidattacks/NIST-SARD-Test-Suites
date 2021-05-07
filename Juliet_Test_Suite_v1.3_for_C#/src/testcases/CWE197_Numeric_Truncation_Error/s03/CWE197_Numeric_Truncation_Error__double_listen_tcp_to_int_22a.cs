/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__double_listen_tcp_to_int_22a.cs
Label Definition File: CWE197_Numeric_Truncation_Error__double.label.xml
Template File: sources-sink-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 197 Numeric Truncation Error
 * BadSource: listen_tcp Read data using a listening tcp connection
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: to_int
 *    BadSink : Convert data to a int
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE197_Numeric_Truncation_Error
{
class CWE197_Numeric_Truncation_Error__double_listen_tcp_to_int_22a : AbstractTestCase
{

    /* The public static variable below is used to drive control flow in the source function.
     * The public static variable mimics a global variable in the C/C++ language family. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad()
    {
        double data;
        badPublicStatic = true;
        data = CWE197_Numeric_Truncation_Error__double_listen_tcp_to_int_22b.BadSource();
        {
            /* POTENTIAL FLAW: Convert data to a int, possibly causing a truncation error */
            IO.WriteLine((int)data);
        }
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the source functions.
     * The public static variable mimics a global variable in the C/C++ language family. */
    public static bool goodG2B1PublicStatic = false;
    public static bool GoodG2B2PublicStatic = false;
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B1();
        GoodG2B2();
    }

    /* goodG2B1() - use goodsource and badsink by setting the static variable to false instead of true */
    private void GoodG2B1()
    {
        double data;
        goodG2B1PublicStatic = false;
        data = CWE197_Numeric_Truncation_Error__double_listen_tcp_to_int_22b.GoodG2B1Source();
        {
            /* POTENTIAL FLAW: Convert data to a int, possibly causing a truncation error */
            IO.WriteLine((int)data);
        }
    }

    /* GoodG2B2() - use goodsource and badsink by reversing the blocks in the if in the sink function */
    private void GoodG2B2()
    {
        double data;
        GoodG2B2PublicStatic = true;
        data = CWE197_Numeric_Truncation_Error__double_listen_tcp_to_int_22b.GoodG2B2Source();
        {
            /* POTENTIAL FLAW: Convert data to a int, possibly causing a truncation error */
            IO.WriteLine((int)data);
        }
    }
#endif //omitgood
}
}
