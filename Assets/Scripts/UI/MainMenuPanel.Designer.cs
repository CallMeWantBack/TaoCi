using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.Example
{
	// Generate Id:3460d89b-902b-430d-b875-04ec56bc8d92
	public partial class MainMenuPanel
	{
		public const string Name = "MainMenuPanel";
		
		[SerializeField]
		public UnityEngine.UI.Button CeramicTrain_Btn;
		[SerializeField]
		public UnityEngine.UI.Button CeramicExamine_Btn;
		[SerializeField]
		public UnityEngine.UI.Button KnowledgeLearning_Btn;
		[SerializeField]
		public UnityEngine.UI.Button KnowledgeExamine_Btn;
		[SerializeField]
		public UnityEngine.UI.Button ExperimentalReport_Btn;
		
		private MainMenuPanelData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			CeramicTrain_Btn = null;
			CeramicExamine_Btn = null;
			KnowledgeLearning_Btn = null;
			KnowledgeExamine_Btn = null;
			ExperimentalReport_Btn = null;
			
			mData = null;
		}
		
		public MainMenuPanelData Data
		{
			get
			{
				return mData;
			}
		}
		
		MainMenuPanelData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new MainMenuPanelData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
