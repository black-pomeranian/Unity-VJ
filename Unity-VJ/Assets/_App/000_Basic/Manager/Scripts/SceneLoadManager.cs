using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private SceneLoader sceneLoader;

    void Start()
    {
        // CurrentMaskIndexの値を監視し、変化時にOnIndexChangedを呼び出す
        parameterManager.CurrentSceneIndex
            .Skip(1)
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
                sceneLoader.LoadScene(newIndex);
                break;
            case 1:
                sceneLoader.LoadScene(newIndex);
                break;
            case 2:
                sceneLoader.LoadScene(newIndex);
                // Action C の処理
                break;
            default:
                Debug.Log($"Scene Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }
}
