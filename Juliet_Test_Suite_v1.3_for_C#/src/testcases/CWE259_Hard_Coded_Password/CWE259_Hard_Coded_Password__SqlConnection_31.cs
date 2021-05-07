/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE259_Hard_Coded_Password__SqlConnection_31.cs
Label Definition File: CWE259_Hard_Coded_Password.label.xml
Template File: sources-sink-31.tmpl.cs
*/
/*
 * @description
 * CWE: 259 Hard Coded Password
 * BadSource: hardcodedPassword Set data to a hardcoded string
 * GoodSource: Read data from the console using readLine()
 * Sinks: SqlConnection
 *    BadSink : data used as password in database connection
 * Flow Variant: 31 Data flow: make a copy of data within the same method
 *
 * */

using TestCaseSupport;
using System;

using System.Data.SqlClient;

using System.IO;

namespace testcases.CWE259_Hard_Coded_Password
{

class CWE259_Hard_Coded_Password__SqlConnection_31 : AbstractTestCase
{
#if (!OMITBAD)
    /* uses badsource and badsink */
    public override void Bad()
    {
        string dataCopy;
        {
            string data;
            /* FLAW: Set data to a hardcoded string */
            data = "7e5tc4s3";
            dataCopy = data;
        }
        {
            string data = dataCopy;
            if (data != null)
            {
                try
                {
                    /* POTENTIAL FLAW: data used as password in database connection */
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + data))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
                }
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        GoodG2B();
    }

    /* goodG2B() - use goodsource and badsink */
    private void GoodG2B()
    {
        string dataCopy;
        {
            string data;
            data = ""; /* init data */
            /* FIX: Read data from the console using ReadLine() */
            try
            {
                /* POTENTIAL FLAW: Read data from the console using ReadLine */
                data = Console.ReadLine();
            }
            catch (IOException exceptIO)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error with stream reading", exceptIO);
            }
            dataCopy = data;
        }
        {
            string data = dataCopy;
            if (data != null)
            {
                try
                {
                    /* POTENTIAL FLAW: data used as password in database connection */
                    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=CWE256;User ID=" + "sa" + ";Password=" + data))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("select * from test_table", connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error with database connection", exceptSql);
                }
            }
        }
    }
#endif //omitgood
}
}
