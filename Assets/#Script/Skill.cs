using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType { Ice , Swoon }

public class Skill : MonoBehaviour {

    [SerializeField] private SkillType skillType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy" && skillType == SkillType.Ice)
            col.transform.GetComponent<EnemyState>().ChangeState(EnemyStateType.Ice);

        if (col.transform.tag == "Enemy" && skillType == SkillType.Swoon)
            col.transform.GetComponent<EnemyState>().ChangeState(EnemyStateType.Swoon);
    }
}
