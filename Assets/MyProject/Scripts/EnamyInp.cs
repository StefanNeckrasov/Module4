using UnityEngine;

public class EnamyInp : InputMan
{
    public override bool PressedAttack { get; protected set; }
    public override Vector3 Motion { get; protected set; }

    private void Update()
    {
        PressedAttack = true;
        Motion = Vector3.zero;


    }
}
