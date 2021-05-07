/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__Class_StringBuilder_22b.cs
Label Definition File: CWE690_NULL_Deref_From_Return__Class.label.xml
Template File: sources-sinks-22b.tmpl.cs
*/
/*
 * @description
 * CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
 * BadSource:  Use a custom method which may return null
 * GoodSource: Use a custom method that never returns null
 * Sinks: trim
 *    GoodSink: Check data for null before calling trim()
 *    BadSink : Call trim() on possibly null object
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Text;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__Class_StringBuilder_22b
{
#if (!OMITBAD)
    public static void BadSink(StringBuilder data )
    {
        if (CWE690_NULL_Deref_From_Return__Class_StringBuilder_22a.badPublicStatic)
        {
            /* POTENTIAL FLAW: data could be null */
            string stringTrimmed = data.ToString().Trim();
            IO.WriteLine(stringTrimmed);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(StringBuilder data )
    {
        if (CWE690_NULL_Deref_From_Return__Class_StringBuilder_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: explicit check for null */
            if (data != null)
            {
                string stringTrimmed = data.ToString().Trim();
                IO.WriteLine(stringTrimmed);
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(StringBuilder data )
    {
        if (CWE690_NULL_Deref_From_Return__Class_StringBuilder_22a.goodB2G2PublicStatic)
        {
            /* FIX: explicit check for null */
            if (data != null)
            {
                string stringTrimmed = data.ToString().Trim();
                IO.WriteLine(stringTrimmed);
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(StringBuilder data )
    {
        if (CWE690_NULL_Deref_From_Return__Class_StringBuilder_22a.goodG2BPublicStatic)
        {
            /* POTENTIAL FLAW: data could be null */
            string stringTrimmed = data.ToString().Trim();
            IO.WriteLine(stringTrimmed);
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }
#endif
}
}
