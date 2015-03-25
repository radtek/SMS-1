using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Analysis
{
    public class FileTransferProcessor
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public int Port { get; set; }

        public string DestinationFolder { get; set; }

        public int TransferAllFiles()
        {
            using (var sftp = new SftpClient(Host, Port, User, Password))
            {
                sftp.Connect();
                var files = sftp.ListDirectory("/");
                int filesTransferred = 0;
                foreach (var remoteFile in files)
                {
                    string fileName = remoteFile.Name;
                    using (var localFile = File.OpenWrite(Path.Combine(DestinationFolder, fileName)))
                    {
                        sftp.DownloadFile(fileName, localFile);
                    }

                    filesTransferred++;
                }                
                sftp.Disconnect();
                return filesTransferred;
            }
        }
    }
}
