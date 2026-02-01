using System.Collections.Generic;
using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public bool CanRoll = true;

    bool rolled = false;
    bool grabbed = false;

    private GameObject grabbedDiceID;

    [HideInInspector]
    public int diceNumber;

    public int minDiceValue = 1;
    public int maxDiceValue = 6;

    public List<Sprite> DiceImage;
    public Damage damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = FindAnyObjectByType<Damage>();
    }

    // Update is called once per frame
    void Update()
    {

        if (CanRoll == false) return;


        


        // grab dice
        if (Input.GetMouseButton(0))
        {
            pickUpDice();
            MoveDice();
        }

        // drop dice
        if (Input.GetMouseButtonUp(0))
        {
            if (grabbed == true && rolled == false)
            {
                Debug.Log("not grabbed");
                grabbedDiceID = null;
                grabbed = false;
                rolled = true;
            }
        }


        DiceState();



    }


    private void pickUpDice()
    {

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


        if (hit.collider != null && hit.collider.gameObject.CompareTag("Dice"))
        {

            grabbedDiceID = hit.collider.gameObject;
            
            

        }

    }

    private void MoveDice()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;

        

        if (grabbedDiceID)
        {
            Vector3 dir =  mousePosition - grabbedDiceID.transform.position;
            
            grabbedDiceID.transform.position = Vector3.Lerp(grabbedDiceID.transform.position, mousePosition, 0.3f);

            grabbedDiceID.GetComponent<Dice>().grabbed = true;
            
        }
    }



    private void DiceState()
    {

        if (rolled)
        {
            diceNumber = Random.Range(minDiceValue, maxDiceValue + 1);
            Debug.Log(diceNumber);
            GetComponent<SpriteRenderer>().sprite = DiceImage[diceNumber - 1];

            damage.DamageEnemy(diceNumber);

            rolled = false;
        }
        else if(!rolled && grabbed)
        {
            Debug.Log("grabbed");

            transform.Rotate(new Vector3(0, 0, 35));
        }
    }

}
