/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__int_array_73a.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-73a.tmpl.cs
*/
/*
 * @description
 * CWE: 476 Null Pointer Dereference
 * BadSource:  Set data to null
 * GoodSource: Set data to a non-null value
 * Sinks:
 *    GoodSink: add check to prevent possibility of null dereference
 *    BadSink : possibility of null dereference
 * Flow Variant: 73 Data flow: data passed in a LinkedList from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections.Generic;
using System;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__int_array_73a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int[] data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        LinkedList<int[]> dataLinkedList = new LinkedList<int[]>();
        dataLinkedList.AddLast(data);
        dataLinkedList.AddLast(data);
        dataLinkedList.AddLast(data);
        CWE476_NULL_Pointer_Dereference__int_array_73b.BadSink(dataLinkedList  );
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
        int[] data;
        /* FIX: hardcode data to non-null */
        data = new int[5];
        LinkedList<int[]> dataLinkedList = new LinkedList<int[]>();
        dataLinkedList.AddLast(data);
        dataLinkedList.AddLast(data);
        dataLinkedList.AddLast(data);
        CWE476_NULL_Pointer_Dereference__int_array_73b.GoodG2BSink(dataLinkedList  );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private static void GoodB2G()
    {
        int[] data;
        /* POTENTIAL FLAW: data is null */
        data = null;
        LinkedList<int[]> dataLinkedList = new LinkedList<int[]>();
        dataLinkedList.AddLast(data);
        dataLinkedList.AddLast(data);
        dataLinkedList.AddLast(data);
        CWE476_NULL_Pointer_Dereference__int_array_73b.GoodB2GSink(dataLinkedList  );
    }
#endif //omitgood
}
}
