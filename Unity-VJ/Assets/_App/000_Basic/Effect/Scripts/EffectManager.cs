using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParameterManager parameterManager;
    [SerializeField] private EffectController effectController;

    void Start()
    {
        // CurrentEffectStates �̊e�v�f�̕ύX���Ď�
        parameterManager.CurrentEffectStates.ObserveAdd()
            .Subscribe(change =>
            {
                if (change.Value) // �ǉ����ꂽ�l�� true �̏ꍇ�̂ݏ���
                {
                    Debug.Log($"Effect Index Activated: {change.Key}");
                    ApplyEffect(change.Key);
                }
            })
            .AddTo(this);

        parameterManager.CurrentEffectStates.ObserveReplace()
            .Subscribe(change =>
            {
                if (change.NewValue) // �l�� true �ɕύX���ꂽ�ꍇ�̂ݏ���
                {
                    Debug.Log($"Effect Index Updated: {change.Key}");
                    ApplyEffect(change.Key);
                }
            })
            .AddTo(this);
    }

    private void ApplyEffect(int effectIndex)
    {
        // effectIndex �ɉ����ăG�t�F�N�g��K�p
        switch (effectIndex)
        {
            case 0:
                effectController.SetEffect1();
                break;
            case 1:
                effectController.SetEffect2();
                break;
            case 2:
                effectController.SetEffect3();
                break;
            case 3:
                effectController.SetEffect4();
                break;
            case 4:
                effectController.SetEffect5();
                break;
            case 5:
                effectController.SetEffect6();
                break;
            case 6:
                effectController.SetEffect7();
                break;
            case 7:
                effectController.SetEffect8();
                break;
            case 8:
                effectController.SetEffect9();
                break;
            case 9:
                effectController.SetEffect10();
                break;
            default:
                Debug.Log($"Effect Index {effectIndex}: No specific action defined.");
                break;
        }
    }
}
