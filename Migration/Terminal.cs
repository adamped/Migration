using System.Diagnostics;

namespace Migration
{
    internal sealed class Terminal
    {
        internal static void Run(string workingDirectory, string command) {

            ProcessStartInfo psi = new()
            {
                FileName = "cmd.exe", // or "powershell.exe" for PowerShell
                WorkingDirectory = workingDirectory,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                UseShellExecute = false,
            };

            Process process = new() { StartInfo = psi };
            process.Start();

            // Send a command to the terminal
            process.StandardInput.WriteLine(command);

            // Close the process
            process.Close();
        }

    }
}
