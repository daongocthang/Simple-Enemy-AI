using FSM;
using Unity.VisualScripting;

namespace Player.States
{
    public class PlayerState:EntityState
    {
        protected readonly Player player;        

        protected PlayerState(Entity entity, string animBoolName) : base(entity, animBoolName)
        {
            player = entity as Player;            
        }
    }
}