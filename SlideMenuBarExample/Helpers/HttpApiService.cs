﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace SlideMenuBarExample.Helpers
{
    public class HttpApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public HttpApiService(string baseAddress)
        {
            // HttpClient의 BaseAddress 설정
            httpClient.BaseAddress = new Uri(baseAddress);
        }

        /// <summary>
        /// 지정한 URL로 POST 요청을 보내고, 결과를 HttpResponseMessage로 반환한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostAsync<T>(string url, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(url, content);

        }

        /// <summary>
        /// 지정한 URL로 GET 요청을 보내고, 결과를 HttpResponseMessage로 반환한다.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await httpClient.GetAsync(url);
        }

        // ++ 추가적으로 PUT, DELETE 등의 메서드를 필요에 따라 구현할 수 있다.

    }
}
