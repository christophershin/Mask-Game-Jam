using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PickCards : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Image[] masks;
    [SerializeField] private TextMeshProUGUI[] maskDescriptions;
    
    private Sprite[] sprites;
    private string[] descriptions;

    [SerializeField] private Mask maskScript;


    [SerializeField] private gameManager GameManager;

    private List<string> _maskOptions = new List<string>();


    //private Dice _dice;

    private void Start()
    {
        sprites = maskScript.GetAllSprites();
        descriptions = maskScript.GetAllDescriptions();

        //_dice = FindAnyObjectByType<Dice>();
        //RollCards();
    }
    
    
    // CALL THIS FROM A DIFFERENT SCRIPT TO ROLL THE MASKS
    public void RollCards()
    {
        //_dice.CanRoll = false;
        SetRollState(false);


        background.SetActive(true);
        
        _maskOptions.Clear();
        
        for (int i = 0; i < masks.Length; i++)
        {
            int roll = Random.Range(0, 12);
            
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
                case 4:
                    _maskOptions.Add("Broken");
                    break;
                case 5:
                    _maskOptions.Add("Devil");
                    break;
                case 6:
                    _maskOptions.Add("Oops");
                    break;
                case 7:
                    _maskOptions.Add("Pie");
                    break;
                case 8:
                    _maskOptions.Add("Sleep");
                    break;
                case 9:
                    _maskOptions.Add("Snake");
                    break;
                case 10:
                    _maskOptions.Add("Theatre");
                    break;
                case 11:
                    _maskOptions.Add("Welding");
                    break;
            }
            masks[i].sprite = sprites[roll];
            maskDescriptions[i].text = descriptions[roll];
        }
    }

    public void PickCard(int i)
    {
        //_dice.CanRoll = true;
        SetRollState(true);
        maskScript.AddNewMask(_maskOptions[i]);
        background.SetActive(false);
    }


    public void SetRollState(bool state)
    {
        for(int i=0; i<GameManager.dices.Count; i++)
        {
            GameManager.dices[i].GetComponent<Dice>().CanRoll = state;
        }
    }
}
