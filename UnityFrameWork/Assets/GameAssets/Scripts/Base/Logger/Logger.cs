using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace TFrameWork.Core.AssetBundleRuntime
{
    internal static class Logger
    {
        [Conditional("ENABLE_LOG")]
        [Conditional("EBABLE_WARNING_LOG")]


        public static void LoggerWarning(string format, params object[] msg)
        {
            UnityEngine.Debug.LogWarning(string.Format(format, msg));
        }

        [Conditional("ENABLE_LOG")]
        [Conditional("EBABLE_WARNING_LOG")]


        public static void LoggerWarning(object msg)
        {
            UnityEngine.Debug.LogWarning(msg);
        }


        public static void LoggerError(string format, params object[] msg)
        {
            UnityEngine.Debug.LogError(string.Format(format, msg));
        }


        public static void LoggerError(object msg)
        {
            UnityEngine.Debug.LogWarning(msg);
        }

        [Conditional("ENABLE_LOG")]

        public static void Log(string format, params object[] msg)
        {
            UnityEngine.Debug.Log(string.Format(format, msg));
        }

        [Conditional("ENABLE_LOG")]
        public static void Log(object msg)
        {
            UnityEngine.Debug.Log(msg);
        }
    }
}

