using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class IteeSpawner : MonoBehaviour
{
    public List<GameObject> EnemyInCambrian;
    public List<GameObject> EnemyInOrdovician;
    public List<GameObject> EnemyInSilurian;
    public List<GameObject> EnemyInDevonain;
    public List<GameObject> EnemyInCarboniferous;
    public List<GameObject> EnemyInPermians;

    public List<GameObject> BossInCambrian;
    public List<GameObject> BossInOrdovician;
    public List<GameObject> BossInSilurian;

    public int level;
    public double hp;

    public GameObject Player;
    public GameObject GameControl;

    float CountTime = 0;
    float MaxCountTime = 0.65f;

    public int round;
    public int stage;
    public string period;

    public bool SpawnerActive;
    int spawncount;
    float maxspawncount;
    public int SpawnSpeed;

    public bool isAcitvateSpawnBoss;

    public bool isMiniBossDie;
    public bool isBossDie;

    public bool ParallaxOnRuun;

    public int RemainEnemy;

    public GameObject Fade;

    [Header("Do not Input Data It was control by layer controller script")]
    public LayerMask enemyLayer;
    public int enemyLayerInt;
    public LayerMask playerLayer;

    public void Start()
    {
        if (period == null) 
        {
            period = "Cambrian";
        }
        stage = GameControl.GetComponent<GameController>().stage;
        ParallaxOnRuun = GameControl.GetComponent<GameController>().ParallaxisRunning;
        round = 0;
        spawncount = 0;
        maxspawncount = 2;
        isIncreasingRound = false;
        isAcitvateSpawner = false;
        SpawnerActive = true;
        isAlreadySpawnMiniBoss = false;
        isAcitvateSpawnBoss = false;

    }

    public void ChangeStage(string InPeriod,int InStage) 
    {
        
        ResetStage();
        period = InPeriod;
        stage = InStage;
    }

    public void Resetspawncount()
    {
        spawncount = 0;
    }
    
    public void ResetStage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, 999, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().SelfDestory();
        }
        Fade.GetComponent<FadeInOut>().FadeIn();
        round = 0;
        spawncount = 0;
        maxspawncount = 2;
        isAlreadySpawnMiniBoss = false;
        isAcitvateSpawnBoss = false;
        isMiniBossDie = false;
        isBossDie = false;
    }

    

    public void MiniBossFight() 
    {
        if (RemainEnemy == 0) 
        {
            if (period == "Cambrian")
            {
                isAlreadySpawnMiniBoss = true;
                int spawnEnemy = Random.Range(0, EnemyInCambrian.Count);
                GameObject Itee = EnemyInCambrian[spawnEnemy];

                float SizeX = 0.10f,
                      SixeY = 0.10f,
                      SizeZ = 0;
                Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);
                spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                
                spawnedObject.layer = enemyLayerInt;
                spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                Itee.GetComponent<EnemyMainSystem>().DropRate = 1000;
                spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = true;
                spawnedObject.GetComponent<EnemyMainSystem>().level += stage + 4;
                spawncount++;
            }
        }
        if (period == "Ordovician") 
        {
            isAlreadySpawnMiniBoss = true;
            int spawnEnemy = Random.Range(0, EnemyInOrdovician.Count);
            GameObject Itee = EnemyInOrdovician[spawnEnemy];

            float SizeX = 0.10f,
                  SixeY = 0.10f,
                  SizeZ = 0;
            Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
            GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);
            spawnedObject.GetComponent<EnemyMainSystem>().player = Player;

            spawnedObject.layer = enemyLayerInt;
            spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

            Itee.GetComponent<EnemyMainSystem>().DropRate = 1000;
            spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = true;
            spawnedObject.GetComponent<EnemyMainSystem>().level += (stage*2) + 10 + 4;
            spawncount++;
        }
        isIncreasingRound = false;
        isAcitvateSpawner = false;
        if (period == "Silurian")
        {
            isAlreadySpawnMiniBoss = true;
            int spawnEnemy = Random.Range(0, EnemyInSilurian.Count);
            GameObject Itee = EnemyInSilurian[spawnEnemy];

            float SizeX = 0.10f,
                  SixeY = 0.10f,
                  SizeZ = 0;
            Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
            GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);
            spawnedObject.GetComponent<EnemyMainSystem>().player = Player;

            spawnedObject.layer = enemyLayerInt;
            spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

            Itee.GetComponent<EnemyMainSystem>().DropRate = 1000;
            spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = true;
            spawnedObject.GetComponent<EnemyMainSystem>().level += (stage * 4) + 30 + 4;
            spawncount++;
        }
        isIncreasingRound = false;
        isAcitvateSpawner = false;
    }

    public void BossFight() 
    {
        Fade.GetComponent<FadeInOut>().FadeIn();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, 999, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().SelfDestory();
        }
        round = 0;
        spawncount = 0;
        Invoke("SpawnBoss", 2);
    }

    public void SpawnBoss() 
    {
        if (period == "Cambrian")
        {
            isAcitvateSpawnBoss = true;
            int spawnEnemy = stage-1;
            GameObject Itee = BossInCambrian[spawnEnemy];

            float SizeX = 0.15f,
                  SixeY = 0.15f,
                  SizeZ = 0;

            GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);
            spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
            spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
            
            spawnedObject.layer = enemyLayerInt;
            spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

            spawnedObject.GetComponent<EnemyMainSystem>().DropRate = 0;
            spawnedObject.GetComponent<EnemyMainSystem>().isIteeBoss = true;
            spawnedObject.GetComponent<EnemyMainSystem>().level += stage + 6 - 1;
            spawnedObject.GetComponent<EnemyMainSystem>().EnemyAttackDmg = spawnedObject.GetComponent<EnemyMainSystem>().EnemyAttackDmg * 5f;
            spawncount++;
        }
        if (period == "Ordovician") 
        {
            isAcitvateSpawnBoss = true;
            int spawnEnemy = stage - 1;
            GameObject Itee = BossInOrdovician[spawnEnemy];

            float SizeX = 0.15f,
                  SixeY = 0.15f,
                  SizeZ = 0;

            GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);
            spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
            spawnedObject.GetComponent<EnemyMainSystem>().player = Player;

            spawnedObject.layer = enemyLayerInt;
            spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

            spawnedObject.GetComponent<EnemyMainSystem>().DropRate = 0;
            spawnedObject.GetComponent<EnemyMainSystem>().isIteeBoss = true;
            spawnedObject.GetComponent<EnemyMainSystem>().level += (stage*2)+10 + 6 - 1;
            spawnedObject.GetComponent<EnemyMainSystem>().EnemyAttackDmg = spawnedObject.GetComponent<EnemyMainSystem>().EnemyAttackDmg * 5f;
            spawncount++;
        }
        if (period == "Silurian")
        {
            isAcitvateSpawnBoss = true;
            int spawnEnemy = stage - 1;
            GameObject Itee = BossInSilurian[spawnEnemy];

            float SizeX = 0.15f,
                  SixeY = 0.15f,
                  SizeZ = 0;

            GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);
            spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
            spawnedObject.GetComponent<EnemyMainSystem>().player = Player;

            spawnedObject.layer = enemyLayerInt;
            spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

            spawnedObject.GetComponent<EnemyMainSystem>().DropRate = 0;
            spawnedObject.GetComponent<EnemyMainSystem>().isIteeBoss = true;
            spawnedObject.GetComponent<EnemyMainSystem>().level += (stage * 4) + 30 + 6 - 1;
            spawnedObject.GetComponent<EnemyMainSystem>().EnemyAttackDmg = spawnedObject.GetComponent<EnemyMainSystem>().EnemyAttackDmg * 5f;
            spawncount++;
        }

        isIncreasingRound = false;
        isAcitvateSpawner = false;
    }

    public void MiniBossIsDie() 
    {
        isMiniBossDie = true;
    }

    public void BossIsDie() 
    {
        isBossDie = true;
        if (GameControl.GetComponent<GameController>().UnlockLevel <= stage + 10 && period == "Cambrian") GameControl.GetComponent<GameController>().UnlockLevel = stage + 10 + 1;
        if (GameControl.GetComponent<GameController>().UnlockLevel <= stage + 20 && period == "Ordovician") GameControl.GetComponent<GameController>().UnlockLevel = stage + 20 + 1;
        if (GameControl.GetComponent<GameController>().UnlockLevel <= stage + 30 && period == "Silurian") GameControl.GetComponent<GameController>().UnlockLevel = stage + 30 + 1;
    }


    public IEnumerator ActiveSpawner() 
    {
        isAcitvateSpawner = true;
        yield return new WaitForSeconds(2f);
        SpawnerActive = true;
        isIncreasingRound = false;
        isAcitvateSpawner=false;
    }

    bool isAcitvateSpawner;
    bool isIncreasingRound;
    bool isAlreadySpawnMiniBoss;
    public void Update()
    {
        stage = GameControl.GetComponent<GameController>().stage;
        ParallaxOnRuun = GameControl.GetComponent<GameController>().ParallaxisRunning;
        if (ParallaxOnRuun ) { SpawnSpeed = 2; }
        else { SpawnSpeed = 1; }
        SpawnEnemy();
        if (round <= 9) maxspawncount = round * 2; 
        else if(round == 10 && RemainEnemy == 0) maxspawncount = 1;
        if (round == 10 && !isAlreadySpawnMiniBoss) 
        {
            MiniBossFight();
            SpawnerActive = false;
        }

        if (isAcitvateSpawnBoss) SpawnerActive = false;
        if (round >= 11 && isMiniBossDie) ResetStage();
        if (isBossDie) ResetStage();
        RemainEnemy = GameControl.GetComponent<GameController>().remainEnemy;
        if (RemainEnemy == 0) 
        {
            if (!isAcitvateSpawner) 
            {
                StartCoroutine(ActiveSpawner());
            }     
        }
        if (spawncount >= maxspawncount) 
        {
            if (isIncreasingRound == false)
            {
                SpawnerActive = false;
                round++;
                isIncreasingRound = true;
                spawncount = 0;

            }
        }  
    }

    public void SpawnEnemy()
    {
        if (SpawnerActive == true)
        {
            if (CountTime < MaxCountTime/SpawnSpeed) CountTime += Time.deltaTime;
            else
            {
                int spawnpoint = Random.Range(0, 3);
                CountTime = 0;
                if (period == "Cambrian")
                {
                    int spawnEnemy = Random.Range(0, 5);
                    GameObject Itee = EnemyInCambrian[spawnEnemy];
                    float SizeX = 0.06f,
                          SixeY = 0.06f,
                          SizeZ = 0;

                    if (spawnpoint == 0)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;
                        spawnedObject.GetComponent<EnemyMainSystem>().level += stage - 1;
                        spawncount++;
                    }
                    if (spawnpoint == 1)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;
                        spawnedObject.GetComponent<EnemyMainSystem>().level += stage - 1;
                        spawncount++;
                    }
                    if (spawnpoint == 2)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, -0.25f) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;
                        spawnedObject.GetComponent<EnemyMainSystem>().level += stage - 1;
                        spawncount++;
                    }


                }
                if (period == "Ordovician")
                {
                    int spawnEnemy = Random.Range(0, EnemyInOrdovician.Count);
                    GameObject Itee = EnemyInOrdovician[spawnEnemy];
                    float SizeX = 0.06f,
                          SixeY = 0.06f,
                          SizeZ = 0;

                    if (spawnpoint == 0)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;

                        spawnedObject.GetComponent<EnemyMainSystem>().level += ((stage*2) + 10) - 1;
                        spawncount++;
                    }
                    if (spawnpoint == 1)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;

                        spawnedObject.GetComponent<EnemyMainSystem>().level += ((stage * 2) + 10) - 1;
                        spawncount++;
                    }
                    if (spawnpoint == 2)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, -0.25f) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;

                        spawnedObject.GetComponent<EnemyMainSystem>().level += ((stage * 2) + 10) - 1;
                        spawncount++;
                    }
                }
                if (period == "Silurian")
                {
                    int spawnEnemy = Random.Range(0, EnemyInSilurian.Count);
                    GameObject Itee = EnemyInSilurian[spawnEnemy];
                    float SizeX = 0.06f,
                          SixeY = 0.06f,
                          SizeZ = 0;

                    if (spawnpoint == 0)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0.25f) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;

                        spawnedObject.GetComponent<EnemyMainSystem>().level += ((stage * 4) + 30) - 1;
                        spawncount++;
                    }
                    if (spawnpoint == 1)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, 0) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;

                        spawnedObject.GetComponent<EnemyMainSystem>().level += ((stage * 4) + 30) - 1;
                        spawncount++;
                    }
                    if (spawnpoint == 2)
                    {
                        Itee.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
                        GameObject spawnedObject = Instantiate(Itee, new Vector3(0, -0.25f) + transform.position, Quaternion.identity);

                        spawnedObject.layer = enemyLayerInt;
                        spawnedObject.GetComponent<EnemyMainSystem>().PlayerLayers = playerLayer;

                        spawnedObject.GetComponent<EnemyMainSystem>().player = Player;
                        Itee.GetComponent<EnemyMainSystem>().DropRate = stage + 5;
                        spawnedObject.GetComponent<EnemyMainSystem>().isIteeMiniBoss = false;

                        spawnedObject.GetComponent<EnemyMainSystem>().level += ((stage * 4) + 30) - 1;
                        spawncount++;
                    }
                }

            }
        }
    }
}
