using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataController : MonoBehaviour {

    public static int money = 0;
    public static int killScore = 0;
    public static int dayCount = 1;
    public static bool isDie = false;
    public static bool isGameClear = false;
    public static bool isNight = false;

    private void Awake()
    {
        money = 0;
        killScore = 0;
        dayCount = 1;
        isDie = false;
        isNight = false;
        isGameClear = false;
    }
}
