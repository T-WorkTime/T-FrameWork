using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using ExcelDataReader;
using LitJson;
using UnityEngine;

namespace TFrameWork.Core.EditorTool
{
    internal sealed class XlsxUtils
    {

        public static Dictionary<string, Dictionary<string, object>> ReadXlsxAllSheets(string path, string nameSpace)
        {
            using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet();
                    Dictionary<string, Dictionary<string, object>> contentToJsonOfSheets = new Dictionary<string, Dictionary<string, object>>();
                    for (int tab_index = 0; tab_index < result.Tables.Count; tab_index++)
                    {
                        DataTable table = result.Tables[tab_index];
                        string sheetName = table.TableName;
                        var sheetContentToDic = ReadContentOfSheet(table, sheetName, nameSpace);
                        contentToJsonOfSheets.Add(sheetName, sheetContentToDic);
                    }
                    return contentToJsonOfSheets;
                }
            }
        }
        
        private static Dictionary<string, object> ReadContentOfSheet(DataTable table, string sheetName, string nameSpace)
        {
            int cols = table.Columns.Count;
            int rows = table.Rows.Count;
            Type type = Type.GetType(string.Format("{0}.{1}, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", nameSpace, sheetName));
            Dictionary<string, object> dic = new Dictionary<string, object>();
            for (int row_i = 2; row_i < rows; row_i++)
            {
                object obj = Activator.CreateInstance(type);
                for (int col_i = 0; col_i < cols; col_i++)
                {
                    string rowOfCol = table.Rows[2][col_i].ToString();
                    if (!string.IsNullOrEmpty(rowOfCol))
                    {
                        string[] colNames = rowOfCol.Split('_');
                        string colName = colNames[1];
                        string colType = colNames[0];
                        if (row_i >= 3)
                        {
                            if (colType != "func")
                            {
                                FieldInfo fieldInfo = type.GetField(colName);
                                string value = table.Rows[row_i][col_i].ToString();
                                if (!string.IsNullOrEmpty(value))
                                {
                                    var valueObj = ParseValue(value, colType);
                                    fieldInfo.SetValue(obj, valueObj);
                                }
                            }
                        }
                    }
                }
                if (row_i >= 3)
                    dic.Add(table.Rows[row_i][0].ToString(), obj);
            }
            return dic;
        }

         private static object ParseValue(string value, string valueType)
        {
            object valueObj = null;
            switch (valueType)
            {
                case "int":
                    valueObj = int.Parse(value);
                    break;
                case "string":
                    valueObj = value;
                    break;
                case "float":
                    valueObj = float.Parse(value);
                    break;
                case "double":
                    valueObj = double.Parse(value);
                    break;
                case "long":
                    valueObj = long.Parse(value);
                    break;
                case "int[]":
                    valueObj = JsonMapper.ToObject<int[]>(value);
                    break;
                case "string[]":
                    valueObj = JsonMapper.ToObject<string[]>(value);
                    break;
                case "float[]":
                    valueObj = JsonMapper.ToObject<float[]>(value);
                    break;
                case "double[]":
                    valueObj = JsonMapper.ToObject<double[]>(value);
                    break;
                case "long[]":
                    valueObj = JsonMapper.ToObject<long[]>(value);
                    break;
                default:
                    break;
            }
            return valueObj;
        }
    }
}

