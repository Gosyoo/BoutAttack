using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerController : LivingEntity {

    public Button[] buttonArr; //按钮列表

    protected override void Start() {
        base.Start();

        //给每个按钮生成时绑定点击事件
        for (int i = 0; i < buttonArr.Length; i++) {
            if (buttonArr[i] != null && skills[i] != null) {
                UnityAction action = skills[i].GetOnClikFunc();
                buttonArr[i].onClick.AddListener(action);
                buttonArr[i].GetComponentInChildren<Text>().text = skills[i].skillName;
            }
        }
        info.Info[PlayerInfo.Name] = "大壮";
    }

    protected override void SetAction() {
        base.SetAction();
        manage.buttonGroup.SetActive(true);
    }
}
