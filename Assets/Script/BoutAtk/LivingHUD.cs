using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingHUD : MonoBehaviour {
    public Text myInfo;
    public Slider mySlider;
    public Text mySliderValue;

    public void setHUD(EntityInfo info) {
        myInfo.text = info.Info[PlayerInfo.Name];
        mySlider.maxValue = info.Attr[PlayerAttr.MaxHP];
        mySlider.value = info.Attr[PlayerAttr.CurHP];
        mySliderValue.text = info.Attr[PlayerAttr.CurHP] + "/" + info.Attr[PlayerAttr.MaxHP];
    }


    public void setHP(int hp) {
        int value = Mathf.Clamp(hp, 0, (int)mySlider.maxValue);
        mySlider.value = value;
        mySliderValue.text = value + "/" + mySlider.maxValue;
    }
}
