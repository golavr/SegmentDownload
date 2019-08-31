using System.Reflection;
using System.Threading;

namespace SegmentDownloader.Core
{
    public static class ThreadEx
    {
        public static void Abort(this Thread thread)
        {
            MethodInfo abort = null;
            var abortMethod = thread.GetType().GetRuntimeMethod("AbortInternal",null);
            abortMethod.Invoke(thread, new object[0]);

            //foreach (MethodInfo m in thread.GetType().GetRuntimeMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            //{
            //    if (m.Name.Equals("AbortInternal") && m.GetParameters().Length == 0) abort = m;
            //}
            //if (abort == null)
            //{
            //    throw new Exception("Failed to get Thread.Abort method");
            //}
            //abort.Invoke(thread, new object[0]);
        }
    }
}