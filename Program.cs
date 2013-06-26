/*
* Copyright 2005-2012 ONIX SOLUTIONS LIMITED. All rights reserved. 
* 
* This software owned by ONIX SOLUTIONS LIMITED [ONIXS] and is protected by copyright law 
* and international copyright treaties. 
* 
* Access to and use of the software is governed by the terms of the applicable ONIXS Software
* Services Agreement (the Agreement) and Customer end user license agreements granting 
* a non-assignable, non-transferable and non-exclusive license to use the software 
* for it's own data processing purposes under the terms defined in the Agreement.
* 
* Except as otherwise granted within the terms of the Agreement, copying or reproduction of any part 
* of this source code or associated reference material to any other location for further reproduction
* or redistribution, and any amendments to this copyright notice, are expressly prohibited. 
*
* Any reproduction or redistribution for sale or hiring of the Software not in accordance with 
* the terms of the Agreement is a violation of copyright law. 
*/

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using FIXForge.NET.FIX;

namespace CmeFastHandlerSample
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
#if DEBUG
                File.Delete("TraceLog.txt");
#endif

                Application.ThreadException += OnThreadException;
                AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var settings = new EngineSettings {Dialect = "Templates/UdpFastFixDialect.xml", LicenseStore = "Licenses"};
                Engine.Init(settings);

                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception During Initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Trace.WriteLine("Unhandled Exception:" + e.ExceptionObject);
            Trace.Flush();

            MessageBox.Show(e.ExceptionObject.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
            Environment.Exit(2);
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Trace.WriteLine("Unhandled Exception:" + e.Exception);
            Trace.Flush();

            MessageBox.Show(e.Exception.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
            Environment.Exit(1);
        }
    }
}