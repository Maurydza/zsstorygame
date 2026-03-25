using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHP = 100;
    protected int currentHP;


    protected virtual void Start()
    {
        currentHP = maxHP;
    }



    protected virtual void Die()
    {
        Destroy(gameObject);
    }



    public virtual void TakeDamage(int damage)
    {
        currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }




    public virtual void Heal(int heal)
    {
        currentHP = Mathf.Clamp(currentHP + heal, 0, maxHP); 
    }

    

    public int GetHP() => currentHP;
}
