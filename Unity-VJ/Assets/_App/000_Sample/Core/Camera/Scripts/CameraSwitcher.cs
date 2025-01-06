using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras; // Virtual Camera��o�^
    private int currentCameraIndex = 0;

    void Start()
    {
        // �S�J�����̗D��x��������
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // C�L�[���������Ƃ��ɃJ������؂�ւ�
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToNextCamera();
        }
    }

    private void SwitchToNextCamera()
    {
        // ���݂̃J�����𖳌����i�D��x��0�ɐݒ�j
        virtualCameras[currentCameraIndex].Priority = 0;

        // ���̃J�����̃C���f�b�N�X���v�Z
        currentCameraIndex = (currentCameraIndex + 1) % virtualCameras.Length;

        // ���̃J������L�����i�D��x�������ݒ�j
        ActivateCamera(currentCameraIndex);
    }

    private void ActivateCamera(int index)
    {
        // �w�肵���C���f�b�N�X�̃J������L����
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = (i == index) ? 10 : 0;
        }
    }
}
