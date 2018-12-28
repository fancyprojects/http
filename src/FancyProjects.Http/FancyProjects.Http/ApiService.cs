using System.Threading;

namespace FancyProjects.Http
{
    public class ApiService : IApiService
    {
        public int MaxAttempts { get; set; } = 3;
        public int RetryWait { get; set; } = 5000;
        private int attempts = 0;



        public TResult Get<TResult>(string url)
        {
            attempts++;
            try
            {
                var result = new HttpService().Get<TResult>(url);
                attempts = 0;
                return result;
            }
            catch (IntegrationException e)
            {
                if (attempts <= MaxAttempts)
                {
                    Thread.Sleep(RetryWait);
                    return Get<TResult>(url);
                }
                attempts = 0;
                throw e;
            }
        }

        public TResult Post<TResult>(string url, object data)
        {
            attempts++;
            try
            {
                var result = new HttpService().Post<TResult>(url, data);
                attempts = 0;
                return result;
            }
            catch (IntegrationException e)
            {
                if (attempts <= MaxAttempts)
                {
                    Thread.Sleep(RetryWait);
                    return Post<TResult>(url, data);
                }
                attempts = 0;
                throw e;
            }
        }

        public TResult Put<TResult>(string url, object data)
        {
            attempts++;
            try
            {
                var result = new HttpService().Put<TResult>(url, data);
                attempts = 0;
                return result;
            }
            catch (IntegrationException e)
            {
                if (attempts <= MaxAttempts)
                {
                    Thread.Sleep(RetryWait);
                    return Put<TResult>(url, data);
                }
                attempts = 0;
                throw e;
            }
        }

        public TResult Delete<TResult>(string url)
        {
            attempts++;
            try
            {
                var result = new HttpService().Delete<TResult>(url);
                attempts = 0;
                return result;
            }
            catch (IntegrationException e)
            {
                if (attempts <= MaxAttempts)
                {
                    Thread.Sleep(RetryWait);
                    return Get<TResult>(url);
                }
                attempts = 0;
                throw e;
            }
        }
    }
}