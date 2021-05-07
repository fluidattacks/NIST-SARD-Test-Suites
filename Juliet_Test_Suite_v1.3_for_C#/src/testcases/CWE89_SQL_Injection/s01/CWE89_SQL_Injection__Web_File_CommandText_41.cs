/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE89_SQL_Injection__Web_File_CommandText_41.cs
Label Definition File: CWE89_SQL_Injection__Web.label.xml
Template File: sources-sinks-41.tmpl.cs
*/
/*
 * @description
 * CWE: 89 SQL Injection
 * BadSource: File Read data from file (named data.txt)
 * GoodSource: A hardcoded string
 * Sinks: CommandText
 *    GoodSink: Use prepared statement and concatenate CommandText (properly)
 *    BadSink : data concatenated into SQL statement used in CommandText, which could result in SQL Injection
 * Flow Variant: 41 Data flow: data passed as an argument from one method to another in the same class
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;
using System.Web;

using System.IO;

namespace testcases.CWE89_SQL_Injection
{
class CWE89_SQL_Injection__Web_File_CommandText_41 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    private static void BadSink(string data , HttpRequest req, HttpResponse resp)
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

    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* Initialize data */
        {
            try
            {
                /* read string from file into data */
                using (StreamReader sr = new StreamReader("data.txt"))
                {
                    /* POTENTIAL FLAW: Read data from a file */
                    /* This will be reading the first "line" of the file, which
                     * could be very long if there are little or no newlines in the file */
                    data = sr.ReadLine();
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        BadSink(data , req, resp );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
        GoodB2G(req, resp);
    }

    private static void GoodG2BSink(string data , HttpRequest req, HttpResponse resp)
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

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string data;
        /* FIX: Use a hardcoded string */
        data = "foo";
        GoodG2BSink(data , req, resp );
    }

    private static void GoodB2GSink(string data , HttpRequest req, HttpResponse resp)
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

    /* goodB2G() - use badsource and goodsink */
    private static void GoodB2G(HttpRequest req, HttpResponse resp)
    {
        string data;
        data = ""; /* Initialize data */
        {
            try
            {
                /* read string from file into data */
                using (StreamReader sr = new StreamReader("data.txt"))
                {
                    /* POTENTIAL FLAW: Read data from a file */
                    /* This will be reading the first "line" of the file, which
                     * could be very long if there are little or no newlines in the file */
                    data = sr.ReadLine();
                }
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptIO, "Error with stream reading");
            }
        }
        GoodB2GSink(data , req, resp );
    }
#endif //omitgood
}
}
