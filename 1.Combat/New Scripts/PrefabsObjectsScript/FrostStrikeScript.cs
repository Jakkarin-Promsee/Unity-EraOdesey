using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostStrikeScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "FrostBite";
    int SkillStatusStack;
    string AttackElement = "Frost";
    public LayerMask Enemylayer;
    float speed = 60f;

    public void Start()
    {
        
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 2.5f;
    }


    public void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            SkillStatusStack = Random.Range(2, 5);
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, PlayerAttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }
}
