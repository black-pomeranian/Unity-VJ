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

        // CurrentMaskIndex�̒l���Ď����A�ω�����OnIndexChanged���Ăяo��
        parameterManager.CurrentRenderIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Render Index Changed: {newValue}");
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
                // �f�t�H���g�̏���
                break;
        }
    }
}
