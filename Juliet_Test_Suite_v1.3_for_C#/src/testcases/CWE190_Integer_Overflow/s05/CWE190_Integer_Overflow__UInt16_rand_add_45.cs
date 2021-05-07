/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt16_rand_add_45.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-45.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: rand Set data to result of rand()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: add
 *    GoodSink: Ensure there will not be an overflow before adding 1 to data
 *    BadSink : Add 1 to data, which can cause an overflow
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt16_rand_add_45 : AbstractTestCase
{

    private ushort dataBad;
    private ushort dataGoodG2B;
    private ushort dataGoodB2G;
#if (!OMITBAD)
    private void BadSink()
    {
        ushort data = dataBad;
        /* POTENTIAL FLAW: if data == ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data + 1);
        IO.WriteLine("result: " + result);
    }

    public override void Bad()
    {
        ushort data;
        /* POTENTIAL FLAW: Use a random value */
        data = (ushort)(new Random().Next(ushort.MinValue, ushort.MaxValue));
        dataBad = data;
        BadSink();
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    private void GoodG2BSink()
    {
        ushort data = dataGoodG2B;
        /* POTENTIAL FLAW: if data == ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data + 1);
        IO.WriteLine("result: " + result);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        ushort data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        dataGoodG2B = data;
        GoodG2BSink();
    }

    private void GoodB2GSink()
    {
        ushort data = dataGoodB2G;
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data < ushort.MaxValue)
        {
            ushort result = (ushort)(data + 1);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform addition.");
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        ushort data;
        /* POTENTIAL FLAW: Use a random value */
        data = (ushort)(new Random().Next(ushort.MinValue, ushort.MaxValue));
        dataGoodB2G = data;
        GoodB2GSink();
    }
#endif //omitgood
}
}
