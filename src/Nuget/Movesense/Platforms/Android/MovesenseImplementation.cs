﻿using Com.Movesense.Mds;
using MdsLibrary;
using MdsLibrary.Api;
using MdsLibrary.Model;
using Plugin.Movesense.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Plugin.Movesense
{
    /// <summary>
    /// Implementation for the IMovesense plugin access interface
    /// </summary>
    public partial class MovesenseImplementation : IMovesense
    {
        private static Mds instance = null;
        private static readonly object padlock = new object();

        private static Android.App.Activity AndroidActivity = null;

        /// <summary>
        /// Root of all paths to Movesense resources.
        /// </summary>
        public string SCHEME_PREFIX => "suunto://";

        /// <summary>
        /// Gets the native MdsLib object
        /// </summary>
        public object MdsInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        if (AndroidActivity == null)
                        {
                            throw new InvalidOperationException("Set Plugin.Movesense.CrossMovesense.Current.Activity to current Android.App.Activity before calling MdsInstance");
                        }

                        instance = new Mds.Builder().Build(AndroidActivity);
                    }
                    return instance;
                }
            }
        }

        /// <summary>
        /// On Android, Activity must be set to the current Android Activity before first access of the library.
        /// </summary>
        public object Activity { set => MovesenseImplementation.AndroidActivity = value as Android.App.Activity; }

    }
}
