using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, ILevelSystem
{
    public int Level { get; private set; }
    public int Experience { get; private set; }
    private int experienceToNextLevel = 100;
    private Enemy currentEnemy;
    
    public void AddExperience(int experience)
    {
        Experience += experience;
        if (Experience >= experienceToNextLevel)
        {
            IncreaseLevel();
        }
    }

    void Update()
    {
        Debug.Log(  "Текущий Уровень" + Level + " " + "Текущий опыт" + Experience);
    }

    public void IncreaseLevel()
    {
        Level++;
        Experience -= experienceToNextLevel;
        experienceToNextLevel = CalculateExperienceRequiredForNextLevel(Level);
    }

    private int CalculateExperienceRequiredForNextLevel(int level)
    {
        return 100 + (level - 1) * 50; // Пример
    }
}
