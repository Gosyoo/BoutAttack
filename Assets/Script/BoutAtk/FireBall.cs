using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public Transform fromPoint;     // 起始点
    public Transform middlePoint;   // 中间点
    public Transform endPoint;      // 终止点
    public Transform moveObj;       // 要移动的物体
    public GameObject effPrefab;

    private float ticker = 0.0f;

    private float attackTime = 2.0f;    // 假设要用2秒飞到目标点
    private bool isOK = false;

    public void InitFireBall(Transform s_pos, Transform m_pos, Transform e_pos,float time) {
        fromPoint = s_pos;
        middlePoint = m_pos;
        endPoint = e_pos;
        attackTime = time;
        isOK = true;
    }


    /// <summary>
    /// 返回曲线在某一时间t上的点
    /// </summary>
    /// <param name="_p0">起始点</param>
    /// <param name="_p1">中间点</param>
    /// <param name="_p2">终止点</param>
    /// <param name="t">当前时间t(0.0~1.0)</param>
    /// <returns></returns>
    public static Vector3 GetCurvePoint(Vector3 _p0, Vector3 _p1, Vector3 _p2, float t) {
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        float x = ((1 - t) * (1 - t)) * _p0.x + 2 * t * (1 - t) * _p1.x + t * t * _p2.x;
        float y = ((1 - t) * (1 - t)) * _p0.y + 2 * t * (1 - t) * _p1.y + t * t * _p2.y;
        float z = ((1 - t) * (1 - t)) * _p0.z + 2 * t * (1 - t) * _p1.z + t * t * _p2.z;
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }

    private void Update() {
        if (!isOK) return;
        ticker += Time.deltaTime;
        float t = ticker / attackTime;  // 这里是计算当前已用时间占计划用时间的百分比，当作增量t
        t = Mathf.Clamp(t, 0.0f, 1.0f);
        Vector3 p1 = fromPoint.position;
        Vector3 p2 = middlePoint.position;
        Vector3 p3 = endPoint.position;
        Vector3 currPos = GetCurvePoint(p1, p2, p3, t);
        moveObj.position = currPos;

        if (t == 1.0f) {
            // 到达目标点
            Instantiate(effPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
