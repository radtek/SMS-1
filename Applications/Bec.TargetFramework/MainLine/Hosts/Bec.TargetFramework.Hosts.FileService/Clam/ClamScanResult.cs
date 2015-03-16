﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Bec.TargetFramework.Hosts.FileService.Clam
{
    public class ClamScanResult
    {
        /// <summary>
        /// The raw string returned by the ClamAV server.
        /// </summary>
        public string RawResult { get; private set; }

        /// <summary>
        /// The parsed results of scan.
        /// </summary>
        public ClamScanResults Result { get; private set; }

        /// <summary>
        /// List of infected files with what viruses they are infected with. Null if the Result is not VirusDetected.
        /// </summary>
        public ReadOnlyCollection<ClamScanInfectedFile> InfectedFiles { get; private set; }

        public ClamScanResult(string rawResult)
        {
            RawResult = rawResult;

            var resultLowered = rawResult.ToLowerInvariant();

            if (resultLowered.EndsWith("ok"))
            {
                Result = ClamScanResults.Clean;
            }
            else if(resultLowered.EndsWith("error"))
            {
                Result = ClamScanResults.Error;
            }
            else if (resultLowered.EndsWith("found"))
            {
                Result = ClamScanResults.VirusDetected;

                var files = rawResult.Split(new[] {"FOUND"}, StringSplitOptions.RemoveEmptyEntries);
                var infectedFiles = new List<ClamScanInfectedFile>();
                foreach(var file in files)
                {
                    var trimFile = file.Trim();
                    var splitFile = trimFile.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    if(splitFile.Length == 2) //then this is the correct size
                    {
                        infectedFiles.Add(new ClamScanInfectedFile() {FileName = splitFile[0].Trim().TrimEnd(':'), VirusName = splitFile[1].Trim()});
                    }
                    else
                    {
                        throw new UnknownClamResponseException(file);
                    }
                }

                InfectedFiles = new ReadOnlyCollection<ClamScanInfectedFile>(infectedFiles);
            }
        }

        public override string ToString()
        {
            return RawResult;
        }
    }
}
