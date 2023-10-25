using System;
using UnityEngine;
using UnityEngine.UI;

namespace Weapon.UI
{
    public class WeaponIcon : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        public void Init(Sprite icon)
        {
            _icon.sprite = icon;
        }
    }
}