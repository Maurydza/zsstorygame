using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LyingItemsSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<LyingItemData> itemsToSpawn = new List<LyingItemData>();
    void Start()
    {
        SceneManager.sceneLoaded += LoadItemsToScene;
        SceneManager.sceneLoaded += ChangeHeldItemsScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadItemsToScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        GameObject[] existingItems = GameObject.FindGameObjectsWithTag("Item");

        foreach (LyingItemData item in itemsToSpawn)
        {
            if (item.sceneIndex == scene.buildIndex)
            {
                GameObject obj = Instantiate(item.prefab, item.position, Quaternion.identity);
            }
        }
    }

    private void ChangeHeldItemsScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (Inventory.rightHandObject != null)
        {
            Inventory.rightHandObject.GetComponent<Item>().CurrentSceneBuildIndex = scene.buildIndex;
        }

        if (Inventory.leftHandObject != null)
        {
            Inventory.leftHandObject.GetComponent<Item>().CurrentSceneBuildIndex = scene.buildIndex;
        }
    }

    public void RemoveItem(int index)
    {
        itemsToSpawn.RemoveAt(index);
    }

    public void AddItem(GameObject prefabObject, Vector3 position)
    {
        LyingItemData item = new LyingItemData()
        {
            prefab = prefabObject,
            position = position,
            sceneIndex = SceneManager.GetActiveScene().buildIndex,
            index = itemsToSpawn.Count
        };
        itemsToSpawn.Add(item);
        itemsToSpawn[item.index].prefab.GetComponent<Item>().index = item.index;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= LoadItemsToScene;
        SceneManager.sceneLoaded -= ChangeHeldItemsScene;
    }
}
