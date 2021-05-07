/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE197_Numeric_Truncation_Error__float_database_to_long_12.cs
Label Definition File: CWE197_Numeric_Truncation_Error__float.label.xml
Template File: sources-sink-12.tmpl.cs
*/
/*
* @description
* CWE: 197 Numeric Truncation Error
* BadSource: database Read data from a database
* GoodSource: A hardcoded non-zero, non-min, non-max, even number
* BadSink: to_long Convert data to a long
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;

namespace testcases.CWE197_Numeric_Truncation_Error
{

class CWE197_Numeric_Truncation_Error__float_database_to_long_12 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink - see how tools report flaws that don't always occur */
    public override void Bad()
    {
        float data;
        if (IO.StaticReturnsTrueOrFalse())
        {
            data = float.MinValue; /* Initialize data */
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
                                data = float.Parse(stringNumber.Trim());
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
        }
        else
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* goodG2B() - use goodsource and badsink by changing the "if" so that
     * both branches use the GoodSource */
    private void GoodG2B()
    {
        float data;
        if (IO.StaticReturnsTrueOrFalse())
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        else
        {
            /* FIX: Use a hardcoded number that won't cause underflow, overflow, divide by zero, or loss-of-precision issues */
            data = 2;
        }
        {
            /* POTENTIAL FLAW: Convert data to a long, possibly causing a truncation error */
            IO.WriteLine((long)data);
        }
    }

    public override void Good()
    {
        GoodG2B();
    }
#endif //omitgood
}
}
