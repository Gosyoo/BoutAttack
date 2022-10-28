using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManage {

    public static Dictionary<BuffID, BuffData> buffHash;

    public BuffManage() {
        buffHash = new Dictionary<BuffID, BuffData>();

        BuffData data = new BuffData(BuffID.Buff_Atk, BuffType.Value, 1);
        data.AttrType = PlayerExtraAttr.Atk;
        data.value = 0.5f;
        //data.effPrefab = 
        buffHash.Add(BuffID.Buff_Atk, data);
    }

    public static BUFF CreateBuff(BuffID id, LivingEntity target) {
        return new BUFF(id, target);
    }

    public static void AddBuff(BUFF buff, LivingEntity target) {
        target.buffs.Add(buff);
    }

    public static void RemoveBuff(BUFF buff, LivingEntity target) {
        target.buffs.Remove(buff);
    }

}

//buff����
public class BuffData {

    public BuffID id;
    public BuffType type;
    //�����ִ�
    public int count;

    //�޸�����
    public PlayerExtraAttr AttrType;
    //�޸�ֵ
    public float value;
    //չʾ��ЧԤ����
    public GameObject effPrefab;

    public BuffData(BuffID _id, BuffType _type, int _count) {
        id = _id;
        type = _type;
        count = _count;
    }
}

//buffID
public enum BuffID {
    Buff_Atk,
    Debuff_Atk,
}

//buff����
public enum BuffType {
    Value, //�ı���ֵ��
    Action,//������
}
