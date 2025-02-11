using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabs; // 複数のPrefabを登録
    public Transform spawnParent; // 生成したオブジェクトの親（nullでも可）
    public int maxObjects = 20; // 最大生成数

    public Vector3 scale = new Vector3(5f, 5f, 5f); // 最大スケール
    public Vector3 minRotation = new Vector3(0f, 120f, 0f); // 最小回転角度
    public Vector3 maxRotation = new Vector3(0f, 240f, 0f); // 最大回転角度（Y軸回転）

    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Coroutine spawnCoroutine;

    private void OnEnable()
    {
        spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    private void OnDisable()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 1f);
            yield return new WaitForSeconds(waitTime);

            SpawnRandomPrefab();
        }
    }

    private void SpawnRandomPrefab()
    {
        if (prefabs.Length == 0) return;

        // ランダムなPrefabを選択
        GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

        // ランダムなX座標を決定（YとZは固定）
        float randomX = Random.Range(-6f, 6f);
        Vector3 spawnPosition = new Vector3(randomX, 0.9f, 0f);

        // 生成
        GameObject newObject = Instantiate(prefab, spawnPosition, Quaternion.identity, spawnParent);

        newObject.transform.localScale = scale;

        // **ランダムな回転設定**
        float randomRotX = Random.Range(minRotation.x, maxRotation.x);
        float randomRotY = Random.Range(minRotation.y, maxRotation.y);
        float randomRotZ = Random.Range(minRotation.z, maxRotation.z);
        newObject.transform.rotation = Quaternion.Euler(randomRotX, randomRotY, randomRotZ);

        // **確実にアクティブにする**
        newObject.SetActive(true);

        // リストに追加
        spawnedObjects.Add(newObject);

        // 20個を超えたら最も古いものを削除
        if (spawnedObjects.Count > maxObjects)
        {
            Destroy(spawnedObjects[0]);
            spawnedObjects.RemoveAt(0);
        }
    }
}
