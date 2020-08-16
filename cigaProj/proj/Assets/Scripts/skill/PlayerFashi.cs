using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerFashi : PlayerBase
{
    //--天谴相关
    public bool isTianQianTrigger = false;
    public int tianQianBegin_BigTime = 0;
    public int tianQian_canMoveBigTime = 0;
    public int tianQian_cdReleaseBigTime = 0;
    public Vector2Int tianQian_DestCoord = Vector2Int.zero;
    //----------------------


    //--huDun相关
    public bool isHuDunTrigger = false;
    public int huDunBegin_BigTime = 0;
    public int huDun_StandBigTime = 0;
    public int huDun_cdReleaseBigTime = 0;
    //---------------

    public override void MyStart()
    {
        base.MyStart();
    }

    public override void MyUpdate()
    {

    }

    public void MoFaDan()
    {
        int needPoint = PlayerConfig.zhanshiCfgDict[PlayerConfig.moFaDan].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError("moFaDan 行动点不够！");
            return;
        }
        CostActPoint(needPoint);
        curSkill = PlayerConfig.tianQian;
        //冷却技能!!
        //   int CdTimes = PlayerConfig.zhanshiCfgDict[PlayerConfig.moFaDan].CdTimes;
        PlayerConfig.CoolCD();
    }
    public void TianQian()
    {
        int needPoint = PlayerConfig.zhanshiCfgDict[PlayerConfig.tianQian].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError("TianQian 行动点不够！");
            return;
        }
        CostActPoint(curActPoints); //消耗完
        curSkill = PlayerConfig.tianQian;

    }

    public void HuDun()
    {
        int needPoint = PlayerConfig.zhanshiCfgDict[PlayerConfig.huDun].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError("huDun 行动点不够！");
            return;
        }

        CostActPoint(needPoint);
        curSkill = PlayerConfig.huDun;
    }



    public override void BigEndFunc()
    {
        base.BigEndFunc();
        if (isTianQianTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();
            if (curBigTime >= tianQian_canMoveBigTime)
            {
                isCanAction = true;
                PlayerConfig.ResetCDAllWithOutTianqian();

                //--技能施法 tianQian_DestCoord  --是不是要放到RealSkillPlayer里去？？？
                if (mCurEnemyList != null)
                {
                    for (int i = 0; i < mCurEnemyList.Count; ++i)
                    {
                        float hp = MagicVal * PlayerConfig.zhanshiCfgDict[PlayerConfig.xuanFengZhan].damagerRatio;
                        mCurEnemyList[i].LoseHP((int)hp);

                        if (mCurEnemyList[i].isHiding)
                        {
                            mCurEnemyList[i].SetHide(false);
                        }
                    }
                }
                else
                {
                    UnityEngine.Debug.Log("tianQian技没有找到敌人");
                }
            }
            if (curBigTime >= tianQian_cdReleaseBigTime)
            {
                PlayerConfig.ResetCDTianQian();
                SetTianQianData(false);
            }
        }

        if (isHuDunTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();

            if (curBigTime >= huDun_StandBigTime && curSheid > 0)
            {
                SetSheild(0);
            }

            if (curBigTime > huDun_cdReleaseBigTime)
            {
                PlayerConfig.CoolCD();
                SetHuDunData(false);
            }
        }
    }

    public override void BeforePlaySkill1()
    {
        if (!isCanAction)
        {
            return;
        }

        MoFaDan();
    }
    public override void BeforePlaySkill2()
    {
        if (!isCanAction)
        {
            return;
        }
        TianQian();
    }
    public override void BeforePlaySkill3()
    {
        if (!isCanAction)
        {
            return;
        }
        HuDun();
    }

    public override void RealPlaySkill()
    {
        base.RealPlaySkill();
        if (!isCanAction)
        {
            return;
        }
        if (curSkill == PlayerConfig.moFaDan)
        {
            //生成子弹
            UnityEngine.Object cubePreb = Resources.Load("BulletMagic", typeof(GameObject));
            GameObject cube = Instantiate(cubePreb) as GameObject;
            BulletMagic com = cube.GetComponent<BulletMagic>();
            com.InitData(this, skillDirect);
        }
        else if (curSkill == PlayerConfig.tianQian)
        {
            SetTianQianData(true);
        }
        else if (curSkill == PlayerConfig.huDun)
        {
            SetSheild(PlayerConfig.huDun_Count);
            SetHuDunData(true);
        }
    }

    private void SetTianQianData(bool isBegin)
    {
        if (isBegin)
        {
            isTianQianTrigger = true;
            tianQianBegin_BigTime = PlayerConfig.GetCurBig();
            tianQian_canMoveBigTime = tianQianBegin_BigTime + PlayerConfig.tianQian_StandCount - 1;
            tianQian_cdReleaseBigTime = tianQianBegin_BigTime + PlayerConfig.tianQian_CDCount;
            tianQian_DestCoord = curChooseCoord;
            //不能移动 所有技能都要CD！！！
            isCanAction = false;
            PlayerConfig.CoolCDAll();
        }
        else
        {
            isTianQianTrigger = false;
        }
    }

    private void SetHuDunData(bool isBegin)
    {
        if (isBegin)
        {
            isHuDunTrigger = true;
            huDunBegin_BigTime = PlayerConfig.GetCurBig();
            huDun_StandBigTime = huDunBegin_BigTime + PlayerConfig.huDun_LiftBigCount;
            huDun_cdReleaseBigTime = huDunBegin_BigTime + PlayerConfig.huDun_CDBigCount;
        }
        else
        {
            isHuDunTrigger = false;
        }
    }


}

