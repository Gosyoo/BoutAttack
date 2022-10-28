using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour {

    public BoutAtkManage manage;
    public LivingEntity target;
    public EntityInfo info;

    public Skill[] skills;  //�����б�
    public List<BUFF> buffs; //Buff�б�

    public event System.Func<IEnumerator> TurnStart; //�غϿ�ʼ
    public event System.Func<IEnumerator> TurnEnd; //�غϽ���
    public event System.Action OnDeath; //����

    public Animator anim;

    public GameObject EffHit;
    public GameObject EffDie;
    public Transform throwPos;

    public bool isDie = false;
    public BoutState State = BoutState.Doing;

    protected virtual void Start() {
        //LivingAction livingAction = new LivingAction(ref info);
    }

    //�غϿ�ʼ
    public void TurnUp() {
        if (TurnStart != null) {
            StartCoroutine(TurnStart());
        }
        SetAction();
    }

    //�ж�����
    protected virtual void SetAction() {
        State = BoutState.Doing;
    }

    //�غϽ���
    public virtual void TurnDown() {
        State = BoutState.End;
        if (TurnEnd != null) {
            StartCoroutine(TurnEnd()); //չʾ����2s��ִ�лغϽ���
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
            OnDeath(); //�����¼�
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
