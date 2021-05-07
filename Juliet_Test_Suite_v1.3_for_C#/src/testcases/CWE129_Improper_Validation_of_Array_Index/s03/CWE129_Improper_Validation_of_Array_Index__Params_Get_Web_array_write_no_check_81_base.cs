/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE129_Improper_Validation_of_Array_Index__Params_Get_Web_array_write_no_check_81_base.cs
Label Definition File: CWE129_Improper_Validation_of_Array_Index.label.xml
Template File: sources-sinks-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 129 Improper Validation of Array Index
 * BadSource: Params_Get_Web Read data from a querystring using Params.Get()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: array_write_no_check
 *    GoodSink: Write to array after verifying index
 *    BadSink : Write to array without any verification of index
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE129_Improper_Validation_of_Array_Index
{
abstract class CWE129_Improper_Validation_of_Array_Index__Params_Get_Web_array_write_no_check_81_base
{
    public abstract void Action(int data , HttpRequest req, HttpResponse resp);
}
}
