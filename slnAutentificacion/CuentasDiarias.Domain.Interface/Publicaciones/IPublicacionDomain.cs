using CuentasDiarias.Domain.Entity;
using CuentasDiarias.Domain.Entity.Publicaciones;

namespace CuentasDiarias.Domain.Interface.Publicaciones
{
    public interface IPublicacionDomain
    {
        bool Insert(Publicacione publicacion);

        bool Update(Publicacione publicacion);

        bool Delete(int Id);
        Publicacione Get(int id);
        IEnumerable<Publicacione> GetAll();

        #region "Asincronos"
        Task<bool> InsertAsync(Publicacione entity);

        Task<bool> UpdateAsync(Publicacione entity);

        Task<bool> DeleteAsync(int Id);
        Task<Publicacione> GetAsync(int id);
        Task<IEnumerable<Publicacione>> GetAllAsync();
        #endregion
    }
}
