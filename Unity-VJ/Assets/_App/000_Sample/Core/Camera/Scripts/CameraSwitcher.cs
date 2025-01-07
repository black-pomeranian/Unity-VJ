using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UniRx;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] virtualCameras; // Virtual Camera��GameObject�Ƃ��ēo�^
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
        virtualCameras[_currentCameraIndex.Value].SetActive(false);

        // ���̃J�����̃C���f�b�N�X���v�Z
        _currentCameraIndex.Value = (_currentCameraIndex.Value + 1) % virtualCameras.Length;

        // ���̃J������L����
        ActivateCamera(_currentCameraIndex.Value);
    }

    private void SwitchToCamera(int index)
    {
        // ���݂̃J�����𖳌���
        virtualCameras[_currentCameraIndex.Value].SetActive(false);

        // �w�肳�ꂽ�J�����ɐ؂�ւ�
        _currentCameraIndex.Value = index;

        // �V�����J������L����
        ActivateCamera(index);
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

    private void OnDestroy()
    {
        // ���������[�N��h�����߁A���X�i�[������
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
