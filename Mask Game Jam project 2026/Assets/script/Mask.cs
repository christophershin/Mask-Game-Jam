using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mask : MonoBehaviour
{
    [SerializeField] private Image maskImage;
    [SerializeField] private TextMeshProUGUI maskDescription;
    
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private string[] descriptions;

    private List<string> _ownedMasks = new List<string>();
    private string _currentMask;

    void Start()
    {
        _ownedMasks.Add("White");
        _ownedMasks.Add("Odd");
        _ownedMasks.Add("Even");
        _ownedMasks.Add("Gojo");
        UpdateMask();
    }

    public void AddNewMask(string mask)
    {
        _ownedMasks.Add(mask);
    }

    public string GetCurrentMask()
    {
        return _currentMask;
    }

    public void NextMask()
    {
        if (_ownedMasks.Count <= 1) return;
        
        string tempMask = _ownedMasks[0];
        _ownedMasks.RemoveAt(0);
        _ownedMasks.Add(tempMask);
        UpdateMask();
        
    }

    public void PreviousMask()
    {
        if (_ownedMasks.Count <= 1) return;
        string tempMask = _ownedMasks[_ownedMasks.Count - 1];
        _ownedMasks.RemoveAt(_ownedMasks.Count - 1);
        _ownedMasks.Insert(0, tempMask);
        UpdateMask();
    }
    
    private void UpdateMask()
    {
        _currentMask = _ownedMasks[0];
        switch (_currentMask)
        {
            case "White":
                maskImage.sprite = sprites[0];
                maskDescription.text = descriptions[0];
                break;
            case "Odd":
                maskImage.sprite = sprites[1];
                maskDescription.text = descriptions[1];
                break;
            case "Even":
                maskImage.sprite = sprites[2];
                maskDescription.text = descriptions[2];
                break;
            case "Gojo":
                maskImage.sprite = sprites[3];
                maskDescription.text = descriptions[3];
                break;
        }
    }
}
