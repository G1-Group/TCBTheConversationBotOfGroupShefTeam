using Npgsql;

namespace TCB.Aplication.DataProviderFolder;

public class DataProvider
{
    private readonly string _cannectionString;

    public DataProvider(string cannectionString)
    {
        _cannectionString = cannectionString;
    }

    public NpgsqlConnection CreateNewNpgsqlConnection()
    {
        return new NpgsqlConnection(this._cannectionString);
    }

    public async Task<NpgsqlDataReader> ExecuteWithResult(string query, NpgsqlParameter[]? parameters)
    {
        var connection = this.CreateNewNpgsqlConnection();
        await connection.OpenAsync();

        var cammond = new NpgsqlCommand(query, connection);
        if(cammond is not null)
            cammond.Parameters.AddRange(parameters);

        var result =await cammond.ExecuteReaderAsync();


        return result;

    }

    public async Task<int> ExecuteNonResult(string query, NpgsqlParameter[]? parameters)
    {
        var connection = this.CreateNewNpgsqlConnection();

        await connection.OpenAsync();

        var cammond = new NpgsqlCommand(query, connection);
        if(cammond is not null)
            cammond.Parameters.AddRange(parameters);

        var result = await cammond.ExecuteNonQueryAsync();

        return result;
    }




}