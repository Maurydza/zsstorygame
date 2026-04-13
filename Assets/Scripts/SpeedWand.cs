using UnityEngine;

public class SpeedWand : Item
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PlayerMovement playerMovement;

    public override void Start()
    {
        base.Start();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    public override void Use()
    {
        base.Use();
        playerMovement.AddStamina(50f);
    }
}
