using System;
using System.Threading;
using System.Windows.Forms;

namespace ProgressBar
{
    internal static class ProgressController
    {
        private static Thread progressThread;
        private static ProgressForm progressWindow;

        // =========================
        // START PROGRESS BAR
        // =========================
        internal static void StartProgressBar(
            int stepSize = 0,
            double interval = 0.0,
            bool timerStatus = false,
            string progressLabel = "")
        {
            progressThread = new Thread(() =>
            {
                progressWindow = new ProgressForm();

                if (stepSize > 0)
                    progressWindow.setSetpSize(stepSize);

                if (interval > 0.0)
                    progressWindow.setInterval(interval);

                if (timerStatus)
                    progressWindow.setTimerStatus(timerStatus);

                if (!string.IsNullOrEmpty(progressLabel))
                    progressWindow.setProgressLabel(progressLabel);

                Application.Run(progressWindow); // message loop
            });

            progressThread.SetApartmentState(ApartmentState.STA);
            progressThread.IsBackground = true;
            progressThread.Start();
        }

        // =========================
        // INCREMENT PROGRESS
        // =========================
        internal static void IncrementProgressBar()
        {
            if (progressWindow != null && progressWindow.IsHandleCreated)
            {
                progressWindow.Invoke(new Action(() =>
                {
                    progressWindow.incrementProgressBar();
                }));
            }
        }

        // =========================
        // STOP PROGRESS BAR
        // =========================
        internal static void StopProgressBar()
        {
            if (progressWindow != null && progressWindow.IsHandleCreated)
            {
                progressWindow.Invoke(new Action(() =>
                {
                    progressWindow.setProgressLabel("Completed!");
                    Thread.Sleep(2000);
                    progressWindow.Close();
                }));

                progressThread.Join();
                progressWindow.Dispose();

                progressWindow = null;
                progressThread = null;
            }
        }
    }
}
