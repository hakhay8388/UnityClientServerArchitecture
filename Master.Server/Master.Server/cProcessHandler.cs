using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Bootstrapper.Core.nHandlers.nProcessHandler
{
    public class cProcessHandler
    {

        public static Process OpenModalProcess(string _ExecFileWithPath, string _Arguments)
        {
            try
            {
                if (File.Exists(_ExecFileWithPath))
                {
                    Process process = new Process();
                    process.StartInfo.FileName = _ExecFileWithPath;
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(_ExecFileWithPath);
                    process.StartInfo.Arguments = _Arguments;
                    process.StartInfo.Verb = "runas";
                    process.Start();
                    process.WaitForExit();

                    return process;
                }
                else if (_ExecFileWithPath.IndexOf("\\") < 1 && _ExecFileWithPath.IndexOf("/") < 1)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = _ExecFileWithPath;
                    process.StartInfo.WorkingDirectory = Path.GetDirectoryName(_ExecFileWithPath);
                    process.StartInfo.Arguments = _Arguments;
                    process.StartInfo.Verb = "runas";
                    process.Start();
                    process.WaitForExit();

                    return process;
                }
            }
            catch (Exception _Ex)
            {
				throw _Ex;
            }

            return null;
        }
    }
}
