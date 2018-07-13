using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace UnityDarkThemeEnabler
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Dark mode
        /// </summary>
        private static byte[] bytesToPatch_ENABLED =  { 0x84, 0xC0, 0x74, 0x08, 0x33, 0xC0, 0x48, 0x83, 0xC4, 0x20, 0x5B, 0xC3, 0x8B, 0x03, 0x48, 0x83, 0xC4, 0x20, 0x5B, 0xC3 };
        /// <summary>
        /// Light mode
        /// </summary>
        private static byte[] bytesToPatch_DISABLED = { 0x84, 0xC0, 0x75, 0x08, 0x33, 0xC0, 0x48, 0x83, 0xC4, 0x20, 0x5B, 0xC3, 0x8B, 0x03, 0x48, 0x83, 0xC4, 0x20, 0x5B, 0xC3 };
        
        private string unityExePath;
        private byte[] unityExecutableContents;

        public Form1()
        {
            InitializeComponent();
        }

        #region Buttons events
        private void btn_selectUnityExe_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                unityExePath = openFileDialog.FileName;
                if (File.Exists(unityExePath))
                {
                    unityExecutableContents = File.ReadAllBytes(unityExePath);
                    if(checkUnityComatibility(unityExecutableContents))
                    {
                        btn_enable.Enabled = true;
                        btn_disable.Enabled = true;
                        MessageBox.Show("Successfully selected Unity.exe, now you can enable or disable dark mode", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    MessageBox.Show("Error: this Unity version is not compatibile with this tool", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                else
                {
                    MessageBox.Show("Not valid path. Please select a valid Unity.exe file.");
                    btn_enable.Enabled = false;
                    btn_disable.Enabled = false;
                }
            }
        }

        private void btn_enable_Click(object sender, EventArgs e)
        {
            patchUnityExe(bytesToPatch_DISABLED, bytesToPatch_ENABLED, "ENABLE");
        }
        private void btn_disable_Click(object sender, EventArgs e)
        {
            patchUnityExe(bytesToPatch_ENABLED, bytesToPatch_DISABLED, "DISABLE");
        }

        #endregion

        #region Unity specific events

        /// <summary>
        /// Patches Unity executable and manages MessageBoxes messages
        /// </summary>
        /// <param name="bytesToFind"></param>
        /// <param name="bytesPatch"></param>
        /// <param name="actionDescription"></param>
        private void patchUnityExe(byte[] bytesToFind, byte[] bytesPatch, string actionDescription)
        {
            string excMessage;
            bool patchResult = patchAtIndex(unityExePath,
                findPatternIndex(unityExecutableContents, bytesToFind),
                bytesPatch, out excMessage);

            if (patchResult)
            {
                MessageBox.Show("Successfully " + actionDescription + "! Now launching Unity 3D", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(unityExePath);
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Error while patching Unity 3D: " + Environment.NewLine + excMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        /// <summary>
        /// Checks if an exe is compatibile with this program.
        /// </summary>
        /// <param name="unityExecutableContents">Contents of the exe file</param>
        /// <returns></returns>
        public static bool checkUnityComatibility(byte[] unityExecutableContents)
        {
            return !(findPatternIndex(unityExecutableContents, bytesToPatch_ENABLED) == -1 &&
                findPatternIndex(unityExecutableContents, bytesToPatch_DISABLED) == -1);
        }

        #endregion

        #region Patching util

        /// <summary>
        /// Patches bytes at the specified index in a file and saves it.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="index"></param>
        /// <param name="patchBytes"></param>
        /// <param name="excMessage"></param>
        /// <returns></returns>
        public static bool patchAtIndex(string fileName, int index, byte[] patchBytes, out string excMessage)
        {
            excMessage = null;
            try
            {
                using (Stream stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    stream.Seek(index, SeekOrigin.Begin);
                    stream.Write(patchBytes, 0, patchBytes.Length);
                }
            }catch(Exception exc)
            {
                excMessage = exc.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Finds a pattern index in a src bytes array.
        /// </summary>
        /// <param name="src"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        static int findPatternIndex(byte[] src, byte[] pattern)
        {
            int c = src.Length - pattern.Length + 1;
            int j;
            for (int i = 0; i < c; i++)
            {
                if (src[i] != pattern[0]) continue;
                for (j = pattern.Length - 1; j >= 1 && src[i + j] == pattern[j]; j--) ;
                if (j == 0) return i;
            }
            return -1;
        }

        #endregion
    }
}
