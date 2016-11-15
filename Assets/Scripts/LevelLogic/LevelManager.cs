using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{



    //SpawnRange
    float spawnRangeY = StaticsConfig.SPAWN_RANGE_Y;

    //Shooter
    public GameObject shooter;
    float timeS;
    float shooterRate;

    //Guardian
    public GameObject guardian;
    float timeG;
    float guardianRate;

    //Aimer
    public GameObject aimer;
    float timeA;
    float aimerRate;

    //Mime
    public GameObject mime;
    float timeM;
    float mimeRate;

    //Shadow
    public GameObject shadow;
    float timeSha;
    float shadowRate;

    //Sniper
    public GameObject sniper;
    float timeSni;
    float sniperRate;

    //Villain
    public GameObject villain;
    float timeV;
    float villainRate;

    //Bullet
    public GameObject bullet;
    float timeB;
    float bulletRate;


    //Boss
    public GameObject boss;
    public GameObject boss2;
    public GameObject boss3;
    bool bossSpawned;
    bool boss2Spawned;
    bool boss3Spawned;
    bool boss4Spawned;
    bool boss5Spawned;


    //Routine
    float timeR;

    //Pooling
    int amountPooled = 10;
    List<GameObject> villains;
    List<GameObject> shooters;
    List<GameObject> guardians;
    List<GameObject> bullets;
    List<GameObject> aimers;
    List<GameObject> mimes;
    List<GameObject> shadows;
    List<GameObject> snipers;

    //ScoreTracking
    ScoreTracking tracker;
    int currentLevel;
    int threshold;

    //MusicManager
    MusicManager am;

    // Use this for initialization
    void Start()
    {
        Transform enemies = GameObject.Find("Enemies").transform;
        villains = new List<GameObject>();
        shooters = new List<GameObject>();
        guardians = new List<GameObject>();
        bullets = new List<GameObject>();
        aimers = new List<GameObject>();
        mimes = new List<GameObject>();
        shadows = new List<GameObject>();
        snipers = new List<GameObject>();

        //initialize pools
        for (int i = 0; i < amountPooled; i++)
        {

            GameObject obj = (GameObject)Instantiate(villain);
            obj.transform.parent = enemies;
            obj.SetActive(false);
            villains.Add(obj);

            GameObject obj2 = (GameObject)Instantiate(shooter);
            obj2.transform.parent = enemies;
            obj2.SetActive(false);
            shooters.Add(obj2);

            GameObject obj3 = (GameObject)Instantiate(guardian);
            obj3.transform.parent = enemies;
            obj3.SetActive(false);
            guardians.Add(obj3);

            GameObject obj4 = (GameObject)Instantiate(bullet);
            obj4.transform.parent = enemies;
            obj4.SetActive(false);
            bullets.Add(obj4);

            GameObject obj5 = (GameObject)Instantiate(aimer);
            obj5.transform.parent = enemies;
            obj5.SetActive(false);
            aimers.Add(obj5);

            GameObject obj6 = (GameObject)Instantiate(mime);
            obj6.transform.parent = enemies;
            obj6.SetActive(false);
            mimes.Add(obj6);

            GameObject obj7 = (GameObject)Instantiate(shadow);
            obj7.transform.parent = enemies;
            obj7.SetActive(false);
            shadows.Add(obj7);

            GameObject obj8 = (GameObject)Instantiate(sniper);
            obj8.transform.parent = enemies;
            obj8.SetActive(false);
            snipers.Add(obj8);
        }


        GameObject tmp = GameObject.FindGameObjectWithTag("MainCamera");
        tracker = tmp.GetComponent<ScoreTracking>();
        am = tmp.GetComponent<MusicManager>();

        currentLevel = 1;
        threshold = 2;

        bossSpawned = false;
        boss2Spawned = false;
        boss3Spawned = false;


        StateManager.PauseGame();

    }



    // Update is called once per frame
    void Update()
    {

        IntervallSpawnAll();
        ManageLevels();
        //DEBUG
        if (Input.GetKeyDown("q"))
        {
            IncrementLevel();
        }
        if (Input.GetKeyDown("o") || Input.GetKeyDown(KeyCode.Escape))
        {

            StateManager.PauseGame();
        }

    }

    void ManageLevels()
    {
        int killCount = tracker.getCurrentKillCount();
        if (killCount >= threshold)
        {
            currentLevel++;
            //threshold = threshold + currentLevel + 1;
            if (currentLevel > 0 && currentLevel <= 5)
            {
                threshold = 5;
            }
            if (currentLevel > 5 && currentLevel <= 10)
            {
                threshold = 7;
            }
            if (currentLevel > 10 && currentLevel <= 20)
            {
                threshold = 10;
            }
            if (currentLevel > 20 && currentLevel <= 40)
            {
                threshold = 20;
            }
            if (currentLevel > 40 && currentLevel <= 60)
            {
                threshold = 30;
            }
            tracker.setThreshold(threshold);
        }


        switch (currentLevel)
        {
            case 1:
                villainRate = 2;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);

                am.playTrack(1);

                break;

            case 2:
                villainRate = 1.5f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 3:
                villainRate = 1.6f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 2;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 4:
                villainRate = 1.5f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 2;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 5:
                villainRate = 1.4f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 1.8f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 6:
                villainRate = 1.4f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 1.7f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 7:
                villainRate = 1.3f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 1.6f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 8:
                villainRate = 1.2f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 1.5f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 9:
                villainRate = 1.1f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 1.5f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 10:
                villainRate = 1.5f;
                shooterRate = 3.0f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 11:
                villainRate = 1.5f;
                shooterRate = 2.8f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 12:
                villainRate = 1.4f;
                shooterRate = 2.7f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 13:
                villainRate = 1.3f;
                shooterRate = 2.7f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 14:
                villainRate = 1.3f;
                shooterRate = 2.5f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 15:
                villainRate = 1.2f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 3.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 16:
                villainRate = 1;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 3.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 17:
                villainRate = 1.4f;
                shooterRate = 2;
                guardianRate = 0;
                bulletRate = 3.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 18:
                villainRate = 1.2f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 1;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 19:
                villainRate = 1.4f;
                shooterRate = 2.7f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 20:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                //bossTime
                am.playTrack(666);
                SpawnBoss(boss);


                tracker.setLevel(currentLevel);
                break;

            case 21:
                villainRate = 2f;
                shooterRate = 3f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);

                am.playTrack(2);
                break;

            case 22:
                villainRate = 1.5f;
                shooterRate = 2.5f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 23:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 24:
                villainRate = 1.4f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 2;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 25:
                villainRate = 1.2f;
                shooterRate = 2.5f;
                guardianRate = 0;
                bulletRate = 4;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 26:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 3;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 27:
                villainRate = 3;
                shooterRate = 2.4f;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 28:
                villainRate = 1.5f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 2;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            case 29:
                villainRate = 1;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                tracker.setLevel(currentLevel);
                break;

            //30-39 not balanced


            case 30:
                villainRate = 0;
                shooterRate = 2;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 2;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;


                tracker.setLevel(currentLevel);
                break;


            case 31:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 32:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 3;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;


                tracker.setLevel(currentLevel);
                break;
            case 33:
                villainRate = 1.7f;
                shooterRate = 4f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 34:
                villainRate = 0;
                shooterRate = 3f;
                guardianRate = 0;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;


                tracker.setLevel(currentLevel);
                break;
            case 35:
                villainRate = 0;
                shooterRate = 4f;
                guardianRate = 0;
                bulletRate = 2.0f;
                aimerRate = 4;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;


                tracker.setLevel(currentLevel);
                break;
            case 36:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 37:
                villainRate = 1.7f;
                shooterRate = 4;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 38:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 1.5f;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 39:
                villainRate = 0;
                shooterRate = 3f;
                guardianRate = 4;
                bulletRate = 0;
                aimerRate = 4;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;

            case 40:

                villainRate = 0.0f;
                shooterRate = 0.0f;
                guardianRate = 0.0f;
                bulletRate = 0.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                //bossTime
                SpawnBoss(boss2);
                am.playTrack(666);

                tracker.setLevel(currentLevel);
                break;

            case 41:
                villainRate = 1.5f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                am.playTrack(1);
                tracker.setLevel(currentLevel);
                break;
            case 42:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 3;


                tracker.setLevel(currentLevel);
                break;
            case 43:
                villainRate = 1.7f;
                shooterRate = 4f;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 3;

                tracker.setLevel(currentLevel);
                break;
            case 44:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 3;

                tracker.setLevel(currentLevel);
                break;
            case 45:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 46:
                villainRate = 0;
                shooterRate = 3f;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 4;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 47:
                villainRate = 0;
                shooterRate = 4;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 3;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 4;

                tracker.setLevel(currentLevel);
                break;
            case 48:
                villainRate = 0;
                shooterRate = 3f;
                guardianRate = 0;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 4;

                tracker.setLevel(currentLevel);
                break;
            case 49:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 50:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 1.6f;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 51:
                villainRate = 1.7f;
                shooterRate = 4f;
                guardianRate = 0;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 2;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 52:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 3;
                shadowRate = 2;
                mimeRate = 0;
                sniperRate = 3;

                tracker.setLevel(currentLevel);
                break;
            case 53:
                villainRate = 1.7f;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 2;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 54:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 2.0f;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 55:
                villainRate = 0;
                shooterRate = 4f;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 3;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;

                tracker.setLevel(currentLevel);
                break;
            case 56:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 2;
                mimeRate = 0;
                sniperRate = 3;

                tracker.setLevel(currentLevel);
                break;
            case 57:
                villainRate = 3;
                shooterRate = 0;
                guardianRate = 2;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 4;

                tracker.setLevel(currentLevel);
                break;
            case 58:
                villainRate = 1.7f;
                shooterRate = 4f;
                guardianRate = 2;
                bulletRate = 3.0f;
                aimerRate = 3;
                shadowRate = 4;
                mimeRate = 0;
                sniperRate = 3.4f;

                tracker.setLevel(currentLevel);
                break;
            case 59:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 2.4f;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 3;
                mimeRate = 0;
                sniperRate = 4;

                tracker.setLevel(currentLevel);
                break;
            case 60:
                villainRate = 0;
                shooterRate = 0;
                guardianRate = 0;
                bulletRate = 0;
                aimerRate = 0;
                shadowRate = 0;
                mimeRate = 0;
                sniperRate = 0;
                am.playTrack(666);
                SpawnBoss(boss3);

                tracker.setLevel(currentLevel);
                break;

        }





    }

    public void Spawn(List<GameObject> list, float y)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {

                list[i].transform.position = new Vector3(10.0f, (y * spawnRangeY) - spawnRangeY / 2, 0.0f);
                list[i].transform.rotation = Quaternion.identity;
                list[i].SetActive(true);
                break;
            }
        }
    }

    void IntervallSpawnAll()
    {
        IntervallSpawnVillain();
        IntervallSpawnShooter();
        IntervallSpawnGuardian();
        IntervallSpawnBullets();
        IntervallSpawnAimers();
        IntervallSpawnShadows();
        IntervallSpawnMimes();
        IntervallSpawnSnipers();
    }

    void IntervallSpawnVillain()
    {
        if (villainRate != 0.0f)
        {

            timeV += Time.deltaTime;
            if (timeV >= villainRate)
            {

                Spawn(villains, Random.Range(0.0f, 1.0f));
                timeV = 0.0f;
            }
        }

    }

    void IntervallSpawnShooter()
    {
        if (shooterRate != 0.0f)
        {
            timeS += Time.deltaTime;
            if (timeS >= shooterRate)
            {

                Spawn(shooters, Random.Range(0.0f, 1.0f));
                timeS = 0.0f;
            }
        }

    }

    void IntervallSpawnGuardian()
    {
        if (guardianRate != 0.0f)
        {
            timeG += Time.deltaTime;
            if (timeG >= guardianRate)
            {

                Spawn(guardians, Random.Range(0.0f, 1.0f));
                timeG = 0.0f;
            }
        }
    }

    void IntervallSpawnBullets()
    {
        if (bulletRate != 0.0f)
        {
            timeB += Time.deltaTime;
            if (timeB >= bulletRate)
            {

                Spawn(bullets, Random.Range(0.0f, 1.0f));
                timeB = 0.0f;
            }
        }
    }

    void IntervallSpawnAimers()
    {
        if (aimerRate != 0.0f)
        {
            timeA += Time.deltaTime;
            if (timeA >= aimerRate)
            {

                Spawn(aimers, Random.Range(0.0f, 1.0f));
                timeA = 0.0f;
            }
        }
    }

    void IntervallSpawnMimes()
    {
        if (mimeRate != 0.0f)
        {
            timeM += Time.deltaTime;
            if (timeM >= mimeRate)
            {

                Spawn(mimes, Random.Range(0.0f, 1.0f));
                timeM = 0.0f;
            }
        }
    }

    void IntervallSpawnShadows()
    {
        if (shadowRate != 0.0f)
        {
            timeSha += Time.deltaTime;
            if (timeSha >= shadowRate)
            {

                Spawn(shadows, Random.Range(0.0f, 1.0f));
                timeSha = 0.0f;
            }
        }
    }

    void IntervallSpawnSnipers()
    {
        if (sniperRate != 0.0f)
        {
            timeSni += Time.deltaTime;
            if (timeSni >= sniperRate)
            {

                Spawn(snipers, Random.Range(0.0f, 1.0f));
                timeSni = 0.0f;
            }
        }
    }

    void DisableAllX(string target)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(target);
        for (var i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }

    public void Restart()
    {

        currentLevel = 1;
        threshold = 2;

        bossSpawned = false;
        boss2Spawned = false;
        boss3Spawned = false;
        tracker.Restart();

    }

    public void SetLevel(int a)
    {
        currentLevel = a;
    }

    public void IncrementLevel()
    {
        currentLevel++;
        //threshold = currentLevel + 1;
        if (currentLevel > 0 && currentLevel <= 5)
        {
            threshold = 5;
        }
        if (currentLevel > 5 && currentLevel <= 10)
        {
            threshold = 7;
        }
        if (currentLevel > 10 && currentLevel <= 20)
        {
            threshold = 10;
        }
        if (currentLevel > 20 && currentLevel <= 40)
        {
            threshold = 20;
        }
        if (currentLevel > 40 && currentLevel <= 60)
        {
            threshold = 30;
        }
        tracker.setThreshold(threshold);
    }

    void SpawnBoss(GameObject boss)
    {

        switch (boss.name)
        {
            case "Boss":
                if (!bossSpawned)
                {
                    DisableAllX("Bullet");
                    DisableAllX("Villain");
                    DisableAllX("Shooter");
                    DisableAllX("Guardian");
                    Instantiate(boss, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
                    bossSpawned = true;
                }
                break;
            case "Boss2":
                if (!boss2Spawned)
                {
                    DisableAllX("Bullet");
                    DisableAllX("Villain");
                    DisableAllX("Shooter");
                    DisableAllX("Guardian");
                    Instantiate(boss, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
                    boss2Spawned = true;
                }
                break;
            case "Boss3":
                if (!boss3Spawned)
                {
                    DisableAllX("Bullet");
                    DisableAllX("Villain");
                    DisableAllX("Shooter");
                    DisableAllX("Guardian");
                    Instantiate(boss, new Vector3(6.72f, 0.0f, 0.0f), Quaternion.identity);
                    boss3Spawned = true;
                }
                break;
            case "Boss4":
                if (!boss4Spawned)
                {
                    DisableAllX("Bullet");
                    DisableAllX("Villain");
                    DisableAllX("Shooter");
                    DisableAllX("Guardian");
                    Instantiate(boss, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
                    boss4Spawned = true;
                }
                break;
            case "Boss5":
                if (!boss5Spawned)
                {
                    DisableAllX("Bullet");
                    DisableAllX("Villain");
                    DisableAllX("Shooter");
                    DisableAllX("Guardian");
                    Instantiate(boss, new Vector3(10.0f, 0.0f, 0.0f), Quaternion.identity);
                    boss5Spawned = true;
                }
                break;

        }


    }

    public void SpawnAtPosition(List<GameObject> list, float x, float y)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {

                list[i].transform.position = new Vector3(x, y, 0.0f);
                list[i].transform.rotation = Quaternion.identity;
                list[i].SetActive(true);
                break;
            }
        }
    }
}
