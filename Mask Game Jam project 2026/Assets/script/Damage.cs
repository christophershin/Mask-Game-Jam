using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Mask mask;
    
    public void DamageEnemy(int diceNumber)
    {
        int damage = diceNumber;
        List<string> currentMasks = mask.GetCurrentMasks();

        for (int i = 0; i < currentMasks.Count; i++)
        {
            switch (currentMasks[i])
            {
                case "White":
                    damage += 2;
                    break;
                case "Odd":
                    if (damage % 2 != 0) damage += 2;
                    break;
                case "Even":
                    if (damage % 2 == 0) damage += 2;
                    break;
                case "Gojo":
                    damage *= 100;
                    break;
            }
        }
        
        
        print("Did " + damage + " Damage");
    }
}
