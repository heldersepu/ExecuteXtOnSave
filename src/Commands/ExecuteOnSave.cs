using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Diagnostics;
using System.Linq;

namespace ExecuteXtOnSave
{
    class ExecuteOnSave : IOleCommandTarget
    {
        private string _filePath;
        private IOleCommandTarget _nextCommandTarget;
        private static Guid _cmdGgroup = typeof(VSConstants.VSStd97CmdID).GUID;
        private static uint[] _cmdId = new[] {
            (uint)VSConstants.VSStd97CmdID.SaveProjectItem,
            (uint)VSConstants.VSStd97CmdID.SaveSolution };

        public ExecuteOnSave(IVsTextView textViewAdapter, string filePath)
        {
            textViewAdapter.AddCommandFilter(this, out _nextCommandTarget);
            _filePath = filePath;
        }

        public int QueryStatus(ref Guid pguidCmdGroup, uint cCmds, OLECMD[] prgCmds, IntPtr pCmdText)
        {
            return _nextCommandTarget.QueryStatus(ref pguidCmdGroup, cCmds, prgCmds, pCmdText);
        }

        public int Exec(ref Guid pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
        {
            if (VSPackage.Options.ExecuteXtOnSave)
            {
                if (pguidCmdGroup == _cmdGgroup && _cmdId.Contains(nCmdID))
                {
                    if (string.IsNullOrEmpty(VSPackage.Options.ExecuteXtCommand))
                        Debug.WriteLine("ExecuteXtCommand is empty...");
                    else
                    {
                        //TODO
                    }
                }
            }

            return _nextCommandTarget.Exec(ref pguidCmdGroup, nCmdID, nCmdexecopt, pvaIn, pvaOut);
        }
    }
}
