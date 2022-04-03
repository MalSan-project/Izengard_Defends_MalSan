using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipSystem
{ 
    
    public class ArmourEquipHolder : MonoBehaviour,IEquipped
    {
        public EquipType HolderType => _holderType;

        public GameObject EquipHolderObject => gameObject;

        [SerializeField]
        private EquipType _holderType;

        private SkinnedMeshRenderer ArmourEquipHolderMesh;
        private Mesh ArmourEquipHolderMeshBase;


        private void Awake()
        {
            ArmourEquipHolderMesh = gameObject.GetComponent<SkinnedMeshRenderer>();
            ArmourEquipHolderMeshBase = ArmourEquipHolderMesh.sharedMesh;
        }

        public void GetEquipped(IEquippable item)
        {
            if (ArmourEquipHolderMesh.sharedMesh != item.ItemMesh && _holderType == item.ItemType)
            {
                ArmourEquipHolderMesh.sharedMesh = item.ItemMesh;                 
            }
        }

        public void UnEquiped(IEquippable item)
        {
            if (item.ItemMesh == ArmourEquipHolderMesh.sharedMesh && _holderType == item.ItemType)
                ArmourEquipHolderMesh.sharedMesh = ArmourEquipHolderMeshBase;
        }

        public void UnEquiped()
        {
            ArmourEquipHolderMesh.sharedMesh = ArmourEquipHolderMeshBase;
        }



    }
}
