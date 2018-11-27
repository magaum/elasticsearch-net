﻿using System.Runtime.Serialization;

namespace Nest
{
	[DataContract]
	public interface IAcknowledgedResponse : IResponse
	{
		bool Acknowledged { get; }
	}

	[DataContract]
	public abstract class AcknowledgedResponseBase : ResponseBase, IAcknowledgedResponse
	{
		[DataMember(Name ="acknowledged")]
		public bool Acknowledged { get; internal set; }
	}
}
