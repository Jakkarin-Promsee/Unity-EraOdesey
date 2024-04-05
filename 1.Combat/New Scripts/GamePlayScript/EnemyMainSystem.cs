using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyMainSystem : MonoBehaviour
{

    public GameObject player;
    public double MaxHp;
    public double MaxDef = 0;
    public float EnemyAttackDmg;
    public SpriteRenderer Image;
    float speed = 2;
    public Transform attackPoint;
    public LayerMask PlayerLayers = 6;
    public Animator animator;
    public bool ParallaxOnRun;

    double currentHp;
    double currentDef;
    float EnemyAttackSpeed;

    double PlayerAttack;
    public int level;
    

    // InStatus
    public string inStatus;
    public float inStatusStack;

    // Fire
    float burnDuration;
    public string fireStatus;
    bool isOnFireEffectInProgress = false;

    //Water
    float WetStack;
    bool isOnWaterEffectInProgress = false;

    //Frost
    string FrostEffect;
    float FrostbiteStack;
    float FreezeDuration;
    float TakeDamageMultiplier = 1;
    bool isOnFrostEffectInProgress = false;
    bool isOnFreezeEffectInProgress = false;

    //Earth






    // DamagePopUp
    [SerializeField] private Transform pfDamagePopUp;
    void Start()
    {
        
        animator = this.GetComponent<Animator>();
        spawner = GameObject.Find("EnemySpawner");
        GameController = GameObject.Find("GameController");
        Silder = GameObject.Find("Slider");
        ParallaxOnRun = GameController.GetComponent<GameController>().ParallaxisRunning;
        MaxHp = 73.3f * Mathf.Exp(0.405f * level) * 3;
        EnemyAttackDmg = 19.2f * Mathf.Exp(0.227f * level);
        MaxDef = 13.1f * Mathf.Exp(0.412f * level);
        EnemyAttackSpeed = 1;
        currentHp = MaxHp;
        currentDef = MaxDef;
        burnDuration = 0;
        WetStack = 0;
    }
    
    public void Attack(out bool AttackComplete)
    {
        
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(this.transform.position, 0.75f, PlayerLayers);
        //Debug.Log("Attack");
        if (hitPlayer.Length > 0)
        {
            AttackComplete = true;
        }
        else AttackComplete = false;

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("Play attack animation");
            animator.SetTrigger("Attack");
            player.GetComponent<PlayerMainController>().TakeDamage(EnemyAttackDmg);
        }

    }

    public void TakeDamage(double takedamage, double playerAttack, string status, float statusStack,string AttackElement)
    {
        
        currentDef = currentDef - currentDef * (WetStack * 0.1f) ;
        if (FrostEffect != "Freeze") 
        {
            currentHp -= (takedamage - (takedamage * (currentDef / MaxHp))) * (TakeDamageMultiplier + (TakeDamageMultiplier * FrostbiteStack));
            Transform damagePopupTranform = Instantiate(pfDamagePopUp, this.transform.position, Quaternion.identity);
            DamagePopup damagePopup = damagePopupTranform.GetComponent<DamagePopup>();
            damagePopup.Setup((takedamage - (takedamage * (currentDef / MaxHp))) * (TakeDamageMultiplier + (TakeDamageMultiplier * FrostbiteStack)));
        }
        
        if (FrostEffect == "Freeze")
        {
            if (AttackElement != "Frost")
            {
                currentHp -= (takedamage - (takedamage*(currentDef/MaxHp))) * 2.5f; // HeathEffect = DamageFromPlayer - (DamageForPlayer * (def/Hp))
                Transform damagePopupTranform = Instantiate(pfDamagePopUp, this.transform.position, Quaternion.identity);
                DamagePopup damagePopup = damagePopupTranform.GetComponent<DamagePopup>();
                damagePopup.Setup((takedamage - (takedamage * (currentDef / MaxHp))));
                    FreezeDuration--;
            }
            else
            {
                currentHp -= (takedamage - (takedamage * (currentDef / MaxHp))) * 0.75f;
                Transform damagePopupTranform = Instantiate(pfDamagePopUp, this.transform.position, Quaternion.identity);
                DamagePopup damagePopup = damagePopupTranform.GetComponent<DamagePopup>();
                damagePopup.Setup((takedamage - (takedamage * (currentDef / MaxHp))) * 0.75f);
            }
        }

        PlayerAttack = playerAttack;

        if (status != "")
        {
            inStatus = status;
            inStatusStack = statusStack;
            if (AttackElement == "Fire") { GetFireEffect(inStatus,inStatusStack);}
            if (AttackElement == "Water") { GetWaterEffect(inStatus, inStatusStack);}
            if (AttackElement == "Frost") { GetFrostEffect(inStatus, inStatusStack);}
                
        }  
    }

    //FireTree ====================================================================================================================================
    public void GetFireEffect(string inStatus,float inStatusStack)
    {
        if (burnDuration != 0)
        {
            //Burning
            if (inStatus == "Burning") 
            {
                if (inStatus == "Burning" && fireStatus != "Inferno" && fireStatus != "Fury")
                {
                    fireStatus = inStatus; burnDuration += inStatusStack;
                }
                if (inStatus == "Burning" && fireStatus == "Inferno")
                {
                    burnDuration += inStatusStack * 0.05f;
                }
                if (inStatus == "Burning" && fireStatus == "Fury")
                {
                    burnDuration += inStatusStack * 0.25f;
                }
                
            }
            //Fury
            if (inStatus == "Fury")
            {
                if (inStatus == "Fury" && fireStatus != "Burning" && fireStatus != "Inferno")
                {
                    fireStatus = inStatus; burnDuration += inStatusStack;
                }
                if (inStatus == "Fury" && fireStatus == "Inferno")
                {
                    burnDuration += inStatusStack * 0.25f;
                }
                if (inStatus == "Fury" && fireStatus == "Burning")
                {
                    fireStatus = inStatus; burnDuration = inStatusStack;
                }
                
            }

            //Inferno
            if ((inStatus == "Inferno")) 
            {
                if (inStatus == "Inferno" && fireStatus != "Burning" && fireStatus != "Fury")
                {
                    fireStatus = inStatus; burnDuration += inStatusStack;
                }
                if (inStatus == "Inferno" && fireStatus == "Fury")
                {
                    fireStatus = inStatus; burnDuration = inStatusStack;
                }
                if (inStatus == "Inferno" && fireStatus == "Burning")
                {
                    fireStatus = inStatus; burnDuration = inStatusStack;
                }
            }
        }

        else if (burnDuration == 0 )
        {
            fireStatus = inStatus;
            burnDuration += inStatusStack;
        }
    }


    public void OnFireEffect()
    {
        Image.color = Color.yellow;
        if (fireStatus == "Burning")
        {
            currentHp -= (PlayerAttack * 0.25f);
        }
        else if (fireStatus == "Fury")
        {
            currentHp -= (PlayerAttack * 1.25f);
        }
        else if (fireStatus == "Inferno")
        {
            currentHp -= (PlayerAttack * 12.5f);
        }
    }
    private IEnumerator DecreaseBurnDurationWithDelay()
    {
        isOnFireEffectInProgress = true;
        yield return new WaitForSeconds(1);
        OnFireEffect();
        burnDuration--;
        isOnFireEffectInProgress = false;
    }
    //FireTree ====================================================================================================================================


    //WaterTree ====================================================================================================================================
    public void GetWaterEffect(string inStatus, float inStatusStack) 
    {
        Image.color = Color.cyan;
        WetStack += inStatusStack;
    }
    private IEnumerator DecreaseWetStackWithDelay()
    {
        isOnWaterEffectInProgress = true;
        yield return new WaitForSeconds(2f);
        WetStack--;
        isOnWaterEffectInProgress = false;
    }
    //WaterTree ====================================================================================================================================

    //FrostTree ====================================================================================================================================
    public void GetFrostEffect(string inStatus, float inStatusStack)
    {
        if (inStatus == "FrostBite") 
        {
            Image.color = Color.blue;
            FrostEffect = "FrostBite";
            if (FrostbiteStack >= 10) 
            {
                OnFreezeEffect();
                FreezeDuration = 7;
            }
            else if (FrostbiteStack < 10) 
            {
                Image.color = Color.blue;
                FrostbiteStack += inStatusStack;
            }
        }
        if (inStatus == "Freeze") 
        {
            OnFreezeEffect();
            FreezeDuration = 7;
        }
    }
    public void OnFreezeEffect() 
    {
        FrostEffect = "Freeze";
        Image.color = Color.black;
        FrostbiteStack = 0;
    }
    private IEnumerator DecreaseFreezeDurationStackWithDelay()
    {
        isOnFreezeEffectInProgress = true;
        yield return new WaitForSeconds(1f);
        FreezeDuration--;
        isOnFreezeEffectInProgress = false;
    }
    private IEnumerator DecreaseFrostBiteStackWithDelay()
    {
        isOnFrostEffectInProgress = true;
        yield return new WaitForSeconds(2f);
        FrostbiteStack--;
        isOnFrostEffectInProgress = false;
    }
    //FrostTree ====================================================================================================================================


    float NormalAttackTime = 0;
    float NormalAttackMaxTime = 1;

    public GameObject Silder;

    private void Update()
    {
        Silder.GetComponent<ProgressSilderController>().BossMaxHp = MaxHp;
        Silder.GetComponent<ProgressSilderController>().BossRemainHp = currentHp;
        ParallaxOnRun = GameController.GetComponent<GameController>().ParallaxisRunning;
        if (currentDef < 0) currentDef = 0;
        if (FrostEffect == "Freeze") EnemyAttackSpeed = 0f;
        if (FrostEffect != "Freeze") EnemyAttackSpeed = 1f - (FrostbiteStack * 0.1f);
        if (NormalAttackTime < NormalAttackMaxTime) NormalAttackTime += Time.deltaTime * EnemyAttackSpeed;
        else
        {
            bool IsComplete = false;
            Attack(out IsComplete);

            if(IsComplete) NormalAttackTime = 0;
            
        }

        if (currentHp < 0)
        {
            Die();
        }

        if (burnDuration > 0)
        {
            if (!isOnFireEffectInProgress)
            {
                StartCoroutine(DecreaseBurnDurationWithDelay());
            }
        }
        else
        {
            fireStatus = "";
        }
        if (WetStack > 0)
        {
            if (!isOnWaterEffectInProgress)
            {
                StartCoroutine(DecreaseWetStackWithDelay());
            }
        }
        if (FrostbiteStack > 0)
        {
            if (!isOnFrostEffectInProgress)
            {
                StartCoroutine(DecreaseFrostBiteStackWithDelay());
            }
        }
        if (FrostbiteStack <= 0) 
        {
            if (FrostEffect != "Freeze") FrostEffect = "";

        }
        if (FrostEffect == "Freeze") 
        {   
            if(FreezeDuration > 0) 
            {
                FrostbiteStack = 0;
                TakeDamageMultiplier = 2.5f;
                if (!isOnFreezeEffectInProgress)
                {
                    StartCoroutine(DecreaseFreezeDurationStackWithDelay());
                }
            }
            if(FreezeDuration <= 0) 
            {
                FrostEffect = "";
                FrostbiteStack = 0;
                Image.color = Color.white;
            }
           
        }
        

        float distamce = Mathf.Abs(player.transform.position.x-this.transform.position.x);

        if (distamce >= 0.5) 
        {
            if (!ParallaxOnRun) { transform.Translate(Vector3.left * speed * Time.deltaTime); }
            if (ParallaxOnRun) { transform.Translate(Vector3.left * speed * 2 * Time.deltaTime); }
        }
            

        player.GetComponent<PlayerMainController>();

    }


    bool IteeFirstDie = true;
    public bool isIteeMiniBoss;
    public bool isIteeBoss;

    public void Die()
    {
        
        if (IteeFirstDie)
        {
            speed = 0;
            Image.color = Color.red;
            Invoke("Destroyer", 0.5f);
            Debug.Log("ITee is Die");
            IteeFirstDie = false;

        }
        
    }

    public GameObject spawner;
    public GameObject GameController;
    public int ItemID;
    public int DropRate;

    public void Destroyer()
    {
        GameObject drop = player.GetComponent<PlayerMainController>().PrefabMaterialSpawn[ItemID];

        GameController.GetComponent<GameController>().killIncrease();
        if (!isIteeBoss) GameController.GetComponent<GameController>().GetExp((144f * Mathf.Exp(0.503f * level))/2);
        Debug.Log("Get Exp " + 144f * Mathf.Exp(0.503f * level) + "Form Level " + level);

        Silder.GetComponent<ProgressSilderController>().roundprogress += 1;
        int RandomDrop = Random.Range(0, 101);
        if (RandomDrop < DropRate) 
        {
            if (ItemID != 0)
            {
                GameObject spawnedDropObject = Instantiate(drop, transform.position, Quaternion.identity);
                spawnedDropObject.GetComponent<InventoryPickup>().ItemData = player.GetComponent<InventoryAllHolder>().InventoryAllItemSystem.InventorySlotMaterials[ItemID - 1].ItemMaterial;
                spawnedDropObject.GetComponent<InventoryPickup>().numberAmount = 1;
                spawnedDropObject.GetComponent<InventoryPickup>().multiplierAmount = 0;
            }

        }

        if (isIteeMiniBoss) { spawner.GetComponent<IteeSpawner>().MiniBossIsDie(); }
        if (isIteeBoss) 
        { 
            spawner.GetComponent<IteeSpawner>().BossIsDie(); 
            GameController.GetComponent<GameController>().AutoChangeStage();
        }

        Destroy(gameObject);
    }

    public void SelfDestory() 
    {
        GameController.GetComponent<GameController>().DecreaseEnemyToZero();
        Silder.GetComponent<ProgressSilderController>().roundprogress = 0;
        Destroy(gameObject);
    }
}
