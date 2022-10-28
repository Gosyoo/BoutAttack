using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityInfo {

    public Dictionary<PlayerInfo, string> Info;
    public Dictionary<PlayerAttr, int> Attr;
    public Dictionary<PlayerExtraAttr, float> ExtraAttr;

    public EntityInfo() {
        Info = new Dictionary<PlayerInfo, string>() {
            { PlayerInfo.Name, "Player" }
        };

        Attr = new Dictionary<PlayerAttr, int>() {
            { PlayerAttr.MaxHP, 20 },
            { PlayerAttr.CurHP, 20 },
            { PlayerAttr.Attack, 10 },
            { PlayerAttr.Defense, 10 },
        };

        ExtraAttr = new Dictionary<PlayerExtraAttr, float>() {
            { PlayerExtraAttr.Atk, 1.0f },
            { PlayerExtraAttr.Def, 1.0f },
        };
    }

}

//角色信息
public enum PlayerInfo {
    Name,
    Level,
}

//角色属性
public enum PlayerAttr {
    MaxHP,
    CurHP,
    Attack,
    Defense,
}

//角色额外属性
public enum PlayerExtraAttr {
    Atk,  //攻击加成
    Def,  //防御加成
}
