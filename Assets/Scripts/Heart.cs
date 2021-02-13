using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Collectable
{
    // Start is called before the first frame update
    void Start()
    {
        collectableName = "Heart";
        description = "increase health by 10";

        DontDestroyOnLoad(this.gameObject);
    }

    override public void Use()
    {
        player.GetComponent<playerManager>().ChangeHealth(10);
        Destroy(this.gameObject);
    }
}
