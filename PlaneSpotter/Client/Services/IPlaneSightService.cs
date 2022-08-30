using Microsoft.AspNetCore.Components.Forms;
using PlaneSpotter.Shared.Models;

namespace PlaneSpotter.Client.Services
{
    public interface IPlaneSightService
    {
        List<SightRecord> Records { get; set; }

        Task GetSightRecords();

        Task<SightRecord> GetSightRecord(int id);

        Task AddSightRecord(SightRecord sightRecord);

        Task UpdateSightRecord(SightRecord sightRecord);

        Task DeleteSightRecord(int id, SightRecord sightRecord);

        Task<ImageResponse?> UploadImage(MultipartFormDataContent multipart);
    }

}
