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

//��ɫ��Ϣ
public enum PlayerInfo {
    Name,
    Level,
}

//��ɫ����
public enum PlayerAttr {
    MaxHP,
    CurHP,
    Attack,
    Defense,
}

//��ɫ��������
public enum PlayerExtraAttr {
    Atk,  //�����ӳ�
    Def,  //�����ӳ�
}
