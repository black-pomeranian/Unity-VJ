using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private MaskController maskController;

    void Start()
    {

        // CurrentMaskIndexの値を監視し、変化時にOnIndexChangedを呼び出す
        parameterManager.CurrentMaskIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Mask Index Changed: {newValue}");
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
                maskController.SetMask1();
                break;
            case 1:
                maskController.SetMask2();

                break;
            case 2:
                maskController.SetMask3();

                break;
            default:
                Debug.Log($"Mask Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }

}
