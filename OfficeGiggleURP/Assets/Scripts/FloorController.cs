using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [SerializeField] Transform enemiesParent;
    int happyCount = 0;
    int enemyCount;
    GreyController greyController;
    public bool levelFinished = false;
    float floorPercentage = 0;

    private void Start()
    {
        greyController = GetComponent<GreyController>();
        enemyCount = enemiesParent.childCount;
    }

    private void FixedUpdate()
    {
        greyController.SetTargetValue(1 - FloorClearPercentage());
    }

    float FloorClearPercentage()
    {
        happyCount = 0;
        floorPercentage = 0;

        foreach (Transform en in enemiesParent)
        {
            if (en.GetComponent<Enemy>().happy) happyCount++;
        }

        levelFinished = happyCount >= enemyCount;

        floorPercentage = (float)happyCount / enemyCount;

        return floorPercentage;
    }
}
