using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [Header("For Player Layer")]
    public LayerMask playerLayer;
    public int layerPlayer_number;

    [Header("For Enemy Layer")]
    public LayerMask enemyLayer;
    public int layerEnemy_number;

    [Header("For Script That must setting layer")]
    public PlayerMainController Player;
    public IteeSpawner EnemySpawenr;

    private void Start() {
        Player.enemyLayers = enemyLayer;

        EnemySpawenr.playerLayer = playerLayer;
        EnemySpawenr.enemyLayer = enemyLayer;
        EnemySpawenr.enemyLayerInt = layerEnemy_number;
    }

}
