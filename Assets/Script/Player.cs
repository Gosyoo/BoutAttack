using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotateSpeed = 200;
    public float maxDistance = 200;
    public LayerMask rayCheckLayer;
    public BoomEff boomEff;

    public LineRenderer rayLineRender;

    // Start is called before the first frame update
    void Start() {
        rayLineRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        //Ðý×ª(ÈÆzÖáÐý×ª)
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        Debug.DrawLine(transform.position, transform.up * 15, Color.red);

        //ÉäÏß¼ì²â
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, transform.up, maxDistance, rayCheckLayer);
        if (rayInfo.collider != null) {
            Instantiate(boomEff, rayInfo.point, Quaternion.identity);
            if (rayLineRender) {
                rayLineRender.enabled = true;
                rayLineRender.SetPosition(1, rayInfo.point);
            }
        } else {
            rayLineRender.enabled = false;
        }

    }
}
