using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private StateController stateController;

    void Start()
    {
        // CurrentMaskIndex�̒l���Ď����A�ω�����OnIndexChanged���Ăяo��
        parameterManager.CurrentStateIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"State Index Changed: {newValue}");
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
                stateController.SetState(newIndex);
                break;
            case 1:
                stateController.SetState(newIndex);
                break;
            case 2:
                stateController.SetState(newIndex);
                break; 
            case 3:
                stateController.SetState(newIndex);
                break;
            case 4:
                stateController.SetState(newIndex);
                break;
            case 5:
                stateController.SetState(newIndex);
                break;
            case 6:
                stateController.SetState(newIndex);
                break;
            case 7:
                stateController.SetState(newIndex);
                break;
            case 8:
                stateController.SetState(newIndex);
                break;
            case 9:
                stateController.SetState(newIndex);
                break;


            default:
                stateController.SetState(newIndex);

                break;
        }
    }
}
