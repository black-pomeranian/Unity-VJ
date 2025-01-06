using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UniRx;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras; // Virtual Cameraを登録
    [SerializeField] private Button[] buttons; // ボタンを登録
    public IReadOnlyReactiveProperty<int> CurrentCameraIndex => _currentCameraIndex;
    private readonly ReactiveProperty<int> _currentCameraIndex = new IntReactiveProperty();

    void Start()
    {
        if (virtualCameras.Length != buttons.Length)
        {
            Debug.LogError("カメラの数とボタンの数が一致していません！");
            return;
        }

        // ボタンにリスナーを登録
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // キャプチャリング
            buttons[i].onClick.AddListener(() => SwitchToCamera(index));
        }

        // 最初のカメラを有効化
        ActivateCamera(0);

        // Destroy時にDispose()する
        _currentCameraIndex.AddTo(this);
    }

    void Update()
    {
        // Cキーを押したら次のカメラへ切り替え
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToNextCamera();
        }
    }

    private void SwitchToNextCamera()
    {
        // 現在のカメラを無効化
        virtualCameras[_currentCameraIndex.Value].Priority = 0;

        // 次のカメラのインデックスを計算
        _currentCameraIndex.Value = (_currentCameraIndex.Value + 1) % virtualCameras.Length;

        // 次のカメラを有効化
        ActivateCamera(_currentCameraIndex.Value);
    }

    private void SwitchToCamera(int index)
    {
        // 指定されたカメラに切り替え
        _currentCameraIndex.Value = index; // 現在のインデックスを更新
        ActivateCamera(index);
    }

    private void ActivateCamera(int index)
    {
        // 指定したインデックスのカメラを有効化
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = (i == index) ? 10 : 0;
        }
    }

    private void OnDestroy()
    {
        // メモリリークを防ぐため、リスナーを解除
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
