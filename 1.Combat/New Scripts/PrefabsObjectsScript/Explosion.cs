using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject FrostCystral;
    double PlayerAttackDamage;
    double ActionDamage;
    public LayerMask Enemylayer;
    public float explosionRadius = 4f;
    public string skillStatus = "Freeze";
    public int skillStatusStack = 0;
    public string attackElement = "Frost";

    public void Start()
    {
        FrostCystral = GameObject.Find("Player");
        ExplosionFun();
        Destroy(gameObject, 1f);
    }
    public void ExplosionFun() 
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, explosionRadius, Enemylayer);
        PlayerAttackDamage = FrostCystral.GetComponent<PlayerMainController>().TotalDamage;
        ActionDamage = PlayerAttackDamage * 2;
        foreach (Collider2D enemy in hitColliders)
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, PlayerAttackDamage, skillStatus, skillStatusStack, attackElement);
        }
        
    }

}
