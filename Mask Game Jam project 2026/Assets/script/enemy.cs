using UnityEngine;
using TMPro;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    public int maxHealth;
    private int health;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = health.ToString();


        





        if(health<=0)
        {
            health = 0;
        }



    }
}
