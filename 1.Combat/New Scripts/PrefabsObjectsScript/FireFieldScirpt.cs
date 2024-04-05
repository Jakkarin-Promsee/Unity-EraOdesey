using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFieldScirpt : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "Buring";
    int SkillStatusStack = 1;
    string AttackElement = "Fire";
    public LayerMask Enemylayer;


    public void Start()
    {
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 1;
    }

 
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(20f,6f), Enemylayer);
        if (hitEnemies.Length > 0)
        {
            ActionDamage = player.AttackDamage * 1.5f;
            SkillStatus = "Burning";
            AttackElement = "Fire";
            SkillStatusStack = 1;
            StartCoroutine(BurnDelay(enemy));
        }
    }
    private void hit(Collider2D enemy)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(this.transform.position, new Vector2(20f, 6f), Enemylayer);
        if (hitEnemies.Length > 0)
        {
            ActionDamage = player.AttackDamage * 0.75f;
            SkillStatus = "Burning";
            AttackElement = "Fire";
            SkillStatusStack = 1;
            StartCoroutine(BurnDelay(enemy));
        }
    }

    private IEnumerator BurnDelay(Collider2D enemy)
    {
        enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, player.TotalDamage, SkillStatus, SkillStatusStack, AttackElement);
        yield return new WaitForSeconds(0.5f);
        hit(enemy);
    }
}
