using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UniRx;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] virtualCameras; // Virtual CameraをGameObjectとして登録
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
        virtualCameras[_currentCameraIndex.Value].SetActive(false);

        // 次のカメラのインデックスを計算
        _currentCameraIndex.Value = (_currentCameraIndex.Value + 1) % virtualCameras.Length;

        // 次のカメラを有効化
        ActivateCamera(_currentCameraIndex.Value);
    }

    private void SwitchToCamera(int index)
    {
        // 現在のカメラを無効化
        virtualCameras[_currentCameraIndex.Value].SetActive(false);

        // 指定されたカメラに切り替え
        _currentCameraIndex.Value = index;

        // 新しいカメラを有効化
        ActivateCamera(index);
    }

    private void ActivateCamera(int index)
    {
        // 全てのカメラを無効化し、指定したカメラだけ有効化
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].SetActive(i == index);
        }

        Debug.Log($"Camera switched to: {virtualCameras[index].name}");
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
