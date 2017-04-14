using System;

namespace UnitTestRunner
{
   public class Program
   {
      public static void Main(string[] args)
      {
         try
         {
            Settings.Init(@"C:\tmp\TestRunnerSettings.json", @"C:\tmp\SlackBotSettings.json");
            var testRunner = new UnitTestRunner(Settings.TestRunnerSettings);
            testRunner.RunTests();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.ReadLine();
      }
   }
}
