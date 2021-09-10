using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPrototupe.Place
{
    
    public class Table : MonoBehaviour
    {
        public enum tableBehavior { IsFree, IsBusy, IsSelected }

        public tableBehavior _tableBehavior;
         
        public Transform pointTable;
        public Vector3 TablePoint { get { return pointTable.position; } }

        private void Awake()
        {
            _tableBehavior = tableBehavior.IsFree;
            
            
        }
    }
}