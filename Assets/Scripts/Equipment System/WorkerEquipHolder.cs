using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EquipSystem
{ 
    
    public class WorkerEquipHolder : MonoBehaviour, IEquipped
    {

        public EquipType HolderType => _holderType;

        public GameObject EquipHolderObject => gameObject;

        [SerializeField]
        private EquipType _holderType;

        private MeshFilter equipHolderMesh;
        private Mesh equipHolderMeshBase;


        private void Awake()
        {
            equipHolderMesh = gameObject.GetComponent<MeshFilter>();
            equipHolderMeshBase = equipHolderMesh.sharedMesh;
        }

        public void GetEquipped(IEquippable item)
        {
            if (equipHolderMesh.mesh!=item.ItemMesh && _holderType==item.ItemType)
            { 
                equipHolderMesh.mesh = item.ItemMesh;                
            }
        }

        public void UnEquiped(IEquippable item)
        {
            if (item.ItemMesh == equipHolderMesh.sharedMesh && _holderType == item.ItemType)
            {
                equipHolderMesh.sharedMesh = equipHolderMeshBase;                
            }
        }
        public void UnEquiped()
        {
            equipHolderMesh.sharedMesh = equipHolderMeshBase;
        }
    }
}
