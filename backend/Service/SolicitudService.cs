namespace backend.Service;

public class SolicitudService(IConfiguration configuration) : ISolicitudService
{
    private readonly List<Solicitud> _solicitudes = [];

    public async Task<List<Solicitud>> GetAllAsync()
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "SELECT id, titulo ,descripcion, prioridad, estado FROM solicitud";
            var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                var solicitud = new Solicitud
                {
                    Id = reader.GetInt32(0),
                    Titulo = reader.GetString(1),
                    Descripcion = reader.GetString(2),
                    Prioridad = reader.GetString(3),
                    Estado = reader.GetString(4),
                };
                _solicitudes.Add(solicitud);
            }
            return _solicitudes;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener las solicitudes: {ex.Message}");
        }
    }

    public async Task<Solicitud?> GetByIdAsync(int id)
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText =
                "SELECT id, titulo, descripcion, prioridad, estado FROM solicitud Where id = :id";
            cmd.Parameters.Add(new OracleParameter("id", id));
            var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                if (reader.GetInt32(0) == id)
                {
                    var solicitud = new Solicitud
                    {
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Prioridad = reader.GetString(3),
                        Estado = reader.GetString(4),
                    };
                    return solicitud;
                }
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener la solicitud con ID {id}: {ex.Message}");
        }
    }

    public async Task<Solicitud?> CreateAsync(NewSolicitud solicitud)
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText =
                "INSERT INTO solicitud (titulo, descripcion, prioridad, estado) VALUES (:titulo, :descripcion, :prioridad, :estado)";
            cmd.Parameters.Add(new OracleParameter("titulo", solicitud.Titulo));
            cmd.Parameters.Add(new OracleParameter("descripcion", solicitud.Descripcion));
            cmd.Parameters.Add(new OracleParameter("prioridad", solicitud.Prioridad.ToString()));
            cmd.Parameters.Add(new OracleParameter("estado", "Pendiente"));
            var reader = await cmd.ExecuteReaderAsync();
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al crear {ex.Message}");
        }
    }

    public async Task<Solicitud?> UpdateAsync(Solicitud solicitud)
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText =
                "UPDATE solicitud SET titulo = :titulo, descripcion = :descripcion, prioridad = :prioridad, estado = :estado WHERE id = :id";
            cmd.Parameters.Add(new OracleParameter("titulo", solicitud.Titulo));
            cmd.Parameters.Add(new OracleParameter("descripcion", solicitud.Descripcion));
            cmd.Parameters.Add(new OracleParameter("prioridad", solicitud.Prioridad.ToString()));
            cmd.Parameters.Add(new OracleParameter("estado", solicitud.Estado));
            cmd.Parameters.Add(new OracleParameter("id", solicitud.Id));
            var reader = await cmd.ExecuteReaderAsync();
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al updated con ID {solicitud.Id}: {ex.Message}");
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM solicitud WHERE id = :id";
            cmd.Parameters.Add(new OracleParameter("id", id));
            var rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la solicitud con ID {id}: {ex.Message}");
        }
    }

    public async Task<Solicitud?> ChangeEstadoAsync(int id, string estado)
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE solicitud SET estado = :estado WHERE id = :id";
            cmd.Parameters.Add(new OracleParameter("estado", estado));
            cmd.Parameters.Add(new OracleParameter("id", id));
            var rowsAffected = cmd.ExecuteNonQuery();
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la solicitud con ID {id}: {ex.Message}");
        }
    }

    public async Task<Solicitud?> ChangePrioridadAsync(int id, string prioridad)
    {
        var connectionString = configuration.GetConnectionString("OracleDb");
        try
        {
            var con = new OracleConnection(connectionString);
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE solicitud SET prioridad = :prioridad WHERE id = :id";
            cmd.Parameters.Add(new OracleParameter("prioridad", prioridad));
            cmd.Parameters.Add(new OracleParameter("id", id));
            var rowsAffected = cmd.ExecuteNonQuery();
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al eliminar la solicitud con ID {id}: {ex.Message}");
        }
    }
}
