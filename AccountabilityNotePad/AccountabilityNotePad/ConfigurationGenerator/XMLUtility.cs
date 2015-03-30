using System;
using System.Xml;

namespace ConfigurationGenerator
{
    class XMLUtility
    {
        private XmlDocument AppFile;
        private string FilePath;

        public XMLUtility(string Path)
        {
            FilePath = Path;
            AppFile = new XmlDocument();
            AppFile.Load(FilePath);

            //if (!KeyExists("AccountabilityWebServiceURL"))
            //{
            //    if (!AddKey("AccountabilityWebServiceURL", "Accountability_WS"))
            //        throw new Exception("Can't add setting element to configuration file.");
            //}

            //if (KeyExists("ServerUpdatesLocation"))
            //{
            //    if (!DeleteKey("ServerUpdatesLocation"))
            //        throw new Exception("Can't delete setting element of configuration file.");
            //}

            //AppFile.Save(args[1]);
        }

        private void Save()
        {
            AppFile.Save(FilePath);
        }

        public bool DeleteKey(string name)
        {
            try
            {
                XmlNode appSettingsNode = AppFile.DocumentElement.SelectSingleNode("Settings");
                foreach (XmlNode ChildNode in appSettingsNode)
                {
                    if (ChildNode.Attributes["name"].Value == name)
                    {
                        appSettingsNode.RemoveChild(ChildNode);
                        this.Save();
                        return true;
                    }
                }
            }
            catch
            { }

            return false;
        }

        public bool AddKey(string name, string value)
        {
            bool result = false;

            try
            {
                XmlElement elem = AppFile.CreateElement("key");
                elem.SetAttribute("name", name);
                elem.InnerXml = "<value>/" + value + "/</value>";
                AppFile.ChildNodes[1].ChildNodes[0].AppendChild(elem);
                this.Save();
                result = true;
            }
            catch
            { }

            return result;
        }

        public bool EditKey(string name, string value)
        {
            try
            {
                XmlNode appSettingsNode = AppFile.DocumentElement.SelectSingleNode("Settings");
                foreach (XmlNode ChildNode in appSettingsNode)
                {
                    if (ChildNode.Attributes["name"].Value == name)
                    {
                        appSettingsNode.RemoveChild(ChildNode);

                        XmlElement elem = AppFile.CreateElement("key");
                        elem.SetAttribute("name", name);
                        elem.InnerXml = value;
                        AppFile.ChildNodes[1].ChildNodes[0].AppendChild(elem);
                        this.Save();
                        return true;
                    }
                }
            }
            catch
            { }

            return false;
        }

        public bool KeyExists(string name)
        {
            try
            {
                XmlNode appSettingsNode = AppFile.DocumentElement.SelectSingleNode("Settings");
                // Attempt to locate the requested setting.
                foreach (XmlNode childNode in appSettingsNode)
                {
                    if (childNode.Attributes["name"].Value == name)
                        return true;
                }
            }
            catch
            { }

            return false;
        }

        public string GetKeyValue(string name)
        {
            try
            {
                XmlNode appSettingsNode = AppFile.DocumentElement.SelectSingleNode("Settings");
                // Attempt to locate the requested setting.
                foreach (XmlNode childNode in appSettingsNode)
                {
                    if (childNode.Attributes["name"].Value == name)
                        return childNode.InnerXml;
                }
            }
            catch
            { }

            return "";
        }
    }
}
