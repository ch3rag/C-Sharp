using System;
using System.Data.Entity.Infrastructure.Interception;

namespace AutoLotDALEF.Interception {
    public class ConsoleWriterInterceptor : IDbCommandInterceptor {

        public void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);
        }

        public void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext) {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);
        }

        public void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext) {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);
        }

        public void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext) {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);
        }

        public void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);
        }

        public void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext) {
            WriteInfo(interceptionContext.IsAsync, command.CommandText);
        }

        private void WriteInfo(bool isAsync, string commandText) {
            Console.WriteLine("IsAsync: {0}, Command Text: {1}", isAsync, commandText);
        }
    }
}
