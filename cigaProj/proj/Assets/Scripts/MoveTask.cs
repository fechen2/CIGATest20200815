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

	/// <summary>
	/// 移动任务
	/// </summary>
	public class MoveTask : Task
	{
		private Unit m_unit;

		private Vector2Int[] m_paths;
		public Vector2Int[] paths { get { return m_paths; } }

		private Vector2Int m_targetPos;

		private GameObject m_gameObject;

		public MoveTask(Unit unit, Vector2Int[] paths , Vector2Int target)
		{
			m_unit = unit;
			m_paths = paths;
			m_targetPos = target;
		}

        public override void ShowSimulation()
        {
            base.ShowSimulation();
			m_gameObject = GameObject.Instantiate(m_unit.gameObject);
			m_gameObject.transform.position = m_targetPos.ToVector3(1.5f);
			m_gameObject.SetAlpha(0.3f);
			
			m_unit.UnSelected();

			Unit unit = m_gameObject.GetComponent<Unit>();
			unit.uniqueId = m_unit.uniqueId;
			unit.unitType = UnitType.Clone;
			unit.Init(m_targetPos);
			unit.Selected();
			unit.parentUnit = m_unit;

			m_unit.AddChild(unit);

			Map.Instance.AddUnit(unit);
		}

        public override void HideSumulation()
        {
			GameObject.Destroy(m_gameObject);
		}

        override public void Play(System.Action action)
		{
			base.Play(action);
			if (m_paths != null)
			{
				Vector3[] path3 = m_paths.Select((Vector2Int pos, int idx) => { return pos.ToVector3(1.5f); }).ToArray();
				Tweener tweener = m_unit.transform.DOPath(path3, 3).SetSpeedBased().SetEase(Ease.Linear);
				tweener.OnComplete(OnMoveCompleteHandler);
				tweener.OnWaypointChange(OnMoveStepCompleteHandler);
			}
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