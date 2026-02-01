using System.Collections.Generic;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public bool CanRoll = true;

    bool rolled = false;
    bool grabbed = false;
    Vector2 offset;
    [HideInInspector]
    public int diceNumber;

    public int minDiceValue = 1;
    public int maxDiceValue = 6;

    public List<Sprite> DiceImage;
    public Damage damage;
    Ray ray;
    RaycastHit hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = FindAnyObjectByType<Damage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRoll == false) return;
        Vector3 mousePos = Input.mousePosition;


        if(rolled)
        {
            diceNumber = Random.Range(minDiceValue, maxDiceValue + 1);
            Debug.Log(diceNumber);
            GetComponent<SpriteRenderer>().sprite = DiceImage[diceNumber-1];
            
            damage.DamageEnemy(diceNumber);
            
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

        if (Input.GetMouseButtonUp(0))
        {
            if (grabbed == true && rolled == false)
            {
                Debug.Log("not grabbed");
                grabbed = false;
                rolled = true;
            }
        }


        //pickUpDice();



    }


    private void pickUpDice()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        RaycastHit hit; // Variable to store information about the hit

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            if(grabbed)
            {
                hit.collider.gameObject.transform.position = mousePos;
            }



        }
    }

}
