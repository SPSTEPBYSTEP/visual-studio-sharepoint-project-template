﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using $customUsing$.Common;

namespace $safeprojectname$
{
    public class InstallCustomActions:BaseOperation
    {
        public InstallCustomActions(SPWeb objSPWeb) : base(objSPWeb) { }

        public void RegisterCustomCoreInScriptLink()
        {
            SPUserCustomAction objSPUserCustomActionScript = null;
            objSPUserCustomActionScript = this.CurrentWeb.UserCustomActions.Add();


            if (!CommonFunctions.IsExistsCustomAction("CustomCore.Js", "ScriptLink", String.Empty, this.CurrentWeb))
            {
                objSPUserCustomActionScript.Location = "ScriptLink";
                objSPUserCustomActionScript.Name = "CustomCore.Js";
                objSPUserCustomActionScript.ScriptSrc = "/_layouts/replaceprojectname/JS/CustomCore.js";
                this.CurrentWeb.AllowUnsafeUpdates = true;
                objSPUserCustomActionScript.Update();
            }
        }
    }
}
