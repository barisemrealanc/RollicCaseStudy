using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform collectibleRoot;
    private List<Transform> monsters;
    public List<Vector3> collectibleDefaultPosition;
    // Start is called before the first frame update
    public void Start()
    {
        FindMonsters();
    }

    private void FindMonsters()
    {
        monsters = new List<Transform>();
        collectibleDefaultPosition = new List<Vector3>();
        for(int i=0; i<collectibleRoot.childCount;i++)
        {
            monsters.Add(collectibleRoot.GetChild(i).transform);
            collectibleDefaultPosition.Add(collectibleRoot.GetChild(i).transform.position);
        }
    }

    public void ResetLevel()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            monsters[i].position = collectibleDefaultPosition[i];
            monsters[i].SetParent(transform);
            monsters[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
