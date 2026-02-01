using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PickCards : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Image[] masks;
    [SerializeField] private TextMeshProUGUI[] maskDescriptions;
    
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] descriptions;

    [SerializeField] private Mask maskScript;

    private List<string> _maskOptions = new List<string>();


    private Dice _dice;

    private void Start()
    {
        _dice = FindAnyObjectByType<Dice>();
        //RollCards();
    }
    
    
    // CALL THIS FROM A DIFFERENT SCRIPT TO ROLL THE MASKS
    public void RollCards()
    {
        _dice.CanRoll = false;
        background.SetActive(true);
        
        _maskOptions.Clear();
        
        for (int i = 0; i < masks.Length; i++)
        {
            int roll = Random.Range(0, 4);
            
            print(roll);
            
            switch (roll)
            {
                case 0:
                    _maskOptions.Add("White");
                    break;
                case 1:
                    _maskOptions.Add("Odd");
                    break;
                case 2:
                    _maskOptions.Add("Even");
                    break;
                case 3:
                    _maskOptions.Add("Gojo");
                    break;
            }
            masks[i].sprite = sprites[roll];
            maskDescriptions[i].text = descriptions[roll];
        }
    }

    public void PickCard(int i)
    {
        _dice.CanRoll = true;
        maskScript.AddNewMask(_maskOptions[i]);
        background.SetActive(false);
    }
}
