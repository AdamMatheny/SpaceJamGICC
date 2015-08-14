using System.Collections.Generic;
using Assets._Scripts.Player;
using UnityEngine;
using System.Linq;

namespace Assets._Scripts.Managers
{
    public class VehiclesManager : Singleton<VehiclesManager>
    {
        [SerializeField]
        private List<PlayerBase> AllVehicles;

        public PlayerBase GetVehicle(VehicleType vehicleType)
        {
            return AllVehicles.First(vehicle => vehicle.PlayerVisualsComponent.type == vehicleType);
        }
    }
}
