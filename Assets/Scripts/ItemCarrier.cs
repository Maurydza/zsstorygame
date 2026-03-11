using UnityEngine;

public class ItemCarrier : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float LHOffsetX;
    [SerializeField] private float LHOffsetY;
    [SerializeField] private float RHOffsetX;
    [SerializeField] private float RHOffsetY;
    private static Vector2 LHOffset;
    private static Vector2 RHOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LHOffset = new Vector2(LHOffsetX, LHOffsetY);
        RHOffset = new Vector2(RHOffsetX, RHOffsetY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Inventory.IsLHINull())
        {
            Inventory.LHITransform(playerRigidbody.position + LHOffset);
        }

        if (!Inventory.IsRHINull())
        {
            Inventory.RHITransform(playerRigidbody.position + RHOffset);
        }
    }
}
