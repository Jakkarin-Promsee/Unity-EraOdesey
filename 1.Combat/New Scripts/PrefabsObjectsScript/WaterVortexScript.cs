using System.Collections;
using UnityEngine;

public class WaterVortexScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "Wet";
    int SkillStatusStack = 1;
    string AttackElement = "Water";
    public LayerMask Enemylayer;
    float speed = 0.5f;


    public void Start()
    {
        isVortaxhit = false;
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 1;
    }

    public void Update()
    {
        if (!isVortaxhit) 
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, this.transform.localScale.magnitude, Enemylayer);
            if (hitEnemies.Length > 0)
            {
                ActionDamage = player.TotalDamage * 1.5f;
                SkillStatus = "Wet";
                AttackElement = "Water";
                SkillStatusStack = 1;
                StartCoroutine(VortexhDelay(enemyI));
            }
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);     
    }

    Collider2D enemyI;
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        enemyI = enemy;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, this.transform.localScale.magnitude, Enemylayer);
        if (hitEnemies.Length > 0)
        {
            ActionDamage = player.TotalDamage * 1.5f;
            SkillStatus = "Wet";
            AttackElement = "Water";
            SkillStatusStack = 1;
            StartCoroutine(VortexhDelay(enemy));
        }
    }
    public bool isVortaxhit;
    private IEnumerator VortexhDelay(Collider2D enemy)
    {
        isVortaxhit = true;
        enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, player.TotalDamage, SkillStatus, SkillStatusStack, AttackElement);
        yield return new WaitForSeconds(1f);
        isVortaxhit = false;
    }
}
