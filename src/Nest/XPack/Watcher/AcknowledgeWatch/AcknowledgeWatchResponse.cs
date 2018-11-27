﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Nest
{
	public interface IAcknowledgeWatchResponse : IResponse
	{
		[DataMember(Name ="status")]
		WatchStatus Status { get; }
	}

	public class AcknowledgeWatchResponse : ResponseBase, IAcknowledgeWatchResponse
	{
		public WatchStatus Status { get; internal set; }
	}

	[DataContract]
	public class WatchStatus
	{
		[DataMember(Name ="actions")]
		public IReadOnlyDictionary<string, ActionStatus> Actions { get; set; }

		[DataMember(Name ="last_checked")]
		public DateTimeOffset? LastChecked { get; set; }

		[DataMember(Name ="last_met_condition")]
		public DateTimeOffset? LastMetCondition { get; set; }

		[DataMember(Name ="state")]
		public ActivationState State { get; set; }

		[DataMember(Name ="version")]
		public int? Version { get; set; }
	}

	public class ActionStatus
	{
		[DataMember(Name ="ack")]
		public AcknowledgeState Acknowledgement { get; set; }

		[DataMember(Name ="last_execution")]
		public ExecutionState LastExecution { get; set; }

		[DataMember(Name ="last_successful_execution")]
		public ExecutionState LastSuccessfulExecution { get; set; }

		[DataMember(Name ="last_throttle")]
		public ThrottleState LastThrottle { get; set; }
	}

	[DataContract]
	public class ActivationState
	{
		[DataMember(Name ="active")]
		public bool Active { get; set; }

		[DataMember(Name ="timestamp")]
		public DateTimeOffset Timestamp { get; set; }
	}

	[DataContract]
	public class AcknowledgeState
	{
		[DataMember(Name ="state")]
		public AcknowledgementState State { get; set; }

		[DataMember(Name ="timestamp")]
		public DateTimeOffset Timestamp { get; set; }
	}

	[DataContract]
	public class ExecutionState
	{
		[DataMember(Name ="successful")]
		public bool Successful { get; set; }

		[DataMember(Name ="timestamp")]
		public DateTimeOffset Timestamp { get; set; }
	}

	[DataContract]
	public class ThrottleState
	{
		[DataMember(Name ="reason")]
		public string Reason { get; set; }

		[DataMember(Name ="timestamp")]
		public DateTimeOffset Timestamp { get; set; }
	}


	public enum AcknowledgementState
	{
		[EnumMember(Value = "awaits_successful_execution")]
		AwaitsSuccessfulExecution,

		[EnumMember(Value = "ackable")]
		Acknowledgable,

		[EnumMember(Value = "acked")]
		Acknowledged
	}
}
