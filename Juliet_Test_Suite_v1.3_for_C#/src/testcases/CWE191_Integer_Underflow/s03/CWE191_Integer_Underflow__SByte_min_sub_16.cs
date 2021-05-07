/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__SByte_min_sub_16.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-16.tmpl.cs
*/
/*
* @description
* CWE: 191 Integer Underflow
* BadSource: min Set data to the min value for sbyte
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* Sinks: sub
*    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
*    BadSink : Subtract 1 from data, which can cause an Underflow
* Flow Variant: 16 Control flow: while(true)
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__SByte_min_sub_16 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        sbyte data;
        while (true)
        {
            /* POTENTIAL FLAW: Use the minimum size of the data type */
            data = sbyte.MinValue;
            break;
        }
        while (true)
        {
            /* POTENTIAL FLAW: if data == sbyte.MinValue, this will overflow */
            sbyte result = (sbyte)(data - 1);
            IO.WriteLine("result: " + result);
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        sbyte data;
        while (true)
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
            break;
        }
        while (true)
        {
            /* POTENTIAL FLAW: if data == sbyte.MinValue, this will overflow */
            sbyte result = (sbyte)(data - 1);
            IO.WriteLine("result: " + result);
            break;
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        sbyte data;
        while (true)
        {
            /* POTENTIAL FLAW: Use the minimum size of the data type */
            data = sbyte.MinValue;
            break;
        }
        while (true)
        {
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
            break;
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
