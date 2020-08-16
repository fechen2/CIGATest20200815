using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMagic : BulletBase
{
    public PlayerBase mCurEnemy = null;
    public List<PlayerBase> mCurEnemyList = new List<PlayerBase>();

    private int LifeMaxCount = PlayerConfig.moBulletLiftCount;
    private int curSmallCount = 0;//当前回合数
    public override void InitData(PlayerBase owner, DirectType direct)
    {
        base.InitData(owner, direct);
        RunOnce();
    }

    public void RunOnce()
    {
        ++curSmallCount;
        PlayerConfig.Move();

        if(curSmallCount > LifeMaxCount)
        {
            DestoryObject(); 
        }
    }

    /// <summary>
    /// 子弹爆炸
    /// </summary>
    public void PlayBomb()
    {
        //碰撞的敌人
        if(mCurEnemy != null)
        {
            float hp = OwnerPlayer.MagicVal *  PlayerConfig.faShiCfgDict[PlayerConfig.moFaDan].damagerRatio;
            mCurEnemy.LoseHP((int)(hp));
        }
        else
        {
            UnityEngine.Debug.LogError(gameObject.name + " BulletMagic没有碰到到敌人！！！");
        }
        //周围的敌人
        if (mCurEnemyList != null)
        {
            for (int i = 0; i < mCurEnemyList.Count; ++i)
            {
                float hp = OwnerPlayer.AttackValue *PlayerConfig.moFaDan_RadiusRatio;
                mCurEnemyList[i].LoseHP((int)hp);
            }
        }
        //延迟销毁
        Invoke("DestoryObject", 2);
    }    

    public override void DestoryObject()
    {
        base.DestoryObject();
    }

    public override void MyStart()
    {
    }
    public override void MyUpdate()
    {

    }
}
