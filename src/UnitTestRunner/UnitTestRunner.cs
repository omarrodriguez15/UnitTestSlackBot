using System;
using System.Diagnostics;
using System.IO;

namespace UnitTestRunner
{
   public class UnitTestRunner
   {
      public string TestRunnerPath { get; set; }
      public string RunnerExe { get; set; }
      public string TestPath { get; set; }
      public string[] Tests { get; set; }

      public UnitTestRunner(TestRunnerSettings settings)
      {
         if (settings != null)
         {
            TestPath = settings.TestPath;
            Tests = settings.Tests;
            TestRunnerPath = settings.TestRunnerPath;
            RunnerExe = settings.RunnerExe;
         }
      }

      public void RunTests()
      {
         var executableFullPath = Path.Combine(TestRunnerPath, RunnerExe);

         foreach (var testDll in Tests)
         {
            RunTest(executableFullPath, testDll);
         }
      }

      private void RunTest(string executableFullPath, string testDll)
      {
         var argsuments = Path.Combine(TestPath, testDll);

         Process proc = BuildProcess(executableFullPath, argsuments);
         proc.Start();

         while (!proc.StandardOutput.EndOfStream)
         {
            HandleOutput(testDll, proc);
         }
      }

      private static void HandleOutput(string testDll, Process proc)
      {
         var line = proc.StandardOutput.ReadLine();
         var dllName = testDll.Replace(".dll", "");
         if (line.Contains($"{dllName}  Total: "))
         {
            Console.WriteLine(line.Trim());
            SlackBot sb = new SlackBot();
            sb.Send(line.Trim());
         }
      }

      private static Process BuildProcess(string executableFullPath, string argsuments)
      {
         return new Process()
         {
            StartInfo = new ProcessStartInfo()
            {
               FileName = executableFullPath,
               Arguments = argsuments,
               UseShellExecute = false,
               RedirectStandardOutput = true,
               CreateNoWindow = false
            }
         };
      }
   }
}
