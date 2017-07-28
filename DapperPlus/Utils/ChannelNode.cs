using System;
namespace DapperPlus.Utils
{
	internal class ChannelNode<T>
	{
		public ChannelNode(T data)
		{
			Data = data;
		}

		public T Data
		{
			get;
			set;
		}

		public ChannelNode<T> Per
		{
			get;
			set;
		}

		public ChannelNode<T> Next
		{
			get;
			set;
		}
	}
}
