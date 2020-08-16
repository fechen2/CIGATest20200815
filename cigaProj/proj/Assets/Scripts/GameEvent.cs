//--------------------------------------------------------------------
// 文件名	:   GameEvent
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
	public enum GameEvent
	{
		CLICK_TILE = 0,
        SystemTxt = 1,
        ShowSkillWindow = 2,
        TASK_EXECUTE_FINISHED = 3,
        RESET_GAME = 4,
    }
}