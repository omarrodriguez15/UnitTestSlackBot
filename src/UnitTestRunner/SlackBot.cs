using SlackBotMessages;

using System;

namespace UnitTestRunner
{
    public class SlackBot
    {
      public string Channel { get; set; }
      public string Username { get; set; }
      public string Avatar { get; set; }
      public string WebHookUrl { get; set; }

      public SlackBot()
      {
         if (Settings.SlackBotSettings != null)
         {
            Channel = Settings.SlackBotSettings.Channel;
            Username = Settings.SlackBotSettings.Username;
            Avatar = Settings.SlackBotSettings.Avatar;
            WebHookUrl = Settings.SlackBotSettings.WebHookUrl;
         }
         else
         {
            //Force to use settings
            throw new Exception("Settings not set for slack bot");
         }
      }

      public bool Send(string message)
      {
         SBMClient client = new SBMClient(WebHookUrl);
         Message msg = new Message(message, Channel, Username, Avatar);

         var res = client.Send(msg);
         Console.WriteLine("Response from bot " + res);

         return !string.IsNullOrEmpty(res);
      }
   }
}
