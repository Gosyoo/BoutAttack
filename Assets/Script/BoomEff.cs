using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEff : MonoBehaviour {

    private float destroyTime = 0.6f;

    private void Start() {
        Destroy(gameObject, destroyTime);
    }

}
