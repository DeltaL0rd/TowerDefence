using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 0 = Slow / 1 = Die All Enemies

public class PowerUpManager : MonoBehaviour
{
    public static int ActivatedPowerUp =-1;

    public void ActivatePowerUp(int ID)
    {
        ActivatedPowerUp = ID;
        GameManager.Instance.PowerUpEffect(ActivatedPowerUp);
    }
}
