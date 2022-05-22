using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {

    private Animator lightAnimator;
    private bool isLightChange = false;
    private float worldTime = 0;

    [SerializeField] private float changeLightTime;
    [SerializeField] EnemySpawn enemySpawn;

    private void Awake()
    {
        lightAnimator = GetComponent<Animator>();
    }

    public void Updated()
    {
        worldTime += Time.deltaTime;

        if (worldTime > changeLightTime)
            WorldTime();
    }

    public void IsNight()
    {
        if (DataController.isGameClear != true || DataController.isDie != true)
        {
            DataController.isNight = true;
            Debug.Log("현재 밤");
            enemySpawn.ChangeState(Wave.NightWave);
        }
    }

    public void IsMorning()
    {
        if (DataController.isGameClear != true || DataController.isDie != true)
        {
            DataController.isNight = false;
            Debug.Log("아침");
            enemySpawn.ChangeState(Wave.MorningWave);
        }
    }

    public void IsWait()
    {
        if (DataController.isGameClear != true || DataController.isDie != true)
        {
            enemySpawn.ChangeState(Wave.WaitWave);
        }
    }

    public void WorldTime()
    {
        isLightChange = !isLightChange;
        lightAnimator.SetBool("IsLight", isLightChange);
        worldTime = 0;
    }

}
