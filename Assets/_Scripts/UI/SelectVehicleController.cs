using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Assets._Scripts.Managers;
using Assets._Scripts.Player;
using Assets._Scripts.UI;

namespace Assets._Scripts.UI
{
    public class SelectVehicleController : GUIScreen
    {
        [SerializeField]
        private List<Image> Player1SelectImages;
        [SerializeField]
        private Text Ready1Text;
        private int CurrectPlayer1Ship;
        private bool Player1Locked;
        
        [SerializeField]
        private List<Image> Player2SelectImages;
        [SerializeField]
        private Text Ready2Text;
        private int CurrectPlayer2Ship;
        private bool Player2Locked;

        [SerializeField]
        private Sprite ShipNoneSprite;

        private bool Player1MenuMoved;
        private bool Player2MenuMoved;

        public override void Show()
        {
            base.Show();
            CurrectPlayer1Ship = 2;
            MovePlayer1SelectLeft(); //To start with 1. ship selected
            CurrectPlayer2Ship = 2;
            MovePlayer2SelectLeft(); //To start with 1. ship selecteda

            Ready1Text.enabled = false;
            Ready2Text.enabled = false;
        }

        private void MovePlayer1SelectRight()
        {
            if (Player1Locked) return;
            if (CurrectPlayer1Ship == 4) return;
            CurrectPlayer1Ship++;

            switch (CurrectPlayer1Ship)
            {
                case 2:
                    Player1SelectImages[0].sprite = ShipNoneSprite;
                    Player1SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[4].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    break;
                case 3:
                    Player1SelectImages[0].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[4].sprite = ShipNoneSprite;
                    break;
                case 4:
                    Player1SelectImages[0].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[3].sprite = ShipNoneSprite;
                    Player1SelectImages[4].sprite = ShipNoneSprite;
                    break;
                case 5:
                    break;
            }
        }

        private void MovePlayer1SelectLeft()
        {
            if (Player1Locked) return;
            if (CurrectPlayer1Ship == 1) return;
            CurrectPlayer1Ship--;

            switch (CurrectPlayer1Ship)
            {
                case 1:
                    Player1SelectImages[0].sprite = ShipNoneSprite;
                    Player1SelectImages[1].sprite = ShipNoneSprite;
                    Player1SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[4].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    break;
                case 2:
                    Player1SelectImages[0].sprite = ShipNoneSprite;
                    Player1SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[4].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    break;
                case 3:
                    Player1SelectImages[0].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    Player1SelectImages[4].sprite = ShipNoneSprite;
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private void MovePlayer2SelectRight()
        {
            if (Player2Locked) return;
            if (CurrectPlayer2Ship == 4) return;
            CurrectPlayer2Ship++;

            switch (CurrectPlayer2Ship)
            {
                case 2:
                    Player2SelectImages[0].sprite = ShipNoneSprite;
                    Player2SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[4].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    break;
                case 3:
                    Player2SelectImages[0].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[4].sprite = ShipNoneSprite;
                    break;
                case 4:
                    Player2SelectImages[0].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[3].sprite = ShipNoneSprite;
                    Player2SelectImages[4].sprite = ShipNoneSprite;
                    break;
                case 5:
                    break;
            }
        }

        private void MovePlayer2SelectLeft()
        {
            if (Player2Locked) return;
            if (CurrectPlayer2Ship == 1) return;
            CurrectPlayer2Ship--;

            switch (CurrectPlayer2Ship)
            {
                case 1:
                    Player2SelectImages[0].sprite = ShipNoneSprite;
                    Player2SelectImages[1].sprite = ShipNoneSprite;
                    Player2SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[4].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    break;
                case 2:
                    Player2SelectImages[0].sprite = ShipNoneSprite;
                    Player2SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[4].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    break;
                case 3:
                    Player2SelectImages[0].sprite = VehiclesManager.instance.GetVehicle(VehicleType.RedShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[1].sprite = VehiclesManager.instance.GetVehicle(VehicleType.BlueShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[2].sprite = VehiclesManager.instance.GetVehicle(VehicleType.PinkShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[3].sprite = VehiclesManager.instance.GetVehicle(VehicleType.WhiteShip).PlayerVisualsComponent.DefaultSprite;
                    Player2SelectImages[4].sprite = ShipNoneSprite;
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private void LockPlayer1()
        {
            Player1Locked = true;
            Ready1Text.enabled = true;
            CheckBothPlayersAreReady();
        }

        private void LockPlayer2()
        {
            Player2Locked = true;
            Ready2Text.enabled = true;
            CheckBothPlayersAreReady();
        }

        private void UnlockPlayer1()
        {
            Player1Locked = false;
            Ready1Text.enabled = false;
        }

        private void UnlockPlayer2()
        {
            Player2Locked = false;
            Ready2Text.enabled = false;
        }

        void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetAxis("Horizontal1") > 0.3f && !Player1MenuMoved)
            {
                MovePlayer1SelectRight();
                Player1MenuMoved = true;
            }
            if (Input.GetAxis("Horizontal1") < -0.3f && !Player1MenuMoved)
            {
                MovePlayer1SelectLeft();
                Player1MenuMoved = true;
            }
            if (Input.GetAxis("Horizontal1") < 0.3f && Input.GetAxis("Horizontal1") > -0.3f)
            {
                Player1MenuMoved = false;
            }

            if (Input.GetAxis("Horizontal2") > 0.3f && !Player2MenuMoved)
            {
                MovePlayer2SelectRight();
                Player2MenuMoved = true;
            }
            if (Input.GetAxis("Horizontal2") < -0.3f && !Player2MenuMoved)
            {
                MovePlayer2SelectLeft();
                Player2MenuMoved = true;
            }
            if (Input.GetAxis("Horizontal2") < 0.3f && Input.GetAxis("Horizontal2") > -0.3f)
            {
                Player2MenuMoved = false;
            }

            if (Input.GetAxis("Player1Fire1") > 0.1f)
            {
                LockPlayer1();
            }
            if (Input.GetAxis("Player1Fire2") > 0.1f)
            {
                UnlockPlayer1();
            }

            if (Input.GetAxis("Player2Fire1") > 0.1f)
            {
                LockPlayer2();
            }
            if (Input.GetAxis("Player2Fire2") > 0.1f)
            {
                UnlockPlayer2();
            }
        }

        private void CheckBothPlayersAreReady()
        {
            if (!Player1Locked || !Player2Locked) return;

            //SET UP SELECTED VEHICLES IN PLAYERMANAGER

            GUIManager.instance.ShowScreen(ScreenType.PlayScreen);
            VehiclesManager.instance.SetUpPlayerShips((VehicleType)CurrectPlayer1Ship - 1, (VehicleType)CurrectPlayer2Ship - 1);
            VehiclesManager.instance.SpawnShips();

            Player1Locked = false;
            Player2Locked = false;
        }
    }
}
