/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__getParameter_Web_trim_22a.cs
Label Definition File: CWE690_NULL_Deref_From_Return.label.xml
Template File: sources-sinks-22a.tmpl.cs
*/
/*
 * @description
 * CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
 * BadSource: getParameter_Web Set data to return of getParameter_Web
 * GoodSource: Set data to fixed, non-null String
 * Sinks: trim
 *    GoodSink: Check data for null before calling trim()
 *    BadSink : Call trim() on possibly null object
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__getParameter_Web_trim_22a : AbstractTestCaseWeb
{

    /* The public static variable below is used to drive control flow in the sink function. */
    public static bool badPublicStatic = false;
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        /* POTENTIAL FLAW: data may be set to null */
        data = req.QueryString["CWE690"];
        badPublicStatic = true;
        CWE690_NULL_Deref_From_Return__getParameter_Web_trim_22b.BadSink(data , req, resp);
    }
#endif //omitbad
    /* The public static variables below are used to drive control flow in the sink functions. */
    public static bool goodB2G1PublicStatic = false;
    public static bool goodB2G2PublicStatic = false;
    public static bool goodG2BPublicStatic = false;
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
        GoodG2B(req, resp);
    }

    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        /* POTENTIAL FLAW: data may be set to null */
        data = req.QueryString["CWE690"];
        goodB2G1PublicStatic = false;
        CWE690_NULL_Deref_From_Return__getParameter_Web_trim_22b.GoodB2G1Sink(data , req, resp);
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        /* POTENTIAL FLAW: data may be set to null */
        data = req.QueryString["CWE690"];
        goodB2G2PublicStatic = true;
        CWE690_NULL_Deref_From_Return__getParameter_Web_trim_22b.GoodB2G2Sink(data , req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data = null;
        /* FIX: Set data to a fixed, non-null String */
        data = "CWE690";
        goodG2BPublicStatic = true;
        CWE690_NULL_Deref_From_Return__getParameter_Web_trim_22b.GoodG2BSink(data , req, resp);
    }
#endif //omitgood
}
}
