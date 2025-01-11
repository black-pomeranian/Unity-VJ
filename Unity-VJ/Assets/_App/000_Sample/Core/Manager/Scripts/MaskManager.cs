using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MaskManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;

    void Start()
    {
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
                Debug.Log("Mask Index is 0: Perform Action A");
                // Action A �̏���
                break;
            case 1:
                Debug.Log("Mask Index is 1: Perform Action B");
                // Action B �̏���
                break;
            case 2:
                Debug.Log("Mask Index is 2: Perform Action C");
                // Action C �̏���
                break;
            default:
                Debug.Log($"Mask Index is {newIndex}: Default Action");
                // �f�t�H���g�̏���
                break;
        }
    }
}
