/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_14.cs
Label Definition File: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database.label.xml
Template File: point-flaw-14.tmpl.cs
*/
/*
* @description
* CWE: 534 Inclusion of Sensitive Information in Log Files
* Sinks:
*    GoodSink: log non-sensitive information to the debug log
*    BadSink : Expose the DB connection string (containing user ID and password) to debug log
* Flow Variant: 14 Control flow: if(IO.staticFive==5) and if(IO.staticFive!=5)
*
* */

using TestCaseSupport;
using System;

using NLog;
using System.Data.SqlClient;

namespace testcases.CWE532_Inclusion_of_Sensitive_Info_in_Log
{
class CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_14 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.staticFive == 5)
        {
            Logger logger = LogManager.GetLogger("cwe_testcases_logger");
            string dbConnectionString = @"Data Source=(local);Initial Catalog=CWE256;User ID=sa;Password=P@ssW0rd";
            try
            {
                using (SqlConnection dBConnection = new SqlConnection(dbConnectionString))
                {
                    dBConnection.Open();
                }
            }
            catch (SqlException exceptSql)
            {
                /* FLAW: Expose the DB connection string (containing user ID and password) to debug log */
                logger.Log(LogLevel.Warn, "Error getting database connection: " + dbConnectionString, exceptSql);
            }
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes IO.staticFive==5 to IO.staticFive!=5 */
    private void Good1()
    {
        if (IO.staticFive != 5)
        {
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
        }
        else
        {
            Logger logger = LogManager.GetLogger("cwe_testcases_logger");
            string dbConnectionString = @"Data Source=(local);Initial Catalog=CWE256;User ID=sa;Password=P@ssW0rd";
            try
            {
                using (SqlConnection dBConnection = new SqlConnection(dbConnectionString))
                {
                    dBConnection.Open();
                }
            }
            catch (SqlException exceptSql)
            {
                /* FIX: Log non-sensitive information to the debug log */
                logger.Log(LogLevel.Warn, "Error getting database connection", exceptSql);
            }
        }
    }

    /* Good2() reverses the bodies in the if statement */
    private void Good2()
    {
        if (IO.staticFive == 5)
        {
            Logger logger = LogManager.GetLogger("cwe_testcases_logger");
            string dbConnectionString = @"Data Source=(local);Initial Catalog=CWE256;User ID=sa;Password=P@ssW0rd";
            try
            {
                using (SqlConnection dBConnection = new SqlConnection(dbConnectionString))
                {
                    dBConnection.Open();
                }
            }
            catch (SqlException exceptSql)
            {
                /* FIX: Log non-sensitive information to the debug log */
                logger.Log(LogLevel.Warn, "Error getting database connection", exceptSql);
            }
        }
    }

    public override void Good()
    {
        Good1();
        Good2();
    }
#endif //omitgood
}
}
