using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FireWaveScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "Burning";
    int SkillStatusStack = 1;
    string AttackElement = "Fire";
    int HitCount;
    public LayerMask Enemylayer;
    float speed = 20f;

    public void Start()
    {
        HitCount = 0;
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 2;
    }


    public void Update()
    {
        if (HitCount >= 10) 
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, PlayerAttackDamage, SkillStatus, SkillStatusStack, AttackElement);
            HitCount++;
        }
    }
}
