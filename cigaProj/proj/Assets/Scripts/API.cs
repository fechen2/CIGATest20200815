//--------------------------------------------------------------------
// 文件名	:   API
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using GameRisker.BasicLib.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Lua
{
	public class API : MonoBehaviour
	{
        private static readonly ObjectEvent<GameEvent> s_objectEvent = new ObjectEvent<GameEvent>();

		public static ObjectEvent<GameEvent> GameEvent { get { return s_objectEvent; } }
	}
}