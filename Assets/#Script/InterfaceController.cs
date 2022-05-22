using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyObject
{
    void Destroy(GameObject target);
}

public interface ITakeDamagable
{
    void TakeDamage(int damage);
}

public class InterfaceController 
{
  
}
