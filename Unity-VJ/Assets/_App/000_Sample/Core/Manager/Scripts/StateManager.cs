using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // ステートのリスト
    [SerializeField] private List<string> states = new List<string>();
    private int currentStateIndex = 0; // 現在のステートのインデックス

    void Start()
    {
        // ステートリストが空の場合の初期化
        if (states.Count == 0)
        {
            states.Add("State1");
            states.Add("State2");
            states.Add("State3");
        }

        // 最初のステートを設定
        Debug.Log("Current State: " + states[currentStateIndex]);
    }

    void Update()
    {
        // Oキーで前のステート
        if (Input.GetKeyDown(KeyCode.O))
        {
            MoveToPreviousState();
        }

        // Pキーで次のステート
        if (Input.GetKeyDown(KeyCode.P))
        {
            MoveToNextState();
        }
    }

    private void MoveToPreviousState()
    {
        if (currentStateIndex > 0)
        {
            currentStateIndex--;
        }
        else
        {
            currentStateIndex = states.Count - 1; // ループして最後のステートへ
        }

        Debug.Log("Current State: " + states[currentStateIndex]);
    }

    private void MoveToNextState()
    {
        if (currentStateIndex < states.Count - 1)
        {
            currentStateIndex++;
        }
        else
        {
            currentStateIndex = 0; // ループして最初のステートへ
        }

        Debug.Log("Current State: " + states[currentStateIndex]);
    }
}
