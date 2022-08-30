using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PlaneSpotter.Server.Services.Impl
{
    public class SightRecordServiceImpl : ISightRecordService
    {
        private readonly DataContext _dbContext;
        private readonly IWebHostEnvironment _env;

        public SightRecordServiceImpl(IWebHostEnvironment env, DataContext dataContext )
        {
            _dbContext = dataContext;
            _env = env;
        }

        public async Task<SightRecord?> AddSightRecord(SightRecord sightRecord)
        {
            _dbContext.SightRecords.Add(sightRecord);
            var i = await _dbContext.SaveChangesAsync();
            return sightRecord;
        }

        public async Task<bool> DeleteSightRecord(int id)
        {
            var sight = await _dbContext.SightRecords.FirstOrDefaultAsync(s => s.Id == id);
            if (sight == null)
                return false;

            _dbContext.SightRecords.Remove(sight);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<SightRecord?> GetSightRecord(int id)
        {
            var sight = await _dbContext.SightRecords.FirstOrDefaultAsync(x => x.Id == id);
           return sight;
        }

        public async Task<List<SightRecord>> GetSightRecords()
        {

            var sights = await _dbContext.SightRecords.ToListAsync();
            return sights;
        }

        public async Task<SightRecord?> UpdateSightRecord(SightRecord sightRecord)
        {
            var sight = await _dbContext.SightRecords.FirstOrDefaultAsync(s => s.Id == sightRecord.Id);
            if (sight == null)
                return null;

            sight.Make = sightRecord.Make;
            sight.Model= sightRecord.Model;
            sight.Registration = sightRecord.Registration;
            sight.Location = sightRecord.Location;
            sight.DateTime = sightRecord.DateTime;

            await _dbContext.SaveChangesAsync();

            return sight;
        }

        public async Task<ImageResponse?> UploadImage(IFormFile file)
        {
            string trustedFileNameForFileStorage;
            var untrustedFileName = file.FileName;

            trustedFileNameForFileStorage = Path.GetRandomFileName();
            var path = Path.Combine(_env.ContentRootPath, "Images", trustedFileNameForFileStorage);

            await using FileStream fs = new(path, FileMode.Create);
            await file.CopyToAsync(fs);

            return new ImageResponse { Name = untrustedFileName, Url = $@".\Images\{untrustedFileName}"};
        }

        public async Task<dynamic> GetImage(string name)
        {
            var uploadResult = await _dbContext.SightRecords
                .FirstOrDefaultAsync(u => u.ImagePath!=null && u.ImagePath.Equals(name));

            var path = Path.Combine(_env.ContentRootPath, "Images", name);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return new { memory = memory, path = Path.GetFileName(path) };
        }
    }
}
