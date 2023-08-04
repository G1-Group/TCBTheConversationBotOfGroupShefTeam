using Npgsql;

namespace TCB.Aplication.DataProviderFolder;

public class DataProvider
{
    private readonly string _cannectionString;

    public DataProvider(string cannectionString)
    {
        _cannectionString = cannectionString;
    }

    public NpgsqlConnection CreateConnection()
    {
        return new NpgsqlConnection(this._cannectionString);
    }

    public async Task<NpgsqlDataReader> ExecuteWithResult(string query, NpgsqlParameter[]? parameters)
    {
        var connection = this.CreateConnection();
        await connection.OpenAsync();

        var command = new NpgsqlCommand(query, connection);
        if(command is not null)
            command.Parameters.AddRange(parameters);

        var result =await command.ExecuteReaderAsync();


        return result;

    }

    public async Task<int> ExecuteNonResult(string query, NpgsqlParameter[]? parameters)
    {
        var connection = this.CreateConnection();

        await connection.OpenAsync();

        var command = new NpgsqlCommand(query, connection);
        if(command is not null)
            command.Parameters.AddRange(parameters);

        var result = await command.ExecuteNonQueryAsync();

        return result;
    }




}