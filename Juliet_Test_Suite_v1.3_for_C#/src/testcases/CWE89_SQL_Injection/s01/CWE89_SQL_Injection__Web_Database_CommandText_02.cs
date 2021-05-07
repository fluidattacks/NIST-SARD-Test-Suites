/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE89_SQL_Injection__Web_Database_CommandText_02.cs
Label Definition File: CWE89_SQL_Injection__Web.label.xml
Template File: sources-sinks-02.tmpl.cs
*/
/*
* @description
* CWE: 89 SQL Injection
* BadSource: Database Read data from a database
* GoodSource: A hardcoded string
* Sinks: CommandText
*    GoodSink: Use prepared statement and concatenate CommandText (properly)
*    BadSink : data concatenated into SQL statement used in CommandText, which could result in SQL Injection
* Flow Variant: 02 Control flow: if(true) and if(false)
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Web;


namespace testcases.CWE89_SQL_Injection
{
class CWE89_SQL_Injection__Web_Database_CommandText_02 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (true)
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (true)
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
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing first true to false */
    private void GoodG2B1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (false)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        if (true)
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
    }

    /* GoodG2B2() - use goodsource and badsink by reversing statements in first if */
    private void GoodG2B2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (true)
        {
            /* FIX: Use a hardcoded string */
            data = "foo";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (true)
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
    }

    /* goodB2G1() - use badsource and goodsink by changing second true to false */
    private void GoodB2G1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (true)
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (false)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
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

    /* goodB2G2() - use badsource and goodsink by reversing statements in second if  */
    private void GoodB2G2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (true)
        {
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
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        if (true)
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

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B1(req, resp);
        GoodG2B2(req, resp);
        GoodB2G1(req, resp);
        GoodB2G2(req, resp);
    }
#endif //omitgood
}
}
