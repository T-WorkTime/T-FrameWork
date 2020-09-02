using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TFrameWork.Core.AssetBundleRuntime
{
    public sealed class LoadAssetCallBack<T> where T: UnityEngine.Object
    {
        private Action<T, object> m_SuccessCallBack;

        private Action<object, string> m_FailCallBack;
        
        private Action<string, string, float, object> m_ProcessCallBack;

        private Action<string, string, UnityEngine.Object, object> m_DepLoadedCallBack;

        public void InvokeSuccessCallBack(T t, object userData)
        {
            if (m_SuccessCallBack != null)
                m_SuccessCallBack(t, userData);
        }

        public void InvokeFailCallBack(object userData, string errorMsg)
        {
            if (m_FailCallBack != null)
                m_FailCallBack(userData, errorMsg);
        }

        public void InvokeProcessCallBack(string bundleName, string assetName, float process, object userData)
        {
            if (m_ProcessCallBack != null)
                m_ProcessCallBack(bundleName, assetName, process, userData);
        }

        public void InvokeDepLoadedCallBack(string bundleName, string depName, UnityEngine.Object obj, object userData)
        {
            if (m_DepLoadedCallBack != null)
                m_DepLoadedCallBack(bundleName, depName, obj, userData);
        }

        public LoadAssetCallBack(Action<T, object> successCallBack, Action<object, string> failCallBack, Action<string, string, float, object>processCallBack, Action<string, string, UnityEngine.Object, object>depLoadedCallBack)
        {
            m_SuccessCallBack = successCallBack;
            m_FailCallBack = failCallBack;
            m_ProcessCallBack = processCallBack;
            m_DepLoadedCallBack = depLoadedCallBack;
        }

        public LoadAssetCallBack(Action<T, object> successCallBack)
            :this(successCallBack, null, null, null)
        {
            
        }

        public LoadAssetCallBack(Action<T, object> successCallBack, Action<object, string> failCallBack)
            :this(successCallBack, failCallBack, null, null)
        {
            
        }

        public LoadAssetCallBack(Action<T, object> successCallBack, Action<object, string> failCallBack, Action<string, string, float, object>processCallBack)
            :this(successCallBack, failCallBack, processCallBack, null)
        {
            
        }

        public LoadAssetCallBack(Action<T, object> successCallBack, Action<object, string> failCallBack, Action<string, string, UnityEngine.Object, object>depLoadedCallBack)
            :this(successCallBack, failCallBack, null, depLoadedCallBack)
        {
            
        }
    }
}

