using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
using WinFormsEg.Data;

namespace WinFormsEg.Repository
{
    public static class UsersRepository
    {
        public static async Task<IEnumerable<string>> ReadData()
        {
            var sinistrosData = new List<string>();

            /*
            var queryString = @"SELECT TOP 500 CPF_SINISTRADO,
                                               DATA_AREA,
                                               USUARIO_CECAD
                                FROM SINISTROS;";
            */

            var queryString = @"SELECT *
                                FROM UserData;";

            using (var connection = new OdbcConnection(AppDbContext.connString))
            {
                var command = new OdbcCommand(queryString, connection);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                    sinistrosData.Add($"Id: {reader[0]} - First Name: {reader[1]} - Last Name: {reader[2]} - Email: {reader[3]} - Gender: {reader[4]} - Country:{reader[5]} - Job Title: {reader[6]}");

                reader.Close();
            }

            return sinistrosData.ToList();
        }
    }
}