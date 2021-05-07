/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__Integer_31.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-31.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__Integer_31 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int? dataCopy;
        {
            int? data;
            /* POTENTIAL FLAW: data is null */
            data = null;
            dataCopy = data;
        }
        {
            int? data = dataCopy;
            /* POTENTIAL FLAW: null dereference will occur if data is null */
            IO.WriteLine("" + data.ToString());
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
        int? dataCopy;
        {
            int? data;
            /* FIX: hardcode data to non-null */
            data = Int32.Parse("5");
            dataCopy = data;
        }
        {
            int? data = dataCopy;
            /* POTENTIAL FLAW: null dereference will occur if data is null */
            IO.WriteLine("" + data.ToString());
        }
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        int? dataCopy;
        {
            int? data;
            /* POTENTIAL FLAW: data is null */
            data = null;
            dataCopy = data;
        }
        {
            int? data = dataCopy;
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
    }
#endif //omitgood
}
}
