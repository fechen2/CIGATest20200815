using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerZhanShi : PlayerBase
{    //--tiaoPi相关
    public bool isTiaoPiTrigger = false;
    public int tiaoPiBegin_BigTime = 0;
    public int tiaoPi_cdReleaseBigTime = 0;
    //----------------------
    public override void MyStart()
    {
        base.MyStart();
    }

    public override void MyUpdate()
    {

    }
    public override void BigEndFunc()
    {
        base.BigEndFunc();

        if (isTiaoPiTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();

            if (curBigTime > tiaoPi_cdReleaseBigTime)
            {
                PlayerConfig.CoolCD();
                SetTiaoPiData(false);
            }
        }
    }
    public void TiaoPi()
    {
        if (curActPoints < PlayerConfig.zhanshiCfgDict[PlayerConfig.tiaoPi].needActPoint)
        {
            UnityEngine.Debug.LogError(gameObject.name + "tiaoPi 行动点不够！");
            return;
        }
        CostActPoint(curActPoints);
        curSkill = PlayerConfig.tiaoPi;
    }

    public void Cai()
    {
        int needPoint = PlayerConfig.zhanshiCfgDict[PlayerConfig.cai].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError(gameObject.name + "Cai 行动点不够！");
            return;
        }
        CostActPoint(needPoint);
        curSkill = PlayerConfig.cai;
    }

    public void XuanFengZhan()
    {
        int needPoint = PlayerConfig.zhanshiCfgDict[PlayerConfig.xuanFengZhan].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError(gameObject.name + "xuanFengZhan 行动点不够！");
            return;
        }
        CostActPoint(needPoint);
        curSkill = PlayerConfig.xuanFengZhan;
    }

    public override void BeforePlaySkill1()
    {
        TiaoPi();
    }
    public override void BeforePlaySkill2()
    {
        Cai();
    }
    public override void BeforePlaySkill3()
    {
        XuanFengZhan();
    }

    public override void RealPlaySkill()
    {
        base.RealPlaySkill();
        UnityEngine.Debug.Log(gameObject.name + "  技能真正释放：" + curSkill);

        if (curSkill == PlayerConfig.tiaoPi)
        {
            SetTiaoPiData(true);
            //跳跃5格子 Move!!
            PlayerConfig.Move();
            //---------TiaoPi跳跃结束 开始调用！！ 缺少跳跃结束的event!!!
            //2圈范围
            if (mCurEnemyList != null)
            {
                for (int i = 0; i < mCurEnemyList.Count; ++i)
                {
                    float hp = AttackValue * PlayerConfig.zhanshiCfgDict[PlayerConfig.tiaoPi].damagerRatio;
                    mCurEnemyList[i].LoseHP((int)hp);

                    if (mCurEnemyList[i].isHiding)
                    {
                        mCurEnemyList[i].SetHide(false);
                    }
                }
            }
            else
            {
                UnityEngine.Debug.Log(gameObject.name + "tiaoPi 技没有找到敌人");
            }
            //-----------------------------------
        }
        else if (curSkill == PlayerConfig.cai)
        {
            //获得一个敌人
            if (mCurEnemy != null)
            {
                float hp = AttackValue * PlayerConfig.zhanshiCfgDict[PlayerConfig.cai].damagerRatio;
                mCurEnemy.LoseHP((int)(hp));
            }
            else
            {
                UnityEngine.Debug.Log(gameObject.name + " 踩踏技没有找到敌人");
            }
        }
        else if (curSkill == PlayerConfig.xuanFengZhan)
        {
            if (mCurEnemyList != null)
            {
                for (int i = 0; i < mCurEnemyList.Count; ++i)
                {
                    if (!mCurEnemyList[i].isHiding)
                    {
                        float hp = AttackValue * PlayerConfig.zhanshiCfgDict[PlayerConfig.xuanFengZhan].damagerRatio;
                        mCurEnemyList[i].LoseHP((int)hp);
                    }
                }
            }
            else
            {
                UnityEngine.Debug.Log(gameObject.name + "xuanFengZhan技没有找到敌人");
            }
        }
    }

    private void SetTiaoPiData(bool isBegin)
    {
        if (isBegin)
        {
            isTiaoPiTrigger = true;
            tiaoPiBegin_BigTime = PlayerConfig.GetCurBig();
            tiaoPi_cdReleaseBigTime = tiaoPiBegin_BigTime + PlayerConfig.huDun_CDBigCount;
        }
        else
        {
            isTiaoPiTrigger = false;
        }
    }

}

