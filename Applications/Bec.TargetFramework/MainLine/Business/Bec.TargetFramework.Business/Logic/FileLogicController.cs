using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure;
using nClam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    public class FileLogicController : LogicBase
    {
        public ClamClient ClamClient { get; set; }

        public async Task<ClamScanResult> UploadFile(FileDTO file)
        {
            var res = ScanByteArrayForVirus(file.Data);
            if (res.Result == ClamScanResults.Clean)
            {
                using (var scope = DbContextScopeFactory.Create())
                {
                    scope.DbContexts.Get<TargetFrameworkEntities>().Files.Add(file.ToEntity());
                    await scope.SaveChangesAsync();
                }
            }
            return res;
        }

        public async Task ClearUnusedFiles(Guid uaoID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var items = scope.DbContexts.Get<TargetFrameworkEntities>().Files.Where(x => x.ParentID == uaoID);
                scope.DbContexts.Get<TargetFrameworkEntities>().Files.RemoveRange(items);
                await scope.SaveChangesAsync();
            }
        }

        public FileDTO DownloadFile(Guid uaoID, Guid fileID)
        {
            //TODO: access controls based on uao & file parent etc
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().Files.Where(x => x.FileID == fileID).Single().ToDto();
            }
        }

        public async Task RemovePendingUpload(Guid uaoID, string filename)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var file = scope.DbContexts.Get<TargetFrameworkEntities>().Files.Where(x => x.ParentID == uaoID && x.Name == filename).FirstOrDefault();
                scope.DbContexts.Get<TargetFrameworkEntities>().Files.Remove(file);
                await scope.SaveChangesAsync();
            }
        }

        public ClamScanResult ScanForVirus(ScanBytesDTO data)
        {
            return ScanByteArrayForVirus(data.Data);
        }

        private ClamScanResult ScanByteArrayForVirus(byte[] data)
        {
            return ClamClient.SendAndScanFile(data);
        }

    }
}
