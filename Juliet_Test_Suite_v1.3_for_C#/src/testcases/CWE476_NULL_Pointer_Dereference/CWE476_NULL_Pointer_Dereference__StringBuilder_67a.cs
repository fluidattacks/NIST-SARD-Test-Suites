/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__StringBuilder_67a.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-67a.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Text;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__StringBuilder_67a : AbstractTestCase
{

    public class Container
    {
        public StringBuilder containerOne;
    }
#if (!OMITBAD)
    public override void Bad()
    {
        StringBuilder data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        Container dataContainer = new Container();
        dataContainer.containerOne = data;
        CWE476_NULL_Pointer_Dereference__StringBuilder_67b.BadSink(dataContainer  );
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
        StringBuilder data;
        /* FIX: hardcode data to non-null */
        data = new StringBuilder();
        Container dataContainer = new Container();
        dataContainer.containerOne = data;
        CWE476_NULL_Pointer_Dereference__StringBuilder_67b.GoodG2BSink(dataContainer  );
    }

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G()
    {
        StringBuilder data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        Container dataContainer = new Container();
        dataContainer.containerOne = data;
        CWE476_NULL_Pointer_Dereference__StringBuilder_67b.GoodB2GSink(dataContainer  );
    }
#endif //omitgood
}
}
