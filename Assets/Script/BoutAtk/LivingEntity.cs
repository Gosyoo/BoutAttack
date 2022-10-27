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
        info.currentHealth -= hit;

        HitEff();
        if (info.currentHealth <= 0 && !isDie) {
            Die();
        }
    }

    public virtual void CureHP(int v) {
        info.currentHealth += v;
        if (info.currentHealth > info.maxHealth) {
            info.currentHealth = info.maxHealth;
        }
    }

    ////���buff
    //public void AddBuff(BUFF buff) {
    //    buffs.Add(buff);
    //}

    ////�Ƴ�buff
    //private void RemoveBuff(BUFF buff) {
    //    buffs.Remove(buff);
    //}

    ////����buff
    //private void UpdateBuff() {
    //    foreach(var buff in buffs) {

    //    }
    //}






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
