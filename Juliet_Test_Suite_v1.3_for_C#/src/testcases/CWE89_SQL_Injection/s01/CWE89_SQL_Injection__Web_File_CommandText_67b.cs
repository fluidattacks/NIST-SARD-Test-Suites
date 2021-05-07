/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE89_SQL_Injection__Web_File_CommandText_67b.cs
Label Definition File: CWE89_SQL_Injection__Web.label.xml
Template File: sources-sinks-67b.tmpl.cs
*/
/*
 * @description
 * CWE: 89 SQL Injection
 * BadSource: File Read data from file (named data.txt)
 * GoodSource: A hardcoded string
 * Sinks: CommandText
 *    GoodSink: Use prepared statement and concatenate CommandText (properly)
 *    BadSink : data concatenated into SQL statement used in CommandText, which could result in SQL Injection
 * Flow Variant: 67 Data flow: data passed in a class from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Web;

namespace testcases.CWE89_SQL_Injection
{
class CWE89_SQL_Injection__Web_File_CommandText_67b
{
#if (!OMITBAD)
    public static void BadSink(CWE89_SQL_Injection__Web_File_CommandText_67a.Container dataContainer , HttpRequest req, HttpResponse resp)
    {
        string data = dataContainer.containerOne;
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
#endif

#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink */
    public static void GoodG2BSink(CWE89_SQL_Injection__Web_File_CommandText_67a.Container dataContainer , HttpRequest req, HttpResponse resp)
    {
        string data = dataContainer.containerOne;
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

    /* goodB2G() - use badsource and goodsink */
    public static void GoodB2GSink(CWE89_SQL_Injection__Web_File_CommandText_67a.Container dataContainer , HttpRequest req, HttpResponse resp)
    {
        string data = dataContainer.containerOne;
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
#endif
}
}
