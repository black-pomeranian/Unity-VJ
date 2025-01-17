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
        // CurrentMaskIndex�̒l���Ď����A�ω�����OnIndexChanged���Ăяo��
        parameterManager.CurrentSceneIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Scene Index Changed: {newValue}");
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
                Debug.Log("Scene Index is 0: Perform Action A");
                // Action A �̏���
                break;
            case 1:
                Debug.Log("Scene Index is 1: Perform Action B");
                // Action B �̏���
                break;
            case 2:
                Debug.Log("Scene Index is 2: Perform Action C");
                // Action C �̏���
                break;
            default:
                Debug.Log($"Scene Index is {newIndex}: Default Action");
                // �f�t�H���g�̏���
                break;
        }
    }
}
