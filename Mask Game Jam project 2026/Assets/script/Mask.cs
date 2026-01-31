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
        _ownedMasks.Add("Odd");
        _ownedMasks.Add("Even");
        _ownedMasks.Add("Gojo");
    }

    void Update()
    {
        for (int i = 0; i < _ownedMasks.Count; i++)
        {
            switch (_ownedMasks[i])
            {
                case "White":
                    print("AAA");
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
}
