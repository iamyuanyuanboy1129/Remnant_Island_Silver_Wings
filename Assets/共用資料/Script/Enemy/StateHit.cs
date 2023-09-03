using UnityEngine;

namespace TwoD
{

    public class StateHit : State
    {
        public override State RunCurrentState()
        {
            return this;
        }
    }
}
