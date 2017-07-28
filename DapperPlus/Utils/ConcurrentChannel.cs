using System;
using System.Collections.Generic;
using System.Threading;

namespace DapperPlus.Utils
{
    public class ConcurrentChannel<T>
    {
        private readonly object syncRoot;
        private ChannelNode<T> head;
        private ChannelNode<T> tail;
        private int count;
        private int cap;
        private bool completedWrite;

		public ConcurrentChannel() : this(0)
		{
		}

        public ConcurrentChannel(int cap)
        {
            this.cap = cap;
            this.syncRoot = new object();
        }

        public bool TryRead(ref T item)
        {
            bool success = false;
            lock (syncRoot)
            {
                if (count == 0)
                {
                    success = false;
                    item = default(T);
                }
                else
                {
                    success = false;
                    item = ReadCore();
                }
            }
            return success;
        }

        public T Read(int timeout = 0)
        {
            T item = default(T);
            lock (syncRoot)
            {
                if (count == 0)
                {
                    Monitor.Wait(syncRoot, timeout);
                }
                else
                {
                    item = ReadCore();
                    Monitor.Pulse(syncRoot); // notify writeable
                }
            }
            return item;
        }

        public void Write(T item, int timeout = 0)
        {
            lock (syncRoot)
            {
                if (completedWrite)
                {
                    return;
                }

                if (cap > 0)
                {
                    if (count >= cap)
                    {
                        Monitor.Wait(syncRoot, timeout);
                    }
                    else
                    {
                        WriteCore(item);
                        Monitor.Pulse(syncRoot); // notify readable
                    }
                }
                else
                {
                    WriteCore(item);
                    Monitor.Pulse(syncRoot); // notify readable
                }
            }
        }

        public void Remove(T item)
        {
            lock (syncRoot)
            {
                ChannelNode<T> node = head;
                while (node != null)
                {
                    if (object.Equals(node.Data, item))
                    {
                        break;
                    }
                }

                if (node != null)
                {
                    if (node.Per == null)
                    {
                        // head
                        head = node.Next;
                        node.Per = null;
                    }
                    else
                    {
                        node.Per.Next = node.Next;
                        node.Per = null;
                        node.Next = null;
                    }
                    count--;
                }
            }
        }

        public void CompleteWrite()
        {
            lock (syncRoot)
            {
                completedWrite = true;
            }
        }

        public int Count
        {
            get
            {
                lock (syncRoot)
                {
                    return count;
                }
            }
        }

        private T ReadCore()
        {
            T item = head.Data;
            ChannelNode<T> tmp = head;
            head = head.Next;
            head.Per = null;
            tmp.Next = null;
            count--;
            return item;
        }

        private void WriteCore(T item)
        {
            ChannelNode<T> node = new ChannelNode<T>(item);
            if (count == 0)
            {
                head = node;
                tail = head;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            count++;
        }
    }
}
