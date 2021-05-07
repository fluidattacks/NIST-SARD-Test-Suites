/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__Integer_66a.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-66a.tmpl.cs
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

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__Integer_66a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int? data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        int?[] dataArray = new int?[5];
        dataArray[2] = data;
        CWE476_NULL_Pointer_Dereference__Integer_66b.BadSink(dataArray  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        int? data;
        /* FIX: hardcode data to non-null */
        data = Int32.Parse("5");
        int?[] dataArray = new int?[5];
        dataArray[2] = data;
        CWE476_NULL_Pointer_Dereference__Integer_66b.GoodG2BSink(dataArray  );
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        int? data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        int?[] dataArray = new int?[5];
        dataArray[2] = data;
        CWE476_NULL_Pointer_Dereference__Integer_66b.GoodB2GSink(dataArray  );
    }
#endif //omitgood
}
}
