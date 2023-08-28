using UnityEngine;

namespace TwoD
{

    public class StateAttack : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
