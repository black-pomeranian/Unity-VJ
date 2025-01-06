using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras; // Virtual Cameraを登録
    private int currentCameraIndex = 0;

    void Start()
    {
        // 全カメラの優先度を初期化
        ActivateCamera(currentCameraIndex);
    }

    void Update()
    {
        // Cキーを押したときにカメラを切り替え
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchToNextCamera();
        }
    }

    private void SwitchToNextCamera()
    {
        // 現在のカメラを無効化（優先度を0に設定）
        virtualCameras[currentCameraIndex].Priority = 0;

        // 次のカメラのインデックスを計算
        currentCameraIndex = (currentCameraIndex + 1) % virtualCameras.Length;

        // 次のカメラを有効化（優先度を高く設定）
        ActivateCamera(currentCameraIndex);
    }

    private void ActivateCamera(int index)
    {
        // 指定したインデックスのカメラを有効化
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = (i == index) ? 10 : 0;
        }
    }
}
