using Azure.DigitalTwins.Core;
using SmartBuildingConsoleApp.DigitalTwins;
using System;

namespace SmartBuildingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitalTwinsManager dtHelper = new DigitalTwinsManager();
            // TODO
          
                        string[] paths = new string[] {
                            "Models/chapter4/campus.json",
                            "Models/chapter4/building.json",
                            "Models/chapter4/floor.json",
                            "Models/chapter4/workarea.json",
                            "Models/chapter4/sensor.json"                
                        };
                        dtHelper.CreateModels(paths);

            // Meetingroom 추가
            // string path = "Models/Chapter4/meetingroom.json";
            //dtHelper.CreateModel(path);


            // Delete Modle

            /*dtHelper.DeleteModel("dtmi:com:smartbuilding:Meetingroom;1");*/

            // Get Model
            /*  DigitalTwinsModelData model = dtHelper.GetModel("dtmi:com:smartbuilding:Room;1");
              Console.WriteLine(model.Id);
              Console.WriteLine(model.LanguageDisplayNames["en"]);


              var models = dtHelper.GetModels();
              foreach (DigitalTwinsModelData model in models)
              {
                  Console.WriteLine(model.Id);
                  Console.WriteLine(model.LanguageDisplayNames["en"]);
              }
            */

/*            dtHelper.CreateDigitalTwin("Campus", "dtmi:com:smartbuilding:Campus:1");
            dtHelper.CreateDigitalTwin("MainBuilding", "dtmi:com:smartbuilding:Building:1");
            dtHelper.CreateDigitalTwin("GroundFloor", "dtmi:com:smartbuilding:Floor:1");
            dtHelper.CreateDigitalTwin("MeetingRoom1.01", "dtmi:com:smartbuilding:Meetingroom:1");*/
            //dtHelper.UpdateDigitalTwin("MeetingRoom1.01", "occupied", true);
        }
    }
}
