/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__max_value_for_loop_74a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-74a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: max_value Set count to a hardcoded value of Integer.MaxValue
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: for_loop
 *    GoodSink: Validate count before using it as the loop variant in a for loop
 *    BadSink : Use count as the loop variant in a for loop
 * Flow Variant: 74 Data flow: data passed in a Dictionary from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections.Generic;
using System;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__max_value_for_loop_74a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int count;
        /* POTENTIAL FLAW: Set count to int.MaxValue */
        count = int.MaxValue;
        Dictionary<int,int> countDictionary = new Dictionary<int,int>();
        countDictionary.Add(0, count);
        countDictionary.Add(1, count);
        countDictionary.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__max_value_for_loop_74b.BadSink(countDictionary  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use GoodSource and BadSink */
    private static void GoodG2B()
    {
        int count;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        Dictionary<int,int> countDictionary = new Dictionary<int,int>();
        countDictionary.Add(0, count);
        countDictionary.Add(1, count);
        countDictionary.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__max_value_for_loop_74b.GoodG2BSink(countDictionary  );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private static void GoodB2G()
    {
        int count;
        /* POTENTIAL FLAW: Set count to int.MaxValue */
        count = int.MaxValue;
        Dictionary<int,int> countDictionary = new Dictionary<int,int>();
        countDictionary.Add(0, count);
        countDictionary.Add(1, count);
        countDictionary.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__max_value_for_loop_74b.GoodB2GSink(countDictionary  );
    }
#endif //omitgood
}
}
