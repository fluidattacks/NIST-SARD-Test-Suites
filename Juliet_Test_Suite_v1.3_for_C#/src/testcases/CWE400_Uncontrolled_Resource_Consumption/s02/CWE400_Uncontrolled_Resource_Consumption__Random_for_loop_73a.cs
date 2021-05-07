/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_73a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-73a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Random Set count to a random value
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: for_loop
 *    GoodSink: Validate count before using it as the loop variant in a for loop
 *    BadSink : Use count as the loop variant in a for loop
 * Flow Variant: 73 Data flow: data passed in a LinkedList from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections.Generic;
using System;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_73a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int count;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        LinkedList<int> countLinkedList = new LinkedList<int>();
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_73b.BadSink(countLinkedList  );
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
        LinkedList<int> countLinkedList = new LinkedList<int>();
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_73b.GoodG2BSink(countLinkedList  );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private static void GoodB2G()
    {
        int count;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        LinkedList<int> countLinkedList = new LinkedList<int>();
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        countLinkedList.AddLast(count);
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_73b.GoodB2GSink(countLinkedList  );
    }
#endif //omitgood
}
}
