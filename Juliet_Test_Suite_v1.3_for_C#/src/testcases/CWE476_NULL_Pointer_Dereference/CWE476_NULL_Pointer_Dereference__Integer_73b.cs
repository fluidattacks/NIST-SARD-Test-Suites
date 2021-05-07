/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE476_NULL_Pointer_Dereference__Integer_73b.cs
Label Definition File: CWE476_NULL_Pointer_Dereference.label.xml
Template File: sources-sinks-73b.tmpl.cs
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
using System;
using System.Collections.Generic;

namespace testcases.CWE476_NULL_Pointer_Dereference
{
class CWE476_NULL_Pointer_Dereference__Integer_73b
{
#if (!OMITBAD)
    public static void BadSink(LinkedList<int?> dataLinkedList )
    {
        int? data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.ToString());
    }
#endif

#if (!OMITGOOD)
    /* goodG2B() - use GoodSource and BadSink */
    public static void GoodG2BSink(LinkedList<int?> dataLinkedList )
    {
        int? data = dataLinkedList.Last.Value;
        /* POTENTIAL FLAW: null dereference will occur if data is null */
        IO.WriteLine("" + data.ToString());
    }

    /* goodB2G() - use BadSource and GoodSink */
    public static void GoodB2GSink(LinkedList<int?> dataLinkedList )
    {
        int? data = dataLinkedList.Last.Value;
        /* FIX: validate that data is non-null */
        if (data != null)
        {
            IO.WriteLine("" + data.ToString());
        }
        else
        {
            IO.WriteLine("data is null");
        }
    }
#endif
}
}
