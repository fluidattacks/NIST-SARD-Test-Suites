/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE190_Integer_Overflow__int_Get_Cookies_Web_square_81_goodG2B.cs
Label Definition File: CWE190_Integer_Overflow__int.label.xml
Template File: sources-sinks-81_goodG2B.tmpl.cs
*/
/*
 * @description
 * CWE: 190 Integer Overflow
 * BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: square
 *    GoodSink: Ensure there will not be an overflow before squaring data
 *    BadSink : Square data, which can lead to overflow
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */
#if (!OMITGOOD)

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE190_Integer_Overflow
{
class CWE190_Integer_Overflow__int_Get_Cookies_Web_square_81_goodG2B : CWE190_Integer_Overflow__int_Get_Cookies_Web_square_81_base
{

    public override void Action(int data , HttpRequest req, HttpResponse resp)
    {
        /* POTENTIAL FLAW: if (data*data) > int.MaxValue, this will overflow */
        int result = (int)(data * data);
        IO.WriteLine("result: " + result);
    }
}
}
#endif
