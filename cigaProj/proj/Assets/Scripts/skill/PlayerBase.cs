using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CampState
{
    A = 1,
    B = 2,
}
public enum ZuZhouType
{
    None = 0,  //0没中  1普通诅咒  2高级诅咒，受到两次伤害
    Normal = 1,
    High = 2,
}

public class PlayerBase : MonoBehaviour
{
    //--属性：
    public int baseProp = 10;
    public int curHP = 100;
    public int AttackValue = 10;
    public int DefendVal = 2;
    public int MagicVal = 20;
    public int Speed = 1;
    public int curMoveEnergy = 1; //移动力，行动点的系数
    //-------------------------
    public string ID = "name"; //id的话  1,2,3,另外一队是+10   11 12 13
    public int MaxActPoints = 3;
    public int curActPoints = 3;

    public CampState CurCamp = CampState.A;
    public string curSkill = "";
    public DirectType skillDirect = DirectType.shang; //施法方向

    public PlayerBase mCurEnemy = null;
    public List<PlayerBase> mCurEnemyList = new List<PlayerBase>();
    public Vector2Int curChooseCoord = Vector2Int.zero;

    public bool isCanAction = true; //是否被禁锢  false:被禁锢
    public bool isHiding = false;//隐身 true隐身 false显示
    public int curSheid = 0; //护盾数

    //--普攻相关
    public bool isNormalSkillTrigger = false;
    //------------------------

    //--诅咒相关
    public ZuZhouType curZuZhouType = 0;//是否中了诅咒  0没中  1普通诅咒  2高级诅咒，受到两次伤害
    public float hasZuZhouDamgeValue = 0;//单次诅咒伤害
    public bool isGetZuzhouTrigger = false;
    public int zuZhouGetBegin_BigTime = 0;
    public int zuZhouGet_skillReleaseBigTime = 0;
    //---------

    public void SetSheild(int v)
    {
        curSheid = v;
    }

    public void SetZuZhouType(ZuZhouType v, int damageValue)
    {
        curZuZhouType = v;

        if(v!= ZuZhouType.None)
        {
            hasZuZhouDamgeValue = damageValue;
            SetGetZuZhouData(true);
        }
    }

    private void SetGetZuZhouData(bool isBegin)
    {
        if (isBegin)
        {
            isGetZuzhouTrigger = true;
            zuZhouGetBegin_BigTime = PlayerConfig.GetCurBig();
            zuZhouGet_skillReleaseBigTime = zuZhouGetBegin_BigTime + PlayerConfig.zuZhou_BigCount;
        }
        else
        {
            isGetZuzhouTrigger = false;
            //--受到伤害：
            if(curZuZhouType == ZuZhouType.Normal)
            {
                this.LoseHP((int)hasZuZhouDamgeValue);
            }
            else if(curZuZhouType == ZuZhouType.Normal)
            {
                this.LoseHP((int)hasZuZhouDamgeValue);
                this.LoseHP((int)hasZuZhouDamgeValue);
            }
        }
    }

    public void SetHide(bool isHide)
    {
        isHiding = isHide;
        MeshRenderer mR = gameObject.GetComponent<MeshRenderer>();
        mR.enabled = !isHide;
    }

    public int GetMoveEnergy()
    {
        return curMoveEnergy;
    }

    /// <summary>
    /// 消耗行动点
    /// </summary>
    /// <param name="val"></param>
    public void CostActPoint(int val)
    {
        curActPoints = curActPoints - val;
        if(curActPoints <0)
        {
            Debug.LogError("行动点结果为负数 是否有误！");
        }
    }

    /// <summary>
    /// 正常移动一格子
    /// </summary>
    public void NormalMoveOneGrid()
    {
        PlayerConfig.Move();
        CostActPoint(1);
    }
    
    public void MoveGrid()
    {
        PlayerConfig.Move();
    }

    public virtual void BeforePlayNormal()
    {
        curSkill = PlayerConfig.normalSkill;
    }

    public virtual void BeforePlaySkill1()
    {
    }
    public virtual void BeforePlaySkill2()
    {
    }
    public virtual void BeforePlaySkill3()
    {
    }

    public virtual void RealPlaySkill()
    {
        if(curSkill == PlayerConfig.normalSkill)
        {
            if (mCurEnemyList != null)
            {
                for (int i = 0; i < mCurEnemyList.Count; ++i)
                {
                    if (!mCurEnemyList[i].isHiding)
                    {
                        if(this is PlayerDaoZei && this.isHiding)
                        {
                            //--无视护卫：
                            float hp = AttackValue;
                            mCurEnemyList[i].LoseHP((int)hp);
                            mCurEnemyList[i].LoseHP((int)hp);
                            this.SetHide(false);
                        }
                        else
                        {
                            float hp = AttackValue;
                            mCurEnemyList[i].LoseHP((int)hp);
                        }
                    }
                    else
                    {
                        mCurEnemyList[i].SetHide(false);
                    }
                }
            }
            else
            {
                UnityEngine.Debug.Log("normalSkill 技没有找到敌人");
            }

            PlayerConfig.CoolCD();
        }
    }
    public virtual void BigBeginFunc()
    {
        PlayerConfig.ResetCDTianQian();//重置普攻
    }
    public virtual void BigEndFunc()
    {
        //--被诅咒：
        if (isGetZuzhouTrigger)
        {
            int curBigTime = PlayerConfig.GetCurBig();

            if (curBigTime > zuZhouGet_skillReleaseBigTime)
            {
                SetGetZuZhouData(false);
            }
        }
    }

    public virtual void LoseHP(int subHp)
    {
        string playerName = gameObject.name;
        if (curSheid >0)
        {
            Debug.Log(playerName + "护盾抵抗一次 curSheid:" + curSheid);

            SetSheild(curSheid - 1);

            return;
        }
       
        Debug.Log(playerName+ "掉血！ curHP：" + curHP + "掉血量："+ subHp + "防御值："+ DefendVal);

        int loseHp = (subHp - DefendVal);
        if(loseHp > 0)
        {
            curHP = curHP - loseHp;
            Debug.Log(playerName + "扣血后 curHP：" + curHP );
            if (curHP <= 0)
            {
                Die();
                Debug.Log(playerName + "死亡！！ ");
            }
        }
    }

    public virtual void Die()
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
