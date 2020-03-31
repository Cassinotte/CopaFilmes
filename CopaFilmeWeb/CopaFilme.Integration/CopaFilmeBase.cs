using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CopaFilme.Integration
{

    public interface ICopaFilmeBase
    {
        Task<IEnumerable<FilmesResponse>> GetFilmesAsync(CancellationToken cancellationToken);
    }

    public class CopaFilmeBase: ICopaFilmeBase
    {
        private HttpClient _httpClient;
        private System.Lazy<JsonSerializerSettings> _settings;

        public string BaseUrl
        {
            get { return "http://copafilmes.azurewebsites.net/api"; }
        }

        public CopaFilmeBase(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(() =>
            {
                var settings = new Newtonsoft.Json.JsonSerializerSettings();
                return settings;

            });
        }

        protected struct ObjectResponseResult<T>

        {

            public ObjectResponseResult(T responseObject, string responseText)

            {

                this.Object = responseObject;

                this.Text = responseText;

            }



            public T Object { get; }



            public string Text { get; }

        }

        protected virtual async System.Threading.Tasks.Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers)

        {

            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            try
            {

                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))

                using (var streamReader = new System.IO.StreamReader(responseStream))

                using (var jsonTextReader = new Newtonsoft.Json.JsonTextReader(streamReader))

                {

                    var serializer = Newtonsoft.Json.JsonSerializer.Create(_settings.Value);

                    var typedBody = serializer.Deserialize<T>(jsonTextReader);

                    return new ObjectResponseResult<T>(typedBody, string.Empty);

                }

            }

            catch (JsonException exception)

            {

                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";

                throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);

            }



        }

        public async Task<IEnumerable<FilmesResponse>> GetFilmesAsync(CancellationToken cancellationToken)
        {
            var urlBuilder_ = new System.Text.StringBuilder();

            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/filmes");

            var client_ = _httpClient;

            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Method = new System.Net.Http.HttpMethod("GET");

                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    var url_ = urlBuilder_.ToString();

                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);

                        if (response_.Content != null && response_.Content.Headers != null)

                        {

                            foreach (var item_ in response_.Content.Headers)

                                headers_[item_.Key] = item_.Value;

                        }

                        var status_ = ((int)response_.StatusCode).ToString();

                        if (status_ == "200")
                        {

                            var objectResponse_ = await ReadObjectResponseAsync<IEnumerable<FilmesResponse>>(response_, headers_).ConfigureAwait(false);

                            return objectResponse_.Object;

                        }

                        else

                        if (status_ == "404")

                        {

                            string responseText_ = (response_.Content == null) ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);

                            throw new ApiException("Not found", (int)response_.StatusCode, responseText_, headers_, null);

                        }

                        else

                        if (status_ != "200" && status_ != "204")

                        {

                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);

                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);

                        }



                        return default;

                    }

                    finally

                    {

                        if (response_ != null)

                            response_.Dispose();

                    }

                }

            }

            finally

            {

            }

        }


    }

    public partial class ApiException : System.Exception

    {

        public int StatusCode { get; private set; }



        public string Response { get; private set; }



        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }



        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)

            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + response.Substring(0, response.Length >= 512 ? 512 : response.Length), innerException)

        {

            StatusCode = statusCode;

            Response = response;

            Headers = headers;

        }



        public override string ToString()

        {

            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());

        }

    }




    public class FilmesResponse
    {
        public string id { get; set; }
        public string titulo { get; set; }
        public int ano { get; set; }
        public double nota { get; set; }
    }
}
