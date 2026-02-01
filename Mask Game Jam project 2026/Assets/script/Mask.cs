using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mask : MonoBehaviour
{
    [SerializeField] private Image[] maskImages;
    [SerializeField] private TextMeshProUGUI[] maskDescriptions;
    
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] descriptions;
    
    private List<string> _ownedMasks = new List<string>();

    private void Start()
    {
        _ownedMasks.Add("White");
        // _ownedMasks.Add("Odd");
        // _ownedMasks.Add("Even");
        // _ownedMasks.Add("Gojo");
    }

    public Sprite[] GetAllSprites()
    {
        return sprites;
    }

    public string[] GetAllDescriptions()
    {
        return descriptions;
    }

    void Update()
    {
        for (int i = 0; i < _ownedMasks.Count; i++)
        {
            switch (_ownedMasks[i])
            {
                case "White":
                    maskImages[i].sprite = sprites[0];
                    maskDescriptions[i].text = descriptions[0];
                    break;
                case "Odd":
                    maskImages[i].sprite = sprites[1];
                    maskDescriptions[i].text = descriptions[1];
                    break;
                case "Even":
                    maskImages[i].sprite = sprites[2];
                    maskDescriptions[i].text = descriptions[2];
                    break;
                case "Gojo":
                    maskImages[i].sprite = sprites[3];
                    maskDescriptions[i].text = descriptions[3];
                    break;
                case "Broken":
                    maskImages[i].sprite = sprites[4];
                    maskDescriptions[i].text = descriptions[4];
                    break;
                case "Devil":
                    maskImages[i].sprite = sprites[5];
                    maskDescriptions[i].text = descriptions[5];
                    break;
                case "Oops":
                    maskImages[i].sprite = sprites[6];
                    maskDescriptions[i].text = descriptions[6];
                    break;
                case "Pie":
                    maskImages[i].sprite = sprites[7];
                    maskDescriptions[i].text = descriptions[7];
                    break;
                case "Sleep":
                    maskImages[i].sprite = sprites[8];
                    maskDescriptions[i].text = descriptions[8];
                    break;
                case "Snake":
                    maskImages[i].sprite = sprites[9];
                    maskDescriptions[i].text = descriptions[9];
                    break;
                case "Theatre":
                    maskImages[i].sprite = sprites[10];
                    maskDescriptions[i].text = descriptions[10];
                    break;
                case "Welding":
                    maskImages[i].sprite = sprites[11];
                    maskDescriptions[i].text = descriptions[11];
                    break;
                
            }
        }
    }

    public void AddNewMask(string mask)
    {
        _ownedMasks.Add(mask);
    }

    public List<string> GetCurrentMasks()
    {
        return _ownedMasks;
    }


    public int GetListSize()
    {
        int count = _ownedMasks.Count;

        return count;
    }
}
