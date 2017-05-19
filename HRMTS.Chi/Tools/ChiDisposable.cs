using System;

namespace HRMTS.Chi.Tools
{
    public abstract class ChiDisposable : IDisposable
    {
        public bool IsDisposed { get; set; }
        public void Dispose()
        {
            if (!IsDisposed)
            {
                Dispose(true);
                IsDisposed = true;

            }

            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }
}
