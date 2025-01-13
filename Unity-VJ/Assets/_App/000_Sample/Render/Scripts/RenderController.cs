using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderController : MonoBehaviour
{
    [SerializeField] private Camera targetCamera; // ����Ώۂ̃J����

    private void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main; // ���C���J�������f�t�H���g�ɐݒ�
        }
    }

    public void SetRender1()
    {
        // UI�ȊO�̂��ׂĂ�\��
        targetCamera.cullingMask = ~(1 << LayerMask.NameToLayer("UI"));
        Debug.Log("All without UI");
    }

    public void SetRender2()
    {
        // Main(���C���[6) + Sub(���C���[7)�݂̂�\��
        targetCamera.cullingMask = (1 << LayerMask.NameToLayer("Main")) | (1 << LayerMask.NameToLayer("Sub"));
        Debug.Log("Main + Sub");
    }

    public void SetRender3()
    {
        // Main(���C���[6)�݂̂�\��
        targetCamera.cullingMask = (1 << LayerMask.NameToLayer("Main"));
        Debug.Log("Main");
    }
}
