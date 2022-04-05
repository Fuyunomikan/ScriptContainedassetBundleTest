using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BundledScriptManager : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) LoadAndAttachComponent();
    }

    /// <summary>
    /// アセットバンドルからアセンブリを生成して、オブジェクトにAddComponentする
    /// </summary>
    private void LoadAndAttachComponent()
    {
        //アセットバンドルのロード
        AssetBundle bundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundle/bundledassembly");

        //TextAssetとしてバンドルデータを取得
        TextAsset text = bundle.LoadAsset<TextAsset>("AdditionalAssembly");

        //byte配列に変換
        byte[] bytes = text.bytes;

        //アセンブリに変換
        Assembly assembly = Assembly.Load(bytes);
        Debug.Log("ロードしたアセンブリ名：" + assembly.FullName);

        //アセンブリ内のType情報取得
        var type = assembly.GetTypes();
        Debug.Log("アセンブリ内のクラス名：" + type[0]);

        //ロードしたTypeのAdd
        targetObject.AddComponent(type[0]);
    }
}


/*
 * アセンブリ内のクラス
 * 
 * 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BundledScript
{
    public class Component : MonoBehaviour
    {
        public void Start()
        {
            Debug.Log("このメソッドはアセットバンドル内のスクリプトから出力されています");
        }
    }
}
 */
