using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneConfig : MonoBehaviour {
    public sceneConfigObject mInfo;

    public void LoadScriptableObject() {
        var configObj = Instantiate(Resources.Load("config/test01") as sceneConfigObject);
        Debug.Log(configObj.mIndex);
        Debug.Log(configObj.spawnPos);
    }
}

public class sceneConfigObject : ScriptableObject {
    /// <summary>
    /// 配置名字
    /// </summary>
    public string mIndex;
    /// <summary>
    /// 出生点位置
    /// </summary>
    public Vector3 spawnPos;
}

