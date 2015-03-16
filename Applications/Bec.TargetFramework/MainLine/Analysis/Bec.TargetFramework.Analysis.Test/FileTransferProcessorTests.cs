using Bec.TargetFramework.Infrastructure.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Bec.TargetFramework.Analysis.Test
{
    [TestClass]
    public class FileTransferProcessorTests : UnitTestBase
    {
        const string DESTINATIONPATH = UnitTestBase.TESTINGPATH + @"\FileTransferProcessor";

        [TestInitialize]
        public override void TestInitialise()
        {
            base.TestInitialise();

            if (!Directory.Exists(DESTINATIONPATH))
                Directory.CreateDirectory(DESTINATIONPATH);

            // Delete the files in the destination folder
            Array.ForEach(Directory.GetFiles(DESTINATIONPATH), File.Delete);
        }

        [TestMethod]
        [Ignore] // Not yet ready to be used
        public void FileTransferProcess_Basic()
        {
            // TODO: Alter this test to remove the SFTP server dependency
            // TODO: Disabled this test for now.

            // This test assumes you have a local SFTP server running.
            // Please downlaod and run (on this pc) http://www.coreftp.com/server/download/msftpsrvr.exe
            // (remember to run as administrator when started it)
            // enter user id=test, password=test, and port=23 into the interface
            // in the root path, enter the folder where you have place a single xml file (I used Interaction2ResponseSample.xml)
            // then press start.

            var fileTransferProcessor = new FileTransferProcessor();
            fileTransferProcessor.Host = "127.0.0.1"; // localhost
            fileTransferProcessor.User = "test";
            fileTransferProcessor.Password = "test";
            fileTransferProcessor.Port = 23;
            fileTransferProcessor.DestinationFolder = DESTINATIONPATH;

            // Check that we don't have any files yet - test initialisation should have emptied it.
            Assert.AreEqual(0, Directory.GetFiles(DESTINATIONPATH).Length);

            // Trigger the code being tested
            var count = fileTransferProcessor.TransferAllFiles();

            // Check that the destination folder now has the file
            Assert.AreEqual(1, count);
            Assert.AreEqual(1, Directory.GetFiles(DESTINATIONPATH).Length);
        }
    }
}
