using FSM;
using Player.States;
using SteeringBehaviour;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Weapon;

namespace Player
{
    public class Player : Entity
    {
        public InputHandler inputHandler { get; private set; }
        public Boid boid { get; private set; }

        private Vector2 pointerInput;
        private WeaponHolder weaponHolder;

        public override void Awake()
        {
            base.Awake();
            boid = GetComponent<Boid>();
            inputHandler = GetComponent<InputHandler>();
            weaponHolder = GetComponentInChildren<WeaponHolder>();
        }

        protected override void OnCreateStates()
        {
            new PlayerIdleState(this, "idle");
            new PlayerMoveState(this, "move");
        }

        public override void Update()
        {
            base.Update();
            pointerInput = inputHandler.GetPointerInput();
            weaponHolder.pointer = pointerInput;
            boid.LookAt(pointerInput);
        }
    }
}