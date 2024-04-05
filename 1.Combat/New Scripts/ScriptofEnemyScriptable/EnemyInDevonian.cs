using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy/4_Devonian")]
[System.Serializable]
public class EnemyInDevonian : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public Sprite EnemyImage;
    [SerializeField] public int level;
    [SerializeField] public float Def;
    [SerializeField] public bool Boss;
    [SerializeField] public RuntimeAnimatorController animation;
    [SerializeField] public int ItemID;
}