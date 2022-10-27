using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public delegate System.Action OnClickButton0();
public delegate System.Action OnClickButton1();
public delegate System.Action OnClickButton2();
public delegate System.Action OnClickButton3();

public class PlayerController : LivingEntity {

    public Button[] buttonArr; //��ť�б�

    protected override void Start() {
        base.Start();

        //��ÿ����ť����ʱ�󶨵���¼�
        for (int i = 0; i < buttonArr.Length; i++) {
            if (buttonArr[i] != null && skills[i] != null) {
                UnityAction action = skills[i].GetOnClikFunc();
                buttonArr[i].onClick.AddListener(action);
                buttonArr[i].GetComponentInChildren<Text>().text = skills[i].skillName;
            }
        }
    }

    protected override void SetAction() {
        base.SetAction();
        manage.buttonGroup.SetActive(true);
    }
}
