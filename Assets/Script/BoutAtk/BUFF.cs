using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BUFF {

    public BuffID buffID;
    //��ǰ��Ч����
    public int currCount;
    //����Ŀ��
    private LivingEntity target;
    //��ЧԤ����
    private GameObject effPrefab;
    //buff����
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

    //��Ч
    public IEnumerator BuffStart() {
        if (currCount > 0) {
            Object.Instantiate(effPrefab, target.transform.position, Quaternion.identity);
            TakeEffect();
        }
        yield return null;
    }

    //ʧЧ
    public IEnumerator BuffEnd() {
        currCount = Mathf.Max(0, currCount - 1);
        if (currCount == 0) {
            DestoryBuff();
        }
        yield return null;
    }

    //buff��Ч
    protected virtual void TakeEffect() {

    }

    //buffʧЧ
    protected virtual void LoseEffect() {

    }

    //buff����
    public void DestoryBuff() {
        GameObject.Destroy(effPrefab);
        target.TurnStart -= BuffStart;
        target.TurnEnd -= BuffEnd;
        LoseEffect();
        BuffManage.RemoveBuff(this, target);
    }
}
