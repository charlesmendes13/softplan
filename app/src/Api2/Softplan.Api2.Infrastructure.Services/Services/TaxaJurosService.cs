﻿using Softplan.Api2.Domain;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;

namespace Softplan.Api2.Infrastructure
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public TaxaJurosService(IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<decimal> ObterAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient(_configuration["Api1:Instance"]);
                var response = await client.GetAsync("api/TaxaJuros");

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<decimal>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível obter a Taxa de Jutos", ex);
            }            
        }
    }
}
