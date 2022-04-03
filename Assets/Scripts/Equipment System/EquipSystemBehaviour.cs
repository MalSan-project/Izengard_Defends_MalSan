using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipSystem
{
    public enum EquipType 
    {
        Head,
        Shoulderpads,
        Body,
        Arms,
        Legs,
        Worker=20,
        Quiver,        
        ResurseCraft,
        LeftHandMeleeWeapon,
        RightHandMeleeWeapon,
        LeftHandShield,
        Bow
    }   
    public class EquipSystemBehaviour : MonoBehaviour 
    {
        [Header("Slot to equip item")]
        [SerializeField]
        private EquipableItemBase _equipableItem;

        [Header("Slot to Unequip item")]
        [SerializeField]
        private EquipableItemBase _unEquipableItem;
        
        
        private ArmourEquipHolder[] _armourEquipHolders;
        private IWeaponEquipped[] _weaponEquipHolders;
        private WorkerEquipHolder _workerEquipHolder;

        private bool isIsWorker = true;

        public void Awake()
        {
            GetEquipHolders();
        }
        private void GetEquipHolders()
        {
            _armourEquipHolders = gameObject.GetComponentsInChildren<ArmourEquipHolder>();
            _weaponEquipHolders = gameObject.GetComponentsInChildren<IWeaponEquipped>();
            _workerEquipHolder= gameObject.GetComponentInChildren<WorkerEquipHolder>();
        }

        public void GetEquipArmour(IEquippable item)
        {
            UnEquipWorker(isIsWorker);
            isIsWorker = false;
            foreach (ArmourEquipHolder holder in _armourEquipHolders)
            {
                if (item.ItemType == holder.HolderType)
                {
                    holder.GetEquipped(item);
                    break;
                }
            }
        }

        public void GetEquipped(IEquippable item)
        {            
            switch(item.ItemType)
            {
                case  EquipType.Arms:
                    GetEquipArmour(item);
                    break;
                case EquipType.Body:
                    GetEquipArmour(item);
                    break;
                case EquipType.Legs:
                    GetEquipArmour(item);
                    break;
                case EquipType.Shoulderpads:
                    GetEquipArmour(item);
                    break;
                case EquipType.Head:
                    GetEquipArmour(item);
                    break;

                case EquipType.LeftHandMeleeWeapon :
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {
                        if (holder.HolderType==EquipType.LeftHandShield|| holder.HolderType == EquipType.Bow || holder.HolderType == EquipType.Quiver)
                        {
                            holder.UnEquiped();
                        }
                        if (item.ItemType==holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }                       
                    }break;

                case EquipType.RightHandMeleeWeapon:
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {
                        if (holder.HolderType == EquipType.Bow || holder.HolderType == EquipType.Quiver)
                        {
                            holder.UnEquiped();
                        }
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }                    
                    break;

                case EquipType.LeftHandShield:
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {
                        if (holder.HolderType == EquipType.Bow | holder.HolderType == EquipType.Quiver)
                        {
                            holder.UnEquiped();
                        }
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }                    
                    break;
                case EquipType.Bow :
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {
                        if (holder.HolderType == EquipType.LeftHandMeleeWeapon | holder.HolderType == EquipType.RightHandMeleeWeapon | holder.HolderType == EquipType.LeftHandShield)
                        {
                            holder.UnEquiped();
                        }
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }
                    break;
                case (EquipType.Worker ):
                    isIsWorker = true;
                    GetWorker();
                    break;



            }
        }
        public void UnEquiped(IEquippable item)
        {
            switch (item.ItemType)
            {
                case EquipType.Arms:
                    UnEquipArmour(item);
                    break;
                case EquipType.Body:
                    UnEquipArmour(item);
                    break;
                case EquipType.Legs:
                    UnEquipArmour(item);
                    break;
                case EquipType.Shoulderpads:
                    UnEquipArmour(item);
                    break;
                case EquipType.Head:
                    UnEquipArmour(item);
                    break;
                case EquipType.LeftHandMeleeWeapon:                    
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {                        
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }
                    break;

                case EquipType.RightHandMeleeWeapon:
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {                        
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }
                    break;

                case EquipType.LeftHandShield:
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    {                        
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }
                    break;
                case EquipType.Bow:
                    UnEquipWorker(isIsWorker);
                    isIsWorker = false;
                    foreach (IWeaponEquipped holder in _weaponEquipHolders)
                    { 
                        if (item.ItemType == holder.HolderType)
                        {
                            holder.GetEquipped(item);
                        }
                    }
                    break;
                case (EquipType.Worker):
                    isIsWorker = true;
                    GetWorker();
                    break;
            }
        }
        public void UnEquipArmour(IEquippable item)
        {
            foreach (ArmourEquipHolder holder in _armourEquipHolders)
            {
                if (item.ItemType == holder.HolderType)
                {
                    holder.UnEquiped(item);
                    break;
                }
            }
        }
        public void GetWorker()
        {
            UnEquipAllWeapons();
            UnEquipAllArmour();

        }
        public void UnEquipAllArmour()
        {
            foreach(ArmourEquipHolder holder in _armourEquipHolders)
            {
                holder.UnEquiped();
            }
        }
        public void UnEquipAllWeapons()
        {
            foreach (IWeaponEquipped holder in _weaponEquipHolders)
            {
                holder.UnEquiped();
            }
        }
        public void UnEquipWorker(bool workerFlag)
        {
            if (workerFlag)
            {
                _workerEquipHolder.UnEquiped();
            }
        }
        public void OnValidate()
        {
            if (_equipableItem!=null)
            { 
            GetEquipped(_equipableItem);
                _equipableItem = null;
            }
            if (_unEquipableItem!=null)
            {
                UnEquiped(_unEquipableItem);
                _unEquipableItem = null;
            }
        }



    }
}
