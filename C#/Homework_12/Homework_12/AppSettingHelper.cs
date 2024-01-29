using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Homework_12
{
    class AppSettingHelper
    {
        private string filePath;

        public AppSettingHelper(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveSettings(string consoleColor, string windowTitle, int windowWidth, int windowHeight)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
              
                writer.Write(consoleColor);
                writer.Write(windowTitle);
                writer.Write(windowWidth);
                writer.Write(windowHeight);
            }
        }

        public (string, string, int, int) LoadSettings()
        {
            string consoleColor, windowTitle;
            int windowWidth, windowHeight;

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
             
                consoleColor = reader.ReadString();
                windowTitle = reader.ReadString();
                windowWidth = reader.ReadInt32();
                windowHeight = reader.ReadInt32();
            }

            return (consoleColor, windowTitle, windowWidth, windowHeight);
        }
    }
}
