using System;
using UnityEngine;

namespace ItemSkills
{
    public class SkillsManager : MonoBehaviour
    {
        public static SkillsManager instance;
        public Transform heroTransform; // Перетащите сюда Transform героя в инспекторе Unity
        public GameObject summonPrefab; // Префаб саммона
        public int numberOfSummons = 2;
        public float SpawnDistance = 2f;

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

                // Дополнительные настройки или действия с саммоном, если необходимо
                // Например, можно добавить компоненты, управляющие поведением саммона и т.д.
            }
        }
    }
    
    
}