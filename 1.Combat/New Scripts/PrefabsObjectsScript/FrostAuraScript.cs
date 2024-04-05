using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostAuraScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "FrostBite";
    int SkillStatusStack = 1;
    string AttackElement = "Frost";
    public LayerMask Enemylayer;


    public void Start()
    {
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 0.2f;
    }


    private void OnTriggerEnter2D(Collider2D enemy)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, this.transform.localScale.magnitude, Enemylayer);
        if (hitEnemies.Length > 0)
        {
            SkillStatus = "FrostBite";
            AttackElement = "Frost";
            SkillStatusStack = 1;
            StartCoroutine(VortexhDelay(enemy));
        }
    }
    private void hit(Collider2D enemy)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, this.transform.localScale.magnitude, Enemylayer);
        if (hitEnemies.Length > 0)
        {
            SkillStatus = "FrostBite";
            AttackElement = "Frost";
            SkillStatusStack = 1;
            StartCoroutine(VortexhDelay(enemy));
        }
    }

    private IEnumerator VortexhDelay(Collider2D enemy)
    {
        enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, player.TotalDamage, SkillStatus, SkillStatusStack, AttackElement);
        yield return new WaitForSeconds(0.5f);
        hit(enemy);
    }
}
