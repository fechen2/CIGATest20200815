//--------------------------------------------------------------------
// 文件名	:   Task
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Lua
{
	abstract public class Task
	{
		public int index { get; set; }

		protected System.Action m_action;

		virtual public void Play(System.Action action)
		{
			m_action = action;
		}

		virtual protected void Complete()
		{
			m_action?.Invoke();
		}

		virtual public void ShowSimulation()
		{

		}

		virtual public void HideSumulation()
		{

		}
	}
}