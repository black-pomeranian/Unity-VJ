using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    // �X�e�[�g�̃��X�g
    [SerializeField] private List<string> states = new List<string>();
    private int currentStateIndex = 0; // ���݂̃X�e�[�g�̃C���f�b�N�X

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
        Debug.Log("Current State: " + states[currentStateIndex]);
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
        if (currentStateIndex > 0)
        {
            currentStateIndex--;
        }
        else
        {
            currentStateIndex = states.Count - 1; // ���[�v���čŌ�̃X�e�[�g��
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
            currentStateIndex = 0; // ���[�v���čŏ��̃X�e�[�g��
        }

        Debug.Log("Current State: " + states[currentStateIndex]);
    }
}
