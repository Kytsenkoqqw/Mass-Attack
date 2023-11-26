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
        public float rotationSpeed = 180f; // Скорость вращения топоров
        public float axeRadius = 5f; // Радиус, в котором появляются топоры
        public float axeDuration = 5f;
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

        private void Update()
        {
            RotateAxe();
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
            // Цикл для создания топоров
            for (int i = 0; i < 360; i += 45) // Используем шаг 45 градусов для создания восьми топоров вокруг героя
            {
                // Вычисление позиции для топора вокруг героя
                float angle = i * Mathf.Deg2Rad;
                Vector3 summonPosition = heroTransform.position + new Vector3(Mathf.Cos(angle) * axeRadius, 0, Mathf.Sin(angle) * axeRadius);

                // Создание топора в вычисленной позиции с начальной ориентацией
                GameObject axe = Instantiate(axePrefab, summonPosition, Quaternion.identity);
            }
        }
        
        private void RotateAxe()
        {
            _angle += rotationSpeed * Time.deltaTime;

            // Вычисляем новую позицию сферы вокруг героя.
            float x = heroTransform.position.x + Mathf.Cos(_angle + BaseAngle) * axeRadius;
            float z = heroTransform.position.z + Mathf.Sin(_angle + BaseAngle) * axeRadius;

            // Устанавливаем новую позицию сферы.
            transform.position = new Vector3(x, transform.position.y, z);
            
        }

        private IEnumerator DestroyAxe()
        {
            RotateAxe();
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
}