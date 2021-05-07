/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE90_LDAP_Injection__Params_Get_Web_17.cs
Label Definition File: CWE90_LDAP_Injection.label.xml
Template File: sources-sink-17.tmpl.cs
*/
/*
* @description
* CWE: 90 LDAP Injection
* BadSource: Params_Get_Web Read data from a querystring using Params.Get()
* GoodSource: A hardcoded string
* BadSink:  data concatenated into LDAP search, which could result in LDAP Injection
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.DirectoryServices;

using System.Web;


namespace testcases.CWE90_LDAP_Injection
{

class CWE90_LDAP_Injection__Params_Get_Web_17 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* POTENTIAL FLAW: Read data from a querystring using Params.Get */
        data = req.Params.Get("name");
        for (int i = 0; i < 1; i++)
        {
            using (DirectoryEntry de = new DirectoryEntry())
            {
                /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
                using (DirectorySearcher search = new DirectorySearcher(de))
                {
                    search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                    search.PropertiesToLoad.Add("mail");
                    search.PropertiesToLoad.Add("telephonenumber");
                    SearchResult sresult = search.FindOne();
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by reversing the block outside the
     * for statement with the one in the for statement */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        for (int i = 0; i < 1; i++)
        {
            using (DirectoryEntry de = new DirectoryEntry())
            {
                /* POTENTIAL FLAW: data concatenated into LDAP search, which could result in LDAP Injection */
                using (DirectorySearcher search = new DirectorySearcher(de))
                {
                    search.Filter = "(&(objectClass=user)(employeename=" + data + "))";
                    search.PropertiesToLoad.Add("mail");
                    search.PropertiesToLoad.Add("telephonenumber");
                    SearchResult sresult = search.FindOne();
                }
            }
        }
    }

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
    }
#endif //omitgood
}
}
