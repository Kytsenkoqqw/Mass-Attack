using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemSkills
{
    public class SkillsManager : MonoBehaviour
    {
        public static SkillsManager instance;
        public Transform heroTransform; 
        public GameObject summonPrefab; 
        public int numberOfSummons = 2;
        public float SpawnDistance = 2f;
        public GameObject axePrefab; 
        public float axeRadius = 5f; // Радиус, в котором появляются топоры
        public float BaseAngle;
        
        private float _angle = 0.0f;
        private float _currentAngle = 0.0f;    
        
        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        
        private void Start()
        {
            // Проверка наличия необходимых компонентов и объектов
            if (heroTransform == null)
            {
                Debug.LogError("Hero Transform not assigned!");
                return;
            }

            if (summonPrefab == null)
            {
                Debug.LogError("Summon Prefab not assigned!");
                return;
            }
        }

        public void GetSkill(ItemSpell spell)
        {
            switch (spell)
            {
                case ItemSpell.Bow:
                    break;
                case ItemSpell.Axe:
                    SpawnAxes();
                    Debug.Log("Work!!!");
                    break;
                case ItemSpell.Ring:
                    break;
                case ItemSpell.Potion:
                    break;
                case ItemSpell.BookOfTheDead:
                    SummonCreatures();
                    break;
                case ItemSpell.Staff:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spell), spell, null);
            }
        }

        private void SummonCreatures()
        {
            // Цикл для создания заданного количества саммонов
            for (int i = 0; i < numberOfSummons; i++)
            {
                // Вычисление позиции для саммона с учетом дистанции от героя
                Vector3 summonPosition = heroTransform.position + new Vector3(i * SpawnDistance, 0, 0);

                // Создание саммона в вычисленной позиции
                GameObject summon = Instantiate(summonPrefab, summonPosition, Quaternion.identity);
            }
        }
        
        private void SpawnAxes()
        {
            int numberOfAxes = 2; // Количество топоров
            float angleStep = 180.0f / (numberOfAxes - 1); // Шаг угла между топорами

            for (int i = 0; i < numberOfAxes; i++)
            {
                float angle = i * angleStep; // Вычисляем угол для текущего топора
                float angleInRadians = angle * Mathf.Deg2Rad; // Переводим угол из градусов в радианы

                // Вычисляем координаты для текущего топора вокруг героя
                float x = heroTransform.position.x + Mathf.Cos(angleInRadians) * axeRadius;
                float z = heroTransform.position.z + Mathf.Sin(angleInRadians) * axeRadius;

                // Создаем топор
                GameObject axe = Instantiate(axePrefab, new Vector3(x, heroTransform.position.y, z),
                    Quaternion.identity);

                // Поворачиваем топор на 90 градусов
                axe.transform.Rotate(Vector3.up, 90f);
            }
        }
    }
}