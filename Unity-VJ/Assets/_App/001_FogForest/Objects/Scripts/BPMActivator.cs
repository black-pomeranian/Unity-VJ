using System.Collections;
using UnityEngine;
using UniRx;

public class BPMActivator : MonoBehaviour
{
    [SerializeField] private OSCServer oscServer; // BPMを取得するOSCServer
    private float frequency;
    private Transform[] childObjects;
    private int currentIndex = 0;
    private Coroutine activationCoroutine;

    void Start()
    {
        // 子オブジェクトを取得
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i);
            childObjects[i].gameObject.SetActive(false); // 初期状態で全て非アクティブ
        }

        // BPM変化を監視し、frequencyを更新
        oscServer.Bpm.Subscribe(newBpm =>
        {
            UpdateFrequency(newBpm);
        }).AddTo(this);
    }

    void UpdateFrequency(float bpm)
    {
        frequency = bpm / 60f;

        // コルーチンを再スタート（BPM変更時に適用）
        if (activationCoroutine != null)
        {
            StopCoroutine(activationCoroutine);
        }
        activationCoroutine = StartCoroutine(ActivationLoop());
    }

    IEnumerator ActivationLoop()
    {
        while (true)
        {
            if (childObjects.Length == 0) yield break;

            // すべての子オブジェクトを非アクティブ化
            foreach (var obj in childObjects)
            {
                obj.gameObject.SetActive(false);
            }

            // 現在のインデックスのオブジェクトをアクティブ化
            childObjects[currentIndex].gameObject.SetActive(true);

            // 次のインデックスへ（ループするように）
            currentIndex = (currentIndex + 1) % childObjects.Length;

            // BPMに基づく時間待機
            yield return new WaitForSeconds(1f / frequency);
        }
    }
}
