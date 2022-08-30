using Microsoft.AspNetCore.Components.Forms;
using PlaneSpotter.Shared.Models;
using System.Net.Http.Json;

namespace PlaneSpotter.Client.Services.Impl
{
    public class PlaneSightServiceImpl : IPlaneSightService
    {
        private readonly HttpClient _http;

        public PlaneSightServiceImpl(HttpClient http)
        {
            _http = http;
        }

        public List<SightRecord> Records { get; set; } = new List<SightRecord>();

        public async Task AddSightRecord(SightRecord sightRecord)
        {
            var data = await _http.PostAsJsonAsync("api/sightrecord/add",sightRecord);
            if (data.IsSuccessStatusCode) 
            {
                var returnValue = await data.Content.ReadFromJsonAsync<SightRecord>();
                if (returnValue!= null)
                {
                    Records.Add(returnValue);
                }
            }
      
        }

        public async Task DeleteSightRecord(int id,SightRecord sightRecord)
        {
            var data = await _http.DeleteAsync($"api/sightrecord/{id}");
            if (data.IsSuccessStatusCode) 
            {
                Records.Remove(sightRecord);
            }
            return ;
        }

        public async Task<SightRecord> GetSightRecord(int id)
        {
            var data = await _http.GetFromJsonAsync<SightRecord>($"api/sightrecord/{id}");
            if (data != null) return data;
            throw new Exception("Sight record not found!");
        }

        public async Task GetSightRecords()
        {
            var data =await _http.GetFromJsonAsync<List<SightRecord>>("api/sightrecord/all");
            if (data != null) Records = data;
        }

        public async Task UpdateSightRecord(SightRecord sightRecord)
        {
            var data = await _http.PutAsJsonAsync("api/sightrecord/edit", sightRecord);
            if (data.IsSuccessStatusCode)
            {
                var returnValue = await data.Content.ReadFromJsonAsync<SightRecord>();
                if (returnValue != null)
                {
                    var obj = Records.FirstOrDefault(x => x.Id == returnValue.Id);
                    if (obj != null) obj = returnValue;
                }
            }
        }

        public async Task<ImageResponse?> UploadImage(MultipartFormDataContent multipart)
        {
            var data = await _http.PostAsync("api/sightrecord/upload", multipart);
            if (data.IsSuccessStatusCode)
            {
                if (data.Content != null) 
                {
                    var response = await data.Content.ReadFromJsonAsync<ImageResponse>();
                    if (response != null) return response; 

                }
            }
            return null;
        }
    }
}
