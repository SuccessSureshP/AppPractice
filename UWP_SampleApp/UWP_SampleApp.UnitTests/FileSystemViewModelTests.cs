using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_SampleApp.ViewModel;

namespace UWP_SampleApp.UnitTests
{
    [TestClass]
    public class FileSystemViewModelTests
    {
        [TestMethod]
        public void TestDirWithOutAnyContent()
        {
            List<string> comands = new List<string>();
            comands.Add("Dir");
            string finalResult = string.Empty;

            FileSystemViewModel fs = new FileSystemViewModel();
            foreach (var command in comands)
            {
                fs.ExecuteCommand(command);
            }
            finalResult = fs.CommandResult;
            Assert.AreEqual("Root>No SubDirectories Found", finalResult);            
        }

        [TestMethod]
        public void TestDirResultsSequenceWithSomeDirectories()
        {
            List<string> comands = new List<string>();
            comands.Add("MkDir f2");
            comands.Add("MkDir f1");
            comands.Add("Dir");
            string finalResult = string.Empty;

            FileSystemViewModel fs = new FileSystemViewModel();
            foreach (var command in comands)
            {
                fs.ExecuteCommand(command);
            }
            finalResult = fs.CommandResult;
            Assert.AreEqual("Root>f1 f2 ", finalResult);
        }
        [TestMethod]
        public void TestMkDirWithNewDirectoryName()
        {
            List<string> comands = new List<string>();
            comands.Add("MkDir f2");           
            string comandResult = string.Empty;

            FileSystemViewModel fs = new FileSystemViewModel();
            foreach (var command in comands)
            {
                fs.ExecuteCommand(command);
            }
            comandResult = fs.CommandResult;
            Assert.AreEqual("Root>", comandResult);

            fs.ExecuteCommand("Dir");
            comandResult = fs.CommandResult;
            Assert.AreEqual("Root>f2 ", comandResult);
        }
    }

}
