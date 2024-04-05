using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSwordScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "";
    int SkillStatusStack = 1;
    string AttackElement = "";
    public LayerMask Enemylayer;
    //float speed = 20f;

    public void Start()
    {
        
    }


    public void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            PlayerAttackDamage = player.TotalDamage;
            ActionDamage = PlayerAttackDamage * 2;
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, PlayerAttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }
}
