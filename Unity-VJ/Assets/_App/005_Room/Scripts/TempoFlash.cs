using System;
using UniRx;
using UnityEngine;

public class TempoFlash : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private float minInterval = 0.1f; // �ŏ��Ԋu
    [SerializeField] private float maxInterval = 1.0f; // �ő�Ԋu

    private IDisposable blinkSubscription;

    private void Start()
    {
        StartRandomBlinking();
    }

    private void StartRandomBlinking()
    {
        blinkSubscription?.Dispose(); // �����̃T�u�X�N���v�V������j��

        float randomInterval = UnityEngine.Random.Range(minInterval, maxInterval);
        blinkSubscription = Observable.Timer(TimeSpan.FromSeconds(randomInterval))
            .Subscribe(_ =>
            {
                ToggleObject();
                StartRandomBlinking(); // ���̃����_���Ԋu�ōēx���s
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