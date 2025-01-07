using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    // ステートのリスト
    [SerializeField] private List<string> states = new List<string>();

    public IReadOnlyReactiveProperty<int> CurrentStateIndex => _currentStateIndex;
    private readonly ReactiveProperty<int> _currentStateIndex = new IntReactiveProperty();
    [SerializeField] private Button[] buttons; // ボタンを登録

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
        Debug.Log("Current State: " + states[_currentStateIndex.Value]);

        // Stateの変更を監視
        _currentStateIndex
            .Skip(1) // 最初の値変更通知をスキップ
            .Subscribe(index => OnStateChanged(states[index]))
            .AddTo(this); // Dispose時に自動的に購読解除

        // ボタンにリスナーを登録
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // キャプチャリング
            buttons[i].onClick.AddListener(() => MoveState(index));
        }
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
        if (_currentStateIndex.Value > 0)
        {
            _currentStateIndex.Value--;
        }
        else
        {
            _currentStateIndex.Value = states.Count - 1; // ループして最後のステートへ
        }
    }

    private void MoveToNextState()
    {
        if (_currentStateIndex.Value < states.Count - 1)
        {
            _currentStateIndex.Value++;
        }
        else
        {
            _currentStateIndex.Value = 0; // ループして最初のステートへ
        }
    }

    private void MoveState(int index)
    {
        if (index >= 0 && index < states.Count)
        {
            _currentStateIndex.Value = index;
            Debug.Log($"Manually moved to State: {states[index]}");
        }
        else
        {
            Debug.LogError($"Invalid State Index: {index}");
        }
    }

    private void OnStateChanged(string newState)
    {
        // 特定のstateに応じた処理を実行
        Debug.Log("State changed to: " + newState);

        if (newState == "State1")
        {
            // State1に対応する処理
            Debug.Log("Executing logic for State1");
        }
        else if (newState == "State2")
        {
            // State2に対応する処理
            Debug.Log("Executing logic for State2");
        }
        else if (newState == "State3")
        {
            // State3に対応する処理
            Debug.Log("Executing logic for State3");
        }
    }
}
