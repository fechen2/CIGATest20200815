﻿//--------------------------------------------------------------------
// 文件名	:   LookAt
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
	public class LookAt : MonoBehaviour
	{
		// Start is called before the first frame update
		void Start()
		{
			
		}

		// Update is called once per frame
		void Update()
		{
			transform.LookAt(Camera.main.transform);
		}
	}
}