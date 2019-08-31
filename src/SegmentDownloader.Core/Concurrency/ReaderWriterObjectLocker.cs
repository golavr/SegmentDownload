using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SegmentDownloader.Core.Concurrency
{
    public class ReaderWriterObjectLocker
    {
        #region BaseReleaser
        class BaseReleaser
        {
            protected ReaderWriterObjectLocker locker;

            public BaseReleaser(ReaderWriterObjectLocker locker)
            {
                this.locker = locker;
            }
        }
        #endregion

        #region ReaderReleaser
        class ReaderReleaser : BaseReleaser, IDisposable
        {
            public ReaderReleaser(ReaderWriterObjectLocker locker)
                : base(locker)
            {
            }

            #region IDisposable Members

            public void Dispose()
            {
                locker.locker.ExitReadLock();
            }

            #endregion
        }
        #endregion

        #region WriterReleaser
        class WriterReleaser : BaseReleaser, IDisposable
        {
            public WriterReleaser(ReaderWriterObjectLocker locker)
                : base(locker)
            {
            }

            #region IDisposable Members

            public void Dispose()
            {
                locker.locker.ExitWriteLock();
            }

            #endregion
        }
        #endregion

        #region Fields
        private ReaderWriterLockSlim locker;
        private IDisposable writerReleaser;
        private IDisposable readerReleaser; 
        #endregion

        #region Constructor
        public ReaderWriterObjectLocker()
        {
            locker = new ReaderWriterLockSlim();

            writerReleaser = new WriterReleaser(this);
            readerReleaser = new ReaderReleaser(this);
        } 
        #endregion

        #region Methods
        public IDisposable LockForRead()
        {
            locker.EnterReadLock();

            return readerReleaser;
        }

        public IDisposable LockForWrite()
        {
            locker.EnterWriteLock();

            return writerReleaser;
        } 
        #endregion
    }
}
