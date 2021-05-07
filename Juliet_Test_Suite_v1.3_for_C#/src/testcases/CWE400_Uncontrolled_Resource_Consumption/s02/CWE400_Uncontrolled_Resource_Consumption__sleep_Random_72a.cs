/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__sleep_Random_72a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption__sleep.label.xml
Template File: sources-sinks-72a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Random Set count to a random value
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks:
 *    GoodSink: Validate count before using it as a parameter in sleep function
 *    BadSink : Use count as the parameter for sleep withhout checking it's size first
 * Flow Variant: 72 Data flow: data passed in a Hashtable from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections;
using System;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__sleep_Random_72a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int count;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        Hashtable countHashtable = new Hashtable(5);
        countHashtable.Add(0, count);
        countHashtable.Add(1, count);
        countHashtable.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__sleep_Random_72b.BadSink(countHashtable  );
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
        Hashtable countHashtable = new Hashtable(5);
        countHashtable.Add(0, count);
        countHashtable.Add(1, count);
        countHashtable.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__sleep_Random_72b.GoodG2BSink(countHashtable  );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private static void GoodB2G()
    {
        int count;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        Hashtable countHashtable = new Hashtable(5);
        countHashtable.Add(0, count);
        countHashtable.Add(1, count);
        countHashtable.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__sleep_Random_72b.GoodB2GSink(countHashtable  );
    }
#endif //omitgood
}
}
