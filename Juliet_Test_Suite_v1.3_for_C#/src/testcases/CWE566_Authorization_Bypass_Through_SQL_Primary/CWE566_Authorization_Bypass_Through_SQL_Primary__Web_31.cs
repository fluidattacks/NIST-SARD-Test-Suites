/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE566_Authorization_Bypass_Through_SQL_Primary__Web_31.cs
Label Definition File: CWE566_Authorization_Bypass_Through_SQL_Primary__Web.label.xml
Template File: sources-sink-31.tmpl.cs
*/
/*
 * @description
 * CWE: 566 Authorization Bypass through SQL primary
 * BadSource:  user id taken from url parameter
 * GoodSource: hardcoded user id
 * Sinks: writeConsole
 *    BadSink : user authorization not checked
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;

using System.Web;

namespace testcases.CWE566_Authorization_Bypass_Through_SQL_Primary
{

class CWE566_Authorization_Bypass_Through_SQL_Primary__Web_31 : AbstractTestCaseWeb
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string dataCopy;
        {
            string data;
            /* FLAW: Get the user ID from a URL parameter */
            data = req.Params.Get("id");
            dataCopy = data;
        }
        {
            string data = dataCopy;
            SqlConnection dBConnection = IO.GetDBConnection();
            SqlCommand preparedStatement = null;
            int id = 0;
            try
            {
                id = int.Parse(data);
            }
            catch (FormatException nfx)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, nfx, "Could not parse int, setting to -1");
                id = -1; /* Assuming this id does not exist */
            }
            try
            {
                dBConnection.Open();
                using (preparedStatement = new SqlCommand(null, dBConnection))
                {
                    preparedStatement.CommandText = "select * from invoices where uid=@id";
                    SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                    idParam.Value = id;
                    preparedStatement.ExecuteNonQuery();
                }
                /* POTENTIAL FLAW: no check to see whether the user has privileges to view the data */
                IO.WriteString("Bad() - result requested: " + data + "\n");
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error executing query");
            }
            finally
            {
                try
                {
                    if (dBConnection != null)
                    {
                        dBConnection.Close();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Could not close Connection");
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B(req, resp);
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B(HttpRequest req, HttpResponse resp)
    {
        string dataCopy;
        {
            string data;
            /* FIX: Use a hardcoded user ID */
            data = "10";
            dataCopy = data;
        }
        {
            string data = dataCopy;
            SqlConnection dBConnection = IO.GetDBConnection();
            SqlCommand preparedStatement = null;
            int id = 0;
            try
            {
                id = int.Parse(data);
            }
            catch (FormatException nfx)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, nfx, "Could not parse int, setting to -1");
                id = -1; /* Assuming this id does not exist */
            }
            try
            {
                dBConnection.Open();
                using (preparedStatement = new SqlCommand(null, dBConnection))
                {
                    preparedStatement.CommandText = "select * from invoices where uid=@id";
                    SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int, 0);
                    idParam.Value = id;
                    preparedStatement.ExecuteNonQuery();
                }
                /* POTENTIAL FLAW: no check to see whether the user has privileges to view the data */
                IO.WriteString("Bad() - result requested: " + data + "\n");
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error executing query");
            }
            finally
            {
                try
                {
                    if (dBConnection != null)
                    {
                        dBConnection.Close();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Could not close Connection");
                }
            }
        }
    }
#endif //omitgood
}
}
