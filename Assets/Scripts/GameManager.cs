using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Paul
{
    public static class GameManager
    {

        public static void Quit()
        {
            EditorApplication.isPlaying = false;
        }
    }
}
