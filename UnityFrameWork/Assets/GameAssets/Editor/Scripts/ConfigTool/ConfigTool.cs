using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ExcelDataReader;
using System.IO;
using System.Data;
using System;
using LitJson;
using System.Reflection;
using System.Text;
using TFrameWork.Core.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// 配置表默认第一行为中文命名，第二行为一些说明
/// </summary>
namespace TFrameWork.Core.EditorTool
{
    internal class ConfigTool
    {
        public static string s_JsonDirName = "/GameAssets/Config/Json";

        public static string s_BinaryDirName = "/GameAssets/Config/Binary";

        public static string s_XlsxDirName = "/GameAssets/Config/Xlsx";

        public static string s_CsDirName = "/GameAssets/Config/CSCode";

        public static string s_CodeNameSpace = "TFrameWork.Core.ConfigCodeLibrary";

        private static ICodeGenerator s_Generator = new ConfigObjClassCodeGenerator();



        [MenuItem("Tools/Config/GenerateCSCode")]
        public static void GenerateCSCode()
        {
            try
            {
                GenerateScripts();
                AssetDatabase.Refresh();
                EditorUtility.ClearProgressBar();
            }
            catch (System.Exception)
            {
                EditorUtility.ClearProgressBar();
                throw;
            }
        }

        // [MenuItem("Tools/Config/XlsxToBinary")]
        // public static void XlsxToBinary()
        // {
        //     try
        //     {
        //         XlsxToJson();
        //         GenerateByteConfigFile();
        //         AssetDatabase.Refresh();
        //     }
        //     catch (System.Exception)
        //     {
        //         EditorUtility.ClearProgressBar();
        //         throw;
        //     }
        // }

        [MenuItem("Tools/Config/XlsxToJson")]
        public static void XlsxToJson()
        {
            try
            {
                GenerateCSCode();
                GenerateJsonConfigFile();
                EditorUtility.ClearProgressBar();
                AssetDatabase.Refresh();
            }
            catch (System.Exception)
            {
                EditorUtility.ClearProgressBar();
                throw;
            }
        }

        private static void GenerateScripts()
        {
            string[] filePaths = Directory.GetFiles(Application.dataPath + s_XlsxDirName, "*.xlsx");
            for (int file_index = 0; file_index < filePaths.Length; file_index++)
            {
                EditorUtility.DisplayProgressBar("生成CS文件", "根据xlsx生成对应的CS文件", (float)file_index / (float)(filePaths.Length));
                using (FileStream stream = File.Open(filePaths[file_index], FileMode.Open, FileAccess.Read))
                {
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        DataSet result = reader.AsDataSet();
                        for (int tab_index = 0; tab_index < result.Tables.Count; tab_index++)
                        {
                            WriteCSFile(result.Tables[tab_index]);
                        }
                    }
                }
            }
        }

        private static void GenerateJsonConfigFile()
        {
            string[] filePaths = Directory.GetFiles(Application.dataPath + s_XlsxDirName, "*.xlsx");
            for (int file_index = 0; file_index < filePaths.Length; file_index++)
            {
                EditorUtility.DisplayProgressBar("生成json配置文件", "根据xlsx生成对应的json文件", (float)file_index / (float)(filePaths.Length));
                LoopWriteJsonFile(XlsxUtils.ReadXlsxAllSheets(filePaths[file_index], s_CodeNameSpace));
            }
        }

        // private static void GenerateByteConfigFile()
        // {
        //     string[] filePaths = Directory.GetFiles(Application.dataPath + s_XlsxDirName, "*.xlsx");
        //     for (int file_index = 0; file_index < filePaths.Length; file_index++)
        //     {
        //         EditorUtility.DisplayProgressBar("生成json配置文件", "根据xlsx生成对应的json文件", (float)file_index / (float)(filePaths.Length));
        //         var content = XlsxUtils.ReadXlsxAllSheets(filePaths[file_index], s_CodeNameSpace);
        //         foreach (var item in content)
        //         {
        //             BinaryFormatter formatter = new BinaryFormatter();
        //             using (MemoryStream stream = new MemoryStream())
        //             {
        //                 string path = string.Format("{0}{1}{2}.byte", Application.dataPath, s_BinaryDirName, item.Key);
        //                 formatter.Serialize(stream, item.Value);
        //                 var bytes = stream.GetBuffer();
        //                 FileUtils.WriteContentToFile(path, bytes, stream);
        //             }
        //         }
        //     }
        // }

        private static void LoopWriteJsonFile(Dictionary<string, Dictionary<string, object>> contentToJsonOfSheets)
        {
            foreach (var sheet in contentToJsonOfSheets)
            {
                Dictionary<string, string> jsonItemDic = new Dictionary<string, string>();
                foreach (var item in sheet.Value)
                {
                    jsonItemDic.Add(item.Key, JsonMapper.ToJson(item.Value));
                }
                string path = string.Format("{0}{1}/{2}.json", Application.dataPath, s_JsonDirName, sheet.Key);
                FileUtils.WriteContentToFile(path, JsonMapper.ToJson(jsonItemDic));
            }
        }

        private static void WriteCSFile(DataTable table)
        {
            string sheetName = table.TableName;
            int cols = table.Columns.Count;
            int rows = table.Rows.Count;
            s_Generator.WriteHeader(s_CodeNameSpace, sheetName);
            for (int col_i = 0; col_i < cols; col_i++)
            {
                string rowOfCol = table.Rows[2][col_i].ToString();
                if (!string.IsNullOrEmpty(rowOfCol))
                {
                    string[] colNames = rowOfCol.Split('_');
                    string colName = colNames[1];
                    string colType = colNames[0];
                    if (colType == "func")
                        s_Generator.WriteFunc(table.Rows[1][col_i].ToString());
                    else
                        s_Generator.WriteMember(colType, colName);
                }
            }
            s_Generator.WriteEnd();
            s_Generator.Save(string.Format("{0}{1}/{2}.cs", Application.dataPath, s_CsDirName, sheetName));
        }
    }
}

