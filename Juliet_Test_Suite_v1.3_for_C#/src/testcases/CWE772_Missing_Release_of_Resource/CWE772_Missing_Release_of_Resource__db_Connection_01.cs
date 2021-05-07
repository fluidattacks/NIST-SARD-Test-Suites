/*
 * @description Missing Release of Resource After Effective Lifetime.  Performs some, but not all, necessary resource cleanup (DB connection is not closed).
 * 
 * */

using System;
using System.Data.SqlClient;
using TestCaseSupport;

namespace testcases.CWE772_Missing_Release_of_Resource
{
    class CWE772_Missing_Release_of_Resource__db_Connection_01 : AbstractTestCase
    {
#if (!OMITBAD)
        public override void Bad()
        {
            SqlConnection dBConnection = null;
            SqlCommand command = null;
            SqlDataReader dr = null;

            try
            {
                int intId = (new Random()).Next(200);

                dBConnection = IO.GetDBConnection();
                command = new SqlCommand("select * from users where id=?");

                dBConnection.Open();
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    IO.WriteLine(dr[0].ToString());
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error!", exceptSql);
            }
            /* FLAW: DB objects are never closed */
        }
#endif // OMITBAD

#if (!OMITGOOD)
        public void Good1()
        {
            SqlConnection dBConnection = null;
            SqlCommand command = null;
            SqlDataReader dr = null;

            try
            {
                int intId = (new Random()).Next(200);

                dBConnection = IO.GetDBConnection();
                command = new SqlCommand("select * from users where id=?");

                dBConnection.Open();
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    IO.WriteLine(dr[0].ToString());
                }
            }
            catch (SqlException exceptSql)
            {
                IO.Logger.Log(NLog.LogLevel.Warn, "Error!", exceptSql);
            }
            finally
            /* FIX: Closing DB objects */
            {
                if (dr != null)
                {
                    dr.Close();
                }

                if (command != null)
                {
                    command.Dispose();
                }

                try
                {
                    if (dBConnection != null)
                    {
                        dBConnection.Close();
                    }
                }
                catch (SqlException exceptSql)
                {
                    IO.Logger.Log(NLog.LogLevel.Warn, "Error closing Connection", exceptSql);
                }
            }
        }

        public override void Good()
        {
            Good1();
        }
#endif // OMITGOOD

}
}
