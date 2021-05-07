/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__Integer_42.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-42.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 42 Data flow: data returned from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__Integer_42 : AbstractTestCase
{
#if (!OMITBAD)
    private static int? BadSource()
    {
        int? data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        return data;
    }

    public override void Bad()
    {
        int? data = BadSource();
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.ToString());
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    private static int? GoodG2BSource()
    {
        int? data;
        /* FIX: hardcode data to non-null */
        data = Int32.Parse("5");
        return data;
    }

    private static void GoodG2B()
    {
        int? data = GoodG2BSource();
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.ToString());
    }

    /* goodB2G() - use badsource and goodsink */
    private static int? GoodB2GSource()
    {
        int? data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        return data;
    }

    private static void GoodB2G()
    {
        int? data = GoodB2GSource();
        /* FIX: validate that data is non-null */
        if (data != null)
        {
            IO.WriteLine("" + data.ToString());
        }
        else
        {
            IO.WriteLine("data is null");
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
