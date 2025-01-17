using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;

    void Start()
    {
        // CurrentMaskIndexの値を監視し、変化時にOnIndexChangedを呼び出す
        parameterManager.CurrentSceneIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Scene Index Changed: {newValue}");
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
                Debug.Log("Scene Index is 0: Perform Action A");
                // Action A の処理
                break;
            case 1:
                Debug.Log("Scene Index is 1: Perform Action B");
                // Action B の処理
                break;
            case 2:
                Debug.Log("Scene Index is 2: Perform Action C");
                // Action C の処理
                break;
            default:
                Debug.Log($"Scene Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }
}
