using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public Sprite playerWithGun;

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "S49" || sceneName == "S59" || sceneName == "S69"
            || sceneName == "SP1" || sceneName == "SP2")
        {
            GameObject player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                SpriteRenderer sr = player.GetComponent<SpriteRenderer>();

                if (sr != null)
                    sr.sprite = playerWithGun;
            }
        }
    }
}