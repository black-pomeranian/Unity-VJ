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

                break;
            case 1:
                RenderSettings.skybox = defaultSkyBox;

                break;
            case 2:
                RenderSettings.skybox = greenSkyBox;

                break;
            default:
                Debug.Log($"Mask Index is {newIndex}: Default Action");
                // �f�t�H���g�̏���
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
