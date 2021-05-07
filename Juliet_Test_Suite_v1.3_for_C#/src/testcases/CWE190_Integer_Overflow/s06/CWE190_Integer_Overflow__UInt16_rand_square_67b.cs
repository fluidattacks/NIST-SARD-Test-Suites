/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__UInt16_rand_square_67b.cs
Label Definition File: CWE190_Integer_Overflow.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: rand Set data to result of rand()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: square
 *    GoodSink: Ensure there will not be an overflow before squaring data
 *    BadSink : Square data, which can lead to overflow
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__UInt16_rand_square_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE190_Integer_Overflow__UInt16_rand_square_67a.Container dataContainer )
    {
        ushort data = dataContainer.containerOne;
        /* POTENTIAL FLAW: if (data*data) > ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data * data);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE190_Integer_Overflow__UInt16_rand_square_67a.Container dataContainer )
    {
        ushort data = dataContainer.containerOne;
        /* POTENTIAL FLAW: if (data*data) > ushort.MaxValue, this will overflow */
        ushort result = (ushort)(data * data);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE190_Integer_Overflow__UInt16_rand_square_67a.Container dataContainer )
    {
        ushort data = dataContainer.containerOne;
        /* FIX: Add a check to prevent an overflow from occurring */
        if (Math.Abs((long)data) <= (long)Math.Sqrt(ushort.MaxValue))
        {
            ushort result = (ushort)(data * data);
            IO.WriteLine("result: " + result);
        }
        else
        {
            IO.WriteLine("data value is too large to perform squaring.");
        }
    }
#endif
}
}
