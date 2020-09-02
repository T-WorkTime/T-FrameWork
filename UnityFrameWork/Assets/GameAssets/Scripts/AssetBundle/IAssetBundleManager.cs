using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFrameWork.Core.AssetBundleRuntime
{
    public interface IAssetBundleManager
    {
        void LoadAsset<T>(string bundleName, string assetName, LoadType loadType, Object userData, object param, LoadAssetCallBack<T> callBack, int priority) where T: UnityEngine.Object;
       
    }
}


