using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TFrameWork.Core.IO
{
    public sealed class FileUtils
    {
        public static void WriteContentToFile(string path, string content, FileStream fs)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            fs.Write(bytes, 0, bytes.Length);
        }

        public static void WriteContentToFile(string path, byte[] content, Stream stream)
        {
            stream.Write(content, 0, content.Length);
        }

        public static async void AsyncWriteContentToFile(string path, string content, FileStream fs)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            Task task = fs.WriteAsync(bytes, 0, bytes.Length);
            await task;
        }
        public static async void AsyncWriteContentToFile(string path, string content)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(content);
                Task task = fs.WriteAsync(bytes, 0, bytes.Length);
                await task;
            }
        }

        public static void WriteContentToFile(string path, string content)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                WriteContentToFile(path, content, fs);
            }
        }

        public static void AppendText(string path, string content)
        {
            if (!File.Exists(path))
                WriteContentToFile(path, content);
            File.AppendText(path);
        }

        public static void SwitchJsonToByteFile(string filePath, string destDir)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string content = File.ReadAllText(filePath);
            string path = string.Format("{0}{1}/{2}.byte", Application.dataPath, destDir, fileName);
            WriteContentToFile(path, content);
        }
    }

}
