using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras; // Virtual Cameraを登録
    [SerializeField] private Button[] buttons; // ボタンを登録
    public int currentCameraIndex = 0; // 現在アクティブなカメラのインデックス

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
        virtualCameras[currentCameraIndex].Priority = 0;

        // 次のカメラのインデックスを計算
        currentCameraIndex = (currentCameraIndex + 1) % virtualCameras.Length;

        // 次のカメラを有効化
        ActivateCamera(currentCameraIndex);
    }

    private void SwitchToCamera(int index)
    {
        // 指定されたカメラに切り替え
        currentCameraIndex = index; // 現在のインデックスを更新
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
