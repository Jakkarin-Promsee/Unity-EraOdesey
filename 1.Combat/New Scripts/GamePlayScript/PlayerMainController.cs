using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
//using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using System.Security.Cryptography;

[System.Serializable]
public class PlayerMainController : MonoBehaviour, IDataPersistance
{
    private string[] multiple = {"", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                 "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    public InventoryAllHolder inventoryAllHolder;

    public List<GameObject> PrefabMaterialSpawn;
    public AudioSource HitEnemy;
    //text
    public TMP_Text LevelText;
    public TMP_Text HpText;
    public TMP_Text AtkText;
    
    [SerializeField] public SkillAllSystem skillAllSystem;

    public bool IsAutoSkillTrickerFromPlayer = false;
    public Animator animator;
    public Transform attackPoint;

    public int level;
    public double MaxHp;
    public double currentHp;


    public double BaseAttack;
    public float PlayerAttackRange = 0.15f;
    public double WeaponAttack;
    public double ArmorStrangth;
    public float AttackSpeed = 1;

    public double PrimryWeaponDamage;
    public double SeconaryWeaponDamge;

    public double HelmetStrength;
    public double ChestplatevStrength;
    public double LeggingStrength;
    public double BootsStrength;


    public double ActionDamage;
    public GameObject FireField;
    public GameObject FireWave;

    public GameObject WaterPillar;
    public GameObject WaterVortax;

    public GameObject FrostStrike;
    public GameObject FrostAura;
    public GameObject FrostCystral;

    public GameObject StoneSword;
    Vector3 RocolPlayerposition;

    float RecolPlayerAttackRange;
    double RecolWeaponAttack;
    double RecolArmorStrangth;
    float RecolAttackSpeed;

    public double TotalAttackSpeed;
    public double AttackDamage;

    //Skill
    public float SkillAttackRange;
    public string SkillStatus;
    public float SkillStatusStack;
    public string AttackElement;


    // Earth Passive Power
    public float EarthEnergyStack;
    public int OnEarthSwordActivated;
    public int EarthSwordSpeed;
    public GameObject EarthSword;

    public float takedamagereductionMultiplier;


    bool Fire1Sword;
    bool Fire2Sword;

    bool Water1Sword;


    bool Frost1Sword;

    bool Earth1Sword;
    bool Earth4Sword;

    double BuffDamage;
    float BuffAttackSpeed;
    


    public List<SkillSlotEarth> AllSkillEarths;
    public List<SkillSlotFire> AllSkillFire;
    public List<SkillSlotFrost> AllSkillFrost;
    public List<SkillSlotWater> AllSkillWater;

    [Header("Do not Input Data It was control by layer controller script")]
    public LayerMask enemyLayers;

    public void LoadData(GameData data)
    {
        for(int i=0; i<skillAllSystem.skillEarth.listSkillSlotEarths.Count; i++)
        {
            skillAllSystem.skillEarth.listSkillSlotEarths[i].Load(data.skillEarth[i]);
        }

        for(int i=0; i<skillAllSystem.skillFire.listSkillSlotFires.Count; i++)
        {
            skillAllSystem.skillFire.listSkillSlotFires[i].Load(data.skillFire[i]);
        }

        for(int i=0; i<skillAllSystem.skillFrost.listSkillSlotFrosts.Count; i++)
        {
            skillAllSystem.skillFrost.listSkillSlotFrosts[i].Load(data.skillFrost[i]);
        }

        for(int i=0; i<skillAllSystem.skillWater.listSkillSlotWaters.Count; i++)
        {
            skillAllSystem.skillWater.listSkillSlotWaters[i].Load(data.skillWater[i]);
        }
    }

    public void SaveData(ref GameData data)
    {
        for(int i=0; i<skillAllSystem.skillEarth.listSkillSlotEarths.Count; i++)
        {
            data.skillEarth[i].SaveNewData(skillAllSystem.skillEarth.listSkillSlotEarths[i]);
        }

        for(int i=0; i<skillAllSystem.skillFire.listSkillSlotFires.Count; i++)
        {
            data.skillFire[i].SaveNewData(skillAllSystem.skillFire.listSkillSlotFires[i]);
        }

        for(int i=0; i<skillAllSystem.skillFrost.listSkillSlotFrosts.Count; i++)
        {
            data.skillFrost[i].SaveNewData(skillAllSystem.skillFrost.listSkillSlotFrosts[i]);
        }

        for(int i=0; i<skillAllSystem.skillWater.listSkillSlotWaters.Count; i++)
        {
            data.skillWater[i].SaveNewData(skillAllSystem.skillWater.listSkillSlotWaters[i]);
        }
    }

    public GameController gameController;

    private void Start()
    {
        isRegenInProgress = false;
        level = gameController.level;
        MaxHp = 958 * Mathf.Exp(0.301f * level);
        BaseAttack = 156 * Mathf.Exp(0.223f * level);
        HealMax();
        RecolPlayerAttackRange = PlayerAttackRange;
        RecolWeaponAttack = WeaponAttack;
        RecolAttackSpeed = AttackSpeed;
        RocolPlayerposition = this.transform.position;

        AllSkillEarths = skillAllSystem.SkillEarth.listSkillSlotEarths;
        AllSkillFire = skillAllSystem.skillFire.listSkillSlotFires;
        AllSkillFrost = skillAllSystem.skillFrost.listSkillSlotFrosts;
        AllSkillWater = skillAllSystem.skillWater.listSkillSlotWaters;

        //Reset all data about skill because it reset prefab to zero
        //skillAllSystem.ClearAllSkillAllElement();

        skillAllSystem.ResetCurrentCooldonwAllSkillAllElement();
    }

    public void HealMax() 
    {
        currentHp = MaxHp;
    }

    public void PlayerReposition() 
    {
        this.transform.position = RocolPlayerposition;
    }

    public double TotalDamage;

    public void TakeDamage(float takedamage)
    {
        Debug.Log("Player Hit!!!");
        currentHp = currentHp - takedamage - (takedamage * takedamagereductionMultiplier);
    }
    bool isRegenInProgress;
    private IEnumerator Regeneration()
    {
        isRegenInProgress = true;
        yield return new WaitForSeconds(1);
        Debug.Log("HeaLLL");
        currentHp += (MaxHp * 0.01f);
        if (currentHp > MaxHp) currentHp = currentHp - (currentHp - MaxHp);
        isRegenInProgress = false;
    }

    private void SumAmountMultiplyPattern(double number1, long multiplier1, double number2, long multiplier2, out double newnewnumber, out long newnewmultiplier)
    {
        bool CheckNumber = Mathf.Abs(multiplier1 - multiplier2) <= 3;

        double newnumber = 0;
        long newmutiplier = 0;

        if (CheckNumber)
        {
            if (multiplier1 == multiplier2)
            {
                newnumber = number1 + number2;
                newmutiplier = multiplier1;
            }

            else if (multiplier1 < multiplier2)
            {
                newnumber = number2 + number1 / Mathf.Pow(1000, Mathf.Abs(multiplier1 - multiplier2));
                newmutiplier = multiplier2;
            }

            else if (multiplier1 > multiplier2)
            {
                newnumber = number1 + number2 / Mathf.Pow(1000, Mathf.Abs(multiplier1 - multiplier2));
                newmutiplier = multiplier1;
            }
        }

        else
        {
            if (number1 > number2) newnumber = number1;
            else newnumber = number2;

            if (multiplier1 > multiplier2) newmutiplier = multiplier1;
            else newmutiplier = multiplier2;
        }

        ConvertNumberToMutiplyPattern(newnumber, newmutiplier, out newnewnumber, out newnewmultiplier);
    }

    public void ConvertNumberToMutiplyPattern(double number, long multiplier, out double newnumber, out long newmutiplier)
    {
        double multiplierValue = 1e3;
        if (number > multiplierValue)
        {
            double mp = 1;
            long mmp = multiplier;

            while (number / mp > multiplierValue)
            {
                mp *= multiplierValue;
                mmp++;
            }

            newnumber = number / mp;
            newmutiplier = mmp;
        }
        else if (number < 1)
        {
            double mp = 1;

            while (number * mp < 0)
            {
                mp *= multiplierValue;
            }

            newnumber = number * mp;
            newmutiplier = (long)(multiplier - mp);
        }
        else
        {
            newnumber = number;
            newmutiplier = multiplier;
        }
    }

    // UPDATE----------------------------------------------------------
    private void Update()
    {
        double[] DamageWeaponNumber = new double[6];
        long[] DamageWeaponMultiplier = new long[6];

        //Sword1 : 0
        //Sword2 : 1
        //Hat    : 2
        //Shirt  : 3
        //Pant   : 4
        //Shoe   : 5

        for (int i = 0; i < 6; i++)
        {
            if (inventoryAllHolder.InventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].ID < inventoryAllHolder.InventoryAllItemSystem.InventorySlotWeapons.Count && inventoryAllHolder.InventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].ID >= 0)
            {
                inventoryAllHolder.InventoryAllItemSystem.InventorySlotWeapons[inventoryAllHolder.InventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].ID].GetDamage(out DamageWeaponNumber[i], out DamageWeaponMultiplier[i]);
            }

            //inventoryAllHolder.InventoryAllItemSystem.InventorySlotWeapons[inventoryAllHolder.InventoryAllItemSystem.equipmentSystem.inventorySlotUI[i].ID].ItemWeapon.Icon;
        }

        double SumArmorNumber;
        long SumArmorMultiplier;

        double SumAllArmorNumber = 0;
        long SumAllArmorMultiplier = 0;

        //SumAmountMultiplyPattern(DamageWeaponNumber[0], DamageWeaponMultiplier[0], DamageWeaponNumber[1], DamageWeaponMultiplier[1], out SumNumberWeapon1, out SumMutiplierWeapon1);
        SumAmountMultiplyPattern(DamageWeaponNumber[2], DamageWeaponMultiplier[2], DamageWeaponNumber[3], DamageWeaponMultiplier[3], out SumArmorNumber, out SumArmorMultiplier);
        SumAllArmorNumber += SumArmorNumber;
        SumAllArmorMultiplier += SumArmorMultiplier;

        SumAmountMultiplyPattern(DamageWeaponNumber[4], DamageWeaponMultiplier[4], DamageWeaponNumber[5], DamageWeaponMultiplier[5], out SumArmorNumber, out SumArmorMultiplier);
        SumAllArmorNumber += SumArmorNumber;
        SumAllArmorMultiplier += SumArmorMultiplier;

        ConvertNumberToMutiplyPattern(SumAllArmorNumber, SumAllArmorMultiplier, out SumArmorNumber, out SumArmorMultiplier);
        SumAllArmorNumber = SumArmorNumber;
        SumAllArmorMultiplier = SumArmorMultiplier;


        ArmorStrangth = SumAllArmorNumber * Mathf.Pow(1000, SumAllArmorMultiplier);
        WeaponAttack = DamageWeaponNumber[0] * Mathf.Pow(1000, DamageWeaponMultiplier[0]);
        
        Debug.Log("WeaponAttack = " + WeaponAttack);
        Debug.Log("HatStrangth =" + ArmorStrangth);

        if (!isRegenInProgress & currentHp < MaxHp) StartCoroutine(Regeneration()); ;
        LevelText.text = "Level " + level;
        double TextDamageForStatusShow = (double)TotalDamage;
        double TextHpForStatusShow = (double)MaxHp;

        double ND, NH;
        long MD, MH;

        ConvertNumberToMutiplyPattern(TextDamageForStatusShow, 0, out ND, out MD);
        ConvertNumberToMutiplyPattern(TextHpForStatusShow, 0, out NH, out MH);

        if (MD<=0) AtkText.text = "Atk " + ND.ToString("F0");
        else {
            if (ND < 10) AtkText.text = (ND * Mathf.Pow(1000, 1)).ToString("F0") + multiple[MD-1];
            else AtkText.text = ND.ToString("F2") + multiple[MD];
        }
        if(MH<=0) HpText.text = "Hp " + NH.ToString("F0");
        else {
            if (NH < 10) HpText.text = (NH * Mathf.Pow(1000, 1)).ToString("F0") + multiple[MH-1];
            else HpText.text = NH.ToString("F2") + multiple[MH];
        }

        MaxHp = 958 * Mathf.Exp(0.301f * level);
        BaseAttack = 156 * Mathf.Exp(0.223f * level);
        level = gameController.level;
        TotalDamage = BaseAttack + WeaponAttack + ArmorStrangth + TotalBuffDamage;
        AttackDamage = BaseAttack + WeaponAttack + WeaponAttack + ArmorStrangth;
        TotalAttackSpeed = AttackSpeed + TotalBuffAttackSpeed;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, PlayerAttackRange, enemyLayers);
        if(hitEnemies.Length > 0 )  IsAutoSkillTrickerFromPlayer = true;
        else IsAutoSkillTrickerFromPlayer = false;

        if (EarthEnergyStack >= 10)
        {
            EarthEnergyStack -= 10;
            GameObject spawnedObject = Instantiate(EarthSword, attackPoint.position, Quaternion.identity);
            spawnedObject.GetComponent<EarthSwordScript>().player = this.GetComponent<PlayerMainController>();
            Destroy(spawnedObject, 15f);
        }
    }
    //------------------------------------------------------------------

    

    //FireSword
    public void StopFire1Sword() 
    {
        Fire1Sword = false;
    }
    public void StopFire2Sword()
    {
        Fire2Sword = false;
    }

    //WaterSword
    public void StopWater1Sword() 
    { 
        Water1Sword = false;
    }

    //Frost
    public void StopFrost1Sword()
    {
        Frost1Sword = false;
    }

    public void StopEarth1Sword() 
    {
        Earth1Sword = false;
    }
    public void StopEarth4Sword()
    {
        Earth4Sword = false;
    }

    //Buff Attack=================================================================================
    public void GetBuff(double inComeBuff, float BuffDuration)
    {
        TotalBuffDamage += inComeBuff;
        StartCoroutine(DeleteBuffWithDelay(inComeBuff, BuffDuration));
        Debug.Log("Buff is Activated");
    }
    private IEnumerator DeleteBuffWithDelay(double OutBuff, float delay)
    {
        yield return new WaitForSeconds(delay);
        TotalBuffDamage -= OutBuff;
        Debug.Log("Buff is UnActivated");
    }
    double TotalBuffDamage;
    //Buff AttackSpeed=================================================================================
    float TotalBuffAttackSpeed;
    public void GetAttackSpeedBuff(float inComeBuff, float BuffDuration)
    {
        TotalBuffAttackSpeed += inComeBuff;
        StartCoroutine(DeleteAttackSpeedBuffWithDelay(inComeBuff, BuffDuration));
    }
    private IEnumerator DeleteAttackSpeedBuffWithDelay(float OutBuff, float delay)
    {
        yield return new WaitForSeconds(delay);
        TotalBuffAttackSpeed -= OutBuff;
    }
    //takedamagereductionMultiplier=================================================

    public void GettakedamagereductionMultiplier(float inComeBuff, float BuffDuration) 
    {
        takedamagereductionMultiplier += inComeBuff;
        StartCoroutine(DeletetakedamagereductionMultiplierWithDelay(inComeBuff, BuffDuration));
    }
    private IEnumerator DeletetakedamagereductionMultiplierWithDelay(float OutBuff, float delay)
    {
        yield return new WaitForSeconds(delay);
        takedamagereductionMultiplier -= OutBuff;
    }



    public void ClearStatsToDefaulse()
    {
        PlayerAttackRange = RecolPlayerAttackRange;
        WeaponAttack = RecolWeaponAttack;
        AttackSpeed = RecolAttackSpeed;
    }
    // Normal Attack ======================================================================================================
    public void NormalAttack(out bool AttackComplete)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, PlayerAttackRange, enemyLayers);
        
        if (hitEnemies.Length > 0)
        {
            skillAllSystem.skillWater.listSkillSlotWaters[0].DecreaseCurrentCooldown(0.25f);
            skillAllSystem.skillWater.listSkillSlotWaters[2].DecreaseCurrentCooldown(0.25f);
            skillAllSystem.skillWater.listSkillSlotWaters[3].DecreaseCurrentCooldown(0.10f);
            ActionDamage = TotalDamage * 1;
            SkillStatus = "";
            SkillStatusStack = 0;
            HitEnemy.Play();
            animator.SetTrigger("Attack");
            AttackComplete = true;
        }
        else 
        {
            AttackComplete = false;
        } 
            


        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage , AttackDamage , SkillStatus, SkillStatusStack, AttackElement);
            if (Fire1Sword == true)
            {
                enemy.GetComponent<EnemyMainSystem>().GetFireEffect("Burning", 1);
            }
            
            if (Fire2Sword == true)
            {
                GameObject spawnedObject = Instantiate(FireWave, attackPoint.position, Quaternion.identity);
                spawnedObject.GetComponent<FireWaveScript>().player = this.GetComponent<PlayerMainController>();
                Destroy(spawnedObject, 5f);
            }
            if (Water1Sword == true)
            {
                int jo = Random.Range(0, 11);
                if (jo <= 5) 
                {
                    enemy.GetComponent<EnemyMainSystem>().GetWaterEffect("Wet", 1);
                }   
            }
            if (Frost1Sword == true)
            {
                enemy.GetComponent<EnemyMainSystem>().GetFrostEffect("FrostBite", 1);
            }
            if (Earth1Sword == true) 
            {
                int StoneBuffChange = Random.Range(1, 101);
                if (StoneBuffChange <= 10) EarthEnergyStack++;
            }
            if (Earth4Sword == true) 
            {
                int StoneBuffChange = Random.Range(1, 101);
                if (StoneBuffChange <= 18) EarthEnergyStack++;
            }

        }
    }
    //FireTree ====================================================================================================================================
    public void FireSkill1()
    {
        AllSkillFire[0].ReCurrentCooldonw();
        ActionDamage = TotalDamage * 3;
        SkillAttackRange = PlayerAttackRange + 5f;
        AttackElement = "Fire";
        SkillStatus = "Burning";
        SkillStatusStack = 5;
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, SkillAttackRange, enemyLayers);
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
            }
        }
        
    }

    public void FireSkill2() 
    {
        Fire1Sword = true;
        AllSkillFire[1].ReCurrentCooldonw();
        BuffDamage = AttackDamage * 1f;
        float BuffDuration = 12f;
        GetBuff(BuffDamage, BuffDuration);
        Invoke("StopFire1Sword", 12);
    }

    public void FireSkill3()
    {
        AllSkillFire[2].ReCurrentCooldonw();
        ActionDamage = TotalDamage * 1.5f;
        AttackElement = "Fire";
        SkillStatus = "Burning";
        SkillStatusStack = 1;
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position + new Vector3(2.5f, 0f), new Vector2(2.5f, 5f), 0f, enemyLayers);
        
        Invoke("FireSkill3Effect", 1);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }


    public void FireSkill3Effect()
    {
        ActionDamage = TotalDamage * 3f;
        AttackElement = "Fire";
        SkillStatus = "Fury";
        SkillStatusStack = 5;
        animator.SetTrigger("Attack");
        float SizeX = 6f,
              SixeY = 3f,
              SizeZ = 1f;
        GameObject spawnedObject = Instantiate(FireField, attackPoint.position + new Vector3(3f, 0f), Quaternion.identity);
        spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
        spawnedObject.GetComponent<FireFieldScirpt>().player = this.GetComponent<PlayerMainController>();
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position + new Vector3(10f, 0f), new Vector2(5f, 10f), 0f, enemyLayers);

        BoxCollider2D boxCollider = spawnedObject.AddComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        GameObject playerObject = GameObject.Find("Player");
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemyCollider in hitEnemies)
            {
                Debug.Log(enemyCollider.gameObject.transform.position.x);
                enemyCollider.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
            }
            
        }
        
        Destroy(spawnedObject, 7f);
    }
    public void FireSkill4()
    {
        Fire2Sword = true;
        AllSkillFire[3].ReCurrentCooldonw();
        BuffDamage = AttackDamage * 0.35f;
        float BuffDuration = 12f;
        GetBuff(BuffDamage, BuffDuration);
        Invoke("StopFire2Sword", 10);
    }
    public void FireSkill5()
    {
        AllSkillFire[4].ReCurrentCooldonw();
        ActionDamage = TotalDamage * 20f;
        AttackElement = "Fire";
        SkillStatus = "Inferno";
        SkillStatusStack = 3;
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(5, 5), 0f, enemyLayers);

        float nearestDistance = float.MaxValue;
        Collider2D nearestEnemy = null;

        foreach (Collider2D enemy in hitEnemies)
        {
            float distance = Vector2.Distance(this.transform.position, enemy.gameObject.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            // Do something with the nearest enemy
            Debug.Log("Nearest enemy found: " + nearestEnemy.gameObject.name);
        }


        this.transform.position = nearestEnemy.gameObject.transform.position;

        Invoke("PlayerReposition", 0.75f);
        nearestEnemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);

    }
    //Water ====================================================================================================================================
    public void WaterSkill1()
    {
        AllSkillWater[0].ReCurrentCooldonw();

        ActionDamage = TotalDamage * 1.2f;
        SkillAttackRange = PlayerAttackRange + 1f;
        AttackElement = "Water";
        SkillStatus = "Wet";
        SkillStatusStack = 1;
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, SkillAttackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }
    public void WaterSkill2()
    {
        AllSkillWater[1].ReCurrentCooldonw();
        BuffAttackSpeed = AttackSpeed * 1f;
        BuffDamage = AttackDamage * -0.1f; // Decrease Attack Dmg
        float BuffDuration = 13f;
        GetBuff(BuffDamage, BuffDuration);
        GetAttackSpeedBuff(BuffAttackSpeed, BuffDuration);
    }

    public void WaterSkill3()
    {
        AllSkillWater[2].ReCurrentCooldonw();
        animator.SetTrigger("Attack");
        GameObject spawnedObject = Instantiate(WaterPillar, attackPoint.position, Quaternion.identity);
        spawnedObject.GetComponent<WaterPillarScript>().player = this.GetComponent<PlayerMainController>();
        Destroy(spawnedObject, 2f);
    }
    public void WaterSkill4()
    {
        AllSkillWater[3].ReCurrentCooldonw();
        Water1Sword = true;
        BuffAttackSpeed = AttackSpeed * 4f;
        float BuffDuration = 10f;
        GetAttackSpeedBuff(BuffAttackSpeed, BuffDuration);
        Invoke("StopWater1Sword", BuffDuration);
    }
    public void WaterSkill5()
    {
        AllSkillWater[4].ReCurrentCooldonw();
        animator.SetTrigger("Attack");
        float SizeX = 3f,
              SixeY = 3f,
              SizeZ = 0;
        GameObject spawnedObject = Instantiate(WaterVortax,new Vector3(attackPoint.position.x, attackPoint.position.y,attackPoint.position.z ), Quaternion.identity);
        spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
        spawnedObject.GetComponent<WaterVortexScript>().player = this.GetComponent<PlayerMainController>();
        Destroy(spawnedObject, 30f);
    }
    //Frost ====================================================================================================================================
    public void FrostSkill1()
    {
        AllSkillFrost[0].ReCurrentCooldonw();
        ActionDamage = TotalDamage * 1;
        SkillAttackRange = PlayerAttackRange + 3f;
        AttackElement = "Frost";
        SkillStatus = "FrostBite";
        SkillStatusStack = Random.Range(1,3);
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, SkillAttackRange + 3f, enemyLayers);
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
            }
        }
    }
    public void FrostSkill2()
    {
        AllSkillFrost[1].ReCurrentCooldonw();
        BuffAttackSpeed = AttackSpeed * 0.25f;
        BuffDamage = AttackDamage * 0.5f; 
        float BuffDuration = 12f;
        Frost1Sword = true;
        GetBuff(BuffDamage, BuffDuration);
        GetAttackSpeedBuff(BuffAttackSpeed, BuffDuration);
        Invoke("StopFrost1Sword", BuffDuration);
    }
    public void FrostSkill3()
    {
        AllSkillFrost[2].ReCurrentCooldonw();
        animator.SetTrigger("Attack");
        GameObject spawnedObject = Instantiate(FrostStrike, attackPoint.position, Quaternion.identity);
        spawnedObject.GetComponent<FrostStrikeScript>().player = this.GetComponent<PlayerMainController>();
        Destroy(spawnedObject, 2f);
    }
    public void FrostSkill4() 
    {
        AllSkillFrost[3].ReCurrentCooldonw();
        animator.SetTrigger("Attack");
        float SizeX = 5f,
              SixeY = 5f,
              SizeZ = 0;
        
        GameObject spawnedObject = Instantiate(FrostAura, new Vector3(attackPoint.position.x, attackPoint.position.y, attackPoint.position.z), Quaternion.identity);
        spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
        spawnedObject.GetComponent<FrostAuraScript>().player = this.GetComponent<PlayerMainController>();
        Destroy(spawnedObject, 15f);
    }
    public void FrostSkill5()
    {
        AllSkillFrost[4].ReCurrentCooldonw();
        animator.SetTrigger("Attack");
        float SizeX = 0.05f,
              SixeY = 0.05f,
              SizeZ = 0;
        GameObject spawnedObject = Instantiate(FrostCystral, attackPoint.position, Quaternion.identity);
        spawnedObject.GetComponent<Transform>().localScale = new Vector3(SizeX, SixeY, SizeZ);
        spawnedObject.GetComponent<FrostCystralScript>().player = this.GetComponent<PlayerMainController>();
        Destroy(spawnedObject, 5f);
    }
    //Earth ====================================================================================================================================

    public void EarthPowerPassive(float InEarthPowerStack)
    {
        EarthEnergyStack += InEarthPowerStack;
    }
    public void EarthSkill1()
    {
        AllSkillEarths[0].ReCurrentCooldonw();
        Invoke("EarthSkill1Active", 1f);
        
    }
    public void EarthSkill1Active()
    {
        EarthPowerPassive(5);
        animator.SetTrigger("Attack");
        GameObject spawnedObject = Instantiate(StoneSword, attackPoint.position, Quaternion.identity);
        spawnedObject.GetComponent<StoneSwordScript>().player = this.GetComponent<PlayerMainController>();
        Destroy(spawnedObject, 5f);
    }
    public void EarthSkill2() 
    {
        Earth1Sword = true;
        AllSkillEarths[1].ReCurrentCooldonw();
        BuffDamage = AttackDamage * 0.1f;
        float BuffDuration = 10f;
        GetBuff(BuffDamage, BuffDuration);
        GettakedamagereductionMultiplier(0.2f, BuffDuration);
        Invoke("StopEarth1Sword", BuffDuration);
    }
    public void EarthSkill3() 
    {
        AllSkillEarths[2].ReCurrentCooldonw();
        Invoke("EarthSkill3Active", 3f);
        BuffDamage = AttackDamage * 0.1f;
        float BuffDuration = 10f;
        GetBuff(BuffDamage, BuffDuration);
        GettakedamagereductionMultiplier(0.2f, BuffDuration);
    }

    public void EarthSkill3Active() 
    {
        EarthPowerPassive(5);
        ActionDamage = TotalDamage * 7f;
        AttackElement = "";
        SkillStatus = "";
        SkillStatusStack = 0;
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position + new Vector3(5f, 0f), new Vector2(10f, 20f), 0f, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }
    public void EarthSkill4()
    {
        Earth4Sword = true;
        AllSkillEarths[3].ReCurrentCooldonw();
        BuffDamage = AttackDamage * 0.25f;
        float BuffDuration = 10f;
        currentHp += MaxHp * 0.3f;
        GetBuff(BuffDamage, BuffDuration);
        GettakedamagereductionMultiplier(0.4f, BuffDuration);
        Invoke("StopEarth4Sword", BuffDuration);
    }
    public void EarthSkill5() 
    {
        AllSkillEarths[4].ReCurrentCooldonw();
        Invoke("EarthSkill5Active", 6f);
        BuffDamage = AttackDamage * 0.25f;
        float BuffDuration = 5f;
        currentHp += MaxHp * 0.15f;
        GetBuff(BuffDamage, BuffDuration);
        GettakedamagereductionMultiplier(0.4f, BuffDuration);
    }
    public void EarthSkill5Active()
    {
        EarthPowerPassive(10);
        ActionDamage = TotalDamage * 15f;
        AttackElement = "";
        SkillStatus = "";
        SkillStatusStack = 0;
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position + new Vector3(5f, 0f), new Vector2(10f, 5f), 0f, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyMainSystem>().TakeDamage(ActionDamage, AttackDamage, SkillStatus, SkillStatusStack, AttackElement);
        }
    }




    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) 
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, PlayerAttackRange);
        Gizmos.DrawWireSphere(attackPoint.position, SkillAttackRange);
    }
}
