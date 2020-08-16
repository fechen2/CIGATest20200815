using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class PlayerDaoZei : PlayerBase
{
    //--yinShen相关
    public bool isYinShenTrigger = false;
    public int yinShenBegin_BigTime = 0;
    public int yinShen_canMoveBigTime = 0;
    public int yinShen_cdReleaseBigTime = 0;
    //----------------------

    //--jipao相关
    public bool isJiPaoTrigger = false;
    public int jiPaoBegin_BigTime = 0;
    public int jiPao_StandBigTime = 0;
    public int jiPao_cdReleaseBigTime = 0;
    //---------------
    //--zuzhou相关
    public bool isZuzhouTrigger = false;
    public int zuZhouBegin_BigTime = 0;
    public int zuZhou_cdReleaseBigTime = 0;
    //---------------
    public override void MyStart()
    {
        base.MyStart();
    }

    public override void MyUpdate()
    {

    }

    public void YinShen()
    {
        int needPoint = PlayerConfig.daoZeiCfgDict[PlayerConfig.yinShen].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError("yinShen 行动点不够！");
            return;
        }
        CostActPoint(needPoint);
        curSkill = PlayerConfig.yinShen;
    }
    public void JiPao()
    {
        int needPoint = PlayerConfig.daoZeiCfgDict[PlayerConfig.jiPao].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError("jiPao 行动点不够！");
            return;
        }
        CostActPoint(curActPoints);
        curSkill = PlayerConfig.jiPao;
    }

    public void ZuZhou()
    {
        int needPoint = PlayerConfig.daoZeiCfgDict[PlayerConfig.zuZhou].needActPoint;
        if (curActPoints < needPoint)
        {
            UnityEngine.Debug.LogError("zuZhou 行动点不够！");
            return;
        }
        CostActPoint(needPoint);
        curSkill = PlayerConfig.zuZhou;
    }

    public override void BigEndFunc()
    {
        base.BigEndFunc();
        if (isYinShenTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();
            if (curBigTime >= yinShenBegin_BigTime && isHiding)
            {
                SetHide(false);
            }
            if (curBigTime >= yinShen_cdReleaseBigTime)
            {
                PlayerConfig.ResetCDTianQian();
                SetYinShenData(false);
            }
        }

        if (isJiPaoTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();

            if (curBigTime >= jiPao_StandBigTime)
            {
                SetSheild(0);
            }

            if (curBigTime > jiPao_cdReleaseBigTime)
            {
                PlayerConfig.ResetCDTianQian();
                SetJiPaoData(false);
            }
        }
        if (isZuzhouTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();

            if (curBigTime > zuZhou_cdReleaseBigTime)
            {
                PlayerConfig.ResetCDTianQian();
                SetZuZhouData(false);
            }
        }
    }

    public override void BeforePlaySkill1()
    {
        if (!isCanAction)
        {
            return;
        }

        YinShen();
    }
    public override void BeforePlaySkill2()
    {
        if (!isCanAction)
        {
            return;
        }
        JiPao();
    }
    public override void BeforePlaySkill3()
    {
        if (!isCanAction)
        {
            return;
        }
        ZuZhou();
    }

    public override void RealPlaySkill()
    {
        base.RealPlaySkill();
        if (!isCanAction)
        {
            return;
        }
        if (curSkill == PlayerConfig.yinShen)
        {
            SetYinShenData(true);
        }
        else if (curSkill == PlayerConfig.jiPao)
        {
            SetJiPaoData(true);
        }
        else if (curSkill == PlayerConfig.zuZhou)
        {
            SetZuZhouData(true);

            //mCurEnemy 当前受到诅咒的人  Map.Instance.TryGetUnit
            if (mCurEnemy != null)
            {
                float damageValue = PlayerConfig.daoZeiCfgDict[PlayerConfig.zuZhou].damagerRatio;
                if (this.isHiding)
                {
                    mCurEnemy.SetZuZhouType(ZuZhouType.High, (int)damageValue);
                }
                else
                {
                    mCurEnemy.SetZuZhouType(ZuZhouType.Normal, (int)damageValue);
                }
            }
        }
    }

    private void SetYinShenData(bool isBegin)
    {
        if (isBegin)
        {
            isYinShenTrigger = true;
            yinShenBegin_BigTime = PlayerConfig.GetCurBig();
            yinShen_canMoveBigTime = yinShenBegin_BigTime + PlayerConfig.yinShen_StandBigCount - 1;
            yinShen_cdReleaseBigTime = yinShenBegin_BigTime + PlayerConfig.yinShen_CDBigCount;
            PlayerConfig.CoolCD();
            SetHide(true);
        }
        else
        {
            isYinShenTrigger = false;
        }
    }

    private void SetJiPaoData(bool isBegin)
    {
        if (isBegin)
        {
            isJiPaoTrigger = true;
            jiPaoBegin_BigTime = PlayerConfig.GetCurBig();
            jiPao_StandBigTime = jiPaoBegin_BigTime + PlayerConfig.jiPao_StandBigCount;
            jiPao_cdReleaseBigTime = jiPaoBegin_BigTime + PlayerConfig.jiPao_CDBigCount;
            curMoveEnergy = PlayerConfig.jiPao_MoveRatio;
        }
        else
        {
            isJiPaoTrigger = false;
            curMoveEnergy = 1;
        }
    }

    private void SetZuZhouData(bool isBegin)
    {
        if (isBegin)
        {
            isZuzhouTrigger = true;
            zuZhouBegin_BigTime = PlayerConfig.GetCurBig();
            zuZhou_cdReleaseBigTime = zuZhouBegin_BigTime + PlayerConfig.zuZhou_CDBigCount;
        }
        else
        {
            isZuzhouTrigger = false;
        }
    }

}

