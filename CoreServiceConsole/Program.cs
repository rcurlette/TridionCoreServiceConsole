using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tridion.ContentManager.CoreService.Client;
using System.Xml;
using CoreServiceConsole.CoreService;

namespace CoreServiceConsole
{
    class Program
    {
        CoreServiceHandler _Handler;
        static void Main(string[] args)
        {
            ComponentData compData = GetComponentData("tcm:6-2923");
            string content = compData.Content;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(content);
        }

        private static ComponentData GetComponentData(string uri)
        {
            string configFilename = "CoreServiceHandler.config";
            CoreServiceHandler coreServiceHandler = new CoreServiceHandler(configFilename);
            ICoreService2010 core = coreServiceHandler.GetNewClient();
            ComponentData compData = core.Read(uri, new CoreServiceConsole.CoreService.ReadOptions()) as ComponentData;
            return compData;
        }
    }
}
