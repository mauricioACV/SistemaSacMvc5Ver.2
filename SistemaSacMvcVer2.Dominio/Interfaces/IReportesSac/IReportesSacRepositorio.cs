using SistemaSacMvcVer2.Dominio.Entidades;

namespace SistemaSacMvcVer2.Dominio.Interfaces.IReportesSac
{
    public interface IReportesSacRepositorio
    {
        ReportesSac ObtenerReporteBasicoObrasPorCodigoCarpeta(string pCodigoCarpeta);
    }
}
