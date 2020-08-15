//--------------------------------------------------------------------
// 文件名	:   Move
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Lua
{
	public class Move : MonoBehaviour
	{
		public Vector2Int[] m_pathVectors;

		public bool isMoving = false;

		private int m_index = 0;

		private Vector3 m_targetPos;

		private System.Action m_action;

		public void SetDestination(Vector2Int[] vectors , System.Action action)
		{
			m_pathVectors = vectors;
			m_index = 0;
			m_action = action;
			if (TryGetTargetPos(out Vector3 pos))
			{
				m_targetPos = pos;
				isMoving = true;
			}
		}

		private bool TryGetTargetPos(out Vector3 vector3)
		{
			if (m_pathVectors != null)
			{
				if (m_index < m_pathVectors.Length)
				{
					Vector2Int vector2 = m_pathVectors[m_index++];
					vector3 = new Vector3(vector2.x,0, vector2.y);
					return true;
				}
			}
			vector3 = Vector3.zero;
			return false;
		}

		// Update is called once per frame
		void Update()
		{
			if (isMoving)
			{
				if (Vector3.Distance(transform.position, m_targetPos) > 0.1f)
				{
					transform.Translate(m_targetPos);
				}
				else if (TryGetTargetPos(out Vector3 pos))
				{
					m_targetPos = pos;
				}
				else
				{
					isMoving = false;//移动结束
					m_action?.Invoke();
				}
			}
		}

	}
}