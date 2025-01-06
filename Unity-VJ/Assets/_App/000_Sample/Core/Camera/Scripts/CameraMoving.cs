using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    // ���S�_
    [SerializeField] private Vector3 _center = Vector3.zero;

    // ��]��
    [SerializeField] private Vector3 _axis = Vector3.up;

    // �~�^������
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
        // ��]�̃N�H�[�^�j�I���쐬
        var angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // �~�^���̈ʒu�v�Z
        var pos = tr.position;

        pos -= _center;
        pos = angleAxis * pos;
        pos += _center;

        tr.position = pos;

    }
}
