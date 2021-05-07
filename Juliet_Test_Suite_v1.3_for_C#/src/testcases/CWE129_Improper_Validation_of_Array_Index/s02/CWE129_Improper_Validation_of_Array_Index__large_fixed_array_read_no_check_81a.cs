/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81a.cs
Label Definition File: CWE129_Improper_Validation_of_Array_Index.label.xml
Template File: sources-sinks-81a.tmpl.cs
*/
/*
 * @description
 * CWE: 129 Improper Validation of Array Index
 * BadSource: large_fixed Set data to a value greater than the size of the array
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: array_read_no_check
 *    GoodSink: Read from array after verifying index
 *    BadSink : Read from array without any verification of index
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

namespace testcases.CWE129_Improper_Validation_of_Array_Index
{
class CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        int data;
        /* POTENTIAL FLAW: Set data to a value greater than the size of the array */
        data = 100;
        CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81_base baseObject = new CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81_bad();
        baseObject.Action(data );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
        GoodB2G();
    }

    /* goodG2B() - use GoodSource and BadSink */
    private void GoodG2B()
    {
        int data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81_base baseObject = new CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81_goodG2B();
        baseObject.Action(data );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private void GoodB2G()
    {
        int data;
        /* POTENTIAL FLAW: Set data to a value greater than the size of the array */
        data = 100;
        CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81_base baseObject = new CWE129_Improper_Validation_of_Array_Index__large_fixed_array_read_no_check_81_goodB2G();
        baseObject.Action(data );
    }
#endif //omitgood
}
}
