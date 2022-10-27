//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////»Øµ÷º¯Êý
//public delegate System.Action livingAct();

//public class LivingAction {

//    private EntityInfo info;

//    public LivingAction(ref EntityInfo info) {
//        this.info = info;
//    }

//    public static void Fight(LivingEntity target, livingAct Func = null) {
//        DiceData dice = new DiceData(DiceType.D6, 1);
//        int damage = BoutAtkUtils.ThrowDice(dice);
//        target.GotHurt(damage);
//        Func();
//    }

//    public static void Cure(LivingEntity target, livingAct Func = null) {
//        DiceData dice = new DiceData(DiceType.D4, 2);
//        int value = BoutAtkUtils.ThrowDice(dice);
//        target.GotHurt(damage);
//    }

//    public static void FireBall(LivingEntity target, livingAct Func = null) {

//    }
//}
