using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text moneyText;
    [SerializeField] private float playTime;
    [SerializeField] private Text playerTimeText;
    [SerializeField] private Text killScoreText;
    [SerializeField] private Text dayCountText;
    [SerializeField] private GameObject clearText;

    [SerializeField] GameObject resultPanel;
    [SerializeField] private Text resultDistanceText;
    [SerializeField] private Text resultKillScoreText;
    [SerializeField] private GameObject player;
    [SerializeField] private Slider playerHpBar;
    [SerializeField] private Text playerHpText;

    private float timer = 2.0f;
  
	void Awake () {
        timer = 2.0f;
        resultPanel.SetActive(false);
        moneyText.text = "" + DataController.money;
        killScoreText.text = "" + DataController.killScore;
        dayCountText.text = "DAY " + DataController.dayCount;
    }

	public void Update () {
        if (DataController.dayCount > 3)
            clearText.SetActive(true);

        if (DataController.isGameClear != true)
        {
            if (DataController.isDie != true)
            {
                moneyText.text = "" + DataController.money;
                KillScoreUpdate();
                PlayTimeUpdate();
                DayCount();
                PlayerHpBarUpdate();
            }
            else
            {
                OnDie();
                ResultText();
            }
        }
    }

    void KillScoreUpdate()
    {
        killScoreText.text = "" + DataController.killScore;
    }

    void ResultText()
    {
        resultKillScoreText.text = "" + DataController.killScore;
    }

    void PlayTimeUpdate()
    {
        playTime += Time.deltaTime;

        playerTimeText.text = string.Format("{0}{1:D}{2}{3:D}{4}", "플레이시간 : ", (int)playTime / 60, "분 ", (int)playTime % 60, "초");
    }

    void DayCount()
    {
        if (DataController.dayCount < 3)
            dayCountText.text = "DAY " + DataController.dayCount;
        else
            dayCountText.text = "LAST DAY";
    }

    public void DayAnimationPlay()
    {   
        Animator animator = dayCountText.GetComponent<Animator>();
        animator.SetTrigger("DayStart");
    }

    void PlayerHpBarUpdate()
    {
        playerHpBar.maxValue = player.GetComponent<PlayerStat>().MaxHp;
        playerHpBar.value = player.GetComponent<PlayerStat>().CurrentHp;
        playerHpText.text = playerHpBar.value + " / " + playerHpBar.maxValue;
    }

    void OnDie()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            resultPanel.SetActive(true);
        }
    }
}
