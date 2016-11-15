using UnityEngine;
using System.Collections;

public class DebugMenu : MonoBehaviour
{
    LevelManager lm;
    HeroManager hm;

    //Shooter
    public GameObject shooter;
    //Guardian
    public GameObject guardian;
    //Aimer
    public GameObject aimer;
    //Mime
    public GameObject mime;
    //Shadow
    public GameObject shadow;
    //Sniper
    public GameObject sniper;
    //Villain
    public GameObject villain;
    //Bullet
    public GameObject bullet;

    //Boss
    public GameObject boss;
    public GameObject boss2;
    public GameObject boss3;

    void Start()
    {
        lm = GameObject.Find("MainCamera").GetComponent<LevelManager>();
        hm = GameObject.Find("NewHero").GetComponent<HeroManager>();
    }

    /// <summary>
    /// DEBUG: Spawns an Enemy enemy at the defined position posY.
    /// </summary>
    /// <param name="enemy">Enemy to spawn</param>
    /// <param name="posY">Where to spawn within SPAWN_RANGE. Define between 0 and 1</param>
    public void DebugSpawnEnemy(GameObject enemy, float posY)
    {
        Instantiate(enemy, new Vector3(10.0f, (posY * StaticsConfig.SPAWN_RANGE_Y) - StaticsConfig.SPAWN_RANGE_Y / 2, 0), Quaternion.identity);
    }

    /// <summary>
    /// DEBUG: Set current level to a.
    /// </summary>
    /// <param name="a">Define current level</param>
    public void DebugSetLevel(int a)
    {
        lm.SetLevel(a);
    }

    public void DebugSkipLevel()
    {
        lm.IncrementLevel();
    }


    public void DebugRestartRound()
    {
        lm.Restart();
    }

    public void DebugKillAllEnemies()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Bullet");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Villain");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Shooter");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Guardian");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    public void DebugInvincibilityToggle()
    {
        //TODO
    }

    public void DebugRefillHP()
    {
        hm.SetHp(hm.GetMaxHp());
    }

}
