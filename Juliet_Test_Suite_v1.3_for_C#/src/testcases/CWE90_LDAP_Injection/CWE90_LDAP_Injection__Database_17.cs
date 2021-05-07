/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE90_LDAP_Injection__Database_17.cs
Label Definition File: CWE90_LDAP_Injection.label.xml
Template File: sources-sink-17.tmpl.cs
*/
/*
* @description
* CWE: 90 LDAP Injection
* BadSource: Database Read data from a database
* GoodSource: A hardcoded string
* BadSink:  data concatenated into LDAP search, which could result in LDAP Injection
* Flow Variant: 17 Control flow: for loops
*
* */

using TestCaseSupport;
using System;

using System.DirectoryServices;

using System.Web;

using System.Data.SqlClient;

namespace testcases.CWE90_LDAP_Injection
{

class CWE90_LDAP_Injection__Database_17 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string data;
        data = ""; /* Initialize data */
        /* Read data from a database */
        {
            try
            {
                /* setup the connection */
                using (SqlConnection connection = IO.GetDBConnection())
                {
                    connection.Open();
                    /* prepare and execute a (hardcoded) query */
                    using (SqlCommand command = new SqlCommand(null, connection))
                    {
                        command.CommandText = "select name from users where id=0";
                        command.Prepare();
                        using (SqlDataReader dr = command.ExecuteReader())
                        {
                            /* POTENTIAL FLAW: Read data from a database query SqlDataReader */
                            data = dr.GetString(1);
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
            }
        }
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
    private void GoodG2B()
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

    public override void Good()
    {
        GoodG2B();
    }
#endif //omitgood
}
}
