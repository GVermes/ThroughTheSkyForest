using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObstacleRight : MonoBehaviour
{
    Animator anim;

    public static BossObstacleRight instace;

    // Start is called before the first frame update
    void Start()
    {
        instace = this;
        anim = GetComponent<Animator>();
    }

    public IEnumerator PlayAnimation()
    {
        anim.SetBool("on", true);
        yield return new WaitForSeconds(7f);
        BossWallButton2.instance.SendMessage("Off");
        anim.SetBool("on", false);
    }
}
