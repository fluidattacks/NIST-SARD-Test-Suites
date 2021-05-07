/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__Class_StringBuilder_66b.cs
Label Definition File: CWE690_NULL_Deref_From_Return__Class.label.xml
Template File: sources-sinks-66b.tmpl.cs
*/
/*
 * @description
 * CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
 * BadSource:  Use a custom method which may return null
 * GoodSource: Use a custom method that never returns null
 * Sinks: trim
 *    GoodSink: Check data for null before calling trim()
 *    BadSink : Call trim() on possibly null object
 * Flow Variant: 66 Data flow: data passed in an array from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Text;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__Class_StringBuilder_66b
{
#if (!OMITBAD)
    public static void BadSink(StringBuilder[] dataArray )
    {
        StringBuilder data = dataArray[2];
        /* POTENTIAL FLAW: data could be null */
        string stringTrimmed = data.ToString().Trim();
        IO.WriteLine(stringTrimmed);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(StringBuilder[] dataArray )
    {
        StringBuilder data = dataArray[2];
        /* POTENTIAL FLAW: data could be null */
        string stringTrimmed = data.ToString().Trim();
        IO.WriteLine(stringTrimmed);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(StringBuilder[] dataArray )
    {
        StringBuilder data = dataArray[2];
        /* FIX: explicit check for null */
        if (data != null)
        {
            string stringTrimmed = data.ToString().Trim();
            IO.WriteLine(stringTrimmed);
        }
    }
#endif
}
}
