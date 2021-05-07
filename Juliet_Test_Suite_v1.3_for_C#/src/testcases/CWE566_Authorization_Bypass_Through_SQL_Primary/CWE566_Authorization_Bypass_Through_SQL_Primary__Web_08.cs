/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE566_Authorization_Bypass_Through_SQL_Primary__Web_08.cs
Label Definition File: CWE566_Authorization_Bypass_Through_SQL_Primary__Web.label.xml
Template File: sources-sink-08.tmpl.cs
*/
/*
* @description
* CWE: 566 Authorization Bypass through SQL primary
* BadSource:  user id taken from url parameter
* GoodSource: hardcoded user id
* BadSink: writeConsole user authorization not checked
* Flow Variant: 08 Control flow: if(PrivateReturnsTrue()) and if(PrivateReturnsFalse())
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;
using System.Data;

using System.Web;

namespace testcases.CWE566_Authorization_Bypass_Through_SQL_Primary
{

class CWE566_Authorization_Bypass_Through_SQL_Primary__Web_08 : AbstractTestCaseWeb
{

    /* The methods below always return the same value, so a tool
     * should be able to figure out that every call to these
     * methods will return true or return false.
     */
    private static bool PrivateReturnsTrue()
    {
        return true;
    }

    private static bool PrivateReturnsFalse()
    {
        return false;
    }
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* FLAW: Get the user ID from a URL parameter */
            data = req.Params.Get("id");
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
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
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B1() - use goodsource and badsink by changing PrivateReturnsTrue() to PrivateReturnsFalse() */
    private void GoodG2B1(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsFalse())
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
        else
        {
            /* FIX: Use a hardcoded user ID */
            data = "10";
        }
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

    /* GoodG2B2() - use goodsource and badsink by reversing statements in if */
    private void GoodG2B2(HttpRequest req, HttpResponse resp)
    {
        string data;
        if (PrivateReturnsTrue())
        {
            /* FIX: Use a hardcoded user ID */
            data = "10";
        }
        else
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run
             * but ensure data is inititialized before the Sink to avoid compiler errors */
            data = null;
        }
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

    public override void Good(HttpRequest req, HttpResponse resp)
    {
        GoodG2B1(req, resp);
        GoodG2B2(req, resp);
    }
#endif //omitgood
}
}
