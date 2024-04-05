using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class FrostCystralScript : MonoBehaviour
{
    public PlayerMainController player;
    public double PlayerAttackDamage;
    double ActionDamage;
    string SkillStatus = "Freeze";
    int SkillStatusStack = 0;
    string AttackElement = "Frost";
    int HitCount;
    public LayerMask Enemylayer;
    float speed = 20f;
    public GameObject explosionPrefab; // Reference to the explosion prefab

    public void Start()
    {
        HitCount = 0;
        PlayerAttackDamage = player.TotalDamage;
        ActionDamage = PlayerAttackDamage * 3;
    }

    public void Update()
    {
        if (HitCount >= 1)
        {
            Explode();
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

    private void Explode()
    {
        float SizeX = 4f,
              SixeY = 4f,
              SizeZ = 0;
        GameObject spawnedObject = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
    }
}