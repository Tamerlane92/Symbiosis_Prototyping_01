#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System;


public class AkWwiseMenu_Mac : MonoBehaviour {

	private static AkUnityPluginInstaller_Mac m_installer = new AkUnityPluginInstaller_Mac();

	// private static AkUnityIntegrationBuilder_Mac m_builder = new AkUnityIntegrationBuilder_Mac();

	[MenuItem("Assets/Wwise/Install Plugins/Mac/Debug", false, (int)AkWwiseMenuOrder.MacDebug)]
	public static void InstallPlugin_Debug () {
		m_installer.InstallPluginByConfig("Debug");
	}

	[MenuItem("Assets/Wwise/Install Plugins/Mac/Profile", false, (int)AkWwiseMenuOrder.MacProfile)]
	public static void InstallPlugin_Profile () {
		m_installer.InstallPluginByConfig("Profile");
	}

	[MenuItem("Assets/Wwise/Install Plugins/Mac/Release", false, (int)AkWwiseMenuOrder.MacRelease)]
	public static void InstallPlugin_Release () {
		m_installer.InstallPluginByConfig("Release");
	}


    [MenuItem("Help/Wwise Help/Mac", false, (int)AkWwiseHelpOrder.WwiseHelpOrder)]
    public static void OpenDocMac () 
    {
 		string DestPath = AkUtilities.GetFullPath(Application.dataPath, "..");
		string docPath = string.Format ("{0}/WwiseUnityIntegrationHelp_AppleCommon_en/index.html", DestPath);
		if (!File.Exists (docPath))
		{
			WwiseSetupWizard.UnzipHelp(DestPath);
		}

		if( File.Exists(docPath))
		{
        	AkDocHelper.OpenDoc(docPath);
        }
        else
        {
        	UnityEngine.Debug.Log("Wwise: Unable to show documentation. Please unzip WwiseUnityIntegrationHelp_AppleCommon_en.zip manually.");
        }
    }
    
//	[MenuItem("Assets/Wwise/Rebuild Integration/Mac/Debug")]
//	public static void RebuildIntegration_Debug () {
//		m_builder.BuildByConfig("Debug", null);
//	}
//
//	[MenuItem("Assets/Wwise/Rebuild Integration/Mac/Profile")]
//	public static void RebuildIntegration_Profile () {
//		m_builder.BuildByConfig("Profile", null);
//	}
//
//	[MenuItem("Assets/Wwise/Rebuild Integration/Mac/Release")]
//	public static void RebuildIntegration_Release () {
//		m_builder.BuildByConfig("Release", null);
//	}
}


public class AkUnityPluginInstaller_Mac : AkUnityPluginInstallerBase
{
	public AkUnityPluginInstaller_Mac()
	{
		m_platform = "Mac";
	}
}


public class AkUnityIntegrationBuilder_Mac : AkUnityIntegrationBuilderBase
{
	public AkUnityIntegrationBuilder_Mac()
	{
		m_platform = "Mac";
	}
}

#endif // #if UNITY_EDITOR