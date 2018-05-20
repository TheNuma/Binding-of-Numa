using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearDeathScript : MonoBehaviour {
    public AnimationClip death;

	void Update () {
        Destroy(this.gameObject, death.length);
    }
}
