using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TFrameWork.Core.AssetBundleRuntime;
using System;

namespace TFrameWork.Core.AssetBundleEditor
{
    internal sealed class AssetBundleBuilder : EditorWindow
    {

        private static AssetBundleWindowInpector s_Inspector;


        [MenuItem("Tools/AssetBundle/AssetBundleBuild")]
        public static void OpenBuildWindow()
        {
            var window = GetWindow<AssetBundleBuilder>(false, "Build AssetBundle");
            window.minSize = window.maxSize = new Vector2 (900, 650);
        }

        public static void StartBuild(LoadType loadType, string outPutPath, BuildTarget targetPlatform, BuildAssetBundleOptions options)
        {
            string buildStr = string.Format("TFrameWork.Core.AssetBundleEditor.{0}Builder", targetPlatform.ToString());
            Type type = Type.GetType(buildStr);
            var builder = (BaseBundleBuilder)Activator.CreateInstance(type, outPutPath, options, targetPlatform);
            builder.StartBuild();
        }

        void OnGUI()
        {
            s_Inspector.OnGUI();
        }

        void OnEnable()
        {
            s_Inspector = new AssetBundleWindowInpector();
            s_Inspector.OnEnable();
        }
    }
}

