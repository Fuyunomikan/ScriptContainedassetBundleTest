using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CleateAssetBundleEditor : MonoBehaviour
{
    [MenuItem("Example/CreateAssetBundle")]
    static private void BuildAssetBundle()
    {
        var builds = new List<UnityEditor.AssetBundleBuild>();

        //�A�Z�b�g�w��
        var build = new AssetBundleBuild();
        build.assetBundleName = "bundledassembly";
        build.assetNames = new string[1] { "Assets/Scripts/DLL/AdditionalAssembly.bytes" };
        builds.Add(build);

        //�r���h
        UnityEditor.BuildPipeline.BuildAssetBundles(
                Application.dataPath + "/AssetBundle",
                builds.ToArray(),
                UnityEditor.BuildAssetBundleOptions.ChunkBasedCompression,
                UnityEditor.BuildTarget.StandaloneWindows64
            );

        Debug.Log("Build Finished");
    }
}