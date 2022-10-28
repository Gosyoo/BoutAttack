using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BUFF {

    public BuffID buffID;
    //当前生效轮数
    public int currCount;
    //作用目标
    private LivingEntity target;
    //特效预制体
    private GameObject effPrefab;
    //buff数据
    private BuffData buffData;

    public BUFF(BuffID _buffID, LivingEntity _target) {
        buffID = _buffID;
        target = _target;
        buffData = BuffManage.buffHash[buffID];
        currCount = buffData.count;

        target.TurnStart += BuffStart;
        target.TurnEnd += BuffEnd;

        BuffManage.AddBuff(this, target);
    }

    //生效
    public IEnumerator BuffStart() {
        if (currCount > 0) {
            Object.Instantiate(effPrefab, target.transform.position, Quaternion.identity);
            TakeEffect();
        }
        yield return null;
    }

    //失效
    public IEnumerator BuffEnd() {
        currCount = Mathf.Max(0, currCount - 1);
        if (currCount == 0) {
            DestoryBuff();
        }
        yield return null;
    }

    //buff生效
    protected virtual void TakeEffect() {

    }

    //buff失效
    protected virtual void LoseEffect() {

    }

    //buff销毁
    public void DestoryBuff() {
        GameObject.Destroy(effPrefab);
        target.TurnStart -= BuffStart;
        target.TurnEnd -= BuffEnd;
        LoseEffect();
        BuffManage.RemoveBuff(this, target);
    }
}
