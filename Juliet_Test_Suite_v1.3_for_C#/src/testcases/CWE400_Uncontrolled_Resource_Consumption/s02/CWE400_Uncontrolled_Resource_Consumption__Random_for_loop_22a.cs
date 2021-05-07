/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_22a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Random Set count to a random value
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: for_loop
 *    GoodSink: Validate count before using it as the loop variant in a for loop
 *    BadSink : Use count as the loop variant in a for loop
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_22a : AbstractTestCase
{

    /* The public static variable below is used to drive control flow in the sink function. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad()
    {
        int count = 0;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        badPublicStatic = true;
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_22b.BadSink(count );
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the sink functions. */
    public static bool goodB2G1PublicStatic = false;
    public static bool goodB2G2PublicStatic = false;
    public static bool goodG2BPublicStatic = false;
#if (!OMITGOOD)
    public override void Good()
    {
        GoodB2G1();
        GoodB2G2();
        GoodG2B();
    }

    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    private void GoodB2G1()
    {
        int count = 0;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        goodB2G1PublicStatic = false;
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_22b.GoodB2G1Sink(count );
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    private void GoodB2G2()
    {
        int count = 0;
        /* POTENTIAL FLAW: Set count to a random value */
        count = (new Random()).Next();
        goodB2G2PublicStatic = true;
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_22b.GoodB2G2Sink(count );
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        int count = 0;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        goodG2BPublicStatic = true;
        CWE400_Uncontrolled_Resource_Consumption__Random_for_loop_22b.GoodG2BSink(count );
    }
#endif //omitgood
}
}
