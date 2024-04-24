using UnityEngine;

public abstract class InputMan : MonoBehaviour
{

    public abstract bool PressedAttack { get; protected set; }
    public abstract Vector3 Motion { get; protected set; }

}
