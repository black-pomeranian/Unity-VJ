using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class RenderManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private RenderController renderController;

    void Start()
    {

        // CurrentMaskIndexの値を監視し、変化時にOnIndexChangedを呼び出す
        parameterManager.CurrentRenderIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Render Index Changed: {newValue}");
                OnIndexChanged(newValue); // 値が変わった際に処理を分岐
            })
            .AddTo(this); // GameObjectが破棄された際に自動で購読解除


    }

    private void OnIndexChanged(int newIndex)
    {
        // newIndexの値に応じて処理を分岐
        switch (newIndex)
        {
            case 0:
                renderController.SetRender1();
                break;
            case 1:
                renderController.SetRender2();

                break;
            case 2:
                renderController.SetRender3();

                break;
            default:
                Debug.Log($"Mask Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }
}
