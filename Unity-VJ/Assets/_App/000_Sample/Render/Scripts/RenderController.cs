using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderController : MonoBehaviour
{
    [SerializeField] private Camera targetCamera; // 操作対象のカメラ

    private void Start()
    {
        if (targetCamera == null)
        {
            targetCamera = Camera.main; // メインカメラをデフォルトに設定
        }
    }

    public void SetRender1()
    {
        // UI以外のすべてを表示
        targetCamera.cullingMask = ~(1 << LayerMask.NameToLayer("UI"));
        Debug.Log("All without UI");
    }

    public void SetRender2()
    {
        // Main(レイヤー6) + Sub(レイヤー7)のみを表示
        targetCamera.cullingMask = (1 << LayerMask.NameToLayer("Main")) | (1 << LayerMask.NameToLayer("Sub"));
        Debug.Log("Main + Sub");
    }

    public void SetRender3()
    {
        // Main(レイヤー6)のみを表示
        targetCamera.cullingMask = (1 << LayerMask.NameToLayer("Main"));
        Debug.Log("Main");
    }
}
