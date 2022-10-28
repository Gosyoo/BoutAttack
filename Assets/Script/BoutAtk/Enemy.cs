using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : LivingEntity {

    protected override void Start() {
        base.Start();
        info.Info[PlayerInfo.Name] = "²ÐÆÆÈÝÆ÷";
    }

    protected override void SetAction() {
        base.SetAction();
        StartCoroutine(Show());
    }

    public IEnumerator Show() {
        yield return new WaitForSeconds(2);

        UnityAction func;
        DiceData dice = new DiceData(DiceType.D6, 1);
        int value = BoutAtkUtils.ThrowDice(dice);
        if (value > 0 && value <= 2) {
            func = skills[0].GetOnClikFunc();
        } else if (value > 2 && value <= 4) {
            func = skills[1].GetOnClikFunc();
        } else {
            func = skills[2].GetOnClikFunc();
        }
        func();
    }
}
