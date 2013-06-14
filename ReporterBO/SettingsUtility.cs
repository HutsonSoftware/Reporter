using System.IO;
using System.Text;
using System.Xml;

namespace Reporter
{
    public static class SettingsUtility
    {
        public static Settings GetSettingsFromFile(string filePath)
        {
            Settings settings = new Settings();

            if (File.Exists(filePath))
            {
                settings.FilePath = filePath;

                XmlReader reader = XmlReader.Create(filePath);
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "LocalReportFolder":
                                if (reader.Read())
                                    settings.LocalReportFolder = reader.Value.Trim().EndsWith("\\") == true ? reader.Value.Trim() : reader.Value.Trim() + "\\";
                                break;
                            case "ServerReportFolder":
                                if (reader.Read())
                                    settings.ServerReportFolder = reader.Value.Trim().EndsWith("\\") == true ? reader.Value.Trim() : reader.Value.Trim() + "\\";
                                break;
                            case "DsnName":
                                if (reader.Read())
                                    settings.DsnName = reader.Value.Trim();
                                break;
                            case "ServerName":
                                if (reader.Read())
                                    settings.ServerName = reader.Value.Trim();
                                break;
                            case "DatabaseName":
                                if (reader.Read())
                                    settings.DatabaseName = reader.Value.Trim();
                                break;
                            case "IntegratedSecurity":
                                if (reader.Read())
                                    settings.IntegratedSecurity = (bool)(reader.Value.Trim() == "1" ? true : false);
                                break;
                            case "UserID":
                                if (reader.Read())
                                    settings.UserID = reader.Value.Trim();
                                break;
                            case "Password":
                                if (reader.Read())
                                    settings.Password = reader.Value.Trim();
                                break;
                        }
                    }
                }
                reader.Close();
                reader = null;
            }
            return settings;
        }

        public static void SaveSettingsToFile(Settings settings)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };
            xmlWriterSettings.OmitXmlDeclaration = true;

            XmlWriter writer = XmlWriter.Create(settings.FilePath, xmlWriterSettings);
            writer.WriteStartElement("Settings");

            writer.WriteElementString("LocalReportFolder", settings.LocalReportFolder);
            writer.WriteElementString("ServerReportFolder", settings.ServerReportFolder);
            writer.WriteElementString("DsnName", settings.DsnName);
            writer.WriteElementString("ServerName", settings.ServerName);
            writer.WriteElementString("DatabaseName", settings.DatabaseName);
            writer.WriteElementString("IntegratedSecurity", (settings.IntegratedSecurity == true ? "1" : "0"));
            writer.WriteElementString("UserID", settings.UserID);
            writer.WriteElementString("Password", settings.Password);

            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
            writer = null;
        }
    }

    public class Settings
    {
        public string FilePath { get; set; }
        public string LocalReportFolder { get; set; }
        public string ServerReportFolder { get; set; }
        public string DsnName { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }

}
