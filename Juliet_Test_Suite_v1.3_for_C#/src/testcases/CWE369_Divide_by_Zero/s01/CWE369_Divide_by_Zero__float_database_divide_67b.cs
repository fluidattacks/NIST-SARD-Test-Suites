/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE369_Divide_by_Zero__float_database_divide_67b.cs
Label Definition File: CWE369_Divide_by_Zero__float.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 369 Divide by zero
 * BadSource: database Read data from a database
 * GoodSource: A hardcoded non-zero number (two)
 * Sinks: divide
 *    GoodSink: Check for zero before dividing
 *    BadSink : Dividing by a value that may be zero
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE369_Divide_by_Zero
{
class CWE369_Divide_by_Zero__float_database_divide_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE369_Divide_by_Zero__float_database_divide_67a.Container dataContainer )
    {
        float data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Possibly divide by zero */
        int result = (int)(100.0 / data);
        IO.WriteLine(result);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE369_Divide_by_Zero__float_database_divide_67a.Container dataContainer )
    {
        float data = dataContainer.containerOne;
        /* POTENTIAL FLAW: Possibly divide by zero */
        int result = (int)(100.0 / data);
        IO.WriteLine(result);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE369_Divide_by_Zero__float_database_divide_67a.Container dataContainer )
    {
        float data = dataContainer.containerOne;
        /* FIX: Check for value of or near zero before dividing */
        if (Math.Abs(data) > 0.000001)
        {
            int result = (int)(100.0 / data);
            IO.WriteLine(result);
        }
        else
        {
            IO.WriteLine("This would result in a divide by zero");
        }
    }
#endif
}
}
