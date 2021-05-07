/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_01.cs
Label Definition File: CWE532_Inclusion_of_Sensitive_Info_in_Log__Database.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 534 Inclusion of Sensitive Information in Log Files
* Sinks:
*    GoodSink: log non-sensitive information to the debug log
*    BadSink : Expose the DB connection string (containing user ID and password) to debug log
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using NLog;
using System.Data.SqlClient;

namespace testcases.CWE532_Inclusion_of_Sensitive_Info_in_Log
{
class CWE532_Inclusion_of_Sensitive_Info_in_Log__Database_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
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
#endif //omitbad
#if (!OMITGOOD)
    public override void Good()
    {
        Good1();
    }

    private void Good1()
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
#endif //omitgood
}
}
