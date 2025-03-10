using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParameterManager : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> CurrentSceneIndex => _currentSceneIndex;
    private readonly ReactiveProperty<int> _currentSceneIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentStateIndex => _currentStateIndex;
    private readonly ReactiveProperty<int> _currentStateIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentMaskIndex => _currentMaskIndex;
    private readonly ReactiveProperty<int> _currentMaskIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentRenderIndex => _currentRenderIndex;
    private readonly ReactiveProperty<int> _currentRenderIndex = new IntReactiveProperty();

    public IReadOnlyReactiveProperty<int> CurrentCameraIndex => _currentCameraIndex;
    private readonly ReactiveProperty<int> _currentCameraIndex = new IntReactiveProperty();

    public IReadOnlyReactiveDictionary<int, bool> CurrentEffectStates => _currentEffectStates;
    private readonly ReactiveDictionary<int, bool> _currentEffectStates = new ReactiveDictionary<int, bool>();


    // 自分で設定
    public int cameraMax;
    public int stateMax;
    public int maskMax;
    public int renderMax;
    public int sceneMax;
    public int effectMax;

    private const int MinIndex = 0;

    void Start()
    {
        _currentSceneIndex.Value = PlayerPrefs.GetInt("TargetScene");
        Debug.Log($"現在のシーンのインデックス: {_currentSceneIndex.Value}");

        SetSceneIndex(_currentSceneIndex.Value);
        SetMaskIndex(0);
        SetStateIndex(0);
        SetCameraIndex(0);
        SetRenderIndex(0);

        // 各ボタンの初期状態を false に設定
        for (int i = 0; i < sceneMax; i++)
        {
            _currentEffectStates[i] = false;
        }
    }


    // ボタンの状態をトグル
    public void ToggleEffectState(int index)
    {
        if (_currentEffectStates.ContainsKey(index))
        {
            _currentEffectStates[index] = !_currentEffectStates[index];
        }
    }

    // Set value functions with clamping
    public void SetStateIndex(int value) => _currentStateIndex.Value = Mathf.Clamp(value, MinIndex, stateMax);
    public void SetMaskIndex(int value) => _currentMaskIndex.Value = Mathf.Clamp(value, MinIndex, maskMax);
    public void SetSceneIndex(int value) => _currentSceneIndex.Value = Mathf.Clamp(value, MinIndex, sceneMax);
    public void SetCameraIndex(int value) => _currentCameraIndex.Value = Mathf.Clamp(value, MinIndex, cameraMax);
    public void SetRenderIndex(int value) => _currentRenderIndex.Value = Mathf.Clamp(value, MinIndex, cameraMax);

    // Increment functions with looping
    public void IncrementStateIndex() => _currentStateIndex.Value = LoopIndex(_currentStateIndex.Value + 1, stateMax);
    public void IncrementMaskIndex() => _currentMaskIndex.Value = LoopIndex(_currentMaskIndex.Value + 1, maskMax);
    public void IncrementSceneIndex() => _currentSceneIndex.Value = LoopIndex(_currentSceneIndex.Value + 1, sceneMax);
    public void IncrementCameraIndex() => _currentCameraIndex.Value = LoopIndex(_currentCameraIndex.Value + 1, cameraMax);
    public void IncrementRenderIndex() => _currentRenderIndex.Value = LoopIndex(_currentCameraIndex.Value + 1, cameraMax);

    // Decrement functions with looping
    public void DecrementStateIndex() => _currentStateIndex.Value = LoopIndex(_currentStateIndex.Value - 1, stateMax);
    public void DecrementMaskIndex() => _currentMaskIndex.Value = LoopIndex(_currentMaskIndex.Value - 1, maskMax);
    public void DecrementSceneIndex() => _currentSceneIndex.Value = LoopIndex(_currentSceneIndex.Value - 1, sceneMax);
    public void DecrementCameraIndex() => _currentCameraIndex.Value = LoopIndex(_currentCameraIndex.Value - 1, cameraMax);
    public void DecremenRenderIndex() => _currentRenderIndex.Value = LoopIndex(_currentCameraIndex.Value - 1, cameraMax);

    // Helper function to loop index
    private int LoopIndex(int value, int max)
    {
        if (value >= max)
            return MinIndex; // 最大値を超えたら最小値にループ
        if (value < MinIndex)
            return max; // 最小値を下回ったら最大値にループ
        return value;
    }
}
