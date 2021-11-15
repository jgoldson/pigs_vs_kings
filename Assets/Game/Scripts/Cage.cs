using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    // Start is called before the first frame update
public void Open() {
    transform.parent.GetComponent<Animator>().SetTrigger("CageOpen");
    Destroy(gameObject, 1);
}
}
