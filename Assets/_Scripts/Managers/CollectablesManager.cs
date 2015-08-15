using UnityEngine;
using System.Collections.Generic;
using Assets._Scripts.Items;
using Assets._Scripts.Weapons;

namespace Assets._Scripts.Managers
{
    public class CollectablesManager : MonoBehaviour
    {
        [SerializeField]
        private List<Collectable> CollectablesList;
    }
}
