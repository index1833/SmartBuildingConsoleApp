using Azure;
using Azure.DigitalTwins.Core;
using Azure.Identity;
using SmartBuildingConsoleApp.DigitalTwins;
using System;
using System.IO;
namespace SmartBuildingConsoleApp.DigitalTwins
{
    public class DigitalTwinsManager
    {
        private static readonly string adtInstanceUrl = "https://DTBDigitalTwins19.api.krc.digitaltwins.azure.net";
        private DigitalTwinsClient client;
        public DigitalTwinsManager()
        {
            Connect();
        }
        public void Connect()
        {
            var cred = new DefaultAzureCredential();
            client = new DigitalTwinsClient(new Uri(adtInstanceUrl), cred);
        }

        public bool CreateModel(string path)
        {
            return CreateModels(new string[] { path });
        }
        public bool CreateModels(string[] path)
        {
            List<string> dtdls = new List<string>();
            foreach (string p in path)
            {
                using var modelStreamReader = new StreamReader(p);
                string dtdl = modelStreamReader.ReadToEnd();
                dtdls.Add(dtdl);
            }
            try
            {
                DigitalTwinsModelData[] models = client.CreateModels(dtdls.ToArray());
            }
            catch (RequestFailedException)
            {
                return false;
            }
            return true;
        }

        public void DeleteModel(string modelId)
        {
            client.DeleteModel(modelId);
        }

        public bool CreateDigitalTwin(string twinId, string modelId)
        {
            BasicDigitalTwin digitalTwin = new BasicDigitalTwin();
            digitalTwin.Metadata = new DigitalTwinMetadata();
            digitalTwin.Metadata.ModelId = modelId;
            digitalTwin.Id = twinId;
            try
            {
                client.CreateOrReplaceDigitalTwin<BasicDigitalTwin>(twinId, digitalTwin);
            }
            catch (RequestFailedException)
            {
                return false;
            }
            return true;
        }
        public bool UpdateDigitalTwin(string twinId, string property, object value)
        {
            try
            {
                BasicDigitalTwin digitalTwin = client.GetDigitalTwin<BasicDigitalTwin>(twinId);
                digitalTwin.Contents[property] = value;
                client.CreateOrReplaceDigitalTwin<BasicDigitalTwin>(twinId, digitalTwin);
            }
            catch (RequestFailedException)
            {
                return false;
            }
            return true;
        }
    }
}