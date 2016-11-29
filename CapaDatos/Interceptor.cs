using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;

//Mediante esta clase podemos interceptar las query que EF envía a la base de datos y loguearlas
public class Interceptor : IDbCommandInterceptor
{
    public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    {
      
    }

    public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
    {

    }

    public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {
        WriteLog(string.Format(" IsAsync: {0}, Command Text: {1}", interceptionContext.IsAsync, command.CommandText));
    }

    public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
    {

    }

    public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    {

    }

    public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
    {

    }

    private void WriteLog(string val)
    {
        StreamWriter w = new StreamWriter("C:\\datos\\query.txt", true);
        w.Write(val);
        w.Close();
    }
}