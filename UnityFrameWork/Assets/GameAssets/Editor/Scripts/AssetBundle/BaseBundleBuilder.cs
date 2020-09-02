using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

namespace TFrameWork.Core.AssetBundleEditor
{
    internal abstract class BaseBundleBuilder 
    {
        private string m_OutPutPath;

        private BuildAssetBundleOptions m_BuildOp;

        private BuildTarget m_Target;

        private string m_Log;

        public BaseBundleBuilder(string outPutPath, BuildAssetBundleOptions op, BuildTarget target)
        {
            m_OutPutPath = outPutPath;
            m_BuildOp = op;
            m_Target = target;
        }

        public abstract void StartBuild();

        public virtual void EncryptBundle()
        {
            string[] filePaths =  Directory.GetFiles(m_OutPutPath, "*.ab");
            for (int file_index = 0; file_index < filePaths.Length; file_index++)
            {
                string path = filePaths[file_index];
                string fileName = Path.GetFileName(path);
                byte[] bytes = File.ReadAllBytes(path);
                byte[] hashCodeBytes = Encoding.ASCII.GetBytes(fileName.GetHashCode().ToString());
                byte[] encryptBytes = new byte[bytes.Length + hashCodeBytes.Length];
                Array.Copy(hashCodeBytes, 0, encryptBytes, 0, hashCodeBytes.Length);
                Array.Copy(bytes, 0, encryptBytes, hashCodeBytes.Length, bytes.Length);
                File.WriteAllBytes(path, encryptBytes);
            }
        }
            

        public virtual void CheckAssets()
        {

        }

        public virtual AssetBundleBuild[] CollectAssets()
        {
            return null;
        }

        public virtual AssetBundleManifest BuildAssetBundle( AssetBundleBuild[]bundleBuilds)
        {
            return BuildPipeline.BuildAssetBundles(m_OutPutPath, bundleBuilds, m_BuildOp, m_Target);
        }

        /// <summary>
        /// 把出错的资源记录下来，打包完上传到飞书
        /// </summary>
        public virtual void ReporterLog()
        {

        }
    }
}
