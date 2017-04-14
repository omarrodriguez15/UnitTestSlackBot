# UnitTestSlackBot

A simple console app that runs to Xunit console runner to run unit test. The results are
then sent to a slack channel using the SlackBotMessages Library which uses a Slack webhook 
integration.

More about [SlackBotMessages](https://github.com/prjseal/SlackBotMessages/).

# Configuration  
The app uses two settings files, which are specified in the main entry point in Program.cs. 
One for the slack bot and one for the unit test runner. Right now the app is tightly coupled 
to xunit output but can easily be changed.


SlackBotSettings.json
```
{
   "Channel": "general",
   "Username": "UnitTesterConsoleApp",
   "Avatar": ":poop:",
   "WebHookUrl":""https://hooks.slack.com/services/Your/WebHook/Url""
}
```

TestRunnerSettings.json
```
{
   "TestRunnerPath": "C:\\Path\\To\\Your\\Runner\\Package\\",
   "RunnerExe": "xunit.console.exe",
   "TestPath": "C:\\Path\\To\\Your\\Test\\dlls",
   "Tests": ["your_unit_test_one.dll", "your_other_unit_test_one.dll"]
}
```