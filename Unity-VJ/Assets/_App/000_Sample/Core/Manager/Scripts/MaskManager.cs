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

        // CurrentMaskIndex�̒l���Ď����A�ω�����OnIndexChanged���Ăяo��
        parameterManager.CurrentMaskIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Mask Index Changed: {newValue}");
                OnIndexChanged(newValue); // �l���ς�����ۂɏ����𕪊�
            })
            .AddTo(this); // GameObject���j�����ꂽ�ۂɎ����ōw�ǉ���


    }

    private void OnIndexChanged(int newIndex)
    {
        // newIndex�̒l�ɉ����ď����𕪊�
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
                // �f�t�H���g�̏���
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
