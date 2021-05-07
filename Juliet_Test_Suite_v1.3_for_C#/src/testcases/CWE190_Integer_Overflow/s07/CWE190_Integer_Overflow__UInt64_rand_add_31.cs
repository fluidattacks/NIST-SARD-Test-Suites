/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt64_rand_add_31.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-31.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: rand Set data to result of rand()
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
class CWE190_Integer_Overflow__UInt64_rand_add_31 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        ulong dataCopy;
        {
            ulong data;
            /* POTENTIAL FLAW: Use a random value */
            data = IO.GetRandomULong();
            dataCopy = data;
        }
        {
            ulong data = dataCopy;
            /* POTENTIAL FLAW: if data == ulong.MaxValue, this will overflow */
            ulong result = (ulong)(data + 1);
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
        ulong dataCopy;
        {
            ulong data;
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
            dataCopy = data;
        }
        {
            ulong data = dataCopy;
            /* POTENTIAL FLAW: if data == ulong.MaxValue, this will overflow */
            ulong result = (ulong)(data + 1);
            IO.WriteLine("result: " + result);
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        ulong dataCopy;
        {
            ulong data;
            /* POTENTIAL FLAW: Use a random value */
            data = IO.GetRandomULong();
            dataCopy = data;
        }
        {
            ulong data = dataCopy;
            /* FIX: Add a check to prevent an overflow from occurring */
            if (data < ulong.MaxValue)
            {
                ulong result = (ulong)(data + 1);
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
