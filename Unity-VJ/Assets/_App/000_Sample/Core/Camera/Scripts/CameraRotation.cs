using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    // 中心点
    [SerializeField] private Vector3 _center = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.up;

    // 円運動周期
    [SerializeField] private float _period = 2;

    
    void Start()
    {
        
    }

    void Update()
    {
        RotateAroud();
    }

    void RotateAroud()
    {
        var tr = transform;
        // 回転のクォータニオン作成
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // 円運動の位置計算
        var pos = tr.position;

        pos -= _center;
        pos = angleAxis * pos;
        pos += _center;

        tr.position = pos;

    }
}
