/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__int_Connect_tcp_modulo_67b.cs
Label Definition File: CWE369_Divide_by_Zero__int.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: Connect_tcp Read data using an outbound tcp connection
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
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
class CWE369_Divide_by_Zero__int_Connect_tcp_modulo_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE369_Divide_by_Zero__int_Connect_tcp_modulo_67a.Container dataContainer )
    {
        int data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Zero modulus will cause an issue.  An integer division will
        result in an exception.  */
        IO.WriteLine("100%" + data + " = " + (100 % data) + "\n");
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE369_Divide_by_Zero__int_Connect_tcp_modulo_67a.Container dataContainer )
    {
        int data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Zero modulus will cause an issue.  An integer division will
        result in an exception.  */
        IO.WriteLine("100%" + data + " = " + (100 % data) + "\n");
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE369_Divide_by_Zero__int_Connect_tcp_modulo_67a.Container dataContainer )
    {
        int data = dataContainer.containerOne;
        /* FIX: test for a zero modulus */
        if (data != 0)
        {
            IO.WriteLine("100%" + data + " = " + (100 % data) + "\n");
        }
        else
        {
            IO.WriteLine("This would result in a modulo by zero");
        }
    }
#endif
}
}
