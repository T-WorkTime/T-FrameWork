using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFrameWork.Core.AssetBundleRuntime
{
    public interface ILoader
    {
        void Load<T>(string bundleName, string assetName, LoadType loadType, Object userData, object param, LoadAssetCallBack<T> callBack, int priority)where T: UnityEngine.Object;

        void Unload(string bundleName, bool unloadAllLoadedObjects, bool isScene);

        void UnloadUnUseCacheAsset();

        void ImmediatelyUnloadBundle(string bundleName, bool unloadAllLoadedObjects, bool isScene);

        void Update();

        void Close();

    }
}

