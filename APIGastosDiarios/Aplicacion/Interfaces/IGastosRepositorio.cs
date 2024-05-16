using System;
using APIGastosDiarios.Modelo;

namespace APIGastosDiarios.Aplicacion.Interfaces
{
    public interface IGastosRepositorio
    {
        public Task<bool> AgregarGastos(RegistrosGastos entidad);
        public Task<IEnumerable<RegistrosGastos>> TraerTodosGastos();
        public Task<IEnumerable<RegistrosGastos>> TraerGastosPorFecha(DateTime fecha);
    }
}

