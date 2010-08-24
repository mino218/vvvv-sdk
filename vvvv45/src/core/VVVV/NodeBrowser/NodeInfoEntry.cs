﻿using System;
using System.Collections.Generic;

using VVVV.PluginInterfaces.V2;
using VVVV.Core;
using VVVV.Core.View;

namespace VVVV.Nodes.NodeBrowser
{
    /// <summary>
    /// Description of NodeInfoEntry.
    /// </summary>
    public class NodeInfoEntry: INamed, IDescripted, IDraggable
    {
        public INodeInfo NodeInfo;
        
        public event RenamedHandler Renamed;
        string FCategory;
        string FUsername;
        string FSystemname;
        string FTooltip;
        
        public NodeInfoEntry(INodeInfo nodeInfo): base()
        {
            NodeInfo = nodeInfo;
            FCategory = nodeInfo.Category;
            FUsername = nodeInfo.Username;
            FSystemname = nodeInfo.Systemname;
            
            FTooltip = "";
            switch (NodeInfo.Type)
            {
                    case TNodeType.Native: {FTooltip = ""; break;}
                    case TNodeType.Plugin: {FTooltip = "P  "; break;}
                    case TNodeType.Module: {FTooltip = "M  "; break;}
                    case TNodeType.Patch: {FTooltip = "V4P "; break;}
                    case TNodeType.Effect: {FTooltip = "FX  "; break;}
                    case TNodeType.Freeframe: {FTooltip = "FF  "; break;}
                    case TNodeType.VST: {FTooltip = "VST "; break;}
            }
            
            if (!string.IsNullOrEmpty(NodeInfo.Shortcut))
                FTooltip += "(" + NodeInfo.Shortcut + ") " ;
            if (!string.IsNullOrEmpty(NodeInfo.Help))
                FTooltip += NodeInfo.Help;
            if (!string.IsNullOrEmpty(NodeInfo.Warnings))
                FTooltip += "\n WARNINGS: " + NodeInfo.Warnings;
            if (!string.IsNullOrEmpty(NodeInfo.Bugs))
                FTooltip += "\n BUGS: " + NodeInfo.Bugs;
            if ((!string.IsNullOrEmpty(NodeInfo.Author)) && (NodeInfo.Author != "vvvv group"))
                FTooltip += "\n AUTHOR: " + NodeInfo.Author;
            if (!string.IsNullOrEmpty(NodeInfo.Credits))
                FTooltip += "\n CREDITS: " + NodeInfo.Credits;
        }
        
        public string Category
        {
            get {return FCategory;}
        }
        
        public string Name
        {
            get {return FUsername;}
        }
        
        public string Description
        {
            get{return FTooltip;}
        }
        
        public bool AllowDrag()
        {
            return true;
        }
        
        public object ItemToDrag()
        {
            return FSystemname;
        }
    }
}