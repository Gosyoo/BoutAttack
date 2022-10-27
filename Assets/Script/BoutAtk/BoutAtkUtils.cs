using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 行动类型
/// </summary>
public enum ActivonType {
    Fight, //格斗
    Cure, //治疗
    Move, //移动
}

/// <summary>
/// 行动结果
/// </summary>
public enum ActResult {
    WOW,
    SUCCEED,
    FAIL,
    FIASCO,
    NUll,
}

/// <summary>
/// 骰子类型
/// </summary>
public enum DiceType {
    D4 = 4,
    D6 = 6,
    D10 = 10,
    D20 = 20,
}

/// <summary>
/// 轮状态
/// </summary>
public enum BoutState {
    Ready,  //准备
    Doing, //进行中
    End,  //结束
}

[System.Serializable]
public struct DiceData {
    public DiceType diceType;
    public int diceCount;
    public int big_succeed;
    public int big_fail;

    public DiceData(DiceType _type, int _count) {
        diceType = _type;
        diceCount = _count;

        int all = (int)diceType * diceCount;
        big_succeed = Mathf.Clamp((int)(all * 0.2), 1, all);
        big_fail = Mathf.Clamp((int)(all * 0.8), 1, all);
    }
}


public static class BoutAtkUtils {

    /// <summary>
    /// 抛骰子
    /// </summary>
    /// <returns></returns>
    public static int ThrowDice(DiceData data) {
        System.Random random = new System.Random((int)(Time.time * 1000));
        int reward = 0;
        for (int i = 0; i < data.diceCount; i++) {
            int randomNum = random.Next(1, (int)data.diceType + 1); //随机值
            reward += randomNum;
        }
        Debug.Log("投掷结果 :" + reward);
        return reward;
    }



}


