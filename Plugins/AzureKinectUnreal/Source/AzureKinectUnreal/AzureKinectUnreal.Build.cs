// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class AzureKinectUnreal : ModuleRules
{
	public AzureKinectUnreal(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
				Path.Combine(ModuleDirectory, "Public")
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
				Path.Combine(ModuleDirectory, "Private")
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
				"Projects"
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);

		// Include Azure Kinect Sensor and Body Tracking SDKs
		string azureKinectSensorSDKPath = "E:/Program Files/Azure Kinect SDK v1.2.0/sdk";
		string azureKinectBodyTrackingSDKPath = "E:/Program Files/Azure Kinect Body Tracking SDK/sdk";

		PublicIncludePaths.AddRange(
			new string[] {
				Path.Combine(azureKinectSensorSDKPath, "include"),
				Path.Combine(azureKinectBodyTrackingSDKPath, "include")
			}
			);

		// Libs path
		PublicLibraryPaths.Add(Path.Combine(azureKinectSensorSDKPath, "windows-desktop", "amd64", "release", "lib"));
		PublicLibraryPaths.Add(Path.Combine(azureKinectBodyTrackingSDKPath, "windows-desktop", "amd64", "release", "lib"));

		// Dlls path = Project/Plugins/AzureKinectUnreal/ThirdParty/dlls
		// ModuleDirectory = Project/Plugins/AzureKinectUnreal/Source/AzureKinectUnreal
		//PublicLibraryPaths.Add(Path.Combine(ModuleDirectory, "../../ThirdParty", "dlls"));

		PublicAdditionalLibraries.AddRange(
			new string[]
			{
				"k4a.lib",
				"k4abt.lib"
			});

		// The dlls should be loaded in the Module's StartupModule
		// and released in the ShutdownModule.
		// Otherwise, put these dlls in Binaries folder and remove this PublicDelayLoadDLLs section
		PublicDelayLoadDLLs.AddRange(
			new string[]
			{
				"k4a.dll",
				"k4abt.dll",
				//"depthengine_2_0.dll",
				//"onnxruntime.dll",
				//"cudnn64_7.dll",
				//"cublas64_100.dll",
				//"cudart64_100.dll"
			});

		// Ensure that the DLL is staged along with the executable
		RuntimeDependencies.Add("k4a.dll"); //"$(PluginDir)/ThirdParty/dlls/k4a.dll"
		RuntimeDependencies.Add("k4abt.dll");    //Path.Combine(ModuleDirectory, "../../ThirdParty", "dlls", "k4abt.dll")
		RuntimeDependencies.Add("depthengine_2_0.dll");	//Path.Combine(ModuleDirectory, "../../ThirdParty", "dlls", "depthengine_2_0.dll")
		//RuntimeDependencies.Add("onnxruntime.dll");
		//RuntimeDependencies.Add("cudnn64_7.dll");
		//RuntimeDependencies.Add("cudart64_100.dll");
		//RuntimeDependencies.Add("cublas64_100.dll");
	}
}
