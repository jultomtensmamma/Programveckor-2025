using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPawinput : MonoBehaviour
//Alexis
{
    private RightClickAbility rightClickAbility;
    private BlackHoleAbility blackHoleAbility;
    private EnergyBurstAbility energyBurstAbility;

    

    void Start()
    {
    rightClickAbility = GetComponent<RightClickAbility>();
    blackHoleAbility = GetComponent<BlackHoleAbility>();
    energyBurstAbility = GetComponent<EnergyBurstAbility>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
    {
        rightClickAbility.UseAbility();

    }
        if (Input.GetKeyDown(KeyCode.E))
    {

        blackHoleAbility.UseAbility();

    }
        if (Input.GetKeyDown(KeyCode.LeftShift))
    {
        energyBurstAbility.UseAbility();
    }

    }
}
