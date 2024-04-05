using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSwordScript : MonoBehaviour
{
    public PlayerMainController player;
    double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "";
    int SkillStatusStack = 1;
    string AttackElement = "";
    int HitCount;
    public LayerMask Enemylayer;
    float speed = 20f;

    public void Start()
    {
        HitCount = 0;
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 6;
    }


    public void Update()
    {
        if (HitCount >= 6)
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
