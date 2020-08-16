using GameLogic.Lua;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
public enum PlayerSkillState
{
    none = 1,
    normalWalk = 2,
}

public enum DirectType
{
    shang = 1,
    xia = 2,
    zuo = 3,
    you = 4,
}

public enum PlayerType
{
    zhanShi = 1,
    faShi = 2,
    daoZei = 3,
}

public class CommonSkillInfo
{
    public int needActPoint = 2;
    public float damagerRatio = 2;
    public CommonSkillInfo(int a, float b)
    {
        needActPoint = a;
        damagerRatio = b;
    }
}


public class PlayerConfig
{
    public const string normalSkill = "normalSkill";


    public const int range_puGong = 1;


    //--
    //  CommonSkillInfo(2 消耗行动点,2伤害倍率) 
    //-----战士相关配置： 
    public const string tiaoPi = "tiaoPi";
    public const string cai = "cai";
    public const string xuanFengZhan = "xuanFengZhan";
    public static Dictionary<string, CommonSkillInfo> zhanshiCfgDict = new Dictionary<string, CommonSkillInfo> {
        {tiaoPi,new CommonSkillInfo(2,2)},
        {cai,new CommonSkillInfo(2,2)},
        {xuanFengZhan,new CommonSkillInfo(2,2)},
    };
    //---------------------------

    //-----法师相关配置： 
    // CommonSkillInfo(2 消耗行动点,2伤害倍率) 
    public const string moFaDan = "moFaDan";
    public const string tianQian = "tianQian";
    public const string huDun = "huDun";
    public const float moFaDan_RadiusRatio = 1.5f;//爆炸时对周围enemy的伤害倍率
    public const int moBulletLiftCount = 2;//魔法弹生命小回合
    public const int moBulletMoveGrid = 2;//魔法弹每小回合移动的格子数

    public const int tianQian_StandCount = 2;//不能移动的大回合(包括当前)
    public const int tianQian_CDCount = 4;//CD大回合（不包括当前）
    public static Dictionary<string, CommonSkillInfo> faShiCfgDict = new Dictionary<string, CommonSkillInfo> {
        {moFaDan,new CommonSkillInfo(2,2)},
        {tianQian,new CommonSkillInfo(1,2)},//至少是1行动点
        {huDun,new CommonSkillInfo(1,0)},
    };
    public const int huDun_Count = 1;
    public const int huDun_LiftBigCount = 2;
    public const int huDun_CDBigCount = 2;
    //---------------------------

    //-----盗贼相关配置： 
    // CommonSkillInfo(2 消耗行动点,2伤害倍率
    public const string yinShen = "yinShen";
    public const string jiPao = "jiPao";
    public const string zuZhou = "zuZhou";

    public static Dictionary<string, CommonSkillInfo> daoZeiCfgDict = new Dictionary<string, CommonSkillInfo> {
        {yinShen,new CommonSkillInfo(1,2)},
        {jiPao,new CommonSkillInfo(2,2)},
        {zuZhou,new CommonSkillInfo(2,1.5f)},
    };
    public const int yinShen_StandBigCount = 3; //隐身持续回合
    public const int yinShen_CDBigCount = 4;//冷却4回合

    public const int jiPao_StandBigCount = 3; //疾跑持续回合
    public const int jiPao_CDBigCount = 3;//疾跑冷却4回合
    public const int jiPao_MoveRatio = 2;//疾跑导致移动力2倍

    public const int zuZhou_BigCount = 1;//诅咒会在1回合后集中敌人
    public const int zuZhou_CDBigCount = 1;//冷却1回合
 //---------------------------




    //-----temp func
    public static void Move()
    {

    }

    public static void CoolCD()
    {

    }
    public static void CoolCDAll()
    {

    }

    public static void ResetCDAllWithOutTianqian()
    {

    }

    public static void ResetCDTianQian()
    {

    }

    public static int GetCurBig()
    {
        return MainPanel.Instance.round;
    }

    public static int GetCurSmall()
    {
        return 0;
    }

    //-------------------------------

}
