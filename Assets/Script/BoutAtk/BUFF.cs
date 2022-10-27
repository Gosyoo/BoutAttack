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
    //��ǰ��Ч����
    public int currCount;
    //����Ŀ��
    private LivingEntity _target;
    //��ЧԤ����
    private GameObject effPrefab;
    //buffЧ��
    private BuffFunc buffFunc;

    public BUFF(int count, GameObject eff, BuffFunc func) {
        currCount = count;
        effPrefab = eff;
        buffFunc = func;
    }

    //��Ч
    public void TakeEffect(LivingEntity target) {
        _target = target;
        if (currCount > 0) {
            Object.Instantiate(effPrefab, _target.transform.position, Quaternion.identity);
            buffFunc();
            currCount = Mathf.Max(0, currCount - 1);
        }
    }

    //ʧЧ
    public void LoseEffect() {
        GameObject.Destroy(effPrefab);
    }
    //3 �غ� ���� �ӳ� buff

    //3 �غ� ���� ���� debuff
}
