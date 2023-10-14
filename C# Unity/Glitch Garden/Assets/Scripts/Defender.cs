using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 50;

    //Utilizado aqui apenas pelo solzinho, mas poderia ser modificado
    public void AddStars(int amount)
    {
        FindObjectOfType<StarsDisplay>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }

}
