using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateType
{
    None , Ice , Swoon
}
public class EnemyState : MonoBehaviour {

    [SerializeField] private EnemyStateType chnage;
    [SerializeField] private EnemyStateType enemyStateType = EnemyStateType.None;
    [Header("지속시간")]
    [SerializeField] private float freezeTime = 0;
    [SerializeField] private float slowSpeed;
    [SerializeField] private float swoonTime = 0;

    [Header("스킬 색깔")]
    [SerializeField] private Color freezeColor;
    [SerializeField] private Color swoonColor;
    [SerializeField] private Color baseColor;

    private float baseSpeed;
    private Movement movement;
    private SpriteRenderer spriteRenderer;

    void Awake () {
        movement = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseSpeed = movement.Speed;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ChangeState(chnage);
        }
    }

    public void ChangeState(EnemyStateType changeState)
    {
        StopCoroutine(enemyStateType.ToString());
        enemyStateType = changeState;
        StartCoroutine(enemyStateType.ToString());
    }

    IEnumerator None()
    {
        spriteRenderer.color = baseColor;
        movement.Speed = baseSpeed;
        yield break;
    }

    IEnumerator Ice()
    {
        movement.Speed = slowSpeed;
        spriteRenderer.color = freezeColor;
        yield return new WaitForSeconds(freezeTime);
        ChangeState(EnemyStateType.None);
    }

    IEnumerator Swoon()
    {
        movement.Speed = 0;
        spriteRenderer.color = swoonColor;
        yield return new WaitForSeconds(swoonTime);
        ChangeState(EnemyStateType.None);
    }

}
