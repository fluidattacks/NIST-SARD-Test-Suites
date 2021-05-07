/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__long_database_to_short_72a.cs
Label Definition File: CWE197_Numeric_Truncation_Error__long.label.xml
Template File: sources-sink-72a.tmpl.cs
*/
/*
 * @description
 * CWE: 197 Numeric Truncation Error
 * BadSource: database Read data from a database
 * GoodSource: A hardcoded non-zero, non-min, non-max, even number
 * Sinks: to_short
 *    BadSink : Convert data to a short
 * Flow Variant: 72 Data flow: data passed in a Hashtable from one method to another in different source files in the same package
 *
 * */

using TestCaseSupport;
using System.Collections;
using System;

using System.Data.SqlClient;

namespace testcases.CWE197_Numeric_Truncation_Error
{
class CWE197_Numeric_Truncation_Error__long_database_to_short_72a : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        long data;
        data = long.MinValue; /* Initialize data */
        /* Read data from a database */
        {
            SqlConnection connection = null;
            SqlDataReader dr = null;
            try
            {
                /* setup the connection */
                using (connection = IO.GetDBConnection())
                {
                    connection.Open();
                    /* prepare and execute a (hardcoded) query */
                    SqlCommand command = new SqlCommand(null, connection);
                    command.CommandText = "select name from users where id=0";
                    command.Prepare();
                    dr = command.ExecuteReader();
                    /* FLAW: Read data from a database query SqlDataReader */
                    string stringNumber = dr.GetString(1);
                    if (stringNumber != null) /* avoid NPD incidental warnings */
                    {
                        try
                        {
                            data = long.Parse(stringNumber.Trim());
                        }
                        catch (FormatException exceptNumberFormat)
                        {
                            IO.Logger.Log(NLog.LogLevel.Warn, exceptNumberFormat, "Number format exception parsing data from string");
                        }
                    }
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error with SQL statement");
            }
            finally
            {
                /* Close database objects */
                try
                {
                    if (dr != null)
                    {
                        dr.Close();
                    }
                }
                catch (Exception except) /* INCIDENTAL: CWE 396 Catch Generic Exception */
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, except, "Error closing SqlDataReader");
                }

                try
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, exceptSql, "Error closing Connection");
                }
            }
        }
        Hashtable dataHashtable = new Hashtable(5);
        dataHashtable.Add(0, data);
        dataHashtable.Add(1, data);
        dataHashtable.Add(2, data);
        CWE197_Numeric_Truncation_Error__long_database_to_short_72b.BadSink(dataHashtable  );
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - use goodsource and badsink */
    private static void GoodG2B()
    {
        long data;
        /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
        data = 2;
        Hashtable dataHashtable = new Hashtable(5);
        dataHashtable.Add(0, data);
        dataHashtable.Add(1, data);
        dataHashtable.Add(2, data);
        CWE197_Numeric_Truncation_Error__long_database_to_short_72b.GoodG2BSink(dataHashtable  );
    }
#endif //omitgood
}
}
