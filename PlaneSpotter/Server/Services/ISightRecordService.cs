using Microsoft.AspNetCore.Mvc;
using PlaneSpotter.Shared.Models;

namespace PlaneSpotter.Server.Services
{
    public interface ISightRecordService
    {
        Task<List<SightRecord>> GetSightRecords();

        Task<SightRecord?> GetSightRecord(int id);

        Task<SightRecord?> AddSightRecord(SightRecord sightRecord);

        Task<SightRecord?> UpdateSightRecord(SightRecord sightRecord);        
        Task<ImageResponse?> UploadImage(IFormFile file);

        Task<dynamic> GetImage(string name);

        Task<bool> DeleteSightRecord(int id);
    }

}
