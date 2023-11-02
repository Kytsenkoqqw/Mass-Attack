using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon.UI
{
    public class WeaponCard : MonoBehaviour

    {
        [SerializeField] private WeaponType _type;
        [SerializeField] private TMP_Text _damage;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _button;

        public void Init(WeaponType type, float damage, int level, Sprite icon, Action onClick )
        {
            _type = type;
            _damage.SetText(damage.ToString());
            _level.SetText(level.ToString());
            _icon.sprite = icon;
            _button.onClick.AddListener(()=>onClick?.Invoke());
            _button.interactable = false;
        }

        private void OnEnable()
        {
            StartCoroutine(DelayMenuLevel());
        }

        IEnumerator DelayMenuLevel()
        {
            Debug.Log("StartDelay");
            yield return  new WaitForSecondsRealtime(1f);
            Debug.Log("EndDelay");
            _button.interactable = true;
        }
    }
}