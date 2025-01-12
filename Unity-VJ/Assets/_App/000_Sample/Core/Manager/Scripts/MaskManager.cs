using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] Material greenSkyBox;
    [SerializeField] Material greenMaterial;
    private Material defaultSkyBox;


    void Start()
    {

        defaultSkyBox = RenderSettings.skybox;

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
                RenderSettings.skybox = defaultSkyBox;

                break;
            case 1:
                RenderSettings.skybox = defaultSkyBox;

                break;
            case 2:
                RenderSettings.skybox = greenSkyBox;

                break;
            default:
                Debug.Log($"Mask Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }

    private void OnDestroy()
    {
        if (defaultSkyBox != null)
        {
            Destroy(defaultSkyBox);
        }
    }
}
