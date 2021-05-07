/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__int_array_61b.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-61b.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 61 Data flow: data returned from one method to another in different classes in the same package
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__int_array_61b
{
#if (!OMITBAD)
    public static int[] BadSource()
    {
        int[] data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        return data;
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static int[] GoodG2BSource()
    {
        int[] data;
        /* FIX: hardcode data to non-null */
        data = new int[5];
        return data;
    }

    /* goodB2G() - use badsource and goodsink */
    public static int[] GoodB2GSource()
    {
        int[] data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        return data;
    }
#endif
}
}
