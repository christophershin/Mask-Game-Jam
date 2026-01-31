using UnityEngine;
using TMPro;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI DiceValueText;
    public GameObject dice;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DiceValueText.text = dice.GetComponent<Dice>().diceNumber.ToString();
    }
}
