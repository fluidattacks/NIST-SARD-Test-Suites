/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__Long_console_ReadLine_sub_68b.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-68b.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: console_ReadLine Read data from the console using ReadLine
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 68 Data flow: data passed as a member variable in the "a" class, which is used by a method in another class in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__Long_console_ReadLine_sub_68b
{
#if (!OMITBAD)
    public static void BadSink()
    {
        long data = CWE191_Integer_Underflow__Long_console_ReadLine_sub_68a.data;
        /* POTENTIAL FLAW: if data == long.MinValue, this will overflow */
        long result = (long)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink()
    {
        long data = CWE191_Integer_Underflow__Long_console_ReadLine_sub_68a.data;
        /* POTENTIAL FLAW: if data == long.MinValue, this will overflow */
        long result = (long)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink()
    {
        long data = CWE191_Integer_Underflow__Long_console_ReadLine_sub_68a.data;
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > long.MinValue)
        {
            long result = (long)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
        }
    }
#endif
}
}
