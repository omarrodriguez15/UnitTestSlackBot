using Newtonsoft.Json;

using System;
using System.IO;

namespace UnitTestRunner
{
   public class Settings
   {
      public static TestRunnerSettings TestRunnerSettings { get; set; }
      public static SlackBotSettings SlackBotSettings { get; set; }

      public static void Init(string trsFilePath, string sbsFilePath)
      {
         if (!File.Exists(trsFilePath) || !File.Exists(sbsFilePath))
         {
            throw new Exception("Settings file(s) missing");
         }

         var content = File.ReadAllText(trsFilePath);
         TestRunnerSettings = JsonConvert.DeserializeObject<TestRunnerSettings>(content);

         content = File.ReadAllText(sbsFilePath);
         SlackBotSettings = JsonConvert.DeserializeObject<SlackBotSettings>(content);
      }
   }

   public class SlackBotSettings
   {
      public string Channel { get; set; }
      public string Username { get; set; }
      public string Avatar { get; set; }
      public string WebHookUrl { get; set; }
   }

   public class TestRunnerSettings
   {
      public string TestRunnerPath { get; set; }
      public string RunnerExe { get; set; }
      public string TestPath { get; set; }
      public string[] Tests { get; set; }
   }
}
