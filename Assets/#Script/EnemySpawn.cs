using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Wave
{
   WaitWave , MorningWave , NightWave
}

public class EnemySpawn : MonoBehaviour {

    [SerializeField] UIController uiController;
    [SerializeField] private Wave wave = Wave.MorningWave;
    [SerializeField] private Transform spawnPoint;

    [Header("적 종류")]
    [SerializeField] private GameObject[] morningEnemys;
    [SerializeField] private GameObject[] nightEnemys;

    [Header("적 생성 시간")]
    [SerializeField] private float[] morningEnemySpwanTime;
    [SerializeField] private float[] nightEnemySpawnTime;

    [Header("적 생성 시간 단계")]
    [SerializeField] private int morningTimeIndex;
    [SerializeField] private int nightTimeIndex;

    [Header("적 종류 번호")]
    [SerializeField] private int morningEnemyIndex;
    [SerializeField] private int nightEnemyIndex;

    [Header("밤낮 바뀔때 대기시간")]
    [SerializeField] private float waitingTime = 0;
    private bool isWait = false;

    void Awake ()
    {
        ChangeState(wave);
	}
	
	void Update () {
	}

    public void ChangeState(Wave changeWave)
    {
        StopCoroutine(wave.ToString());
        wave = changeWave;
        StartCoroutine(wave.ToString());
    }
    IEnumerator WaitWave()
    {
        Debug.Log("대기중");
        yield break;
    }

    IEnumerator MorningWave()
    {
        isWait = false;

        DataController.dayCount++;
        if (DataController.dayCount <= 3)
            uiController.DayAnimationPlay();

        else
        {
            DataController.isGameClear = true;
            yield break;
        }

        while (true)
        {
            if (DataController.isDie )
                yield break;

            if (isWait != true) // 대기시간 ( 밤낮 바뀔때 )
            {
                yield return new WaitForSeconds(waitingTime);
                isWait = true;
            }

            //if (DataController.isNight != false)
            //{
            //    ChangeState(Wave.NightWave);
            //}
            morningEnemyIndex = Random.Range(0, morningEnemys.Length);
            MorningWaveEnemy(morningEnemyIndex);
            yield return new WaitForSeconds(morningEnemySpwanTime[morningTimeIndex - 1]);
        }
    }

    IEnumerator NightWave()
    {
        isWait = false;

        while (true)
        {
            if (DataController.isDie)
                yield break;

            if (isWait != true) // 대기시간 ( 밤낮 바뀔때 )
            {
                yield return new WaitForSeconds(waitingTime);
                isWait = true;
            }

            //if (DataController.isNight != false)
            //{
            //    ChangeState(Wave.MorningWave);
            //}
            nightEnemyIndex = Random.Range(0, nightEnemys.Length);
            NightWaveEnemy(nightEnemyIndex);
            yield return new WaitForSeconds(nightEnemySpawnTime[nightTimeIndex - 1]);
        }
    }

    void MorningWaveEnemy(int index)
    {
        GameObject clone = Instantiate(morningEnemys[index]);
        clone.transform.position = spawnPoint.position;
    }

    void NightWaveEnemy(int index)
    {
        GameObject clone = Instantiate(nightEnemys[nightEnemyIndex]);
        clone.transform.position = spawnPoint.position;
    }
}
