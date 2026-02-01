using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Random = UnityEngine.Random;

public class Damage : MonoBehaviour
{
    // Current Enemy
    private int _currentEnemy;
    private int _currentHealth;
    private int _currentTurns;
    
    // Enemy Infos Reference
    [SerializeField] private Sprite[] enemySprite;
    [SerializeField] private string[] enemyNames;
    [SerializeField] private int[] enemyHealth;
    [SerializeField] private int[] playerTurns;
    
    // Actual Enemy Info
    private List<Sprite> _enemySpritesInOrder = new List<Sprite>();
    private List<string> _enemyNamesInOrder =  new List<string>();
    
    // Current Enemy Info
    [SerializeField] private TextMeshProUGUI currentEnemyName;
    [SerializeField] private Image currentEnemyImage;
    [SerializeField] private TextMeshProUGUI currentEnemyHealthText;
    [SerializeField] private TextMeshProUGUI currentPlayerTurnsText;
    
    // Other scripts
    [SerializeField] private Mask mask;
    [SerializeField] private PickCards pickCards;
    
    // Important
    private int _previousDamage;
    private bool _firstMask = true;

    private void Start()
    {
        
        List<int> pool = new List<int>();

        for (int i = 0; i < 9; i++)
        {
            pool.Add(i);
        }
        
        // Enemies 1-4
        for (int i = 0; i < 4; i++)
        {
            int roll = roll = DrawRandom(pool);
            
            print(roll.ToString());
            
            _enemySpritesInOrder.Add(enemySprite[roll]);
            _enemyNamesInOrder.Add(enemyNames[roll]);
        }
        
        // Final Boss
        _enemySpritesInOrder.Add(enemySprite[9]);
        _enemyNamesInOrder.Add(enemyNames[9]);
        
        _currentEnemy = 0;
        _currentTurns = playerTurns[_currentEnemy];
        _currentHealth = enemyHealth[_currentEnemy];
        currentEnemyName.text = _enemyNamesInOrder[_currentEnemy];
        currentEnemyImage.sprite = _enemySpritesInOrder[_currentEnemy];
        currentEnemyHealthText.text = _currentHealth.ToString();
        currentPlayerTurnsText.text = "Turns Left: " + _currentTurns.ToString();
    }
    
    // randomn range kept drawing the same enemies again so i used this
    private int DrawRandom(List<int> pool)
    {
        if (pool.Count == 0)
        {
            Debug.LogError("Pool is empty!");
            return -1;
        }

        int index = Random.Range(0, pool.Count);
        int value = pool[index];

        pool.RemoveAt(index); 

        return value;
    }



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
                    damage *= 5;
                    break;
                case "Broken":
                    int brokenMaskDmg = Random.Range(0, 15);
                    damage += brokenMaskDmg;
                    break;
                case "Devil":
                    int devilMask = Random.Range(0, 2);
                    if (devilMask == 0)
                    {
                        damage *= 3;
                    }
                    else
                    {
                        damage = damage / 2;
                    }
                    break;
                case "Oops":
                    break;
                case "Pie":
                    break;
                case "Sleep":
                    damage += _previousDamage / 2;
                    break;
                case "Snake":
                    break;
                case "Theatre":
                    if (_firstMask)
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage += 2;
                    }
                    break;
                case "Welding":
                    if (diceNumber < 3)
                    {
                        damage *= 3;
                    }
                    break;
            }
        }
        
        _currentHealth -= damage;
        currentEnemyHealthText.text = _currentHealth.ToString();
        currentPlayerTurnsText.text = "Turns Left: " + _currentTurns.ToString();

        _previousDamage = damage;
        
        if (_currentHealth <= 0)
        {
            NextEnemy();
            return;
        }
        
        _currentTurns -= 1;

        if (_currentTurns <= 0)
        {
            GameOver();
            return;
        }
    }

    private void NextEnemy()
    {
        if (_currentEnemy == 4)
        {
            EndGame();
            return;
        }
        
        pickCards.RollCards();
        
        _currentEnemy += 1;
        _currentTurns = playerTurns[_currentEnemy];
        _currentHealth = enemyHealth[_currentEnemy];
        currentEnemyName.text = _enemyNamesInOrder[_currentEnemy];
        currentEnemyImage.sprite = _enemySpritesInOrder[_currentEnemy];
        currentEnemyHealthText.text = _currentHealth.ToString();
        currentPlayerTurnsText.text = "Turns Left: " + _currentTurns.ToString();
    }

    private void GameOver()
    {
        SceneManager.LoadScene("Scenes/You Lose");
    }

    private void EndGame()
    {
        SceneManager.LoadScene("Scenes/You Win");
    }


    public int currentEnemy()
    {
        return _currentEnemy;
    }

    public int getEnemyHealth()
    {

        int health = _currentHealth;

        return health;
    }
}
