using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    // �X�e�[�g�̃��X�g
    [SerializeField] private List<string> states = new List<string>();

    public IReadOnlyReactiveProperty<int> CurrentStateIndex => _currentStateIndex;
    private readonly ReactiveProperty<int> _currentStateIndex = new IntReactiveProperty();
    [SerializeField] private Button[] buttons; // �{�^����o�^

    void Start()
    {
        // �X�e�[�g���X�g����̏ꍇ�̏�����
        if (states.Count == 0)
        {
            states.Add("State1");
            states.Add("State2");
            states.Add("State3");
        }

        // �ŏ��̃X�e�[�g��ݒ�
        Debug.Log("Current State: " + states[_currentStateIndex.Value]);

        // State�̕ύX���Ď�
        _currentStateIndex
            .Skip(1) // �ŏ��̒l�ύX�ʒm���X�L�b�v
            .Subscribe(index => OnStateChanged(states[index]))
            .AddTo(this); // Dispose���Ɏ����I�ɍw�ǉ���

        // �{�^���Ƀ��X�i�[��o�^
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // �L���v�`�������O
            buttons[i].onClick.AddListener(() => MoveState(index));
        }
    }

    void Update()
    {
        // O�L�[�őO�̃X�e�[�g
        if (Input.GetKeyDown(KeyCode.O))
        {
            MoveToPreviousState();
        }

        // P�L�[�Ŏ��̃X�e�[�g
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
            _currentStateIndex.Value = states.Count - 1; // ���[�v���čŌ�̃X�e�[�g��
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
            _currentStateIndex.Value = 0; // ���[�v���čŏ��̃X�e�[�g��
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
        // �����state�ɉ��������������s
        Debug.Log("State changed to: " + newState);

        if (newState == "State1")
        {
            // State1�ɑΉ����鏈��
            Debug.Log("Executing logic for State1");
        }
        else if (newState == "State2")
        {
            // State2�ɑΉ����鏈��
            Debug.Log("Executing logic for State2");
        }
        else if (newState == "State3")
        {
            // State3�ɑΉ����鏈��
            Debug.Log("Executing logic for State3");
        }
    }
}
