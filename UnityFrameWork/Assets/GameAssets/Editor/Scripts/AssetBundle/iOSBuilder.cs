﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TFrameWork.Core.AssetBundleEditor
{
    internal sealed class iOSBuilder : BaseBundleBuilder
    {
       public iOSBuilder(string outPutPath, BuildAssetBundleOptions op, BuildTarget target)
            : base(outPutPath, op, target)
        {

        }

        public override void StartBuild()
        {
            
        }
    }
}
