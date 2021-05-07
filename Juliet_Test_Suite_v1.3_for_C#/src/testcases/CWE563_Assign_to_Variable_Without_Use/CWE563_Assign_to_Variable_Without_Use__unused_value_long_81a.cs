/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_value_long_81a.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_value.label.xml
Template File: sources-sinks-81a.tmpl.cs
*/
/*
 * @description
 * CWE: 563 Assignment to Variable without Use
 * BadSource:  Initialize data
 * GoodSource: Initialize and use data
 * Sinks:
 *    GoodSink: Use data
 *    BadSink : re-initialize and use data
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_value_long_81a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        long data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = 5L;
        CWE563_Assign_to_Variable_Without_Use__unused_value_long_81_base baseObject = new CWE563_Assign_to_Variable_Without_Use__unused_value_long_81_bad();
        baseObject.Action(data );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use GoodSource and BadSink */
    private void GoodG2B()
    {
        long data;
        /* FIX: Initialize and use data before it is overwritten */
        data = 5L;
        IO.WriteLine("" + data);
        CWE563_Assign_to_Variable_Without_Use__unused_value_long_81_base baseObject = new CWE563_Assign_to_Variable_Without_Use__unused_value_long_81_goodG2B();
        baseObject.Action(data );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private void GoodB2G()
    {
        long data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = 5L;
        CWE563_Assign_to_Variable_Without_Use__unused_value_long_81_base baseObject = new CWE563_Assign_to_Variable_Without_Use__unused_value_long_81_goodB2G();
        baseObject.Action(data );
    }
#endif //omitgood
}
}
