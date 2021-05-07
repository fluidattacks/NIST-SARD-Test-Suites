/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__max_value_write_81a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-81a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: max_value Set count to a hardcoded value of Integer.MaxValue
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: write
 *    GoodSink: Write to a file count number of times, but first validate count
 *    BadSink : Write to a file count number of times
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__max_value_write_81a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int count;
        /* POTENTIAL FLAW: Set count to int.MaxValue */
        count = int.MaxValue;
        CWE400_Uncontrolled_Resource_Consumption__max_value_write_81_base baseObject = new CWE400_Uncontrolled_Resource_Consumption__max_value_write_81_bad();
        baseObject.Action(count );
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
        int count;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        CWE400_Uncontrolled_Resource_Consumption__max_value_write_81_base baseObject = new CWE400_Uncontrolled_Resource_Consumption__max_value_write_81_goodG2B();
        baseObject.Action(count );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private void GoodB2G()
    {
        int count;
        /* POTENTIAL FLAW: Set count to int.MaxValue */
        count = int.MaxValue;
        CWE400_Uncontrolled_Resource_Consumption__max_value_write_81_base baseObject = new CWE400_Uncontrolled_Resource_Consumption__max_value_write_81_goodB2G();
        baseObject.Action(count );
    }
#endif //omitgood
}
}
