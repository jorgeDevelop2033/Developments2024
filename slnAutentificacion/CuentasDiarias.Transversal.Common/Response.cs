using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
namespace CuentasDiarias.Transversal.Common
{
    public class Response<T>
    {
        //informacion que va exponer la web api
        public T Data { get; set; } //metodos del dominio la informacion
        public bool IsSuccess { get; set; } // almacena del estado de la ejecuccion
        public string Message { get; set; } //Informacion del tipo de la operacin se ejecuto o no correctamente
        //public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}