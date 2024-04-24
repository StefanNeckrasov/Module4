using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInp : InputMan
{
    public override bool PressedAttack { get; protected set; }
    public override Vector3 Motion { get; protected set; }

    private void Update()
    {
        PressedAttack = UnityEngine.Input.GetMouseButtonDown(0);
        Motion = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0, UnityEngine.Input.GetAxis("Vertical"));


    }
}
