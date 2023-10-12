using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, ILevelSystem
{
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int ExperienceToNextLevel { get; private set; } = 100;
    private Enemy currentEnemy;
    public event Action <int> OnChangeXp;
    public static PlayerCharacter instance;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    public void AddExperience(int experience)
    {
        Experience += experience;
        if (Experience >= ExperienceToNextLevel)
        {
            IncreaseLevel();
        }
        OnChangeXp?.Invoke(Experience);
    }

    void Update()
    {
        Debug.Log(  "Текущий Уровень" + Level + " " + "Текущий опыт" + Experience);
    }

    public void IncreaseLevel()
    {
        Level++;
        Experience -= ExperienceToNextLevel;
        ExperienceToNextLevel = CalculateExperienceRequiredForNextLevel(Level);
    }

    private int CalculateExperienceRequiredForNextLevel(int level)
    {
        return 100 + (level - 1) * 50; // Пример
    }
}
