using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemSkills
{
    public class SkillsManager : MonoBehaviour
    {
        public static SkillsManager instance;
        public GameObject arrowPrefab;
        public int numberOfArrows = 5;
        public float arrowFallSpeed = 5f;
        public Transform heroTransform; 
        public GameObject summonPrefab; 
        public int numberOfSummons = 2;
        public float SpawnDistance = 2f;
        public AxeAttack axePrefab; 
        public float axeRadius = 5f; // Радиус, в котором появляются топоры
        private List<AxeAttack> _axes = new List<AxeAttack>();
        
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
                    SpawnArrows();
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
            for (int i = 0; i < 2; i++)
            {
                int numSpheres = 2;
                float totalAngle = 360f;

                // Вычисляем угол для равномерного распределения сфер вокруг героя
                float angle = totalAngle * (((float) _axes.Count + 1) / numSpheres);
                float spawnAngle = angle * Mathf.Deg2Rad;
                float radius = 8f; // Расстояние от героя до сферы

                // Вычисляем положение сферы в полярных координатах
                float spawnX = Mathf.Cos(spawnAngle) * radius;
                float spawnZ = Mathf.Sin(spawnAngle) * radius;

                Vector3 spawnPosition = heroTransform.position + new Vector3(spawnX, 0, spawnZ);

                var axe = Instantiate(axePrefab, spawnPosition, Quaternion.Euler(0,0, -90));
                axe.BaseAngle = spawnAngle; 
                _axes.Add(axe);
            }
        }
        
        private void SpawnArrows()
        {
            // Создаем заданное количество стрел.
            for (int i = 0; i < numberOfArrows; i++)
            {
                // Создаем префаб стрелы.
                GameObject arrow = Instantiate(arrowPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            }
        }

        private Vector3 GetRandomSpawnPosition()
        {
            // Генерируем случайную позицию в пределах экрана (высота = 10, ширина = 10, для примера).
            float randomX = Random.Range(-5f, 5f);
            float randomZ = Random.Range(-5f, 5f);

            return new Vector3(randomX, 10f, randomZ);
        }
    }
}