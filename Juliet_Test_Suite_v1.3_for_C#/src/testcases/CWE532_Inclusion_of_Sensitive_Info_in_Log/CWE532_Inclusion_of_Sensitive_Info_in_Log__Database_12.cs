/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_12.cs
Label Definition File: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database.label.xml
Template File: point-flaw-12.tmpl.cs
*/
/*
* @description
* CWE: 534 Inclusion of Sensitive Information in Log Files
* Sinks:
*    GoodSink: log non-sensitive information to the debug log
*    BadSink : Expose the DB connection string (containing user ID and password) to debug log
* Flow Variant: 12 Control flow: if(IO.StaticReturnsTrueOrFalse())
*
* */

using TestCaseSupport;
using System;

using NLog;
using System.Data.SqlClient;

namespace testcases.CWE532_Inclusion_of_Sensitive_Info_in_Log
{
class CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_12 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
        if (IO.StaticReturnsTrueOrFalse())
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
#endif //omitbad
#if (!OMITGOOD)
    /* Good1() changes the "if" so that both branches use the GoodSink */
    private void Good1()
    {
        if (IO.StaticReturnsTrueOrFalse())
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

    public override void Good()
    {
        Good1();
    }
#endif //omitgood
}
}
