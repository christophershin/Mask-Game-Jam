using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Damage : MonoBehaviour
{
    // Current Enemy
    private int _currentEnemy;
    private int _currentHealth;
    
    // Enemy Infos
    [SerializeField] private string[] enemyName;
    [SerializeField] private Sprite[] enemySprite;
    [SerializeField] private int[] enemyHealth;
    
    // Current Enemy Info
    [SerializeField] private TextMeshProUGUI currentEnemyName;
    [SerializeField] private Image currentEnemyImage;
    [SerializeField] private TextMeshProUGUI currentEnemyHealthText;
    
    // Other scripts
    [SerializeField] private Mask mask;
    [SerializeField] private PickCards pickCards;

    private void Start()
    {
        _currentEnemy = 0;
        _currentHealth = enemyHealth[_currentEnemy];
        currentEnemyName.text = enemyName[_currentEnemy];
        currentEnemyImage.sprite = enemySprite[_currentEnemy];
        currentEnemyHealthText.text = enemyHealth[_currentEnemy].ToString();
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
                    damage *= 100;
                    break;
            }
        }
        
        _currentHealth -= damage;
        currentEnemyHealthText.text = _currentHealth.ToString();
        
        if (_currentHealth <= 0)
        {
            pickCards.RollCards();
            NextEnemy();
        }
    }

    private void NextEnemy()
    {
        if (_currentEnemy == 9)
        {
            EndGame();
            return;
        }
        
        
        _currentEnemy += 1;
        _currentHealth = enemyHealth[_currentEnemy];
        currentEnemyName.text = enemyName[_currentEnemy];
        currentEnemyImage.sprite = enemySprite[_currentEnemy];
        currentEnemyHealthText.text = enemyHealth[_currentEnemy].ToString();
    }

    private void EndGame()
    {
        print("YOU WIN!!!!");
    }
}
