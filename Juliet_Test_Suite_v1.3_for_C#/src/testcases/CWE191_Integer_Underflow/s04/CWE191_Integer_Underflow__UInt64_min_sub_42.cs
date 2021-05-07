/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__UInt64_min_sub_42.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-42.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: min Set data to the min value for ulong
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 42 Data flow: data returned from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__UInt64_min_sub_42 : AbstractTestCase
{
#if (!OMITBAD)
    private static ulong BadSource()
    {
        ulong data;
        /* POTENTIAL FLAW: Use the minimum size of the data type */
        data = ulong.MinValue;
        return data;
    }

    public override void Bad()
    {
        ulong data = BadSource();
        /* POTENTIAL FLAW: if data == ulong.MinValue, this will overflow */
        ulong result = (ulong)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private static ulong GoodG2BSource()
    {
        ulong data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        return data;
    }

    private static void GoodG2B()
    {
        ulong data = GoodG2BSource();
        /* POTENTIAL FLAW: if data == ulong.MinValue, this will overflow */
        ulong result = (ulong)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private static ulong GoodB2GSource()
    {
        ulong data;
        /* POTENTIAL FLAW: Use the minimum size of the data type */
        data = ulong.MinValue;
        return data;
    }

    private static void GoodB2G()
    {
        ulong data = GoodB2GSource();
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > ulong.MinValue)
        {
            ulong result = (ulong)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
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
