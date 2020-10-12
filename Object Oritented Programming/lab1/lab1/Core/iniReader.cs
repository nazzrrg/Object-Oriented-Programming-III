using System;
using System.IO;
using lab1.Core.Exceptions;

namespace lab1.Core
{
    public class iniReader
    {
        public string[] ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNonExistentException($"File {filePath} does not exist");
            }

            if (Path.GetExtension(filePath) != ".INI" && Path.GetExtension(filePath) != ".ini")
            {
                throw new IncorrectFileExtensionException($"Extension {Path.GetExtension(filePath)} is not supported");
            }

            try
            {
                return File.ReadAllLines(filePath);
            } catch (Exception e)
            {
                throw new FileReadException($"Failed to read file. Error message: {e.Message}");
            }
        }
    }
}
