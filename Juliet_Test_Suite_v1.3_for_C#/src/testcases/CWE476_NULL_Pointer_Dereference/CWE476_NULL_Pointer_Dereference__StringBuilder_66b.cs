/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__StringBuilder_66b.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-66b.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 66 Data flow: data passed in an array from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Text;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__StringBuilder_66b
{
#if (!OMITBAD)
    public static void BadSink(StringBuilder[] dataArray )
    {
        StringBuilder data = dataArray[2];
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.Length);
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(StringBuilder[] dataArray )
    {
        StringBuilder data = dataArray[2];
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.Length);
    }

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(StringBuilder[] dataArray )
    {
        StringBuilder data = dataArray[2];
        /* FIX: validate that data is non-null */
        if (data != null)
        {
            IO.WriteLine("" + data.Length);
        }
        else
        {
            IO.WriteLine("data is null");
        }
    }
#endif
}
}
