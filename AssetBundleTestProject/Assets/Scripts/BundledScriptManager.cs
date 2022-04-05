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
    /// �A�Z�b�g�o���h������A�Z���u���𐶐����āA�I�u�W�F�N�g��AddComponent����
    /// </summary>
    private void LoadAndAttachComponent()
    {
        //�A�Z�b�g�o���h���̃��[�h
        AssetBundle bundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundle/bundledassembly");

        //TextAsset�Ƃ��ăo���h���f�[�^���擾
        TextAsset text = bundle.LoadAsset<TextAsset>("AdditionalAssembly");

        //byte�z��ɕϊ�
        byte[] bytes = text.bytes;

        //�A�Z���u���ɕϊ�
        Assembly assembly = Assembly.Load(bytes);
        Debug.Log("���[�h�����A�Z���u�����F" + assembly.FullName);

        //�A�Z���u������Type���擾
        var type = assembly.GetTypes();
        Debug.Log("�A�Z���u�����̃N���X���F" + type[0]);

        //���[�h����Type��Add
        targetObject.AddComponent(type[0]);
    }
}


/*
 * �A�Z���u�����̃N���X
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
            Debug.Log("���̃��\�b�h�̓A�Z�b�g�o���h�����̃X�N���v�g����o�͂���Ă��܂�");
        }
    }
}
 */
