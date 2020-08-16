//--------------------------------------------------------------------
// 文件名	:   MoveTask
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.Lua
{

	public class SkillTask : Task
	{
		private PlayerBase playerBase;

		private string playSkillName;
		public SkillTask(PlayerBase unit, string skillName)
		{
			playerBase = unit;
			playSkillName = skillName;
		}

        public override void ShowSimulation()
        {
            base.ShowSimulation();
		}

        public override void HideSumulation()
        {
			//GameObject.Destroy(m_gameObject);
		}

        override public void Play(System.Action action)
		{
			base.Play(action);
			playerBase.RealPlaySkill();
		}

		private void OnMoveStepCompleteHandler(int value)
		{

		}

		private void OnMoveCompleteHandler()
		{
			Complete();
		}
	}
}