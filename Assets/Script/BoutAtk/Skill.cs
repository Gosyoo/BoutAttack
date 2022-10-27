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
    //拥有者
    public LivingEntity _entity;
    //技能类型
    public SkillType skillType;
    //技能数值
    public DiceData skillDamage;
    //技能名
    public string skillName;
    //技能特效
    public string effTrightName;
    //技能特效预制体
    public GameObject effPrefab;
    //特效时间
    public float effTime = 0.3f;


    public Skill() {

    }

    //获取点击方法
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

    //战斗
    protected virtual IEnumerator Fight() {
        int damage = BoutAtkUtils.ThrowDice(skillDamage);
        FightEff();
        yield return new WaitForSeconds(effTime);
        _entity.target.GotHurt(damage);
        _entity.manage.SetDialogText(_entity.info.name + "使用了攻击，造成了" + damage + "点伤害");
        Debug.Log(_entity.info.name + "造成了" + damage + "点伤害");
    }

    protected virtual IEnumerator Cure() {
        int value = BoutAtkUtils.ThrowDice(skillDamage);
        CureEff();
        yield return new WaitForSeconds(effTime);
        _entity.CureHP(value);
        _entity.manage.SetDialogText(_entity.info.name + "使用了治疗，恢复了" + value + "点生命");
        Debug.Log(_entity.info.name + "恢复了" + value + "点生命");
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
