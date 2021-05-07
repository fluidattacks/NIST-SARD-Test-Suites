/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE690_NULL_Deref_From_Return__getParameter_Web_trim_12.cs
Label Definition File: CWE690_NULL_Deref_From_Return.label.xml
Template File: sources-sinks-12.tmpl.cs
*/
/*
* @description
* CWE: 690 Unchecked return value is null, leading to a null pointer dereference.
* BadSource: getParameter_Web Set data to return of getParameter_Web
* GoodSource: Set data to fixed, non-null String
* Sinks: trim
*    GoodSink: Check data for null before calling trim()
*    BadSink : Call trim() on possibly null object
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE690_NULL_Deref_From_Return
{
class CWE690_NULL_Deref_From_Return__getParameter_Web_trim_12 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: data may be set to null */
            data = req.QueryString["CWE690"];
        }
        else
        {
            /* FIX: Set data to a fixed, non-null String */
            data = "CWE690";
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: data could be null */
            string stringTrimmed = data.Trim();
            IO.WriteLine(stringTrimmed);
        }
        else
        {
            /* FIX: explicit check for null */
            if (data != null)
            {
                string stringTrimmed = data.Trim();
                IO.WriteLine(stringTrimmed);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by changing the first "if" so that
     * both branches use the GoodSource */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Set data to a fixed, non-null String */
            data = "CWE690";
        }
        else
        {
            /* FIX: Set data to a fixed, non-null String */
            data = "CWE690";
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: data could be null */
            string stringTrimmed = data.Trim();
            IO.WriteLine(stringTrimmed);
        }
        else
        {
            /* POTENTIAL FLAW: data could be null */
            string stringTrimmed = data.Trim();
            IO.WriteLine(stringTrimmed);
        }
    }

    /* goodB2G() - use badsource and goodsink by changing the second "if" so that
     * both branches use the GoodSink */
    private void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* POTENTIAL FLAW: data may be set to null */
            data = req.QueryString["CWE690"];
        }
        else
        {
            /* POTENTIAL FLAW: data may be set to null */
            data = req.QueryString["CWE690"];
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: explicit check for null */
            if (data != null)
            {
                string stringTrimmed = data.Trim();
                IO.WriteLine(stringTrimmed);
            }
        }
        else
        {
            /* FIX: explicit check for null */
            if (data != null)
            {
                string stringTrimmed = data.Trim();
                IO.WriteLine(stringTrimmed);
            }
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)

    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }
#endif //omitgood
}
}
