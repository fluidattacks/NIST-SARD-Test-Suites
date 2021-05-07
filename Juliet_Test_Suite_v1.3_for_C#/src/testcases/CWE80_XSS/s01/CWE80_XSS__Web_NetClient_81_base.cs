/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE80_XSS__Web_NetClient_81_base.cs
Label Definition File: CWE80_XSS__Web.label.xml
Template File: sources-sink-81_base.tmpl.cs
*/
/*
 * @description
 * CWE: 80 Cross Site Scripting (XSS)
 * BadSource: NetClient Read data from a web server with WebClient
 * GoodSource: A hardcoded string
 * Sinks: Web
 *    BadSink : Display of data in web page without any encoding or validation
 * Flow Variant: 81 Data flow: data passed in a parameter to an abstract method
 *
 * */

using TestCaseSupport;
using System;

using System.Web;

namespace testcases.CWE80_XSS
{
abstract class CWE80_XSS__Web_NetClient_81_base
{
    public abstract void Action(string data , HttpRequest req, HttpResponse resp);
}
}
