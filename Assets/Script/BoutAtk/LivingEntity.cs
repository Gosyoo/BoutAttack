using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour {

    public BoutAtkManage manage;
    public LivingEntity target;
    public EntityInfo info;

    public Skill[] skills;  //技能列表
    public List<BUFF> buffs; //Buff列表

    public event System.Func<IEnumerator> TurnStart; //回合开始
    public event System.Func<IEnumerator> TurnEnd; //回合结束
    public event System.Action OnDeath; //死亡

    public Animator anim;

    public GameObject EffHit;
    public GameObject EffDie;
    public Transform throwPos;

    public bool isDie = false;
    public BoutState State = BoutState.Doing;

    protected virtual void Start() {
        //LivingAction livingAction = new LivingAction(ref info);
    }

    //回合开始
    public void TurnUp() {
        if (TurnStart != null) {
            StartCoroutine(TurnStart());
        }
        SetAction();
    }

    //行动设置
    protected virtual void SetAction() {
        State = BoutState.Doing;
    }

    //回合结束
    public virtual void TurnDown() {
        State = BoutState.End;
        if (TurnEnd != null) {
            StartCoroutine(TurnEnd()); //展示结束2s后执行回合结束
        }
    }

    public virtual void GotHurt(int hit) {
        info.Attr[PlayerAttr.CurHP] -= hit;
        int curHP = info.Attr[PlayerAttr.CurHP];
        HitEff();
        if (curHP <= 0 && !isDie) {
            Die();
        }
    }

    public virtual void CureHP(int v) {
        info.Attr[PlayerAttr.CurHP] += v;
        int curHP = info.Attr[PlayerAttr.CurHP];
        int maxHP = info.Attr[PlayerAttr.MaxHP];
        if (curHP > maxHP) {
            info.Attr[PlayerAttr.CurHP] = maxHP;
        }
    }

    protected virtual void Die() {
        isDie = true;
        if (OnDeath != null) {
            OnDeath(); //触发事件
        }
        Instantiate(EffDie, transform.position, EffDie.transform.rotation);
        Destroy(gameObject, 0.5f);
        Destroy(EffDie, 1);
    }

    public void HitEff() {
        anim.SetTrigger("Hit");
        Instantiate(EffHit, transform.position, Quaternion.identity);
    }
}
