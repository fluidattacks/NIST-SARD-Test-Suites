/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE601_Open_Redirect__Web_Get_Cookies_Web_81_base.cs
Label Definition File: CWE601_Open_Redirect__Web.label.xml
Template File: sources-sink-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 601 Open Redirect
 * BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
 * GoodSource: A hardcoded string
 * Sinks:
 *    BadSink : place redirect string directly into redirect api call
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE601_Open_Redirect
{
abstract class CWE601_Open_Redirect__Web_Get_Cookies_Web_81_base
{
    public abstract void Action(string data , HttpRequest req, HttpResponse resp);
}
}
