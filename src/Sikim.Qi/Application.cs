using System;
using Sikim.Qi.Interop;

namespace Sikim.Qi
{
    public class Application
    {
        private readonly IntPtr _Handle;

        public Application(string[] args){
            int argc = args.Length;

            _Handle = ApplicationNative.Create(ref argc, args);
        }
    }
}
