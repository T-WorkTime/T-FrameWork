using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TFrameWork.Core.AssetBundleEditor
{
    internal sealed class AndroidBuilder : BaseBundleBuilder
    {
        public AndroidBuilder(string outPutPath, BuildAssetBundleOptions op, BuildTarget target)
            : base(outPutPath, op, target)
        {

        }

        public override void StartBuild()
        {
            CheckAssets();
            var builds = CollectAssets();
            var manifest = BuildAssetBundle(builds);
            ReporterLog();
        }

    }
}
