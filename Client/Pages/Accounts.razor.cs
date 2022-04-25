using BusinessLogicLayer.DTO.AccountDTOs;
using Client.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Client.Pages
{
    public partial class Accounts
    {
        private List<AccountInfoResponse> _Accounts = new();

        [Inject] private HttpClient _httpClient { get; set; }
        [Inject] private IConfiguration _config { get; set; }
        [Inject] private ITokenService TokenService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenResponse = await TokenService.GetTokenAsync("AccountAPI.read");
            _httpClient.SetBearerToken(tokenResponse.AccessToken);

            var result = await _httpClient.GetAsync(_config["apiUrl"] + "/api/Account/getAll");

            if(result.IsSuccessStatusCode) _Accounts = await result.Content.ReadFromJsonAsync<List<AccountInfoResponse>>();
        }
    }
}
