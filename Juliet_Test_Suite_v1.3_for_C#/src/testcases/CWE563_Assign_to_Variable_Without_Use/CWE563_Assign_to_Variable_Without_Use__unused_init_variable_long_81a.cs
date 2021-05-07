/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE563_Assign_to_Variable_Without_Use__unused_init_variable_long_81a.cs
Label Definition File: CWE563_Assign_to_Variable_Without_Use__unused_init_variable.label.xml
Template File: source-sinks-81a.tmpl.cs
*/
/*
 * @description
 * CWE: 563 Assignment to Variable without Use
 * BadSource:  Initialize data
 * Sinks:
 *    GoodSink: Use data
 *    BadSink : do nothing
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE563_Assign_to_Variable_Without_Use
{
class CWE563_Assign_to_Variable_Without_Use__unused_init_variable_long_81a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        long data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = 5L;
        CWE563_Assign_to_Variable_Without_Use__unused_init_variable_long_81_base baseObject = new CWE563_Assign_to_Variable_Without_Use__unused_init_variable_long_81_bad();
        baseObject.Action(data );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodB2G();
    }

    /* goodB2G() - use BadSource and GoodSink */
    private void GoodB2G()
    {
        long data;
        /* POTENTIAL FLAW: Initialize, but do not use data */
        data = 5L;
        CWE563_Assign_to_Variable_Without_Use__unused_init_variable_long_81_base baseObject = new CWE563_Assign_to_Variable_Without_Use__unused_init_variable_long_81_goodB2G();
        baseObject.Action(data );
    }
#endif //omitgood
}
}
