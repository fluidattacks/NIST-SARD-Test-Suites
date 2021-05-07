/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE191_Integer_Underflow__Byte_rand_sub_73b.cs
Label Definition File: CWE191_Integer_Underflow.label.xml
Template File: sources-sinks-73b.tmpl.cs
*/
/*
 * @description
 * CWE: 191 Integer Underflow
 * BadSource: rand Set data to result of rand()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: sub
 *    GoodSink: Ensure there will not be an underflow before subtracting 1 from data
 *    BadSink : Subtract 1 from data, which can cause an Underflow
 * Flow Variant: 73 Data flow: data passed in a LinkedList from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;
using System.Collections.Generic;

using System.Web;

namespace testcases.CWE191_Integer_Underflow
{
class CWE191_Integer_Underflow__Byte_rand_sub_73b
{
#if (!OMITBAD)
    public static void BadSink(LinkedList<byte> dataLinkedList )
    {
        byte data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: if data == byte.MinValue, this will overflow */
        byte result = (byte)(data - 1);
        IO.WriteLine("result: " + result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(LinkedList<byte> dataLinkedList )
    {
        byte data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: if data == byte.MinValue, this will overflow */
        byte result = (byte)(data - 1);
        IO.WriteLine("result: " + result);
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(LinkedList<byte> dataLinkedList )
    {
        byte data = dataLinkedList.Last.Value;
        /* FIX: Add a check to prevent an overflow from occurring */
        if (data > byte.MinValue)
        {
            byte result = (byte)(data - 1);
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
