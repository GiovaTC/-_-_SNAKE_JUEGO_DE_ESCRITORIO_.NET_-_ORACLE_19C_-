using Oracle.ManagedDataAccess.Client;

namespace snake_game.Db
{
    public static class OracleConnectionFactory
    {
        private const string  CONNECTION_STRING =
            "User Id=system;Password=Tapiero123;Data Source=localhost:1521/orcl";

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(CONNECTION_STRING);
        }   
    }
}   
