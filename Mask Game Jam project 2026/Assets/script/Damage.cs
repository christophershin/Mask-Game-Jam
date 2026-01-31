using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Mask mask;
    
    public void DamageEnemy(int diceNumber)
    {
        int damage = diceNumber;
        switch (mask.GetCurrentMask())
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
        print("Did " + damage + " Damage");
    }
}
