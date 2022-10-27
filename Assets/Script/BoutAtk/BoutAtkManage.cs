using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoutAtkManage : MonoBehaviour {

    public List<Transform> entityList;

    public Text dialogText;
    public LivingHUD myHUD;
    public LivingHUD enemyHUD;

    public GameObject buttonGroup;
    public Transform middlePos;

    private LivingEntity currLivingEntity;

    private bool END = false;
    private int entityIndex = 0;

    void InitData() {
        foreach (var item in entityList) {
            LivingEntity living = item.GetComponent<LivingEntity>();
            living.TurnStart += OnTurnStart;
            living.TurnEnd += OnTurnEnd;
            living.OnDeath += OnBoutEnd;
        }

        entityIndex = 0;
        END = false;

        myHUD.setHUD(entityList[0].GetComponent<LivingEntity>().info);
        enemyHUD.setHUD(entityList[1].GetComponent<LivingEntity>().info);
    }

    void Start() {

        InitData();
        buttonGroup.SetActive(false);
        StartBout();
    }

    void Update() {
        if (!END) {
            UpdateHP();
        }
    }

    //����HP
    void UpdateHP() {
        myHUD.setHP(entityList[0].GetComponent<LivingEntity>().info.currentHealth);
        enemyHUD.setHP(entityList[1].GetComponent<LivingEntity>().info.currentHealth);
    }

    //��ʼս��
    void StartBout() {
        if (END) {
            BoutEnd();
            return;
        }
        if (entityIndex < entityList.Count) {
            LivingEntity curEntityScript = entityList[entityIndex].GetComponent<LivingEntity>();
            currLivingEntity = curEntityScript;
            currLivingEntity.TurnUp();
        }
    }

    //�غϿ�ʼ
    private IEnumerator OnTurnStart() {
        dialogText.text = currLivingEntity.info.name + "׼���ж���!";
        yield return null;
    }

    //�غϽ���
    private IEnumerator OnTurnEnd() {
        buttonGroup.SetActive(false);
        yield return new WaitForSeconds(2f);
        entityIndex++;
        if (entityIndex >= entityList.Count) {
            entityIndex = 0;
        }
        StartBout();
    }

    //����
    private void OnBoutEnd() {
        END = true;
        UpdateHP();
    }

    //ս������
    private void BoutEnd() {
        GameObject[] playerArr = GameObject.FindGameObjectsWithTag("Player");
        foreach (var item in playerArr) {
            if (!item.GetComponent<LivingEntity>().isDie) {
                dialogText.text = "�غϽ��������ʤ����";
                return;
            }
        }
        dialogText.text = "ʧ���ˣ�";
        return;
    }

    //�����ı�չʾ
    public void SetDialogText(string str) {
        dialogText.text = str;
    }
}
