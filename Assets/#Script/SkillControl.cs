using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour {

    [SerializeField] private KeyCode buyItemButton;
    [SerializeField] private 
     
	void Update () {

        if (Input.GetKeyDown(buyItemButton))
            ClickButton();
    }

    void ClickButton()
    {
        switch(buyItemButton)
        {
            case KeyCode.Alpha6:
                Debug.Log("6번");
                break;

            case KeyCode.Alpha7:
                Debug.Log("7번");
                break;
        }
    }

    public void SlowSkill()
    {

    }

    public void StunSkill()
    {

    }

    public void BounceSkill()
    {

    }

    public void UpgradeCastle()
    {

    }

    public void AllKillSkill()
    {

    }

}
