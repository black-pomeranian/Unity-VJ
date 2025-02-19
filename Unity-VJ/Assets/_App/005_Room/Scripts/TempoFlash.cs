using System;
using UniRx;
using UnityEngine;

public class TempoFlash : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private float minInterval = 0.1f; // 最小間隔
    [SerializeField] private float maxInterval = 1.0f; // 最大間隔

    private IDisposable blinkSubscription;

    private void Start()
    {
        StartRandomBlinking();
    }

    private void StartRandomBlinking()
    {
        blinkSubscription?.Dispose(); // 既存のサブスクリプションを破棄

        float randomInterval = UnityEngine.Random.Range(minInterval, maxInterval);
        blinkSubscription = Observable.Timer(TimeSpan.FromSeconds(randomInterval))
            .Subscribe(_ =>
            {
                ToggleObject();
                StartRandomBlinking(); // 次のランダム間隔で再度実行
            });
    }

    private void ToggleObject()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }

    private void OnDestroy()
    {
        blinkSubscription?.Dispose();
    }
}