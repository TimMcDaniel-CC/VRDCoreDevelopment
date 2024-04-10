using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DupeObject : MonoBehaviour
{
    public void Dupe()
    {
        GameObject.Instantiate(this.gameObject, this.transform.position, this.transform.rotation);
    }
}
