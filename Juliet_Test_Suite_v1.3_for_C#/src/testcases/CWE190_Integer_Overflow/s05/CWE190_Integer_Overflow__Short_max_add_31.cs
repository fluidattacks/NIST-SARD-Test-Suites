/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__Short_max_add_31.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-31.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: max Set data to the max value for short
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: add
 *    GoodSink: Ensure there will not be an overflow before adding 1 to data
 *    BadSink : Add 1 to data, which can cause an overflow
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__Short_max_add_31 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        short dataCopy;
        {
            short data;
            /* POTENTIAL FLAW: Use the maximum size of the data type */
            data = short.MaxValue;
            dataCopy = data;
        }
        {
            short data = dataCopy;
            /* POTENTIAL FLAW: if data == short.MaxValue, this will overflow */
            short result = (short)(data + 1);
            IO.WriteLine("result: " + result);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        short dataCopy;
        {
            short data;
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
            dataCopy = data;
        }
        {
            short data = dataCopy;
            /* POTENTIAL FLAW: if data == short.MaxValue, this will overflow */
            short result = (short)(data + 1);
            IO.WriteLine("result: " + result);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        short dataCopy;
        {
            short data;
            /* POTENTIAL FLAW: Use the maximum size of the data type */
            data = short.MaxValue;
            dataCopy = data;
        }
        {
            short data = dataCopy;
            /* FIX: Add a check to prevent an overflow from occurring */
            if (data < short.MaxValue)
            {
                short result = (short)(data + 1);
                IO.WriteLine("result: " + result);
            }
            else
            {
                IO.WriteLine("data value is too large to perform addition.");
            }
        }
    }
#endif //omitgood
}
}
