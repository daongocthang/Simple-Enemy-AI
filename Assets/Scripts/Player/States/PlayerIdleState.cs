using FSM;
using UnityEngine;

namespace Player.States
{
    public class PlayerIdleState : PlayerState
    {
        private bool moving;

        public PlayerIdleState(Entity entity, string animBoolName) : base(entity, animBoolName)
        {
        }

        public override void DoChecks()
        {
            base.DoChecks();

            moving = !player.inputHandler.GetMovementInput().Equals(Vector2.zero);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void LogicUpdate()
        {
            if (moving)
            {
                stateMachine.ChangeState<PlayerMoveState>();
            }
        }
    }
}