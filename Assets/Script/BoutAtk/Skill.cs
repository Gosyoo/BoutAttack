using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum SkillType {
    ATTACK,
    CURE,
    BUFF,
    DEBUFF,
}

public delegate IEnumerator SkillFunc();

[System.Serializable]
public class Skill {
    //ӵ����
    public LivingEntity _entity;
    //��������
    public SkillType skillType;
    //������ֵ
    public DiceData skillDamage;
    //������
    public string skillName;
    //������Ч
    public string effTrightName;
    //������ЧԤ����
    public GameObject effPrefab;
    //��Чʱ��
    public float effTime = 0.3f;


    public Skill() {

    }

    //��ȡ�������
    public UnityAction GetOnClikFunc() {
        SkillFunc skillFunc;
        if (skillType == SkillType.ATTACK) {
            skillFunc = new SkillFunc(Fight);
        } else if (skillType == SkillType.CURE) {
            skillFunc = new SkillFunc(Cure);
        } else if (skillType == SkillType.BUFF) {
            skillFunc = new SkillFunc(Fight);
        } else if (skillType == SkillType.DEBUFF) {
            skillFunc = new SkillFunc(Fight);
        } else {
            skillFunc = new SkillFunc(() => { return null; });
        }
        return new UnityAction(() => {
            if (_entity.State != BoutState.Doing) return;
            _entity.StartCoroutine(skillFunc());
            _entity.TurnDown();
        });
    }

    //ս��
    protected virtual IEnumerator Fight() {
        int damage = BoutAtkUtils.ThrowDice(skillDamage);
        FightEff();
        yield return new WaitForSeconds(effTime);
        _entity.target.GotHurt(damage);
        _entity.manage.SetDialogText(_entity.info.name + "ʹ���˹����������" + damage + "���˺�");
        Debug.Log(_entity.info.name + "�����" + damage + "���˺�");
    }

    protected virtual IEnumerator Cure() {
        int value = BoutAtkUtils.ThrowDice(skillDamage);
        CureEff();
        yield return new WaitForSeconds(effTime);
        _entity.CureHP(value);
        _entity.manage.SetDialogText(_entity.info.name + "ʹ�������ƣ��ָ���" + value + "������");
        Debug.Log(_entity.info.name + "�ָ���" + value + "������");
    }

    //protected virtual void Buff() {
    //    BuffFunc func = new BuffFunc(() => {

    //    });
    //    BUFF buff = new BUFF(2, effPrefab, func);
    //    _entity.AddBuff(buff);
    //}

    //protected virtual void DeBuff() {
    //    _entity.target.AddBuff();
    //}

    public void FightEff() {
        _entity.anim.SetTrigger("Fight");
        if (effPrefab) {
            GameObject eff = Object.Instantiate(effPrefab, _entity.throwPos.position, Quaternion.identity);
            eff.GetComponent<FireBall>().InitFireBall(_entity.throwPos, _entity.manage.middlePos, _entity.target.throwPos, effTime);
        }
    }


    public void CureEff() {
        _entity.anim.SetTrigger("Cure");
        Object.Instantiate(effPrefab, _entity.transform.position, Quaternion.identity);
    }

}
