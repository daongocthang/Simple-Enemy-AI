using FSM;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Player.States
{
    public class PlayerMoveState : PlayerState
    {
        private Vector2 axisInput;
        private const float Speed = 10f;

        public PlayerMoveState(Entity entity, string animBoolName) : base(entity, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();
            axisInput = player.inputHandler.GetMovementInput();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (!axisInput.Equals(Vector2.zero))
            {
                player.boid.SetVelocity(axisInput * (Speed * Time.deltaTime));
            }
            else
            {
                stateMachine.ChangeState<PlayerIdleState>();
            }
        }
    }
}