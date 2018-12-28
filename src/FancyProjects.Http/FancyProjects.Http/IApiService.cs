namespace FancyProjects.Http
{
    public interface IApiService
    {
        TResult Get<TResult>(string url);
        TResult Post<TResult>(string url, object data);
        TResult Put<TResult>(string url, object data);
        TResult Delete<TResult>(string url);
    }
}