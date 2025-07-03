namespace backend.Model;

public interface ISolicitudService
{
    Task<List<Solicitud>> GetAllAsync();
    Task<Solicitud?> GetByIdAsync(int id);
    Task<Solicitud> CreateAsync(NewSolicitud solicitud);
    Task<Solicitud?> UpdateAsync(Solicitud solicitud);
    Task<bool> DeleteAsync(int id);

    Task<Solicitud?> ChangeEstadoAsync(int id, string estado);
    Task<Solicitud?> ChangePrioridadAsync(int id, string prioridad);


}
