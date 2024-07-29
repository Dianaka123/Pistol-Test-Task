using Assets.Scripts.Configurations;
using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.InputSystem.Implementation
{
    public class SwitchWeaponByOneImageSystem : MonoBehaviour, IPointerClickHandler, IWeaponSystem
    {
        [SerializeField]
        private Image _weaponImage;

        public event Action<Weapon> Switch;

        private List<Weapon> _weapons;
        public Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;

        [Inject]
        public void Construct(WeaponsConfiguration weaponsConfig)
        {
            var weaponsConfigList = weaponsConfig.weapons;

            _weapons = new List<Weapon>(weaponsConfig.weapons.Count);

            foreach(var weapon in weaponsConfigList)
            {
                _weapons.Add(new Weapon(weapon));
            }
            _currentWeapon = _weapons[0];
        }

        private void Update()
        {
            _weaponImage.sprite = _currentWeapon.WeaponImage;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            var nextIndex = _weapons.IndexOf(_currentWeapon) + 1;

            if (nextIndex >= _weapons.Count)
            {
                nextIndex = 0;
            }

            _currentWeapon = _weapons[nextIndex];

            Switch?.Invoke(_currentWeapon);
        }
    }
}
