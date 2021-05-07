/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_value_int_01.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_value.label.xml
Template File: sources-sinks-01.tmpl.cs
*/
/*
* @description
* CWE: 563 Assignment to Variable without Use
* BadSource:  Initialize data
* GoodSource: Initialize and use data
* Sinks:
*    GoodSink: Use data
*    BadSink : re-initialize and use data
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_value_int_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = 5;
        /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
        data = 10;
        IO.WriteLine("" + data);
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
        int data;
        /* FIX: Initialize and use data before it is overwritten */
        data = 5;
        IO.WriteLine("" + data);
        /* POTENTIAL FLAW: Possibly over-write the initial value of data before using it */
        data = 10;
        IO.WriteLine("" + data);
    }

    /* goodB2G() - use badsource and goodsink */
    private void GoodB2G()
    {
        int data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = 5;
        /* FIX: Use data without over-writing its value */
        IO.WriteLine("" + data);
    }
#endif //omitgood
}
}
