using UnityEngine;
using UnityEngine.SceneManagement;

class PlayerTeleport : MonoBehaviour
{
    public static string targetSpawnID;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Spawnpoint[] spawns = FindObjectsByType<Spawnpoint>(FindObjectsSortMode.None);

        foreach (var spawn in spawns)
        {
            if (spawn.spawnID == targetSpawnID)
            {
                transform.position = spawn.transform.position;
                break;
            }
        }
    }

}
