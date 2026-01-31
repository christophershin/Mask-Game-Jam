using System.Collections.Generic;
using NUnit.Framework.Internal;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{


    bool rolled = false;
    bool grabbed = false;
    Vector2 offset;
    public int diceNumber;

    public int minDiceValue = 1;
    public int maxDiceValue = 6;

    public List<Sprite> DiceImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        // Dice
        if(rolled)
        {
            diceNumber = Random.Range(minDiceValue, maxDiceValue + 1);
            Debug.Log(diceNumber);
            GetComponent<SpriteRenderer>().sprite = DiceImage[diceNumber-1];

            rolled = false;
        }


        if (Input.GetMouseButton(0))
        {
            if (rolled == false)
            {
                Debug.Log("grabbed");
                grabbed = true;
                transform.Rotate(new Vector3(0, 0, 35));
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            if (grabbed == true && rolled == false)
            {
                Debug.Log("not grabbed");
                grabbed = false;
                rolled = true;
            }
        }
    }


    private void OnMouse()
    {

    }

    private void OnMouseUp()
    {


    }
}
