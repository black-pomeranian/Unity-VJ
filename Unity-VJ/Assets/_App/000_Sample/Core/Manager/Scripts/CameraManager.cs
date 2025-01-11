using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UniRx;
using System;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject[] virtualCameras; // Virtual Camera��GameObject�Ƃ��ēo�^
    [SerializeField] private ParameterManager parameterManager;

    void Start()
    {
        // CurrentMaskIndex�̒l���Ď����A�ω�����OnIndexChanged���Ăяo��
        parameterManager.CurrentCameraIndex
            .Subscribe(newValue =>
            {
                Debug.Log($"Camera Index Changed: {newValue}");
                OnIndexChanged(newValue); // �l���ς�����ۂɏ����𕪊�
            })
            .AddTo(this); // GameObject���j�����ꂽ�ۂɎ����ōw�ǉ���
    }

    private void OnIndexChanged(int newIndex)
    {
        Debug.Log(newIndex);

        ActivateCamera(newIndex);
        // newIndex�̒l�ɉ����ď����𕪊�
        switch (newIndex)
        {
            case 0:
                Debug.Log("Camera Index is 0: Perform Action A");
                // Action A �̏���
                break;
            case 1:
                Debug.Log("Camera Index is 1: Perform Action B");
                // Action B �̏���
                break;
            case 2:
                Debug.Log("Camera Index is 2: Perform Action C");
                // Action C �̏���
                break;
            default:
                Debug.Log($"Camera Index is {newIndex}: Default Action");
                // �f�t�H���g�̏���
                break;
        }
    }

    private void ActivateCamera(int index)
    {
        // �S�ẴJ�����𖳌������A�w�肵���J���������L����
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].SetActive(i == index);
        }

        Debug.Log($"Camera switched to: {virtualCameras[index].name}");
    }
}
