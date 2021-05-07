/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE89_SQL_Injection__Web_Get_Cookies_Web_ExecuteScalar_12.cs
Label Definition File: CWE89_SQL_Injection__Web.label.xml
Template File: sources-sinks-12.tmpl.cs
*/
/*
* @description
* CWE: 89 SQL Injection
* BadSource: Get_Cookies_Web Read data from the first cookie using Cookies
* GoodSource: A hardcoded string
* Sinks: ExecuteScalar
*    GoodSink: Use prepared statement and ExecuteScalar() (properly)
*    BadSink : data concatenated into SQL statement used in ExecuteScalar(), which could result in SQL Injection
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Web;


namespace testcases.CWE89_SQL_Injection
{
class CWE89_SQL_Injection__Web_Get_Cookies_Web_ExecuteScalar_12 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            data = ""; /* initialize data in case there are no cookies */
            /* Read data from cookies */
            {
                HttpCookieCollection cookieSources = req.Cookies;
                if (cookieSources != null)
                {
                    /* POTENTIAL FLAW: Read data from the first cookie value */
                    data = cookieSources[0].Value;
                }
            }
        }
        else
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            try
            {
                using (SqlConnection dbConnection = IO.GetDBConnection())
                {
                    dbConnection.Open();
                    using (SqlCommand badSqlCommand = new SqlCommand(null, dbConnection))
                    {
                        /* POTENTIAL FLAW: data concatenated into SQL statement used in ExecuteScalar(), which could result in SQL Injection */
                        badSqlCommand.CommandText = "select * from users where name='" +data+"'";
                        object firstCol = badSqlCommand.ExecuteScalar();
                        if (firstCol != null)
                        {
                            IO.WriteLine(firstCol.ToString()); /* Use ResultSet in some way */
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
        }
        else
        {
            try
            {
                using (SqlConnection dbConnection = IO.GetDBConnection())
                {
                    dbConnection.Open();
                    using (SqlCommand goodSqlCommand = new SqlCommand(null, dbConnection))
                    {
                        /* FIX: Use prepared statement and concatenate ExecuteScalar() (properly) */
                        SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                        nameParam.Value = data;
                        goodSqlCommand.CommandText += "select * from users where name=@name";
                        goodSqlCommand.Prepare();
                        object firstCol = goodSqlCommand.ExecuteScalar();
                        if (firstCol != null)
                        {
                            IO.WriteLine(firstCol.ToString()); /* Use ResultSet in some way */
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
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
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        else
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            try
            {
                using (SqlConnection dbConnection = IO.GetDBConnection())
                {
                    dbConnection.Open();
                    using (SqlCommand badSqlCommand = new SqlCommand(null, dbConnection))
                    {
                        /* POTENTIAL FLAW: data concatenated into SQL statement used in ExecuteScalar(), which could result in SQL Injection */
                        badSqlCommand.CommandText = "select * from users where name='" +data+"'";
                        object firstCol = badSqlCommand.ExecuteScalar();
                        if (firstCol != null)
                        {
                            IO.WriteLine(firstCol.ToString()); /* Use ResultSet in some way */
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
        }
        else
        {
            try
            {
                using (SqlConnection dbConnection = IO.GetDBConnection())
                {
                    dbConnection.Open();
                    using (SqlCommand badSqlCommand = new SqlCommand(null, dbConnection))
                    {
                        /* POTENTIAL FLAW: data concatenated into SQL statement used in ExecuteScalar(), which could result in SQL Injection */
                        badSqlCommand.CommandText = "select * from users where name='" +data+"'";
                        object firstCol = badSqlCommand.ExecuteScalar();
                        if (firstCol != null)
                        {
                            IO.WriteLine(firstCol.ToString()); /* Use ResultSet in some way */
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
        }
    }

    /* goodB2G() - use badsource and goodsink by changing the second "if" so that
     * both branches use the GoodSink */
    private void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
        if(IO.StaticReturnsTrueOrFalse())
        {
            data = ""; /* initialize data in case there are no cookies */
            /* Read data from cookies */
            {
                HttpCookieCollection cookieSources = req.Cookies;
                if (cookieSources != null)
                {
                    /* POTENTIAL FLAW: Read data from the first cookie value */
                    data = cookieSources[0].Value;
                }
            }
        }
        else
        {
            data = ""; /* initialize data in case there are no cookies */
            /* Read data from cookies */
            {
                HttpCookieCollection cookieSources = req.Cookies;
                if (cookieSources != null)
                {
                    /* POTENTIAL FLAW: Read data from the first cookie value */
                    data = cookieSources[0].Value;
                }
            }
        }
        if(IO.StaticReturnsTrueOrFalse())
        {
            try
            {
                using (SqlConnection dbConnection = IO.GetDBConnection())
                {
                    dbConnection.Open();
                    using (SqlCommand goodSqlCommand = new SqlCommand(null, dbConnection))
                    {
                        /* FIX: Use prepared statement and concatenate ExecuteScalar() (properly) */
                        SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                        nameParam.Value = data;
                        goodSqlCommand.CommandText += "select * from users where name=@name";
                        goodSqlCommand.Prepare();
                        object firstCol = goodSqlCommand.ExecuteScalar();
                        if (firstCol != null)
                        {
                            IO.WriteLine(firstCol.ToString()); /* Use ResultSet in some way */
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
            }
        }
        else
        {
            try
            {
                using (SqlConnection dbConnection = IO.GetDBConnection())
                {
                    dbConnection.Open();
                    using (SqlCommand goodSqlCommand = new SqlCommand(null, dbConnection))
                    {
                        /* FIX: Use prepared statement and concatenate ExecuteScalar() (properly) */
                        SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                        nameParam.Value = data;
                        goodSqlCommand.CommandText += "select * from users where name=@name";
                        goodSqlCommand.Prepare();
                        object firstCol = goodSqlCommand.ExecuteScalar();
                        if (firstCol != null)
                        {
                            IO.WriteLine(firstCol.ToString()); /* Use ResultSet in some way */
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
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
