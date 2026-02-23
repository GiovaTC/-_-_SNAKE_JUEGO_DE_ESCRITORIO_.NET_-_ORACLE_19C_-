using Oracle.ManagedDataAccess.Client;
using snake_game.Models;

namespace snake_game.Db
{
    public class ScoreRepository
    {
        public void SaveScore(GameScore score)
        {
            using var conn = OracleConnectionFactory.GetConnection();
            using var cmd = new OracleCommand("SP_INSERT_SCORE", conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("P_PLAYER_NAME", OracleDbType.Varchar2)
                .Value = score.PlayerName;
            cmd.Parameters.Add("P_SCORE", OracleDbType.Int32)
                .Value = score.Score;

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
