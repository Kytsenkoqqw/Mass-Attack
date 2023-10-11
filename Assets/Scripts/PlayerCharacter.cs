using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, ILevelSystem
{
    public int CurrentLevel {  get { return currentLevel; }  }
    public int CurrentExperience { get { return currentExperience; } }
    private int currentLevel;
    private int currentExperience;
    private int experienceToNextLevel = 100;
    private Enemy currentEnemy;
    
    public void AddExperience(int experience)
    {
        currentExperience += experience;
        if (currentExperience >= experienceToNextLevel)
        {
            IncreaseLevel();
        }
    }

    void Update()
    {
        Debug.Log(  "Текущий Уровень" + CurrentLevel + " " + "Текущий опыт" + CurrentExperience);
    }

    public void IncreaseLevel()
    {
        currentLevel++;
        currentExperience -= experienceToNextLevel;
        experienceToNextLevel = CalculateExperienceRequiredForNextLevel(currentLevel);
    }

    private int CalculateExperienceRequiredForNextLevel(int level)
    {
        return 100 + (level - 1) * 50; // Пример
    }
}
