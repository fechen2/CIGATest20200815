//--------------------------------------------------------------------
// 文件名	:   Unit
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.Lua
{
	public enum TaskType
	{
		None,
		Move,
		Attack,
		Skill,
	}

	public class Unit : MonoBehaviour
	{
		public int index;

		public Vector2Int curPos { get; private set; }

		public bool isMoving { get; private set; }

		private int m_index = 0;

		private Vector3 m_targetPos;

		private System.Action m_action;

		public float speed = 5;

		public CampType campType;

		public string uniqueId { get; set; }

		private Renderer m_renderer;

		private object m_taskParam;
		private TaskType m_taskType;
		private bool m_isCompeteSetTask;

		public bool selected { get; private set; }
		public void Init(Vector2Int pos)
		{
			curPos = pos;
			m_renderer = GetComponent<Renderer>();
			m_originalColor = m_renderer.material.color;
		}

		private Color m_originalColor;

		public int ability = 3;

		public void Selected()
		{
			if (!m_isCompeteSetTask)
			{
				selected = true;
				m_renderer.material.DOColor(Color.yellow, 0.5f).SetLoops(-1, LoopType.Yoyo);
				ShowGrid(ability);
			}
		}

		public void UnSelected()
		{
			if (!m_isCompeteSetTask)
			{
				selected = false;
				m_renderer.material.DOKill();
				m_renderer.material.color = m_originalColor;
				HideGrid(ability);
			}
		}

		public void SetTask(TaskType taskType,object param)
		{
			m_taskType = taskType;
			m_taskParam = param;

			gameObject.SetColor(Color.green);
			m_isCompeteSetTask = true;
		}

		public void Play()
		{
			switch (m_taskType)
			{
				case TaskType.Move:
					PlayMove();
					break;
				case TaskType.Attack:
					PlayAttack();
					break;
				case TaskType.Skill:
					PlaySkill();
					break;
				default:

					break;
			}
		}

		private void PlayMove()
		{
			Vector2Int[]  paths = m_taskParam as Vector2Int[];
			if (paths != null)
			{
				Vector3[] path3 = paths.Select((Vector2Int pos, int idx) => { return pos.ToVector3(1.5f); }).ToArray();
				Tweener tweener = transform.DOPath(path3, 1).SetSpeedBased().SetEase(Ease.Linear);
				tweener.OnComplete(OnMoveCompleteHandler);
				tweener.OnWaypointChange(OnMoveStepCompleteHandler);
			}
		}

		private void OnMoveStepCompleteHandler(int value)
		{
			Debug.LogError("OnMoveStepCompleteHandler value = "+ value.ToString());
		}

        private void OnMoveCompleteHandler()
        {
			Debug.LogError("OnMoveCompleteHandler");
			TaskComplete();
		}

        private void PlayAttack()
		{ 
		
		}

		private void PlaySkill()
		{

		}

		private void TaskComplete()
		{
			gameObject.SetColor(m_originalColor);
		}

		//private void SetDestination(Vector2Int[] path, System.Action action)
		//{
		//	m_index = 0;
		//	m_action = action;
		//	if (TryGetTargetPos(out Vector3 pos))
		//	{
		//		m_targetPos = pos;
		//		isMoving = true;
		//	}
		//}

		//private bool TryGetTargetPos(out Vector3 vector3)
		//{
		//	if (m_pathVectors != null)
		//	{
		//		if (m_index < m_pathVectors.Length)
		//		{
		//			Vector2Int vector2 = m_pathVectors[m_index++];
		//			vector3 = new Vector3(vector2.x, 0, vector2.y);
		//			return true;
		//		}
		//	}
		//	vector3 = Vector3.zero;
		//	return false;
		//}

		// Update is called once per frame
		//void Update()
		//{
		//	if (isMoving)
		//	{
		//		if (Vector3.Distance(transform.position, m_targetPos) > 0.1f)
		//		{
		//			m_targetPos.y = transform.position.y;
		//			transform.position = Vector3.Lerp(transform.position, m_targetPos, Time.deltaTime * speed);
		//		}
		//		else
		//		{
		//			curPos = m_targetPos.ToVector2Int();
		//			if (TryGetTargetPos(out Vector3 pos))
		//			{
		//				m_targetPos = pos;
		//			}
		//			else
		//			{
		//				isMoving = false;//移动结束
		//				m_action?.Invoke();
		//			}
		//		}
		//	}
		//}


		public void ShowGrid(int ability)
		{
			Map.Instance.ShowGrid(this);
		}

		public void HideGrid(int ability)
		{
			Map.Instance.HideGrid(this);
		}
	}
}