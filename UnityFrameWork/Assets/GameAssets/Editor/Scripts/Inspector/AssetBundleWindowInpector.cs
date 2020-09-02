using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TFrameWork.Core.AssetBundleRuntime;
using LitJson;

namespace TFrameWork.Core.AssetBundleEditor
{
    internal sealed class AssetBundleWindowInpector
    {

        private string m_Version;

        public string Version
        {
            get
            {
                return m_Version;
            }
            set
            {
                m_Version = value;
            }
        }

        private string m_ResVersion;

        public string ResVersion
        {
            get
            {
                return m_ResVersion;
            }
            set
            {
                m_ResVersion = value;
            }
        }
        
        private LoadType m_LoadType;

        public LoadType LoadMethodType
        {
            get
            {
                return m_LoadType;
            }
            set
            {
                m_LoadType = value;
            }
        }

        private string m_OutPutPath = Application.streamingAssetsPath;

        public string OutPutPath
        {
            get
            {
                return m_OutPutPath;
            }
            set
            {
                m_OutPutPath = value;
            }
        }

        private BuildTarget m_TargetPlatform = EditorUserBuildSettings.activeBuildTarget;

        public BuildTarget TargetPlatform
        {
            get
            {
                return m_TargetPlatform;
            }
            set
            {
                m_TargetPlatform = value;
            }
        }

        private static BuildAssetBundleOptions m_Options = BuildAssetBundleOptions.ChunkBasedCompression;

        public static BuildAssetBundleOptions Opations
        {
            get
            {
                return m_Options;
            }
            set
            {
                m_Options = value;
            }
        }

        public AssetBundleWindowInpector()
        {
        }


        public void Open()
        {

        }

        public void Update()
        {

        }

        public void OnGUI()
        {
            GUILayout.BeginVertical();
            EditorGUILayout.LabelField("Version", GUILayout.Width(160f));
            m_Version = EditorGUILayout.TextField(m_Version);
            EditorGUILayout.LabelField("ResVersion", GUILayout.Width(160f));
            m_ResVersion = EditorGUILayout.TextField(m_ResVersion);
            EditorGUILayout.LabelField("OutPutPackagePath", GUILayout.Width(160f));
            m_OutPutPath = EditorGUILayout.TextField(m_OutPutPath);
            EditorGUILayout.LabelField("LoadType", GUILayout.Width(160f));
            EditorGUILayout.EnumPopup(m_LoadType);
            EditorGUILayout.LabelField("TargetPlatform", GUILayout.Width(160f));
            EditorGUILayout.EnumPopup(m_TargetPlatform);
            EditorGUILayout.LabelField("CompressType", GUILayout.Width(160f));
            EditorGUILayout.EnumPopup(m_Options);
            GUILayout.Space(15);
            if (GUILayout.Button("开始build assetbundle", GUILayout.Width(900), GUILayout.Height(22)))
            {
                AssetBundleBuilder.StartBuild(m_LoadType, m_OutPutPath, m_TargetPlatform, m_Options);
            } 
            GUILayout.EndVertical();
        }

        public void OnEnable()
        {
            LoadConfig();
        }

        private void ReadAssetConfig()
        {

        }

        private void LoadConfig()
        {
            string configStr = EditorPrefs.GetString("BuildConfig", "");
            if (!string.IsNullOrEmpty(configStr))
            {
                var buildConfig = JsonMapper.ToObject<BuildConfig>(configStr);
                m_Version = buildConfig.m_Version;
                m_ResVersion = buildConfig.m_ResVersion;
                m_OutPutPath = buildConfig.m_OutPutPath;
                m_TargetPlatform = buildConfig.m_TargetPlatform;
                m_LoadType = buildConfig.m_LoadType;
                m_Options = buildConfig.m_Options;
            }
            else
            {
                m_Version = "1.0.1";
                m_ResVersion = "1.0.1.1";
                m_OutPutPath = Application.streamingAssetsPath;
                m_TargetPlatform = EditorUserBuildSettings.activeBuildTarget;
                m_LoadType = LoadType.AsyncLoadFromFile;
                m_Options = BuildAssetBundleOptions.ChunkBasedCompression;
            }
        }

        internal sealed class BuildConfig
        {
            public string m_Version;

            public string m_ResVersion;

            public string m_OutPutPath;

            public LoadType m_LoadType;

            public BuildAssetBundleOptions m_Options;

            public BuildTarget m_TargetPlatform;
        }

    }
}

