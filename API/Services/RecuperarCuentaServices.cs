using API.Interfaces;
using Commons.Helpers;
using Data.Dto;
using Data.Entities;
using Data.Managers;

namespace API.Services
{
    public class RecuperarCuentaServices : IRecuperarCuentaServices
    {
        private readonly RecuperarCuentaManager _manager;

        public RecuperarCuentaServices()
        {
            _manager = new RecuperarCuentaManager();
        }

        public Usuarios BuscarUsuario(LoginDto login)
        {
            try
            {
                var respuesta = _manager.BuscarUsuario(login);
                return respuesta;
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RecuperarCuentaServices", "BuscarUsuario");
                throw;
            }
        }

        public bool GuardarCodigo(Usuarios usuario)
        {
            try
            {
                var respuesta = _manager.Guardar(usuario, usuario.Id);
                return respuesta.Result;
            }
            catch (Exception ex)
            {
                GenerateLogHelper.LogError(ex, "RecuperarCuentaServices", "GuardarCodigo");
                throw;
            }
        }

    }
}
