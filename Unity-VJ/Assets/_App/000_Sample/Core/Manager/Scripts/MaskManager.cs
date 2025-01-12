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
    [SerializeField] GameObject maskedObject1;

    private Material defaultSkyBox;

    private MeshRenderer defaultRenderer1;
    private Material defaultMaterial1;

    void Start()
    {

        defaultSkyBox = RenderSettings.skybox;

        defaultRenderer1 = maskedObject1.GetComponent<MeshRenderer>();
        defaultMaterial1 = defaultRenderer1.material;

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
                defaultRenderer1.material = defaultMaterial1; 
                break;
            case 1:
                RenderSettings.skybox = defaultSkyBox;
                defaultRenderer1.material = greenMaterial;

                break;
            case 2:
                RenderSettings.skybox = greenSkyBox;
                defaultRenderer1.material = defaultMaterial1;


                break;
            default:
                Debug.Log($"Mask Index is {newIndex}: Default Action");
                // デフォルトの処理
                break;
        }
    }

    private void OnDestroy()
    {
        DestroyMaterial(defaultSkyBox);
        DestroyMaterial(greenMaterial);
    }

    private void DestroyMaterial(Material material)
    {
        if (material != null)
        {
            Destroy(material);
        }
    }
}
