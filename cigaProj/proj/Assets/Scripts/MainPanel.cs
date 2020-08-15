//--------------------------------------------------------------------
// 文件名	:   MainPanel
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
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.Lua
{
	public class MainPanel : MonoBehaviour
	{
		public Button leftButtonA;
		public Button leftButtonB;
		public Button leftButtonC;

		public Button rightButtonA;
		public Button rightButtonB;
		public Button rightButtonC;

        public Button playButton;

        public Text systemPromptTxt;

        public GameObject messageObj;
        public Button buttonSure;
        public Button buttonCannel;
        public Text messageTxt;
        private System.Action<bool> m_mssageBoxAction;

        public Text roundText;

        private Unit m_selectedUnit;

        public static MainPanel Instance;

        /// <summary>
        /// 当前回合数
        /// </summary>
        public int round { get; set; } = 1;
        /// <summary>
        /// 当前回合第几步
        /// </summary>
        public int step { get; set; } = 0;

        private void Start()
        {
            Instance = this;

            leftButtonA.onClick.AddListener(OnClickLeftAButtonAHandler);
			leftButtonB.onClick.AddListener(OnClickLeftBButtonAHandler);
			leftButtonC.onClick.AddListener(OnClickLeftCButtonAHandler);

			rightButtonA.onClick.AddListener(OnClickRightAButtonAHandler);
			rightButtonB.onClick.AddListener(OnClickRightBButtonAHandler);
			rightButtonC.onClick.AddListener(OnClickRightCButtonAHandler);

            buttonSure.onClick.AddListener(OnClickSureHandler);
            buttonCannel.onClick.AddListener(OnClickCannelHandler);

            playButton.onClick.AddListener(OnClickPlayHandler);

            API.GameEvent.Add(GameEvent.SystemTxt, OnRecivedSystemTxtHandler);

            messageObj.SetActive(false);
            systemPromptTxt.gameObject.SetActive(false);
        }

        private void OnClickPlayHandler()
        {
            if (step == 3)
            {
                round++;
                step = 0;
            }
            step++;
            roundText.text = string.Format("R:{0} S:{1}", round, step);
            Map.Instance.Play();
        }

        public void ShowMessageBox(string txt,System.Action<bool> callback)
        {
            messageObj.SetActive(true);
            messageTxt.text = txt;
            m_mssageBoxAction = callback;
        }

        private void OnClickCannelHandler()
        {
            m_mssageBoxAction?.Invoke(false); 
            messageObj.SetActive(false);
        }

        private void OnClickSureHandler()
        {
            m_mssageBoxAction?.Invoke(true); 
            messageObj.SetActive(false);
        }

        private void OnRecivedSystemTxtHandler(object value)
        {
            systemPromptTxt.gameObject.SetActive(true);
            systemPromptTxt.text = value.ToString();
            Invoke("OnDelayTimeHandler",2);
        }

        private void OnDelayTimeHandler()
        {
            systemPromptTxt.gameObject.SetActive(false);
        }

        private void OnClickRightCButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.RIGHT.ToString() + "2");
            m_selectedUnit.Selected();
        }

        private void OnClickRightBButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.RIGHT.ToString() + "1");
            m_selectedUnit.Selected();
        }

        private void OnClickRightAButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.RIGHT.ToString() + "0");
            m_selectedUnit.Selected();
        }

        private void OnClickLeftCButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.LEFT.ToString() + "2");
            m_selectedUnit.Selected();
        }

        private void OnClickLeftBButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.LEFT.ToString() + "1");
            m_selectedUnit.Selected();
        }

        private void OnClickLeftAButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.LEFT.ToString() + "0");
            m_selectedUnit.Selected();
        }
    }
}