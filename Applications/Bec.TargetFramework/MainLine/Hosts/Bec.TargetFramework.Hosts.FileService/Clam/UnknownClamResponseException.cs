using System;

namespace Bec.TargetFramework.Hosts.FileService.Clam
{
    public class UnknownClamResponseException : Exception
    {
        public UnknownClamResponseException(string response) : base(String.Format("Unable to parse the server response: {0}", response))
        {
        }
    }
}