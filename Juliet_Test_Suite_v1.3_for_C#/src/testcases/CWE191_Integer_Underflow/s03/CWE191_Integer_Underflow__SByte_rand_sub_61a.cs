/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__SByte_rand_sub_61a.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-61a.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: rand Set data to result of rand()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 61 Data flow: data returned from one method to another in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__SByte_rand_sub_61a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        sbyte data = CWE191_Integer_Underflow__SByte_rand_sub_61b.BadSource();
        /* POTENTIAL FLAW: if data == sbyte.MinValue, this will overflow */
        sbyte result = (sbyte)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        sbyte data = CWE191_Integer_Underflow__SByte_rand_sub_61b.GoodG2BSource();
        /* POTENTIAL FLAW: if data == sbyte.MinValue, this will overflow */
        sbyte result = (sbyte)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        sbyte data = CWE191_Integer_Underflow__SByte_rand_sub_61b.GoodB2GSource();
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > sbyte.MinValue)
        {
            sbyte result = (sbyte)(data - 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too small to perform subtraction.");
        }
    }
#endif //omitgood
}
}
