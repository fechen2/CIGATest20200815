using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBase : MonoBehaviour
{
    public PlayerBase OwnerPlayer;
    private CampState camp;
    private DirectType directValue = DirectType.shang;
    public virtual void InitData(PlayerBase owner , DirectType direct)
    {
        if(owner == null)
        {
            Debug.LogError("源头是空的！");
            return;
        }
        OwnerPlayer = owner;
        directValue = direct;
        camp = OwnerPlayer.CurCamp;
    }

    public virtual void DestoryObject()
    {
        
    }

    public virtual void MyStart()
    {

    }
    public virtual void MyUpdate()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        MyStart();
    }

    // Update is called once per frame
    void Update()
    {
        MyUpdate();
    }
}
