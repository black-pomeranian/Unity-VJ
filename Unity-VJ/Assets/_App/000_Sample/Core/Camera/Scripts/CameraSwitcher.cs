using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UniRx;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras; // Virtual Camera��o�^
    [SerializeField] private Button[] buttons; // �{�^����o�^
    public IReadOnlyReactiveProperty<int> CurrentCameraIndex => _currentCameraIndex;
    private readonly ReactiveProperty<int> _currentCameraIndex = new IntReactiveProperty();

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

        // Destroy����Dispose()����
        _currentCameraIndex.AddTo(this);
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
        virtualCameras[_currentCameraIndex.Value].Priority = 0;

        // ���̃J�����̃C���f�b�N�X���v�Z
        _currentCameraIndex.Value = (_currentCameraIndex.Value + 1) % virtualCameras.Length;

        // ���̃J������L����
        ActivateCamera(_currentCameraIndex.Value);
    }

    private void SwitchToCamera(int index)
    {
        // �w�肳�ꂽ�J�����ɐ؂�ւ�
        _currentCameraIndex.Value = index; // ���݂̃C���f�b�N�X���X�V
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
