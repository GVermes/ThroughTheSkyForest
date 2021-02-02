using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObstacle : MonoBehaviour
{

    Animator anim;

    public static BossObstacle instace;

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
        BossWallButton.instance.SendMessage("Off");
        anim.SetBool("on", false);
    }
}
