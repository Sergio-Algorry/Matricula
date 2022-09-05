namespace Matricula.Client.Servicios
{
    public interface IHttpService
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}