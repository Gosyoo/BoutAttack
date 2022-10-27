using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType {
    Buff,
    DeBuff,
}

public delegate void BuffFunc();

public class BUFF {

    public BuffType buffType;
    //当前生效轮数
    public int currCount;
    //作用目标
    private LivingEntity _target;
    //特效预制体
    private GameObject effPrefab;
    //buff效果
    private BuffFunc buffFunc;

    public BUFF(int count, GameObject eff, BuffFunc func) {
        currCount = count;
        effPrefab = eff;
        buffFunc = func;
    }

    //生效
    public void TakeEffect(LivingEntity target) {
        _target = target;
        if (currCount > 0) {
            Object.Instantiate(effPrefab, _target.transform.position, Quaternion.identity);
            buffFunc();
            currCount = Mathf.Max(0, currCount - 1);
        }
    }

    //失效
    public void LoseEffect() {
        GameObject.Destroy(effPrefab);
    }
    //3 回合 攻击 加成 buff

    //3 回合 攻击 削减 debuff
}
