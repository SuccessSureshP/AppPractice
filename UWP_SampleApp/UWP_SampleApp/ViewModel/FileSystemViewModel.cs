using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using System.IO;
using UWP_SampleApp.Model;
using GalaSoft.MvvmLight.Command;

namespace UWP_SampleApp.ViewModel
{
    public class FileSystemViewModel : ViewModelBase
    {
        private FileDirectory _currentDir;
                
        public FileSystemViewModel()
        {
            _currentDir  = new FileDirectory();
            _currentDir.Name = "Root";
            _currentDir.Parent = null;
            _currentDir.SubDirectories = new List<FileDirectory>();

            this.RunButtonClickCommand = new RelayCommand(RunCommand);

        }

        private string _commandResult;
        private string _commandTest;

        public string CommandText
        {
            get
            {
                return _commandTest;
            }
            set
            {               
                Set(ref _commandTest, value);
            }
        }
        public RelayCommand RunButtonClickCommand { get; private set; }

        public string CommandResult
        {
            get
            {
                return _commandResult;
            }
            set
            {
                if(_currentDir != null)
                    value = $"{_currentDir.Name}>{value}";
                Set(ref _commandResult, value);
            }
        }

        private void RunCommand()
        {
            ExecuteCommand(CommandText);
        }
        public void ExecuteCommand(string cmdText)
        {
            var commandWithArgs = cmdText.Split(' ');
            var cmd = commandWithArgs[0];
            var cmdParam = string.Empty;

            if (commandWithArgs.Length > 1)
                cmdParam = commandWithArgs[1];

            switch (cmd)
            {
                case "Dir":
                    {
                        if (_currentDir.SubDirectories == null || _currentDir.SubDirectories.Count == 0)
                            CommandResult = "No SubDirectories Found";
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            //sb.Append($"{_currentDir.Name}>");
                            foreach (var directory in _currentDir.SubDirectories.OrderBy(d => d.Name))
                            {
                                sb.Append(directory.Name);
                                sb.Append(" ");
                            }
                            CommandResult = sb.ToString();
                        }
                        break;
                    }
                case "MkDir":
                    {
                        if (string.IsNullOrEmpty(cmdParam))
                            throw new ArgumentNullException("Please specify Directory name to create");
                        if (_currentDir.SubDirectories.Exists(d => d.Name.Equals(cmdParam, StringComparison.OrdinalIgnoreCase)))
                        CommandResult = "Directory Already Exists with same name";

                        FileDirectory newDir = new FileDirectory();
                        newDir.Name = cmdParam;
                        newDir.Parent = _currentDir;
                        _currentDir.SubDirectories.Add(newDir);
                        CommandResult = string.Empty;
                        break;
                    }
                default:
                    {
                        //Handling unknown command
                        break;
                    }
            }
        }

    }
}
