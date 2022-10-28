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

//buff数据
public class BuffData {

    public BuffID id;
    public BuffType type;
    //持续轮次
    public int count;

    //修改属性
    public PlayerExtraAttr AttrType;
    //修改值
    public float value;
    //展示特效预制体
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

//buff类型
public enum BuffType {
    Value, //改变数值型
    Action,//动作型
}
