using Assets.Scripts.Configurations;
using Assets.Scripts.Enums;
using Assets.Scripts.InputSystem.Interface;
using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.InputSystem.Implementation
{
    public class SwitchWeaponsByButtons : MonoBehaviour, IWeaponSystem, ISwitchWeaponNotifier
    {
        [SerializeField]
        private Button _pistolBtn;

        [SerializeField]
        private Button _shotgunBtn;

        [SerializeField]
        private Image _pistolImage;

        [SerializeField]
        private Image _shotgunImage;

        public event Action<Weapon> Switch;

        private List<Weapon> _weapons;
        public Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;

        [Inject]
        public void Construct(WeaponsConfiguration weaponsConfig)
        {
            var weaponsConfigList = weaponsConfig.weapons;

            _weapons = new List<Weapon>(weaponsConfig.weapons.Count);

            foreach (var weapon in weaponsConfigList)
            {
                _weapons.Add(new Weapon(weapon));
            }
            _currentWeapon = _weapons[0];
        }

        private void Start()
        {
            InitView(WeaponTypes.Pistol, _pistolImage, _pistolBtn);
            InitView(WeaponTypes.Shotgun, _shotgunImage, _shotgunBtn);
        }

        private void InitView(WeaponTypes type, Image image, Button button)
        {
            var weapon = GetWeaponByType(type);
            image.sprite = weapon.WeaponImage;
            button.onClick.AddListener(() => { Switch?.Invoke(weapon); });
        }

        private Weapon GetWeaponByType(WeaponTypes type)
        {
            return _weapons.Find(w => w.Type == type);
        }

    }
}
