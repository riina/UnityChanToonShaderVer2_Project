﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

// GameViewSizeHelper
// https://github.com/anchan828/unity-GameViewSizeHelper

namespace Unity.Toonshader.EditorTests
{
    public class SetupAndGrabScreen
    {
        const string filenameExtenstion = ".png";
        const string testReferenceFilaneme = "LightAndShadows";
        const string testTargetFilename = "UtsTestImage";
        static Texture2D s_refereceTexure2D;
        static Texture2D s_capturedTexture2D;

        [MenuItem("Edit/Unity Toon shader test/Setup Scene")]
        private static void SetupScene()
        {
            Debug.Log("SetupScene");
            var scenePath = "Assets/Legacy/Sample Scenes/LightAndShadows/LightAndShadows.unity";

            EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            SetupGameViewSize();
        }
        private static void SetupGameViewSize()
        {

            int width = 1920;
            int height = 1080;
            string viewSizeName = string.Format("{0} * {1}", width, height);
            GameViewSizeHelper.AddCustomSize(GameViewSizeGroupType.Standalone, GameViewSizeHelper.GameViewSizeType.FixedResolution, width, height, viewSizeName);
            GameViewSizeHelper.ChangeGameViewSize(GameViewSizeGroupType.Standalone, GameViewSizeHelper.GameViewSizeType.FixedResolution, width, height, viewSizeName);
        }
        [MenuItem("Edit/Unity Toon shader test/Capture Screen and Test Iamge")]
        private static void CreateTestImage()
        {
            ScreenCapture.CaptureScreenshot(testTargetFilename + filenameExtenstion);
        }

        [MenuItem("Edit/Unity Toon shader test/Create Reference Iamge")]
        private static void CreateRenferenceImage()
        {
            ScreenCapture.CaptureScreenshot(testReferenceFilaneme + filenameExtenstion);
        }

        [MenuItem("Edit/Unity Toon shader test/Execute test")]
        private static void ExecuteTest()
        {
        //    s_refereceTexure2D = LoadPNG();
        //    s_capturedTexture2D = LoadPNG();
        }

        public static Texture2D LoadPNG(string filePath)
        {

            Texture2D tex2D = null;
            byte[] fileData;

            if (File.Exists(filePath))
            {
                fileData = File.ReadAllBytes(filePath);
                tex2D = new Texture2D(2, 2);
                tex2D.LoadImage(fileData); 
            }
            return tex2D;
        }
    }

}