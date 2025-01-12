using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> CurrentStateIndex => _currentStateIndex;
    private readonly ReactiveProperty<int> _currentStateIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentMaskIndex => _currentMaskIndex;
    private readonly ReactiveProperty<int> _currentMaskIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentSceneIndex => _currentSceneIndex;
    private readonly ReactiveProperty<int> _currentSceneIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentCameraIndex => _currentCameraIndex;
    private readonly ReactiveProperty<int> _currentCameraIndex = new IntReactiveProperty();

    [SerializeField] private GameObject StateButtons;
    [SerializeField] private GameObject MaskButtons;
    [SerializeField] private GameObject SceneButtons;
    [SerializeField] private GameObject CameraButtons;

    //�����Őݒ�
    public int stateMax;
    public int maskMax;
    public int sceneMax;
    public int cameraMax;

    private const int MinIndex = 0;

    void Start()
    {

        // �����l��ݒ�
        SetStateIndex(0);
        SetMaskIndex(0);
        SetSceneIndex(0);
        SetCameraIndex(0);
    }

    // Set value functions with clamping
    public void SetStateIndex(int value) => _currentStateIndex.Value = Mathf.Clamp(value, MinIndex, stateMax);
    public void SetMaskIndex(int value) => _currentMaskIndex.Value = Mathf.Clamp(value, MinIndex, maskMax);
    public void SetSceneIndex(int value) => _currentSceneIndex.Value = Mathf.Clamp(value, MinIndex, sceneMax);
    public void SetCameraIndex(int value) => _currentCameraIndex.Value = Mathf.Clamp(value, MinIndex, cameraMax);

    // Increment functions with looping
    public void IncrementStateIndex() => _currentStateIndex.Value = LoopIndex(_currentStateIndex.Value + 1, stateMax);
    public void IncrementMaskIndex() => _currentMaskIndex.Value = LoopIndex(_currentMaskIndex.Value + 1, maskMax);
    public void IncrementSceneIndex() => _currentSceneIndex.Value = LoopIndex(_currentSceneIndex.Value + 1, sceneMax);
    public void IncrementCameraIndex() => _currentCameraIndex.Value = LoopIndex(_currentCameraIndex.Value + 1, cameraMax);

    // Decrement functions with looping
    public void DecrementStateIndex() => _currentStateIndex.Value = LoopIndex(_currentStateIndex.Value - 1, stateMax);
    public void DecrementMaskIndex() => _currentMaskIndex.Value = LoopIndex(_currentMaskIndex.Value - 1, maskMax);
    public void DecrementSceneIndex() => _currentSceneIndex.Value = LoopIndex(_currentSceneIndex.Value - 1, sceneMax);
    public void DecrementCameraIndex() => _currentCameraIndex.Value = LoopIndex(_currentCameraIndex.Value - 1, cameraMax);

    // Helper function to loop index
    private int LoopIndex(int value, int max)
    {
        if (value >= max)
            return MinIndex; // �ő�l�𒴂�����ŏ��l�Ƀ��[�v
        if (value < MinIndex)
            return max; // �ŏ��l�����������ő�l�Ƀ��[�v
        return value;
    }
}
