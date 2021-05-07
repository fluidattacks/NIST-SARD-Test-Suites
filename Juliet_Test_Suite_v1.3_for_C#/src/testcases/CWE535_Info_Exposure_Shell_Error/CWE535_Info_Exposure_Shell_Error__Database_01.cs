/* TEMPLATE GENERATED TESTCASE FILE
Filename: CWE535_Info_Exposure_Shell_Error__Database_01.cs
Label Definition File: CWE535_Info_Exposure_Shell_Error__Database.label.xml
Template File: point-flaw-01.tmpl.cs
*/
/*
* @description
* CWE: 535 Information Exposure through Shell Error
* Sinks:
*    GoodSink: write non-sensitive information to Console.WriteLine
*    BadSink : Expose the DB connection string to Console.WriteLine
* Flow Variant: 01 Baseline
*
* */

using TestCaseSupport;
using System;

using System.Data.SqlClient;

namespace testcases.CWE535_Info_Exposure_Shell_Error
{
class CWE535_Info_Exposure_Shell_Error__Database_01 : AbstractTestCase
{
#if (!OMITBAD)
    public override void Bad()
    {
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
            /* FLAW: Expose the DB connection string (containing user ID and password) to Console */
            Console.WriteLine("Error getting database connection: " + dbConnectionString);
            Console.WriteLine(exceptSql);
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
            /* FIX: Message written to Console does not contain the DB connection string */
            Console.WriteLine(exceptSql);
        }
    }
#endif //omitgood
}
}
