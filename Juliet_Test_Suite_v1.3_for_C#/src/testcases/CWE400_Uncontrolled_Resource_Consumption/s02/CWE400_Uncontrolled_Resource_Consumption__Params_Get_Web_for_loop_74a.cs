/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_for_loop_74a.cs
Label Definition File: CWE400_Uncontrolled_Resource_Consumption.label.xml
Template File: sources-sinks-74a.tmpl.cs
*/
/*
 * @description
 * CWE: 400 Uncontrolled Resource Consumption
 * BadSource: Params_Get_Web Read count from a querystring using Params.Get()
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: for_loop
 *    GoodSink: Validate count before using it as the loop variant in a for loop
 *    BadSink : Use count as the loop variant in a for loop
 * Flow Variant: 74 Data flow: data passed in a Dictionary from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections.Generic;
using System;

using System.Web;


namespace testcases.CWE400_Uncontrolled_Resource_Consumption
{
class CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_for_loop_74a : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        int count;
        count = int.MinValue; /* Initialize count */
        /* POTENTIAL FLAW: Read count from a querystring using Params.Get() */
        {
            string stringNumber = req.Params.Get("name");
            try
            {
                count = int.Parse(stringNumber.Trim());
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from parameter 'name'");
            }
        }
        Dictionary<int,int> countDictionary = new Dictionary<int,int>();
        countDictionary.Add(0, count);
        countDictionary.Add(1, count);
        countDictionary.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_for_loop_74b.BadSink(countDictionary , req, resp );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    /* goodG2B() - use GoodSource and BadSink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        int count;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        count = 2;
        Dictionary<int,int> countDictionary = new Dictionary<int,int>();
        countDictionary.Add(0, count);
        countDictionary.Add(1, count);
        countDictionary.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_for_loop_74b.GoodG2BSink(countDictionary , req, resp );
    }

    /* goodB2G() - use BadSource and GoodSink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        int count;
        count = int.MinValue; /* Initialize count */
        /* POTENTIAL FLAW: Read count from a querystring using Params.Get() */
        {
            string stringNumber = req.Params.Get("name");
            try
            {
                count = int.Parse(stringNumber.Trim());
            }
            catch (FormatException exceptNumberFormat)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception reading count from parameter 'name'");
            }
        }
        Dictionary<int,int> countDictionary = new Dictionary<int,int>();
        countDictionary.Add(0, count);
        countDictionary.Add(1, count);
        countDictionary.Add(2, count);
        CWE400_Uncontrolled_Resource_Consumption__Params_Get_Web_for_loop_74b.GoodB2GSink(countDictionary , req, resp );
    }
#endif //omitgood
}
}
