using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(SceneConfig))]
public class SceneConfigEditor : Editor {
    SceneConfig mScript;

    /// <summary>
    /// �ű������ʱ����룬target���Ƕ�Ӧ[CustomEditor(typeof(SceneConfig))]��SceneConfig��
    /// </summary>
    public void OnEnable() {
        mScript = target as SceneConfig;
        if (mScript.mInfo == null) {
            mScript.mInfo = new sceneConfigObject();
        }
    }

    /// <summary>
    /// ���ؽű��Ľ���
    /// </summary>
    public override void OnInspectorGUI() {
        mScript.mInfo.mIndex = EditorGUILayout.TextField("����������", mScript.mInfo.mIndex);

        mScript.mInfo.spawnPos = EditorGUILayout.Vector3Field("������λ��", mScript.mInfo.spawnPos);
        //mScript.mInfo.dic = EditorGUILayout.("������λ��", mScript.mInfo.spawnPos);

        if (GUILayout.Button("����")) {
            if (string.IsNullOrEmpty(mScript.mInfo.mIndex)) {
                Debug.LogError("δ����������");
                return;
            }

            string path = "config/" + mScript.mInfo.mIndex;

            var configObj = Resources.Load(path) as sceneConfigObject;
            if (configObj != null) {
                configObj = Instantiate(configObj);
                configObj.name = mScript.mInfo.mIndex;
            }
            mScript.mInfo = configObj;
        }

        if (GUILayout.Button("����")) {
            if (string.IsNullOrEmpty(mScript.mInfo.mIndex)) {
                Debug.LogError("δ����������");
                return;
            }

            string path = "Assets/Resources/config/" + mScript.mInfo.mIndex + ".asset";

            if (File.Exists(path)) {
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }


            AssetDatabase.CreateAsset(Instantiate(mScript.mInfo), "Assets/Resources/config/" + mScript.mInfo.mIndex + ".asset");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
