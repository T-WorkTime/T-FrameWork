using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TFrameWork.Core.AssetBundleRuntime
{
    internal sealed class BundleLoader : ILoader
    {
        
        public void ImmediatelyUnloadBundle(string bundleName, bool unloadAllLoadedObjects, bool isScene)
        {
            
        }

        public void Load<T>(string bundleName, string assetName, LoadType loadType, Object userData, object param, LoadAssetCallBack<T> callBack, int priority)where T: UnityEngine.Object
        {
            
        }

        public void Unload(string bundleName, bool unloadAllLoadedObjects, bool isScene)
        {
            
        }

        public void UnloadUnUseCacheAsset()
        {
            
        }

        public void Update()
        {
            
        }

        public void Close()
        {
            
        }

        private void SetAssetInfo<T>(string bundleName, string assetName, LoadType loadType, Object userData, object param, LoadAssetCallBack<T> callBack, int priority)where T: UnityEngine.Object
        {
            
            switch (loadType)
            {
                case LoadType.AsycLoadStream:
                case LoadType.SyncLoadStream:
                    break;
                case LoadType.AsyncLoadFromFile:
                case LoadType.SyncLoadFromFle:
                    break;
                case LoadType.AsyncLoadFromMemory:
                case LoadType.SyncLoadFromMemory:
                    break;
                case LoadType.AsyncLoadScene:
                case LoadType.SyncLoadScene:
                    break;
                default:
                    break;

            }
        }
    }
}

