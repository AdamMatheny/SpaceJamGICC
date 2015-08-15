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

        [SerializeField]
        private Transform Player1SpawningPoint;
        [SerializeField]
        private Transform Player2SpawningPoint;

        private VehicleType Player1ShipType;
        private VehicleType Player2ShipType;

        public PlayerBase Player1Ship;
        public PlayerBase Player2Ship;

        public PlayerBase GetVehicle(VehicleType vehicleType)
        {
            return AllVehicles.First(vehicle => vehicle.PlayerVisualsComponent.type == vehicleType);
        }

        public void SetUpPlayerShips(VehicleType type1, VehicleType type2)
        {
            Player1ShipType = type1;
            Player2ShipType = type2;
        }

        public void SpawnShips()
        {
            Player1Ship = (Instantiate(GetVehicle(Player1ShipType).gameObject, Player1SpawningPoint.position, Player1SpawningPoint.rotation) as GameObject).GetComponent<PlayerBase>();
            Player2Ship = (Instantiate(GetVehicle(Player2ShipType).gameObject, Player2SpawningPoint.position, Player2SpawningPoint.rotation) as GameObject).GetComponent<PlayerBase>();

            Player1Ship.PlayerControlComponent.SetUpControlsAsPlayer1();
            Player2Ship.PlayerControlComponent.SetUpControlsAsPlayer2();

            Player1Ship.mPlayerNumber = 1;
            Player2Ship.mPlayerNumber = 2;

            Player1Ship.gameObject.transform.parent = MapManager.instance.PlayersTransform;
            Player2Ship.gameObject.transform.parent = MapManager.instance.PlayersTransform;

            CollectablesManager.instance.StartSpawning();
        }
    }
}
