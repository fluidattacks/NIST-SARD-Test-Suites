/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__Integer_45.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-45.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 45 Data flow: data passed as a private class member variable from one function to another in the same class
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__Integer_45 : AbstractTestCase
{

    private int? dataBad;
    private int? dataGoodG2B;
    private int? dataGoodB2G;
#if (!OMITBAD)
    private void BadSink()
    {
        int? data = dataBad;
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.ToString());
    }

    public override void Bad()
    {
        int? data;
        /* POTENTIAL FLAW: data is null */
        data = null;
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
        int? data = dataGoodG2B;
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.ToString());
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        int? data;
        /* FIX: hardcode data to non-null */
        data = Int32.Parse("5");
        dataGoodG2B = data;
        GoodG2BSink();
    }

    private void GoodB2GSink()
    {
        int? data = dataGoodB2G;
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

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        int? data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        dataGoodB2G = data;
        GoodB2GSink();
    }
#endif //omitgood
}
}
