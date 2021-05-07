/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_15.cs
Label Definition File: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database.label.xml
Template File: point-flaw-15.tmpl.cs
*/
/*
* @description
* CWE: 534 Inclusion of Sensitive Information in Log Files
* Sinks:
*    GoodSink: log non-sensitive information to the debug log
*    BadSink : Expose the DB connection string (containing user ID and password) to debug log
* Flow Variant: 15 Control flow: switch(7)
*
* */

using TestCaseSupport;
using System;

using NLog;
using System.Data.SqlClient;

namespace testcases.CWE532_Inclusion_of_Sensitive_Info_in_Log
{
class CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_15 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        switch (7)
        {
        case 7:
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
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        }
    }
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() change the switch to switch(8) */
    private void Good1()
    {
        switch (8)
        {
        case 7:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
        default:
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
            break;
        }
    }

    /* Good2() reverses the blocks in the switch  */
    private void Good2()
    {
        switch (7)
        {
        case 7:
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
            break;
        default:
            /* INCIDENTAL: CWE 561 Dead Code, the code below will never run */
            IO.WriteLine("Benign, fixed string");
            break;
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
