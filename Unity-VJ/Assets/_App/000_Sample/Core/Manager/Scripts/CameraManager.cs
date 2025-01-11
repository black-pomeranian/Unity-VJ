using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UniRx;
using System;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] virtualCameras; // Virtual CameraをGameObjectとして登録
    [SerializeField] private ParameterManager parameterManager;

    void Start()
    {
        // CurrentMaskIndexの値を監視し、変化時にOnIndexChangedを呼び出す
        parameterManager.CurrentCameraIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Camera Index Changed: {newValue}");
                OnIndexChanged(newValue); // 値が変わった際に処理を分岐
            })
            .AddTo(this); // GameObjectが破棄された際に自動で購読解除
    }

    private void OnIndexChanged(int newIndex)
    {
        Debug.Log(newIndex);

        ActivateCamera(newIndex);
        // newIndexの値に応じて処理を分岐
        switch (newIndex)
        {
            case 0:
                Debug.Log("Camera Index is 0: Perform Action A");
                // Action A の処理
                break;
            case 1:
                Debug.Log("Camera Index is 1: Perform Action B");
                // Action B の処理
                break;
            case 2:
                Debug.Log("Camera Index is 2: Perform Action C");
                // Action C の処理
                break;
            default:
                Debug.Log($"Camera Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }

    private void ActivateCamera(int index)
    {
        // 全てのカメラを無効化し、指定したカメラだけ有効化
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].SetActive(i == index);
        }

        Debug.Log($"Camera switched to: {virtualCameras[index].name}");
    }
}
