using UnityEngine;
using TMPro;


public class GameController : MonoBehaviour, IDataPersistance
{
    public int level;
    public double exprequirement; //435e^0.56x
    public double expNow; 
    public double cumulatedexp;
    double PlayerHp;

    public AudioSource ThemeSong;

    bool isCountdowned;
    public int stage = 1;
    [SerializeField]public string period;
    public int remainEnemy;
    public int killed;
    public GameObject EnemySpawner;
    public TMP_Text StageText;
    public LayerMask enemyLayers;
    public Transform PointHitToStopRun;

    public int UnlockLevel;
    public int UnlockperiodNumber; // 1 = carbrian

    public GameObject CambrianBackGround;
    public GameObject OrdovicianBackGround;
    public GameObject SilurianBackGround;



    public GameObject[] CambrianStagelockPanel;
    public GameObject[] OrdovicianStagelockPanel;
    public GameObject[] SilurianStagelockPanel;

    GameObject Player;


    public void LoadData(GameData data)
    {
        Debug.Log(data.UnlockLevel.ToString());
        UnlockLevel = data.UnlockLevel;
        level = data.level;
    }

    public void SaveData(ref GameData data) 
    {
        data.UnlockLevel = UnlockLevel;
        data.level = level;
    }

    private void Start()
    {
        if (period == null) 
        {
            period = "Cambrian";
        }
        isCountdowned = false;
        Player = GameObject.Find("Player");
       
        ThemeSong.Play();
        cumulatedexp = 0;
        killed = 0;
        //UnlockLevel = 11; // period = Unlock / 10 stage = Unlock %10 
        UnlockperiodNumber = UnlockLevel / 10;
        remainEnemy = 0;
        AutoChangeStage();
    }

    public void AutoChangeStage()
    {
        if (UnlockLevel == 11) CambrianStage1();
        if (UnlockLevel == 12) CambrianStage2();
        if (UnlockLevel == 13) CambrianStage3();
        if (UnlockLevel == 14) CambrianStage4();
        if (UnlockLevel == 15) CambrianStage5();
        if (UnlockLevel == 16) CambrianStage6();
        if (UnlockLevel == 17) CambrianStage7();
        if (UnlockLevel == 18) CambrianStage8();
        if (UnlockLevel == 19) CambrianStage9();
        if (UnlockLevel == 20) CambrianStage10();
        if (UnlockLevel == 21) OrdovicianStage1();
        if (UnlockLevel == 22) OrdovicianStage2();
        if (UnlockLevel == 23) OrdovicianStage3();
        if (UnlockLevel == 24) OrdovicianStage4();
        if (UnlockLevel == 25) OrdovicianStage5();
        if (UnlockLevel == 26) OrdovicianStage6();
        if (UnlockLevel == 27) OrdovicianStage7();
        if (UnlockLevel == 28) OrdovicianStage8();
        if (UnlockLevel == 29) OrdovicianStage9();
        if (UnlockLevel == 30) OrdovicianStage10();
        if (UnlockLevel == 31) SilurianStage1();
        if (UnlockLevel == 32) SilurianStage2();
        if (UnlockLevel == 33) SilurianStage3();
        if (UnlockLevel == 34) SilurianStage4();
        if (UnlockLevel == 35) SilurianStage5();
        if (UnlockLevel == 36) SilurianStage6();
        if (UnlockLevel == 37) SilurianStage7();
        if (UnlockLevel == 38) SilurianStage8();
        if (UnlockLevel == 39) SilurianStage9();
        if (UnlockLevel == 40) SilurianStage10();
    }
    public string IntToRoman(int num)
    {
        string[] romanNumerals = new string[]
        {
            "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X"
        };

        if (num >= 1 && num <= 10)
        {
            return romanNumerals[num];
        }
        else
        {
            Debug.LogError("Number out of range. Cannot convert to Roman numeral.");
            return "";
        }
    }

    public GameObject[] Parallax;
    public bool ParallaxisRunning;

    public void GetExp(double exp) 
    {
        expNow += exp;
    }

    public void ResetPLayerHp() 
    {
        Player.GetComponent<PlayerMainController>().currentHp = Player.GetComponent<PlayerMainController>().MaxHp;
    } 

    public void Update()
    {
        period = EnemySpawner.GetComponent<IteeSpawner>().period;
        if (period == "Cambrian")
        {
            CambrianBackGround.SetActive(true);
            OrdovicianBackGround.SetActive(false);
            SilurianBackGround.SetActive(false);
        }
        if (period == "Ordovician") 
        {
            CambrianBackGround.SetActive(false);
            OrdovicianBackGround.SetActive(true);
            SilurianBackGround.SetActive(false);
        }
        if (period == "Silurian") 
        {
            CambrianBackGround.SetActive(false);
            OrdovicianBackGround.SetActive(false);
            SilurianBackGround.SetActive(true);
        }



        Collider2D[] RemainEnemiesCheckCircle = Physics2D.OverlapCircleAll(this.transform.position, 999f, enemyLayers);
        remainEnemy = RemainEnemiesCheckCircle.Length;

        PlayerHp = Player.GetComponent<PlayerMainController>().currentHp;

        if (PlayerHp <= 0) 
        {
            EnemySpawner.GetComponent<IteeSpawner>().Fade.GetComponent<FadeInOut>().FadeIn();
            EnemySpawner.GetComponent<IteeSpawner>().ResetStage();
            ResetPLayerHp();
        }
        if (level == 1) exprequirement = 400;
        if(level != 1) exprequirement = 435 * Mathf.Exp(0.56f * level);
        if (expNow >= exprequirement) 
        {
            level++;
            expNow = expNow - exprequirement;
        }


        for (int i = 11; i <= UnlockLevel && i < 21; i++) 
        {
            int x = i - 11;
            CambrianStagelockPanel[x].SetActive(false);
        }
        for (int i = 21; i <= UnlockLevel && i< 31; i++) 
        {
            int x = i - 21;
            OrdovicianStagelockPanel[x].SetActive(false);
        }
        for (int i = 31; i <= UnlockLevel && i < 41; i++)
        {
            int x = i - 31;
            SilurianStagelockPanel[x].SetActive(false);
        }


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PointHitToStopRun.position, 1f, enemyLayers);
        string text = period + " Stage " + IntToRoman(stage);
        StageText.text = text;
        if (hitEnemies.Length == 0) 
        {
            for(int i = 0; i <= Parallax.Length - 1; i++) 
            {
                Parallax[i].GetComponent<Parallax>().ParallaxRunning = true;
                ParallaxisRunning = true;
            }
            
        }
            
        else 
        {
            for (int i = 0; i <= Parallax.Length - 1; i++)
            {
                Parallax[i].GetComponent<Parallax>().ParallaxRunning = false;
                ParallaxisRunning = false;
            }
        }
    }

    public void killIncrease() 
    {
        killed++;
    }

    public void DecreaseEnemyToZero() 
    { 
        remainEnemy  = 0; 
    }
    // Cambrian ---------------------------------------------------------------------------------------------
    public void CambrianStage1() { if (UnlockLevel >= 11) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 1); stage = 1; }
    public void CambrianStage2() { if (UnlockLevel >= 12) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 2); stage = 2; }
    public void CambrianStage3() { if (UnlockLevel >= 13) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 3); stage = 3; }
    public void CambrianStage4() { if (UnlockLevel >= 14) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 4); stage = 4; }
    public void CambrianStage5() { if (UnlockLevel >= 15) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 5); stage = 5; }
    public void CambrianStage6() { if (UnlockLevel >= 16) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 6); stage = 6; }
    public void CambrianStage7() { if (UnlockLevel >= 17) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 7); stage = 7; }
    public void CambrianStage8() { if (UnlockLevel >= 18) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 8); stage = 8; }
    public void CambrianStage9() { if (UnlockLevel >= 19) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 9); stage = 9; }
    public void CambrianStage10() { if (UnlockLevel >= 20) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Cambrian", 10); stage = 10; }

    //Ordovician ---------------------------------------------------------------------------------------------
    public void OrdovicianStage1() { if (UnlockLevel >= 21) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 1); stage = 1; }
    public void OrdovicianStage2() { if (UnlockLevel >= 22) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 2); stage = 2; }
    public void OrdovicianStage3() { if (UnlockLevel >= 23) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 3); stage = 3; }
    public void OrdovicianStage4() { if (UnlockLevel >= 24) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 4); stage = 4; }
    public void OrdovicianStage5() { if (UnlockLevel >= 25) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 5); stage = 5; }
    public void OrdovicianStage6() { if (UnlockLevel >= 26) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 6); stage = 6; }
    public void OrdovicianStage7() { if (UnlockLevel >= 27) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 7); stage = 7; }
    public void OrdovicianStage8() { if (UnlockLevel >= 28) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 8); stage = 8; }
    public void OrdovicianStage9() { if (UnlockLevel >= 29) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 9); stage = 9; }
    public void OrdovicianStage10() { if (UnlockLevel >= 30) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Ordovician", 10); stage = 10; }

    //Silurian -----------------------------------------------------------------------------------------------
    public void SilurianStage1() { if (UnlockLevel >= 21) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 1); stage = 1; }
    public void SilurianStage2() { if (UnlockLevel >= 22) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 2); stage = 2; }
    public void SilurianStage3() { if (UnlockLevel >= 23) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 3); stage = 3; }
    public void SilurianStage4() { if (UnlockLevel >= 24) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 4); stage = 4; }
    public void SilurianStage5() { if (UnlockLevel >= 25) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 5); stage = 5; }
    public void SilurianStage6() { if (UnlockLevel >= 26) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 6); stage = 6; }
    public void SilurianStage7() { if (UnlockLevel >= 27) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 7); stage = 7; }
    public void SilurianStage8() { if (UnlockLevel >= 28) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 8); stage = 8; }
    public void SilurianStage9() { if (UnlockLevel >= 29) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 9); stage = 9; }
    public void SilurianStage10() { if (UnlockLevel >= 30) EnemySpawner.GetComponent<IteeSpawner>().ChangeStage("Silurian", 10); stage = 10; }
}

