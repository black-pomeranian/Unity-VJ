using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras; // Virtual Camera��o�^
    [SerializeField] private Button[] buttons; // �{�^����o�^
    public int currentCameraIndex = 0; // ���݃A�N�e�B�u�ȃJ�����̃C���f�b�N�X

    void Start()
    {
        if (virtualCameras.Length != buttons.Length)
        {
            Debug.LogError("�J�����̐��ƃ{�^���̐�����v���Ă��܂���I");
            return;
        }

        // �{�^���Ƀ��X�i�[��o�^
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // �L���v�`�������O
            buttons[i].onClick.AddListener(() => SwitchToCamera(index));
        }

        // �ŏ��̃J������L����
        ActivateCamera(0);
    }

    void Update()
    {
        // C�L�[���������玟�̃J�����֐؂�ւ�
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToNextCamera();
        }
    }

    private void SwitchToNextCamera()
    {
        // ���݂̃J�����𖳌���
        virtualCameras[currentCameraIndex].Priority = 0;

        // ���̃J�����̃C���f�b�N�X���v�Z
        currentCameraIndex = (currentCameraIndex + 1) % virtualCameras.Length;

        // ���̃J������L����
        ActivateCamera(currentCameraIndex);
    }

    private void SwitchToCamera(int index)
    {
        // �w�肳�ꂽ�J�����ɐ؂�ւ�
        currentCameraIndex = index; // ���݂̃C���f�b�N�X���X�V
        ActivateCamera(index);
    }

    private void ActivateCamera(int index)
    {
        // �w�肵���C���f�b�N�X�̃J������L����
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = (i == index) ? 10 : 0;
        }
    }

    private void OnDestroy()
    {
        // ���������[�N��h�����߁A���X�i�[������
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
