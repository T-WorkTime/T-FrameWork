using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TFrameWork.Core.AssetBundleRuntime
{
    internal sealed partial class AssetBundleManager : BaseManager, IAssetBundleManager
    {
        private BundleLoader m_Loader;

        public override void Initialize(int priority)
        {
            base.Initialize(priority);
            m_Loader = new BundleLoader();
        }

        public void LoadAsset<T>(string bundleName, string assetName, LoadType loadType, Object userData, object param, LoadAssetCallBack<T> callBack, int priority) where T : Object
        {
            if (string.IsNullOrEmpty(bundleName))
            {

            }

            if (string.IsNullOrEmpty(assetName))
            {

            }
            m_Loader.Load<T>(bundleName, assetName, loadType, userData, param, callBack, priority);
        }

        public void LoadAsset<T>(string bundleName, string assetName, LoadType loadType, Object userData, object param, LoadAssetCallBack<T> callBack) where T : Object
        {
            if (string.IsNullOrEmpty(bundleName))
            {

            }

            if (string.IsNullOrEmpty(assetName))
            {

            }
            m_Loader.Load<T>(bundleName, assetName, loadType, userData, param, callBack, 0);
        }

        public void LoadAsset<T>(string bundleName, string assetName, LoadType loadType, Object userData,  LoadAssetCallBack<T> callBack) where T : Object
        {
            if (string.IsNullOrEmpty(bundleName))
            {

            }

            if (string.IsNullOrEmpty(assetName))
            {

            }
            m_Loader.Load<T>(bundleName, assetName, loadType, userData, null, callBack, 0);
        }

        public void LoadAsset<T>(string bundleName, string assetName, LoadType loadType, LoadAssetCallBack<T> callBack) where T : Object
        {
            if (string.IsNullOrEmpty(bundleName))
            {

            }

            if (string.IsNullOrEmpty(assetName))
            {

            }
            m_Loader.Load<T>(bundleName, assetName, loadType, null, null, callBack, 0);
        }

        public void UnloadUnUseCacheAsset()
        {
            m_Loader.UnloadUnUseCacheAsset();
        }

        public void Unload(string bundleName, bool unloadAllLoadedObjects, bool isScene)
        {
            if (string.IsNullOrEmpty(bundleName))
            {

            }
            m_Loader.Unload(bundleName, isScene, unloadAllLoadedObjects);
        }

        public override void Update()
        {
            m_Loader.Update();
        }

        public override void Destroy()
        {
            m_Loader.Close();
            m_Loader = null;
        }


    }
}
