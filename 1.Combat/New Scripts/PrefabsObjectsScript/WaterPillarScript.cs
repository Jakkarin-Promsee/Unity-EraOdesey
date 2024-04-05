using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WaterPillarScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "Wet";
    int SkillStatusStack = 3;
    string AttackElement = "Water";
    public LayerMask Enemylayer;
    float speed = 30f;

    public void Start()
    {
        PlayerAttackDamage = player.TotalDamage;
        
    }


    public void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            ActionDamage = PlayerAttackDamage * 4;
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, PlayerAttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }
}
