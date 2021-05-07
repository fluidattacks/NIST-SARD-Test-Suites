/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE89_SQL_Injection__Web_NetClient_CommandText_22b.cs
Label Definition File: CWE89_SQL_Injection__Web.label.xml
Template File: sources-sinks-22b.tmpl.cs
*/
/*
 * @description
 * CWE: 89 SQL Injection
 * BadSource: NetClient Read data from a web server with WebClient
 * GoodSource: A hardcoded string
 * Sinks: CommandText
 *    GoodSink: Use prepared statement and concatenate CommandText (properly)
 *    BadSink : data concatenated into SQL statement used in CommandText, which could result in SQL Injection
 * Flow Variant: 22 Control flow: Flow controlled by value of a public static variable. Sink functions are in a separate file from sources.
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace testcases.CWE89_SQL_Injection
{
class CWE89_SQL_Injection__Web_NetClient_CommandText_22b
{
#if (!OMITBAD)
    public static void BadSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE89_SQL_Injection__Web_NetClient_CommandText_22a.badPublicStatic)
        {
            if (data != null)
            {
                string[] names = data.Split('-');
                int successCount = 0;
                SqlCommand badSqlCommand = null;
                try
                {
                    using (SqlConnection dbConnection = IO.GetDBConnection())
                    {
                        badSqlCommand.Connection = dbConnection;
                        dbConnection.Open();
                        for (int i = 0; i < names.Length; i++)
                        {
                            /* POTENTIAL FLAW: data concatenated into SQL statement used in CommandText, which could result in SQL Injection */
                            badSqlCommand.CommandText += "update users set hitcount=hitcount+1 where name='" + names[i] + "';";
                        }
                        var affectedRows = badSqlCommand.ExecuteNonQuery();
                        successCount += affectedRows;
                        IO.WriteLine("Succeeded in " + successCount + " out of " + names.Length + " queries.");
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
                }
                finally
                {
                    try
                    {
                        if (badSqlCommand != null)
                        {
                            badSqlCommand.Dispose();
                        }
                    }
                    catch (SqlException exceptSql)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error disposing SqlCommand", exceptSql);
                    }
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }
#endif

#if (!OMITGOOD)
    /* goodB2G1() - use badsource and goodsink by setting the static variable to false instead of true */
    public static void GoodB2G1Sink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE89_SQL_Injection__Web_NetClient_CommandText_22a.goodB2G1PublicStatic)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            if (data != null)
            {
                string[] names = data.Split('-');
                int successCount = 0;
                try
                {
                    /* FIX: Use prepared statement and concatenate CommandText (properly) */
                    using (SqlConnection dbConnection = IO.GetDBConnection())
                    {
                        dbConnection.Open();
                        using (SqlCommand goodSqlCommand = new SqlCommand(null, dbConnection))
                        {
                            for (int i = 0; i < names.Length; i++)
                            {
                                SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                                nameParam.Value = names[i];
                                goodSqlCommand.CommandText += "update users set hitcount=hitcount+1 where name=@name;";
                            }
                            goodSqlCommand.Prepare();
                            int affectedRows = goodSqlCommand.ExecuteNonQuery();
                            successCount += affectedRows;
                            IO.WriteLine("Succeeded in " + successCount + " out of " + names.Length + " queries.");
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
                }
            }
        }
    }

    /* goodB2G2() - use badsource and goodsink by reversing the blocks in the if in the sink function */
    public static void GoodB2G2Sink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE89_SQL_Injection__Web_NetClient_CommandText_22a.goodB2G2PublicStatic)
        {
            if (data != null)
            {
                string[] names = data.Split('-');
                int successCount = 0;
                try
                {
                    /* FIX: Use prepared statement and concatenate CommandText (properly) */
                    using (SqlConnection dbConnection = IO.GetDBConnection())
                    {
                        dbConnection.Open();
                        using (SqlCommand goodSqlCommand = new SqlCommand(null, dbConnection))
                        {
                            for (int i = 0; i < names.Length; i++)
                            {
                                SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                                nameParam.Value = names[i];
                                goodSqlCommand.CommandText += "update users set hitcount=hitcount+1 where name=@name;";
                            }
                            goodSqlCommand.Prepare();
                            int affectedRows = goodSqlCommand.ExecuteNonQuery();
                            successCount += affectedRows;
                            IO.WriteLine("Succeeded in " + successCount + " out of " + names.Length + " queries.");
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }

    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
    {
        if (CWE89_SQL_Injection__Web_NetClient_CommandText_22a.goodG2BPublicStatic)
        {
            if (data != null)
            {
                string[] names = data.Split('-');
                int successCount = 0;
                SqlCommand badSqlCommand = null;
                try
                {
                    using (SqlConnection dbConnection = IO.GetDBConnection())
                    {
                        badSqlCommand.Connection = dbConnection;
                        dbConnection.Open();
                        for (int i = 0; i < names.Length; i++)
                        {
                            /* POTENTIAL FLAW: data concatenated into SQL statement used in CommandText, which could result in SQL Injection */
                            badSqlCommand.CommandText += "update users set hitcount=hitcount+1 where name='" + names[i] + "';";
                        }
                        var affectedRows = badSqlCommand.ExecuteNonQuery();
                        successCount += affectedRows;
                        IO.WriteLine("Succeeded in " + successCount + " out of " + names.Length + " queries.");
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error getting database connection", exceptSql);
                }
                finally
                {
                    try
                    {
                        if (badSqlCommand != null)
                        {
                            badSqlCommand.Dispose();
                        }
                    }
                    catch (SqlException exceptSql)
                    {
                        IO.Logger.Log(NLog.LogLevel.Warn, "Error disposing SqlCommand", exceptSql);
                    }
                }
            }
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
    }
#endif
}
}
