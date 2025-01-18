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
        // CurrentMaskIndexの値を監視し、変化時にOnIndexChangedを呼び出す
        parameterManager.CurrentStateIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"State Index Changed: {newValue}");
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
                stateController.SetState1();
                break;
            case 1:
                stateController.SetState2();

                break;
            case 2:
                stateController.SetState3();

                break;
            default:
                stateController.SetState4();

                break;
        }
    }
}
