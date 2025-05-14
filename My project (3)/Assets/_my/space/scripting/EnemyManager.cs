using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject[] enemyLinUp = new GameObject[6];
    List<List<GameObject>> fleetList;
    int numColumn = 7;

    float enemyMoveTimer = 1;
    float stepDealay = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnFleet()
    {
        fleetList = new List<List<GameObject>>();

        for(int i = 0; i <numColumn; i++)
        {
            List<GameObject> column = new List<GameObject>();

            for (int j = 0; j < enemyLinUp.Length; j++)
            {
                GameObject enemy = Instantiate(enemyLinUp[j]);
                column.Add(enemy);
                PositionEnemy(enemy, i, j);
            }
            
            fleetList.Add(column);
        }
    }

    private void PositionEnemy(GameObject enemy, int column, int row)
    {
        float offsetX = 1;
        float offsetY = 1;

        float startX = transform.position.x + (-offsetX * (float)numColumn / 2);
        float startY = transform.position.y + (-offsetY * 9);

        float posX = startX + (float) column * offsetX;
        float posY = startY + (float) row * offsetY;

        enemy.transform.position = new Vector2 (posX, posY);
    }

    private bool IsEnemyMoveTime()
    {
        bool resurt = false;

        enemyMoveTimer -= Time.deltaTime;
        if (enemyMoveTimer > 0)
        {
            resurt = true;
        }

        return resurt;
    }
    private void MoveFleet(Vector2 direction, float distance)
    {
        for(int i = 0; i < fleetList.Count; i++)
        {
            List<GameObject> column = fleetList[i];

            for (int j = 0; j < column.Count; j++)
            {
                GameObject ememy = column[j];
                if (!Enemy.activeInHierarchy)
                {
                    continue;
                }


                enemy.GetComponent<Enemy>().EnemyMove(direction, distance);
            }

        }

        enemyMoveTimer = stepDealay;
    }
}


