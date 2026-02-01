using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.Rendering;
using System.Collections.Generic;
using System;

public class gameManager : MonoBehaviour
{

    public int numOfDiceToSpawn;
    public GameObject dicePrefab;

    [HideInInspector]
    public int numDiceCanPlay;

    [HideInInspector]
    public List<GameObject> dices = new List<GameObject>();
    public List<GameObject> dicePlayed = new List<GameObject>();

    public Transform spawnPos;


    private GameObject Mask;

    private GameObject Enemy;

    private int lastMaskNum;

    private void Awake()
    {

        for (int i = 0; i < numOfDiceToSpawn; i++)
        {
            GameObject _dice = Instantiate(dicePrefab);
            _dice.SetActive(false);
            dices.Add(_dice);
        }

    }




    void Start()
    {
        lastMaskNum = -1;
        Mask = GameObject.Find("Mask");
        Enemy = GameObject.Find("Enemy");


    }

    // Update is called once per frame
    void Update()
    {

        if (lastMaskNum!= Mask.GetComponent<Mask>().GetListSize())
        {
            lastMaskNum = Mask.GetComponent<Mask>().GetListSize();
            int ownedMasks = Mask.GetComponent<Mask>().GetListSize();
            
            
            for(int i=0; i<ownedMasks; i++)
            {
                dices[i].SetActive(true);
                dices[i].transform.position = spawnPos.position;
            }

        }


    }
}
